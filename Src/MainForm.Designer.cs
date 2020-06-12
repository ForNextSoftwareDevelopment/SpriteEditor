namespace SpriteEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbSpriteDraw = new System.Windows.Forms.PictureBox();
            this.rbHiRes = new System.Windows.Forms.RadioButton();
            this.rbMultiColor = new System.Windows.Forms.RadioButton();
            this.panelColors = new System.Windows.Forms.Panel();
            this.panelHiResMultiColor = new System.Windows.Forms.Panel();
            this.rbSpriteMultiColor1 = new System.Windows.Forms.RadioButton();
            this.panelSpriteMultiColor1 = new System.Windows.Forms.Panel();
            this.rbSpriteMultiColor0 = new System.Windows.Forms.RadioButton();
            this.panelSpriteMultiColor0 = new System.Windows.Forms.Panel();
            this.rbSpriteBackgroundColor = new System.Windows.Forms.RadioButton();
            this.panelSpriteBackgroundColor = new System.Windows.Forms.Panel();
            this.panelSpriteColor = new System.Windows.Forms.Panel();
            this.rbSpriteColor = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbSpriteData = new System.Windows.Forms.TextBox();
            this.pbSprites = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMirrorHorizontal = new System.Windows.Forms.Button();
            this.btnMirrorVertical = new System.Windows.Forms.Button();
            this.btnShiftRight = new System.Windows.Forms.Button();
            this.btnShiftLeft = new System.Windows.Forms.Button();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnShiftDown = new System.Windows.Forms.Button();
            this.btnShiftUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpriteDraw)).BeginInit();
            this.panelColors.SuspendLayout();
            this.panelHiResMultiColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprites)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbSpriteDraw
            // 
            this.pbSpriteDraw.BackColor = System.Drawing.Color.Black;
            this.pbSpriteDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSpriteDraw.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbSpriteDraw.Location = new System.Drawing.Point(12, 27);
            this.pbSpriteDraw.Name = "pbSpriteDraw";
            this.pbSpriteDraw.Size = new System.Drawing.Size(242, 212);
            this.pbSpriteDraw.TabIndex = 0;
            this.pbSpriteDraw.TabStop = false;
            this.pbSpriteDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSpriteDraw_Paint);
            this.pbSpriteDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSpriteDraw_MouseDown);
            this.pbSpriteDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSpriteDraw_MouseUp);
            // 
            // rbHiRes
            // 
            this.rbHiRes.AutoSize = true;
            this.rbHiRes.Checked = true;
            this.rbHiRes.Location = new System.Drawing.Point(3, 3);
            this.rbHiRes.Name = "rbHiRes";
            this.rbHiRes.Size = new System.Drawing.Size(54, 17);
            this.rbHiRes.TabIndex = 1;
            this.rbHiRes.TabStop = true;
            this.rbHiRes.Text = "HiRes";
            this.rbHiRes.UseVisualStyleBackColor = true;
            this.rbHiRes.CheckedChanged += new System.EventHandler(this.rbHiRes_CheckedChanged);
            // 
            // rbMultiColor
            // 
            this.rbMultiColor.AutoSize = true;
            this.rbMultiColor.Location = new System.Drawing.Point(156, 3);
            this.rbMultiColor.Name = "rbMultiColor";
            this.rbMultiColor.Size = new System.Drawing.Size(71, 17);
            this.rbMultiColor.TabIndex = 1;
            this.rbMultiColor.Text = "MultiColor";
            this.rbMultiColor.UseVisualStyleBackColor = true;
            this.rbMultiColor.CheckedChanged += new System.EventHandler(this.rbMultiColor_CheckedChanged);
            // 
            // panelColors
            // 
            this.panelColors.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelColors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColors.Controls.Add(this.panelHiResMultiColor);
            this.panelColors.Controls.Add(this.rbSpriteMultiColor1);
            this.panelColors.Controls.Add(this.panelSpriteMultiColor1);
            this.panelColors.Controls.Add(this.rbSpriteMultiColor0);
            this.panelColors.Controls.Add(this.panelSpriteMultiColor0);
            this.panelColors.Controls.Add(this.rbSpriteBackgroundColor);
            this.panelColors.Controls.Add(this.panelSpriteBackgroundColor);
            this.panelColors.Controls.Add(this.panelSpriteColor);
            this.panelColors.Controls.Add(this.rbSpriteColor);
            this.panelColors.Location = new System.Drawing.Point(12, 245);
            this.panelColors.Name = "panelColors";
            this.panelColors.Size = new System.Drawing.Size(242, 152);
            this.panelColors.TabIndex = 2;
            // 
            // panelHiResMultiColor
            // 
            this.panelHiResMultiColor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelHiResMultiColor.Controls.Add(this.rbHiRes);
            this.panelHiResMultiColor.Controls.Add(this.rbMultiColor);
            this.panelHiResMultiColor.Location = new System.Drawing.Point(5, 5);
            this.panelHiResMultiColor.Name = "panelHiResMultiColor";
            this.panelHiResMultiColor.Size = new System.Drawing.Size(230, 24);
            this.panelHiResMultiColor.TabIndex = 2;
            // 
            // rbSpriteMultiColor1
            // 
            this.rbSpriteMultiColor1.AutoSize = true;
            this.rbSpriteMultiColor1.Enabled = false;
            this.rbSpriteMultiColor1.Location = new System.Drawing.Point(5, 127);
            this.rbSpriteMultiColor1.Name = "rbSpriteMultiColor1";
            this.rbSpriteMultiColor1.Size = new System.Drawing.Size(77, 17);
            this.rbSpriteMultiColor1.TabIndex = 0;
            this.rbSpriteMultiColor1.Text = "MultiColor1";
            this.rbSpriteMultiColor1.UseVisualStyleBackColor = true;
            // 
            // panelSpriteMultiColor1
            // 
            this.panelSpriteMultiColor1.BackColor = System.Drawing.Color.Gray;
            this.panelSpriteMultiColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSpriteMultiColor1.Enabled = false;
            this.panelSpriteMultiColor1.Location = new System.Drawing.Point(155, 127);
            this.panelSpriteMultiColor1.Name = "panelSpriteMultiColor1";
            this.panelSpriteMultiColor1.Size = new System.Drawing.Size(80, 18);
            this.panelSpriteMultiColor1.TabIndex = 1;
            this.panelSpriteMultiColor1.Click += new System.EventHandler(this.panelSpriteColor_Click);
            // 
            // rbSpriteMultiColor0
            // 
            this.rbSpriteMultiColor0.AutoSize = true;
            this.rbSpriteMultiColor0.Enabled = false;
            this.rbSpriteMultiColor0.Location = new System.Drawing.Point(4, 105);
            this.rbSpriteMultiColor0.Name = "rbSpriteMultiColor0";
            this.rbSpriteMultiColor0.Size = new System.Drawing.Size(77, 17);
            this.rbSpriteMultiColor0.TabIndex = 0;
            this.rbSpriteMultiColor0.Text = "MultiColor0";
            this.rbSpriteMultiColor0.UseVisualStyleBackColor = true;
            // 
            // panelSpriteMultiColor0
            // 
            this.panelSpriteMultiColor0.BackColor = System.Drawing.Color.LightGray;
            this.panelSpriteMultiColor0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSpriteMultiColor0.Enabled = false;
            this.panelSpriteMultiColor0.Location = new System.Drawing.Point(155, 105);
            this.panelSpriteMultiColor0.Name = "panelSpriteMultiColor0";
            this.panelSpriteMultiColor0.Size = new System.Drawing.Size(80, 18);
            this.panelSpriteMultiColor0.TabIndex = 1;
            this.panelSpriteMultiColor0.Click += new System.EventHandler(this.panelSpriteColor_Click);
            // 
            // rbSpriteBackgroundColor
            // 
            this.rbSpriteBackgroundColor.AutoSize = true;
            this.rbSpriteBackgroundColor.Location = new System.Drawing.Point(4, 83);
            this.rbSpriteBackgroundColor.Name = "rbSpriteBackgroundColor";
            this.rbSpriteBackgroundColor.Size = new System.Drawing.Size(83, 17);
            this.rbSpriteBackgroundColor.TabIndex = 0;
            this.rbSpriteBackgroundColor.Text = "Background";
            this.rbSpriteBackgroundColor.UseVisualStyleBackColor = true;
            // 
            // panelSpriteBackgroundColor
            // 
            this.panelSpriteBackgroundColor.BackColor = System.Drawing.Color.Black;
            this.panelSpriteBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSpriteBackgroundColor.Location = new System.Drawing.Point(155, 83);
            this.panelSpriteBackgroundColor.Name = "panelSpriteBackgroundColor";
            this.panelSpriteBackgroundColor.Size = new System.Drawing.Size(80, 18);
            this.panelSpriteBackgroundColor.TabIndex = 1;
            this.panelSpriteBackgroundColor.Click += new System.EventHandler(this.panelSpriteColor_Click);
            // 
            // panelSpriteColor
            // 
            this.panelSpriteColor.BackColor = System.Drawing.Color.White;
            this.panelSpriteColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSpriteColor.Location = new System.Drawing.Point(155, 60);
            this.panelSpriteColor.Name = "panelSpriteColor";
            this.panelSpriteColor.Size = new System.Drawing.Size(80, 18);
            this.panelSpriteColor.TabIndex = 1;
            this.panelSpriteColor.Click += new System.EventHandler(this.panelSpriteColor_Click);
            // 
            // rbSpriteColor
            // 
            this.rbSpriteColor.AutoSize = true;
            this.rbSpriteColor.Checked = true;
            this.rbSpriteColor.Location = new System.Drawing.Point(4, 60);
            this.rbSpriteColor.Name = "rbSpriteColor";
            this.rbSpriteColor.Size = new System.Drawing.Size(49, 17);
            this.rbSpriteColor.TabIndex = 0;
            this.rbSpriteColor.TabStop = true;
            this.rbSpriteColor.Text = "Color";
            this.rbSpriteColor.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 527);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(242, 24);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbSpriteData
            // 
            this.tbSpriteData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSpriteData.BackColor = System.Drawing.SystemColors.Info;
            this.tbSpriteData.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSpriteData.Location = new System.Drawing.Point(322, 27);
            this.tbSpriteData.Multiline = true;
            this.tbSpriteData.Name = "tbSpriteData";
            this.tbSpriteData.ReadOnly = true;
            this.tbSpriteData.Size = new System.Drawing.Size(659, 522);
            this.tbSpriteData.TabIndex = 4;
            // 
            // pbSprites
            // 
            this.pbSprites.BackColor = System.Drawing.Color.Black;
            this.pbSprites.Location = new System.Drawing.Point(260, 27);
            this.pbSprites.Name = "pbSprites";
            this.pbSprites.Size = new System.Drawing.Size(56, 370);
            this.pbSprites.TabIndex = 5;
            this.pbSprites.TabStop = false;
            this.pbSprites.Click += new System.EventHandler(this.pbSprites_Click);
            this.pbSprites.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSprites_Paint);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(984, 25);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 19);
            this.toolStripMenuItem1.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripMenuItem.Image")));
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportToolStripMenuItem.Image")));
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(44, 19);
            this.toolStripMenuItem2.Text = "Help";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manualToolStripMenuItem.Image")));
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnMirrorHorizontal
            // 
            this.btnMirrorHorizontal.BackColor = System.Drawing.Color.White;
            this.btnMirrorHorizontal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMirrorHorizontal.Image = ((System.Drawing.Image)(resources.GetObject("btnMirrorHorizontal.Image")));
            this.btnMirrorHorizontal.Location = new System.Drawing.Point(12, 403);
            this.btnMirrorHorizontal.Name = "btnMirrorHorizontal";
            this.btnMirrorHorizontal.Size = new System.Drawing.Size(56, 56);
            this.btnMirrorHorizontal.TabIndex = 8;
            this.btnMirrorHorizontal.UseVisualStyleBackColor = false;
            this.btnMirrorHorizontal.Click += new System.EventHandler(this.btnMirrorHorizontal_Click);
            // 
            // btnMirrorVertical
            // 
            this.btnMirrorVertical.BackColor = System.Drawing.Color.White;
            this.btnMirrorVertical.Image = ((System.Drawing.Image)(resources.GetObject("btnMirrorVertical.Image")));
            this.btnMirrorVertical.Location = new System.Drawing.Point(74, 403);
            this.btnMirrorVertical.Name = "btnMirrorVertical";
            this.btnMirrorVertical.Size = new System.Drawing.Size(56, 56);
            this.btnMirrorVertical.TabIndex = 9;
            this.btnMirrorVertical.UseVisualStyleBackColor = false;
            this.btnMirrorVertical.Click += new System.EventHandler(this.btnMirrorVertical_Click);
            // 
            // btnShiftRight
            // 
            this.btnShiftRight.BackColor = System.Drawing.Color.White;
            this.btnShiftRight.Image = ((System.Drawing.Image)(resources.GetObject("btnShiftRight.Image")));
            this.btnShiftRight.Location = new System.Drawing.Point(136, 403);
            this.btnShiftRight.Name = "btnShiftRight";
            this.btnShiftRight.Size = new System.Drawing.Size(56, 56);
            this.btnShiftRight.TabIndex = 10;
            this.btnShiftRight.UseVisualStyleBackColor = false;
            this.btnShiftRight.Click += new System.EventHandler(this.btnShiftRight_Click);
            // 
            // btnShiftLeft
            // 
            this.btnShiftLeft.BackColor = System.Drawing.Color.White;
            this.btnShiftLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnShiftLeft.Image")));
            this.btnShiftLeft.Location = new System.Drawing.Point(198, 403);
            this.btnShiftLeft.Name = "btnShiftLeft";
            this.btnShiftLeft.Size = new System.Drawing.Size(56, 56);
            this.btnShiftLeft.TabIndex = 11;
            this.btnShiftLeft.UseVisualStyleBackColor = false;
            this.btnShiftLeft.Click += new System.EventHandler(this.btnShiftLeft_Click);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.BackColor = System.Drawing.Color.White;
            this.btnRotateRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateRight.Image")));
            this.btnRotateRight.Location = new System.Drawing.Point(12, 465);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(56, 56);
            this.btnRotateRight.TabIndex = 12;
            this.btnRotateRight.UseVisualStyleBackColor = false;
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.BackColor = System.Drawing.Color.White;
            this.btnRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateLeft.Image")));
            this.btnRotateLeft.Location = new System.Drawing.Point(74, 465);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(56, 56);
            this.btnRotateLeft.TabIndex = 13;
            this.btnRotateLeft.UseVisualStyleBackColor = false;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.White;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(136, 465);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(56, 56);
            this.btnCopy.TabIndex = 14;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.BackColor = System.Drawing.Color.White;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.Location = new System.Drawing.Point(198, 465);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(56, 56);
            this.btnPaste.TabIndex = 15;
            this.btnPaste.UseVisualStyleBackColor = false;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnShiftDown
            // 
            this.btnShiftDown.BackColor = System.Drawing.Color.White;
            this.btnShiftDown.Image = ((System.Drawing.Image)(resources.GetObject("btnShiftDown.Image")));
            this.btnShiftDown.Location = new System.Drawing.Point(260, 465);
            this.btnShiftDown.Name = "btnShiftDown";
            this.btnShiftDown.Size = new System.Drawing.Size(56, 56);
            this.btnShiftDown.TabIndex = 17;
            this.btnShiftDown.UseVisualStyleBackColor = false;
            this.btnShiftDown.Click += new System.EventHandler(this.btnShiftDown_Click);
            // 
            // btnShiftUp
            // 
            this.btnShiftUp.BackColor = System.Drawing.Color.White;
            this.btnShiftUp.Image = ((System.Drawing.Image)(resources.GetObject("btnShiftUp.Image")));
            this.btnShiftUp.Location = new System.Drawing.Point(260, 403);
            this.btnShiftUp.Name = "btnShiftUp";
            this.btnShiftUp.Size = new System.Drawing.Size(56, 56);
            this.btnShiftUp.TabIndex = 16;
            this.btnShiftUp.UseVisualStyleBackColor = false;
            this.btnShiftUp.Click += new System.EventHandler(this.btnShiftUp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnShiftDown);
            this.Controls.Add(this.btnShiftUp);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnRotateLeft);
            this.Controls.Add(this.btnRotateRight);
            this.Controls.Add(this.btnShiftLeft);
            this.Controls.Add(this.btnShiftRight);
            this.Controls.Add(this.btnMirrorVertical);
            this.Controls.Add(this.btnMirrorHorizontal);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pbSprites);
            this.Controls.Add(this.tbSpriteData);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panelColors);
            this.Controls.Add(this.pbSpriteDraw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.Text = "SpriteEditor";
            ((System.ComponentModel.ISupportInitialize)(this.pbSpriteDraw)).EndInit();
            this.panelColors.ResumeLayout(false);
            this.panelColors.PerformLayout();
            this.panelHiResMultiColor.ResumeLayout(false);
            this.panelHiResMultiColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprites)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSpriteDraw;
        private System.Windows.Forms.RadioButton rbHiRes;
        private System.Windows.Forms.RadioButton rbMultiColor;
        private System.Windows.Forms.Panel panelColors;
        private System.Windows.Forms.RadioButton rbSpriteColor;
        private System.Windows.Forms.Panel panelSpriteColor;
        private System.Windows.Forms.RadioButton rbSpriteMultiColor1;
        private System.Windows.Forms.Panel panelSpriteMultiColor1;
        private System.Windows.Forms.RadioButton rbSpriteMultiColor0;
        private System.Windows.Forms.Panel panelSpriteMultiColor0;
        private System.Windows.Forms.RadioButton rbSpriteBackgroundColor;
        private System.Windows.Forms.Panel panelSpriteBackgroundColor;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbSpriteData;
        private System.Windows.Forms.PictureBox pbSprites;
        private System.Windows.Forms.Panel panelHiResMultiColor;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnMirrorHorizontal;
        private System.Windows.Forms.Button btnMirrorVertical;
        private System.Windows.Forms.Button btnShiftRight;
        private System.Windows.Forms.Button btnShiftLeft;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.Button btnRotateLeft;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnShiftDown;
        private System.Windows.Forms.Button btnShiftUp;
    }
}

