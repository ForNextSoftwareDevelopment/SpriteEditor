using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteEditor
{
    public partial class MainForm : Form
    {
        #region Members

        // Sprites data (1 byte per pixel, so 24 by 21 bytes)
        private byte[,,] spriteData;

        // Sprites color (indexed 0x00 to 0x0F)
        private int[] spriteColorIndex;

        // Sprites multicolor (indexed 0x00 to 0x0F)
        private int spriteMultiColor0Index;
        private int spriteMultiColor1Index;

        // Sprites multicolor mode 
        private bool[] spriteMultiColor;

        // Selected sprite index
        private byte selectedSprite;

        // Mouse down flag
        private bool mouseDown;

        // Clipboard sprite data (1 byte per pixel, so 24 by 21 bytes)
        private byte[,] clipboardSpriteData;

        // Clipboard sprite color (indexed 0x00 to 0x0F)
        private int clipboardSpriteColorIndex;

        // Clipboard sprite multicolor mode
        private bool clipboardSpriteMultiColor;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            mouseDown = false;

            // Set data, colors, screens etc
            Init();
        }

        #endregion

        #region Events

        /// <summary>
        /// Paint event handler sprite draw picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void pbSpriteDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (rbHiRes.Checked)
            {
                for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                    {
                        if (spriteData[selectedSprite, column, row] == 0x00)
                        {
                            Brush brush = new SolidBrush(panelSpriteBackgroundColor.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 10, 10));
                        }

                        if (spriteData[selectedSprite, column, row] == 0x01)
                        {
                            Brush brush = new SolidBrush(panelSpriteColor.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 10, 10));
                        }
                    }
                }
            }

            if (rbMultiColor.Checked)
            {
                for (int column = 0; column < Constants.SPRITE_WIDTH; column += 2)
                {
                    for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                    {
                        if ((spriteData[selectedSprite, column, row] == 0x00) && (spriteData[selectedSprite, column + 1, row] == 0x00))
                        {
                            Brush brush = new SolidBrush(panelSpriteBackgroundColor.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 20, 10));
                        }

                        if ((spriteData[selectedSprite, column, row] == 0x00) && (spriteData[selectedSprite, column + 1, row] == 0x01))
                        {
                            Brush brush = new SolidBrush(panelSpriteMultiColor0.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 20, 10));
                        }

                        if ((spriteData[selectedSprite, column, row] == 0x01) && (spriteData[selectedSprite, column + 1, row] == 0x00))
                        {
                            Brush brush = new SolidBrush(panelSpriteColor.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 20, 10));
                        }

                        if ((spriteData[selectedSprite, column, row] == 0x01) && (spriteData[selectedSprite, column + 1, row] == 0x01))
                        {
                            Brush brush = new SolidBrush(panelSpriteMultiColor1.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 20, 10));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Paint event handler sprites preview picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbSprites_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            for (int i = 0; i < Constants.NUM_SPRITES; i++)
            {
                g.DrawRectangle(Pens.SteelBlue, new Rectangle(1, 1 + i * (2 * (Constants.SPRITE_HEIGHT + 2)), 2 * (Constants.SPRITE_WIDTH + 2), 2 * (Constants.SPRITE_HEIGHT + 1)));
                g.DrawRectangle(Pens.SteelBlue, new Rectangle(2, 2 + i * (2 * (Constants.SPRITE_HEIGHT + 2)), 2 * (Constants.SPRITE_WIDTH + 2), 2 * (Constants.SPRITE_HEIGHT + 1)));
            }

            g.DrawRectangle(Pens.Red, new Rectangle(1, 1 + selectedSprite * (2 * (Constants.SPRITE_HEIGHT + 2)), 2 * (Constants.SPRITE_WIDTH + 2), 2 * (Constants.SPRITE_HEIGHT + 1)));
            g.DrawRectangle(Pens.Red, new Rectangle(2, 2 + selectedSprite * (2 * (Constants.SPRITE_HEIGHT + 2)), 2 * (Constants.SPRITE_WIDTH + 2), 2 * (Constants.SPRITE_HEIGHT + 1)));

            for (int i = 0; i < Constants.NUM_SPRITES; i++)
            {
                if (!spriteMultiColor[i])
                {
                    for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
                    {
                        for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                        {
                            Brush brush = new SolidBrush(Color.Black);

                            if (spriteData[i, column, row] == 0x00)
                            {
                                brush = new SolidBrush(panelSpriteBackgroundColor.BackColor);
                            }

                            if (spriteData[i, column, row] == 0x01)
                            {
                                brush = new SolidBrush(Constants.Colors[spriteColorIndex[i]]);
                            }

                            g.FillRectangle(brush, new Rectangle(4 + column * 2, 3 + (i * (Constants.SPRITE_HEIGHT + 2) + row) * 2, 2, 2));
                        }
                    }
                }

                if (spriteMultiColor[i])
                {
                    for (int column = 0; column < Constants.SPRITE_WIDTH; column += 2)
                    {
                        for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                        {
                            Brush brush = new SolidBrush(Color.Black);

                            if ((spriteData[i, column, row] == 0x00) && (spriteData[i, column + 1, row] == 0x00))
                            {
                                brush = new SolidBrush(panelSpriteBackgroundColor.BackColor);
                            }

                            if ((spriteData[i, column, row] == 0x00) && (spriteData[i, column + 1, row] == 0x01))
                            {
                                brush = new SolidBrush(panelSpriteMultiColor0.BackColor);
                            }

                            if ((spriteData[i, column, row] == 0x01) && (spriteData[i, column + 1, row] == 0x00))
                            {
                                brush = new SolidBrush(Constants.Colors[spriteColorIndex[i]]);
                            }

                            if ((spriteData[i, column, row] == 0x01) && (spriteData[i, column + 1, row] == 0x01))
                            {
                                brush = new SolidBrush(panelSpriteMultiColor1.BackColor);
                            }

                            g.FillRectangle(brush, new Rectangle(4 + column * 2, 3 + (i * (Constants.SPRITE_HEIGHT + 2) + row) * 2, 4, 2));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Mouse button down event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbSpriteDraw_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;

            Graphics gSpriteDraw = pbSpriteDraw.CreateGraphics();
            Graphics gSprites = pbSprites.CreateGraphics();

            Brush brush = Brushes.Black;
            if (rbSpriteColor.Checked) brush = new SolidBrush(panelSpriteColor.BackColor);
            if (rbSpriteBackgroundColor.Checked) brush = new SolidBrush(panelSpriteBackgroundColor.BackColor);
            if (rbSpriteMultiColor0.Checked) brush = new SolidBrush(panelSpriteMultiColor0.BackColor);
            if (rbSpriteMultiColor1.Checked) brush = new SolidBrush(panelSpriteMultiColor1.BackColor);
            if (e.Button == MouseButtons.Right) brush = new SolidBrush(panelSpriteBackgroundColor.BackColor);

            while (mouseDown)
            {
                int mouseX = Cursor.Position.X - this.Location.X - pbSpriteDraw.Location.X - 9;
                int mouseY = Cursor.Position.Y - this.Location.Y - pbSpriteDraw.Location.Y - 32;

                int x = (mouseX / 10);
                int y = (mouseY / 10);

                if ((x < 0) || (y < 0) || (x >= Constants.SPRITE_WIDTH) || (y >= Constants.SPRITE_HEIGHT)) return;

                if (rbHiRes.Checked)
                {
                    gSpriteDraw.FillRectangle(brush, new Rectangle(x * 10, y * 10, 10, 10));
                    gSprites.FillRectangle(brush, new Rectangle(4 + x * 2, 3 + (selectedSprite * (Constants.SPRITE_HEIGHT + 2) + y) * 2, 2, 2));
                    if (rbSpriteColor.Checked) spriteData[selectedSprite, x, y] = (byte)0x01;
                    if (rbSpriteBackgroundColor.Checked) spriteData[selectedSprite, x, y] = (byte)0x00;
                    if (e.Button == MouseButtons.Right) spriteData[selectedSprite, x, y] = (byte)0x00;
                }

                if (rbMultiColor.Checked)
                {
                    if (x % 2 != 0) x--;
                    gSpriteDraw.FillRectangle(brush, new Rectangle(x * 10, y * 10, 20, 10));
                    gSprites.FillRectangle(brush, new Rectangle(4 + x * 2, 3 + (selectedSprite * (Constants.SPRITE_HEIGHT + 2) + y) * 2, 4, 2));

                    if (rbSpriteColor.Checked)
                    {
                        spriteData[selectedSprite, x, y] = (byte)0x1;
                        spriteData[selectedSprite, x + 1, y] = (byte)0x0;
                    }

                    if (rbSpriteBackgroundColor.Checked)
                    {
                        spriteData[selectedSprite, x, y] = (byte)0x00;
                        spriteData[selectedSprite, x + 1, y] = (byte)0x00;
                    }

                    if (rbSpriteMultiColor0.Checked)
                    {
                        spriteData[selectedSprite, x, y] = (byte)0x00;
                        spriteData[selectedSprite, x + 1, y] = (byte)0x01;
                    }

                    if (rbSpriteMultiColor1.Checked)
                    {
                        spriteData[selectedSprite, x, y] = (byte)0x01;
                        spriteData[selectedSprite, x + 1, y] = (byte)0x01;
                    }

                    if (e.Button == MouseButtons.Right)
                    {
                        spriteData[selectedSprite, x, y] = (byte)0x00;
                        spriteData[selectedSprite, x + 1, y] = (byte)0x00;
                    }
                }

                Application.DoEvents();
            }
        }

        /// <summary>
        /// Mouse button up event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbSpriteDraw_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

            FillSpriteData();
        }

        /// <summary>
        /// Sprite color panel clicked event => choose color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelSpriteColor_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;

            FormColorDialog colorDialog = new FormColorDialog(panel.BackColor);
            DialogResult dialogResult = colorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                panel.BackColor = colorDialog.color;
                if (panel.Name == "panelSpriteColor")
                {
                    spriteColorIndex[selectedSprite] = colorDialog.colorIndex;
                }

                if (panel.Name == "panelSpriteMultiColor0")
                {
                    spriteMultiColor0Index = colorDialog.colorIndex;
                }

                if (panel.Name == "panelSpriteMultiColor1")
                {
                    spriteMultiColor1Index = colorDialog.colorIndex;
                }
            }

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Radio button HiRes clicked event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbHiRes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHiRes.Checked)
            {
                rbSpriteColor.Checked = true;
                rbSpriteMultiColor0.Enabled = false;
                rbSpriteMultiColor1.Enabled = false;
                panelSpriteMultiColor0.Enabled = false;
                panelSpriteMultiColor1.Enabled = false;
                spriteMultiColor[selectedSprite] = false;
            }

            FillSpriteData();

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Radio button MultiColor clicked event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbMultiColor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMultiColor.Checked)
            {
                rbSpriteMultiColor0.Enabled = true;
                rbSpriteMultiColor1.Enabled = true;
                panelSpriteMultiColor0.Enabled = true;
                panelSpriteMultiColor1.Enabled = true;
                spriteMultiColor[selectedSprite] = true;
            }

            FillSpriteData();

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Sprites preview picturebox clicked event => choose sprite for editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbSprites_Click(object sender, EventArgs e)
        {
            int mouseX = Cursor.Position.X - this.Location.X - pbSprites.Location.X - 9;
            int mouseY = Cursor.Position.Y - this.Location.Y - pbSprites.Location.Y - 32;

            selectedSprite = (byte)(mouseY / (2 * (Constants.SPRITE_HEIGHT + 2)));

            panelSpriteColor.BackColor = Constants.Colors[spriteColorIndex[selectedSprite]];

            rbMultiColor.CheckedChanged -= rbMultiColor_CheckedChanged;
            rbHiRes.CheckedChanged -= rbHiRes_CheckedChanged;
            rbMultiColor.Checked = spriteMultiColor[selectedSprite];
            rbHiRes.Checked = !spriteMultiColor[selectedSprite];
            rbMultiColor.CheckedChanged += new EventHandler(rbMultiColor_CheckedChanged);
            rbHiRes.CheckedChanged += new EventHandler(rbHiRes_CheckedChanged);

            if (rbHiRes.Checked)
            {
                rbSpriteColor.Checked = true;
                rbSpriteMultiColor0.Enabled = false;
                rbSpriteMultiColor1.Enabled = false;
                panelSpriteMultiColor0.Enabled = false;
                panelSpriteMultiColor1.Enabled = false;
                spriteMultiColor[selectedSprite] = false;
            }

            if (rbMultiColor.Checked)
            {
                rbSpriteMultiColor0.Enabled = true;
                rbSpriteMultiColor1.Enabled = true;
                panelSpriteMultiColor0.Enabled = true;
                panelSpriteMultiColor1.Enabled = true;
                spriteMultiColor[selectedSprite] = true;
            }

            FillSpriteData();

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Load a header file with sprite data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Header|*.h";
            openFileDialog.Title = "Open a sprite header file";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                ReadFile(openFileDialog.FileName);
                FillSpriteData();

                if (spriteMultiColor[selectedSprite]) rbMultiColor.Checked = true; else rbHiRes.Checked = true;

                pbSpriteDraw.Invalidate();
                pbSprites.Invalidate();
            }
        }

        /// <summary>
        /// Save a header file with sprite data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Header|*.h";
            saveFileDialog.Title = "Save a sprite header file";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                SaveFile(saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// Export sprite image (current selected)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image(*.png)|*.png";
            saveFileDialog.Title = "Save a sprite image file";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                Bitmap bmSpriteDraw = new Bitmap(pbSpriteDraw.Width, pbSpriteDraw.Height);
                pbSpriteDraw.DrawToBitmap(bmSpriteDraw, pbSpriteDraw.ClientRectangle);
                bmSpriteDraw.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        /// <summary>
        /// Program exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// View manual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelp formHelp = new FormHelp();
            formHelp.ShowDialog();
        }

        /// <summary>
        /// View about box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        /// <summary>
        /// Clear the current selected sprite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics gSpriteDraw = pbSpriteDraw.CreateGraphics();

            gSpriteDraw.Clear(panelSpriteBackgroundColor.BackColor);
            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    spriteData[selectedSprite, column, row] = (byte)0x00;
                }
            }

            tbSpriteData.Text = "";

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();

            FillSpriteData();
        }

        /// <summary>
        /// Mirror the current selected sprite in horizontal direction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMirrorHorizontal_Click(object sender, EventArgs e)
        {
            byte[,] tempSpriteData = new byte[Constants.SPRITE_WIDTH, Constants.SPRITE_HEIGHT];

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    tempSpriteData[column, row] = spriteData[selectedSprite, Constants.SPRITE_WIDTH - 1 - column, row];
                }
            }

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    spriteData[selectedSprite, column, row] = tempSpriteData[column, row];
                }
            }

            FillSpriteData();

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Mirror the current selected sprite in vertical direction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMirrorVertical_Click(object sender, EventArgs e)
        {
            byte[,] tempSpriteData = new byte[Constants.SPRITE_WIDTH, Constants.SPRITE_HEIGHT];

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    tempSpriteData[column, row] = spriteData[selectedSprite, column, Constants.SPRITE_HEIGHT - 1 - row];
                }
            }

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    spriteData[selectedSprite, column, row] = tempSpriteData[column, row];
                }
            }

            FillSpriteData();

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Rotate the current selected sprite right (clockwise)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            // Since the sprite is not a square, use space width in both dimensions
            byte[,] tempSpriteData = new byte[Constants.SPRITE_WIDTH, Constants.SPRITE_WIDTH];

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    tempSpriteData[Constants.SPRITE_WIDTH - 1 - row, column] = spriteData[selectedSprite, column, row];
                }
            }

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    spriteData[selectedSprite, column, row] = tempSpriteData[column, row];
                }
            }

            FillSpriteData();

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Rotate the current selected sprite left (counter clockwise)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            // Since the sprite is not a square, use space width in both dimensions
            byte[,] tempSpriteData = new byte[Constants.SPRITE_WIDTH, Constants.SPRITE_WIDTH];

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    tempSpriteData[row, Constants.SPRITE_WIDTH - 1 - column] = spriteData[selectedSprite, column, row];
                }
            }

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    spriteData[selectedSprite, column, row] = tempSpriteData[column, row];
                }
            }

            FillSpriteData();

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Shift all pixels right in the currently selected sprite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShiftRight_Click(object sender, EventArgs e)
        {
            byte[,] tempSpriteData = new byte[Constants.SPRITE_WIDTH, Constants.SPRITE_HEIGHT];

            if (rbHiRes.Checked)
            {
                for (int column = 0; column < Constants.SPRITE_WIDTH - 1; column++)
                {
                    for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                    {
                        tempSpriteData[column + 1, row] = spriteData[selectedSprite, column, row];
                    }
                }

                for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                    {
                        spriteData[selectedSprite, column, row] = tempSpriteData[column, row];
                    }
                }
            }

            if (rbMultiColor.Checked)
            {
                for (int column = 0; column < Constants.SPRITE_WIDTH - 2; column+=2)
                {
                    for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                    {
                        tempSpriteData[column + 2, row] = spriteData[selectedSprite, column, row];
                        tempSpriteData[column + 3, row] = spriteData[selectedSprite, column + 1, row];
                    }
                }

                for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                    {
                        spriteData[selectedSprite, column, row] = tempSpriteData[column, row];
                    }
                }
            }

            FillSpriteData();

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Shift all pixels left in the currently selected sprite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShiftLeft_Click(object sender, EventArgs e)
        {
            byte[,] tempSpriteData = new byte[Constants.SPRITE_WIDTH, Constants.SPRITE_HEIGHT];

            if (rbHiRes.Checked)
            {
                for (int column = 1; column < Constants.SPRITE_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                    {
                        tempSpriteData[column - 1, row] = spriteData[selectedSprite, column, row];
                    }
                }

                for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                    {
                        spriteData[selectedSprite, column, row] = tempSpriteData[column, row];
                    }
                }
            }

            if (rbMultiColor.Checked)
            {
                for (int column = 2; column < Constants.SPRITE_WIDTH; column+=2)
                {
                    for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                    {
                        tempSpriteData[column - 2, row] = spriteData[selectedSprite, column, row];
                        tempSpriteData[column - 1, row] = spriteData[selectedSprite, column + 1, row];
                    }
                }

                for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                    {
                        spriteData[selectedSprite, column, row] = tempSpriteData[column, row];
                    }
                }
            }

            FillSpriteData();

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }


        /// <summary>
        /// Shift all pixels of the current sprite 1 up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShiftUp_Click(object sender, EventArgs e)
        {
            byte[,] tempSpriteData = new byte[Constants.SPRITE_WIDTH, Constants.SPRITE_HEIGHT];

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 1; row < Constants.SPRITE_HEIGHT; row++)
                {
                    tempSpriteData[column, row - 1] = spriteData[selectedSprite, column, row];
                }
            }

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    spriteData[selectedSprite, column, row] = tempSpriteData[column, row];
                }
            }

            FillSpriteData();

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Shift all pixels of the current sprite 1 down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShiftDown_Click(object sender, EventArgs e)
        {
            byte[,] tempSpriteData = new byte[Constants.SPRITE_WIDTH, Constants.SPRITE_HEIGHT];

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT - 1; row++)
                {
                    tempSpriteData[column, row + 1] = spriteData[selectedSprite, column, row];
                }
            }

            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    spriteData[selectedSprite, column, row] = tempSpriteData[column, row];
                }
            }

            FillSpriteData();

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Paste image from clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPaste_Click(object sender, EventArgs e)
        {
            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    spriteData[selectedSprite, column, row] = clipboardSpriteData[column, row];
                }
            }

            spriteColorIndex[selectedSprite] = clipboardSpriteColorIndex;
            spriteMultiColor[selectedSprite] = clipboardSpriteMultiColor;

            if (clipboardSpriteMultiColor) rbMultiColor.Checked = true; else rbHiRes.Checked = true;
            panelSpriteColor.BackColor = Constants.Colors[clipboardSpriteColorIndex];

            pbSpriteDraw.Invalidate();
            pbSprites.Invalidate();
        }

        /// <summary>
        /// Copy image to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            for (int column = 0; column < Constants.SPRITE_WIDTH; column++)
            {
                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    clipboardSpriteData[column, row] = spriteData[selectedSprite, column, row];
                }
            }

            clipboardSpriteColorIndex = spriteColorIndex[selectedSprite];
            clipboardSpriteMultiColor = spriteMultiColor[selectedSprite];
        }

        #endregion

        #region Methods

        /// <summary>
        /// Init, set all variables, screen etc.
        /// </summary>
        private void Init()
        {
            spriteData = new byte[Constants.NUM_SPRITES, Constants.SPRITE_WIDTH, Constants.SPRITE_HEIGHT];

            spriteColorIndex = new int[] { 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01 };
            spriteMultiColor0Index = 0x0F;
            spriteMultiColor1Index = 0x0C;

            spriteMultiColor = new bool[] { false, false, false, false, false, false, false, false };

            selectedSprite = 0;

            panelSpriteColor.BackColor = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
            panelSpriteBackgroundColor.BackColor = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
            panelSpriteMultiColor0.BackColor = Color.FromArgb(0xFF, 0xBB, 0xBB, 0xBB);
            panelSpriteMultiColor1.BackColor = Color.FromArgb(0xFF, 0x77, 0x77, 0x77);

            clipboardSpriteData = new byte[Constants.SPRITE_WIDTH, Constants.SPRITE_HEIGHT];
            clipboardSpriteColorIndex = 0x00;
            clipboardSpriteMultiColor = false;

            ToolTip toolTipClear = new ToolTip();
            toolTipClear.ShowAlways = true;
            toolTipClear.SetToolTip(btnClear, "Clear (delete) current sprite");

            ToolTip toolTipCopy = new ToolTip();
            toolTipCopy.ShowAlways = true;
            toolTipCopy.SetToolTip(btnCopy, "Copy current sprite to the clipboard");

            ToolTip toolTipPaste = new ToolTip();
            toolTipPaste.ShowAlways = true;
            toolTipPaste.SetToolTip(btnPaste, "Paste clipboard data to current sprite");

            ToolTip toolTipRotateRight = new ToolTip();
            toolTipRotateRight.ShowAlways = true;
            toolTipRotateRight.SetToolTip(btnRotateRight, "Rotate current sprite right (clockwise) 90 degrees");

            ToolTip toolTipRotateLeft = new ToolTip();
            toolTipRotateLeft.ShowAlways = true;
            toolTipRotateLeft.SetToolTip(btnRotateLeft, "Rotate current sprite left (counter clockwise) 90 degrees");

            ToolTip toolTipMirrorHorizontal = new ToolTip();
            toolTipMirrorHorizontal.ShowAlways = true;
            toolTipMirrorHorizontal.SetToolTip(btnMirrorHorizontal, "Mirror current sprite horizontally");

            ToolTip toolTipMirrorVertical = new ToolTip();
            toolTipMirrorVertical.ShowAlways = true;
            toolTipMirrorVertical.SetToolTip(btnMirrorVertical, "Mirror current sprite vertically");

            ToolTip toolTipShiftRight = new ToolTip();
            toolTipShiftRight.ShowAlways = true;
            toolTipShiftRight.SetToolTip(btnShiftRight, "Shift all pixels of the current sprite to the right");

            ToolTip toolTipShiftLeft = new ToolTip();
            toolTipShiftLeft.ShowAlways = true;
            toolTipShiftLeft.SetToolTip(btnShiftLeft, "Shift all pixels of the current sprite to the left");

            ToolTip toolTipShiftDown = new ToolTip();
            toolTipShiftDown.ShowAlways = true;
            toolTipShiftDown.SetToolTip(btnShiftDown, "Shift all pixels of the current sprite down");

            ToolTip toolTipShiftUp = new ToolTip();
            toolTipShiftUp.ShowAlways = true;
            toolTipShiftUp.SetToolTip(btnShiftUp, "Shift all pixels of the current sprite up");

            ToolTip toolTipColor = new ToolTip();
            toolTipColor.ShowAlways = true;
            toolTipColor.SetToolTip(panelSpriteColor, "Choose color");
            toolTipColor.SetToolTip(panelSpriteBackgroundColor, "Choose color");
            toolTipColor.SetToolTip(panelSpriteMultiColor0, "Choose color");
            toolTipColor.SetToolTip(panelSpriteMultiColor1, "Choose color");

            FillSpriteData();
        }

        /// <summary>
        /// Redraw the sprite data textbox
        /// </summary>
        private void FillSpriteData()
        {
            tbSpriteData.Text = "/* SPRITE " + selectedSprite.ToString() + ": ";
            tbSpriteData.Text += spriteMultiColor[selectedSprite] ? "Multicolor */\r\n" : "Hi-Res */\r\n";
            tbSpriteData.Text += "const unsigned char sprite" + selectedSprite.ToString() + "[] = \r\n{\r\n";

            string[] lines = new string[21];
            string[] comment = new string[21];

            for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
            {
                lines[row] = "    ";
                comment[row] = "/* ";

                for (int column = 0; column < Constants.SPRITE_WIDTH; column += 8)
                {
                    byte data = (byte)0x00;

                    if (rbHiRes.Checked)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            data += spriteData[selectedSprite, column + i, row] == 0x01 ? (byte)(Math.Pow(2, (7 - i))): (byte)0;
                            comment[row] += spriteData[selectedSprite, column + i, row] == 0x01 ? "X" : ".";
                        }
                    }

                    if (rbMultiColor.Checked)
                    {
                        for (int i = 0; i < 8; i += 2)
                        {
                            data += spriteData[selectedSprite, column + i,     row] == 0x01 ? (byte)(Math.Pow(2, (7 - i    ))) : (byte)0;
                            data += spriteData[selectedSprite, column + i + 1, row] == 0x01 ? (byte)(Math.Pow(2, (7 - i - 1))) : (byte)0;

                            if ((spriteData[selectedSprite, column + i, row] == 0x00) && (spriteData[selectedSprite, column + i + 1, row] == 0x00)) comment[row] += "..";
                            if ((spriteData[selectedSprite, column + i, row] == 0x00) && (spriteData[selectedSprite, column + i + 1, row] == 0x01)) comment[row] += "@@";
                            if ((spriteData[selectedSprite, column + i, row] == 0x01) && (spriteData[selectedSprite, column + i + 1, row] == 0x00)) comment[row] += "XX";
                            if ((spriteData[selectedSprite, column + i, row] == 0x01) && (spriteData[selectedSprite, column + i + 1, row] == 0x01)) comment[row] += "%%";
                        }
                    }

                    lines[row] += "0x";
                    lines[row] += string.Format("{0:X2}", data) + ", ";
                }

                comment[row] += " */";
            }

            for (int i = 0; i < lines.Length; i++)
            {
                tbSpriteData.Text += lines[i];
                if (i == lines.Length - 1)
                {
                    tbSpriteData.Text = tbSpriteData.Text.Trim();
                    tbSpriteData.Text = tbSpriteData.Text.TrimEnd(',');
                    tbSpriteData.Text = tbSpriteData.Text + "  ";
                }

                tbSpriteData.Text += comment[i];
                if (i != lines.Length - 1) tbSpriteData.Text += "\r\n";
            }

            tbSpriteData.Text += "\r\n};\r\n\r\n";
        }

        /// <summary>
        /// Save header file
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveFile(string fileName)
        {
            string fileContent = "";
            fileContent += "char* ptrSprite_0_Color = (char*)0xD027;\r\n";
            fileContent += "char* ptrSprite_1_Color = (char*)0xD028;\r\n";
            fileContent += "char* ptrSprite_2_Color = (char*)0xD029;\r\n";
            fileContent += "char* ptrSprite_3_Color = (char*)0xD02A;\r\n";
            fileContent += "char* ptrSprite_4_Color = (char*)0xD02B;\r\n";
            fileContent += "char* ptrSprite_5_Color = (char*)0xD02C;\r\n";
            fileContent += "char* ptrSprite_6_Color = (char*)0xD02D;\r\n";
            fileContent += "char* ptrSprite_7_Color = (char*)0xD02E;\r\n\r\n";

            fileContent += "\r\n";
            fileContent += "char* ptrSpritesMultiColor  = (char*)0xD01C;\r\n";
            fileContent += "char* ptrSpriteMultiColor_0 = (char*)0xD025;\r\n";
            fileContent += "char* ptrSpriteMultiColor_1 = (char*)0xD026;\r\n\r\n";

            for (int i = 0; i < Constants.NUM_SPRITES; i++)
            {
                fileContent += "/* SPRITE " + i.ToString() + ": ";
                fileContent += spriteMultiColor[i] ? "Multicolor */\r\n" : "Hi-Res */\r\n";

                fileContent += "const unsigned char sprite" + i.ToString() + "[] = \r\n{\r\n";

                string[] lines = new string[21];
                string[] comment = new string[21];

                for (int row = 0; row < Constants.SPRITE_HEIGHT; row++)
                {
                    lines[row] = "    ";
                    comment[row] = "/* ";

                    for (int column = 0; column < Constants.SPRITE_WIDTH; column += 8)
                    {
                        byte data = (byte)0x00;
                        if (!spriteMultiColor[i])
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                data += spriteData[i, column + j, row] == 0x01 ? (byte)(Math.Pow(2, (7 - j))) : (byte)0;
                                comment[row] += spriteData[i, column + j, row] == 0x01 ? "X" : ".";
                            }
                        }

                        if (spriteMultiColor[i])
                        {
                            for (int j = 0; j < 8; j += 2)
                            {
                                data += spriteData[i, column + j, row] == 0x01 ? (byte)(Math.Pow(2, (7 - j))) : (byte)0;
                                data += spriteData[i, column + j + 1, row] == 0x01 ? (byte)(Math.Pow(2, (7 - j - 1))) : (byte)0;
                                
                                if ((spriteData[i, column + j, row] == 0x00) && (spriteData[i, column + j + 1, row] == 0x00)) comment[row] += "..";
                                if ((spriteData[i, column + j, row] == 0x00) && (spriteData[i, column + j + 1, row] == 0x01)) comment[row] += "@@";
                                if ((spriteData[i, column + j, row] == 0x01) && (spriteData[i, column + j + 1, row] == 0x00)) comment[row] += "XX";
                                if ((spriteData[i, column + j, row] == 0x01) && (spriteData[i, column + j + 1, row] == 0x01)) comment[row] += "%%";
                            }
                        }

                        lines[row] += "0x";
                        lines[row] += string.Format("{0:X2}", data) + ", ";
                    }

                    comment[row] += " */";
                }

                for (int j = 0; j < lines.Length; j++)
                {
                    fileContent += lines[j];
                    if (j == lines.Length - 1)
                    {
                        fileContent =  fileContent.Trim();
                        fileContent =  fileContent.TrimEnd(',');
                        fileContent += "  ";
                    }

                    fileContent += comment[j];
                    if (j != lines.Length - 1) fileContent += "\r\n";
                }

                fileContent += "\r\n};\r\n\r\n";
            }

            fileContent += "void Init()\r\n{\r\n";

            for (int i = 0; i < Constants.NUM_SPRITES; i++)
            {
                fileContent += "    *ptrSprite_" + i.ToString() + "_Color = 0x" + string.Format("{0:X2}", spriteColorIndex[i]) + ";\r\n";
            }

            // Pseudo variable for loading this file into the editor again
            fileContent += "\r\n    // spritesBackGroundColor = 0x" + string.Format("{0:X4}", panelSpriteBackgroundColor.BackColor.ToArgb()) + ";\r\n";

            byte spritesMultiColor = 0x00;
            for (int i = 0; i < Constants.NUM_SPRITES; i++)
            {
                spritesMultiColor += spriteMultiColor[i] ? (byte)(Math.Pow(2, i)) : (byte)0;
            }

            fileContent += "    *ptrSpritesMultiColor  = 0b" + Convert.ToString(spritesMultiColor, 2).PadLeft(8, '0') + ";\r\n";
            fileContent += "    *ptrSpriteMultiColor_0 = 0x" + string.Format("{0:X2}", spriteMultiColor0Index) + ";\r\n";
            fileContent += "    *ptrSpriteMultiColor_1 = 0x" + string.Format("{0:X2}", spriteMultiColor1Index) + ";\r\n";

            fileContent += "}\r\n";

            try
            {
                File.WriteAllText(fileName, fileContent);
            } catch (Exception ex)
            {
                MessageBox.Show("Can't write file: " + fileName + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("File saved as\r\n" + fileName, "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Load header file
        /// </summary>
        /// <param name="fileName"></param>
        private void ReadFile(string fileName)
        {
            string message = "";
            string fileContent;
            string search;
            int pos = 0;

            try
            {
                fileContent = File.ReadAllText(fileName);
            } catch (Exception ex)
            {
                MessageBox.Show("Can't read file: " + fileName + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Sprites backgroundcolor
                search = "spritesBackGroundColor";
                pos = fileContent.IndexOf(search) + search.Length;
                if (pos >= 0)
                {
                    int number = 0;
                    bool result = ReadNumber(fileContent, pos, ref number);
                    if (result)
                    {
                        panelSpriteBackgroundColor.BackColor = Color.FromArgb((int)number);
                    } else
                    {
                        message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                    }
                } else
                {
                    message += "Parameter '" + search + "' not found.\r\n\r\n";
                }

                for (int i = 0; i < Constants.NUM_SPRITES; i++)
                {
                    // Sprite color
                    search = "*ptrSprite_" + i.ToString() + "_Color";
                    pos = fileContent.IndexOf(search) + search.Length;
                    if (pos >= 0)
                    {
                        int number = 0;
                        bool result = ReadNumber(fileContent, pos, ref number);
                        if (result && (number >= 0x00) && (number <= 0x0F))
                        {
                            spriteColorIndex[i] = number;
                            if (selectedSprite == i) panelSpriteColor.BackColor = Constants.Colors[number];
                        } else
                        {
                            message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                        }
                    } else
                    {
                        message += "Parameter '" + search + "' not found.\r\n\r\n";
                    }

                    // Sprite data 
                    search = "const unsigned char sprite" + i.ToString() + "[]";
                    pos = fileContent.IndexOf(search);
                    if (pos >= 0)
                    {
                        bool skip = false;

                        pos += search.Length;
                        int posStart = fileContent.IndexOf('{', pos);
                        int posEnd = fileContent.IndexOf('}', pos);
                        string strValues = fileContent.Substring(posStart + 1, posEnd - posStart - 2);
                        string[] values = strValues.Split(',');
                        if (values.Length < (Constants.SPRITE_WIDTH / 8 * Constants.SPRITE_HEIGHT))
                        {
                            message += "Not enough (valid) values found for:\r\n" + search + "\r\nSkipping further reading of this sprite\r\n\r\n";
                            skip = true;
                        }

                        int valIndex = 0;
                        for (int row = 0; row < Constants.SPRITE_HEIGHT && !skip; row++)
                        {
                            int temp = 0;
                            bool result;

                            if (!skip)
                            {
                                result = ReadNumber(values[valIndex++], 0, ref temp);
                                if (result && (temp >= 0x00) && (temp <= 0xFF))
                                {
                                    byte number = (byte)temp;
                                    for (int column = 0; column < 8 && !skip; column++)
                                    {
                                        int shift = 7 - column;
                                        spriteData[i, column, row] = (byte)((number & (byte)Math.Pow(2, shift)) >> shift);
                                    }
                                } else
                                {
                                    message += "No (valid) values found for:\r\n" + search + "\r\nSkipping further reading of this sprite\r\n\r\n";
                                    skip = true;
                                }
                            }

                            if (!skip)
                            {
                                result = ReadNumber(values[valIndex++], 0, ref temp);
                                if (result && (temp >= 0x00) && (temp <= 0xFF))
                                {
                                    byte number = (byte)temp;
                                    for (int column = 8; column < 16 && !skip; column++)
                                    {
                                        int shift = 15 - column;
                                        spriteData[i, column, row] = (byte)((number & (byte)Math.Pow(2, shift)) >> shift);
                                    }
                                } else
                                {
                                    message += "No (valid) values found for:\r\n" + search + "\r\nSkipping further reading of this sprite\r\n\r\n";
                                    skip = true;
                                }
                            }

                            if (!skip)
                            {
                                result = ReadNumber(values[valIndex++], 0, ref temp);
                                if (result && (temp >= 0x00) && (temp <= 0xFF))
                                {
                                    byte number = (byte)temp;
                                    for (int column = 16; column < 24 && !skip; column++)
                                    {
                                        int shift = 23 - column;
                                        spriteData[i, column, row] = (byte)((number & (byte)Math.Pow(2, shift)) >> shift);
                                    }
                                } else
                                {
                                    message += "No (valid) values found for:\r\n" + search + "\r\nSkipping further reading of this sprite\r\n\r\n";
                                    skip = true;
                                }
                            }
                        }
                    } else
                    {
                        message += "Parameter '" + search + "' not found.\r\n\r\n";
                    }
                }

                // Sprite multicolor 
                search = "*ptrSpritesMultiColor";
                pos = fileContent.IndexOf(search) + search.Length;
                if (pos >= 0)
                {
                    int number = 0;
                    bool result = ReadNumber(fileContent, pos, ref number);
                    if (result && (number >= 0x00) && (number <= 0xFF))
                    {
                        for (int i = 0; i < Constants.NUM_SPRITES; i++)
                        {
                            spriteMultiColor[i] = (number & Convert.ToInt32(Math.Pow(2, i))) == Math.Pow(2, i) ? true : false;
                        }
                    } else
                    {
                        message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                    }
                } else
                {
                    message += "Parameter '" + search + "' not found.\r\n\r\n";
                }

                // Multicolor 0
                search = "*ptrSpriteMultiColor_0";
                pos = fileContent.IndexOf(search) + search.Length;
                if (pos >= 0)
                {
                    int number = 0;
                    bool result = ReadNumber(fileContent, pos, ref number);
                    if (result && (number >= 0x00) && (number <= 0x0F))
                    {
                        spriteMultiColor0Index = number;
                        panelSpriteMultiColor0.BackColor = Constants.Colors[number];
                    } else
                    {
                        message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                    }
                } else
                {
                    message += "Parameter '" + search + "' not found.\r\n\r\n";
                }

                // Multicolor 1
                search = "*ptrSpriteMultiColor_1";
                pos = fileContent.IndexOf(search) + search.Length;
                if (pos >= 0)
                {
                    int number = 0;
                    bool result = ReadNumber(fileContent, pos, ref number);
                    if (result && (number >= 0x00) && (number <= 0x0F))
                    {
                        spriteMultiColor1Index = number;
                        panelSpriteMultiColor1.BackColor = Constants.Colors[number];
                    } else
                    {
                        message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                    }
                } else
                {
                    message += "Parameter '" + search + "' not found.\r\n\r\n";
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Can't read file: " + fileName + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (message != "")
            {
                MessageBox.Show(message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Read a number in the file (decimal, hexadecimal or binary)
        /// </summary>
        /// <param name="content"></param>
        /// <param name="pos"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool ReadNumber(string content, int pos, ref int number)
        {
            string skipChars = " \t\n\r=;";

            // Skip spaces, tabs, newlines etc.
            while ((pos < content.Length) && skipChars.Contains(content[pos])) pos++;

            // Skip comment
            if ((pos < content.Length) && (content[pos] == '/') && (content[pos + 1] == '*'))
            {
                while ((pos < content.Length) && !((content[pos] == '*') && (content[pos + 1] == '/'))) pos++;
                if ((content[pos] == '*') && (content[pos + 1] == '/')) pos += 2;
                while ((pos < content.Length) && skipChars.Contains(content[pos])) pos++;
            }

            // EOF
            if (pos == content.Length) return false;

            if ((content[pos] == '0') && (content[pos + 1] == 'x')) // HEX number
            {
                pos += 2;

                // Read positions until space, newline, tab etc.
                string strNum = "";
                while ((pos < content.Length) && !skipChars.Contains(content[pos]))
                {
                    strNum += content[pos];
                    pos++;
                }

                // Calculate number
                bool result = int.TryParse(strNum, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out number);

                return result;
            } else
            if ((content[pos] == '0') && (content[pos + 1] == 'b')) // BIN number
            {
                pos += 2;

                // Read positions until space, newline, tab etc.
                string strNum = "";
                while (!skipChars.Contains(content[pos]) && (pos < content.Length)) strNum += content[pos++];

                // Calculate number
                number = 0;
                for (int i = 0; i < strNum.Length; i++)
                {
                    if (strNum[i] == '1') number += Convert.ToInt32(Math.Pow(2, strNum.Length - i -1));
                }

                return true;
            } else
            if (char.IsDigit(content[pos])) // DEC number
            {
                // Read positions until space, newline, tab etc.
                string strNum = "";
                while (!skipChars.Contains(content[pos]) && (pos < content.Length)) strNum += content[pos++];

                // Calculate number
                bool result = int.TryParse(strNum, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out number);

                return result;
            }

            return false;
        }

        #endregion
    }
}
