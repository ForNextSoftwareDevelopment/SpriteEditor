using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpriteEditor
{
    public partial class FormColorDialog : Form
    {
        #region Members

        public Color color;
        public int colorIndex;

        private Panel panelOverlay;

        #endregion

        #region Constructor

        public FormColorDialog(Color color)
        {
            InitializeComponent();

            this.color = color;

            panelColor0.BackColor  = Constants.Colors[ 0];
            panelColor1.BackColor  = Constants.Colors[ 1];
            panelColor2.BackColor  = Constants.Colors[ 2];
            panelColor3.BackColor  = Constants.Colors[ 3];
            panelColor4.BackColor  = Constants.Colors[ 4];
            panelColor5.BackColor  = Constants.Colors[ 5];
            panelColor6.BackColor  = Constants.Colors[ 6];
            panelColor7.BackColor  = Constants.Colors[ 7];
            panelColor8.BackColor  = Constants.Colors[ 8];
            panelColor9.BackColor  = Constants.Colors[ 9];
            panelColor10.BackColor = Constants.Colors[10];
            panelColor11.BackColor = Constants.Colors[11];
            panelColor12.BackColor = Constants.Colors[12];
            panelColor13.BackColor = Constants.Colors[13];
            panelColor14.BackColor = Constants.Colors[14];
            panelColor15.BackColor = Constants.Colors[15];

            panelColor0.Tag = 0;
            panelColor1.Tag = 1;
            panelColor2.Tag = 2;
            panelColor3.Tag = 3;
            panelColor4.Tag = 4;
            panelColor5.Tag = 5;
            panelColor6.Tag = 6;
            panelColor7.Tag = 7;
            panelColor8.Tag = 8;
            panelColor9.Tag = 9;
            panelColor10.Tag = 10;
            panelColor11.Tag = 11;
            panelColor12.Tag = 12;
            panelColor13.Tag = 13;
            panelColor14.Tag = 14;
            panelColor15.Tag = 15;

            foreach (Control control in this.Controls)
            {
                if (control.BackColor == color)
                {
                    Panel panel = (Panel)control;
                    panelOverlay = new Panel();
                    panelOverlay.Size = new Size(panel.Size.Width + 4, panel.Size.Height + 4);
                    panelOverlay.Location = new Point(panel.Location.X - 2, panel.Location.Y - 2);
                    panelOverlay.BackColor = Color.FromArgb(0x80, 0xFF, 0x00, 0x00);
                    panelOverlay.Visible = true;

                    this.Controls.Add(panelOverlay);
                }
            }
        }

        #endregion

        private void panelColor_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            color = panel.BackColor;
            colorIndex = Convert.ToInt32(panel.Tag);

            this.Controls.Remove(panelOverlay);

            panelOverlay = new Panel();
            panelOverlay.Size = new Size(panel.Size.Width + 4, panel.Size.Height + 4);
            panelOverlay.Location = new Point(panel.Location.X - 2, panel.Location.Y - 2);
            panelOverlay.BackColor = Color.FromArgb(0x80, 0xFF, 0x00, 0x00);
            panelOverlay.Visible = true;

            this.Controls.Add(panelOverlay);
        }
    }
}
