namespace RGB_LED_controller
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonRainbow = new System.Windows.Forms.Button();
            this.buttonRainbow2 = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.buttonSetBrightness = new System.Windows.Forms.Button();
            this.buttonChooseColor = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonChangeColor = new System.Windows.Forms.Button();
            this.buttonWhite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ButtonColorRight = new System.Windows.Forms.Button();
            this.buttonColorLeft = new System.Windows.Forms.Button();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.buttonSetDualColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRainbow
            // 
            this.buttonRainbow.Location = new System.Drawing.Point(13, 13);
            this.buttonRainbow.Name = "buttonRainbow";
            this.buttonRainbow.Size = new System.Drawing.Size(95, 23);
            this.buttonRainbow.TabIndex = 0;
            this.buttonRainbow.Text = "Rainbow";
            this.buttonRainbow.UseVisualStyleBackColor = true;
            this.buttonRainbow.Click += new System.EventHandler(this.ButtonRainbow_Click);
            // 
            // buttonRainbow2
            // 
            this.buttonRainbow2.Location = new System.Drawing.Point(13, 43);
            this.buttonRainbow2.Name = "buttonRainbow2";
            this.buttonRainbow2.Size = new System.Drawing.Size(95, 23);
            this.buttonRainbow2.TabIndex = 1;
            this.buttonRainbow2.Text = "Rainbow 2";
            this.buttonRainbow2.UseVisualStyleBackColor = true;
            this.buttonRainbow2.Click += new System.EventHandler(this.ButtonRainbow2_Click);
            // 
            // buttonRed
            // 
            this.buttonRed.Location = new System.Drawing.Point(114, 13);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(95, 23);
            this.buttonRed.TabIndex = 2;
            this.buttonRed.Text = "Red";
            this.buttonRed.UseVisualStyleBackColor = true;
            this.buttonRed.Click += new System.EventHandler(this.ButtonRed_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.Location = new System.Drawing.Point(114, 43);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(95, 23);
            this.buttonGreen.TabIndex = 3;
            this.buttonGreen.Text = "Green";
            this.buttonGreen.UseVisualStyleBackColor = true;
            this.buttonGreen.Click += new System.EventHandler(this.ButtonGreen_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.Location = new System.Drawing.Point(114, 72);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(95, 23);
            this.buttonBlue.TabIndex = 4;
            this.buttonBlue.Text = "Blue";
            this.buttonBlue.UseVisualStyleBackColor = true;
            this.buttonBlue.Click += new System.EventHandler(this.ButtonBlue_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 5;
            this.hScrollBar1.Location = new System.Drawing.Point(319, 13);
            this.hScrollBar1.Maximum = 104;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(95, 17);
            this.hScrollBar1.SmallChange = 5;
            this.hScrollBar1.TabIndex = 5;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.HScrollBar1_ValueChanged);
            // 
            // buttonSetBrightness
            // 
            this.buttonSetBrightness.Location = new System.Drawing.Point(316, 72);
            this.buttonSetBrightness.Name = "buttonSetBrightness";
            this.buttonSetBrightness.Size = new System.Drawing.Size(95, 23);
            this.buttonSetBrightness.TabIndex = 6;
            this.buttonSetBrightness.Text = "Set Brightness";
            this.buttonSetBrightness.UseVisualStyleBackColor = true;
            this.buttonSetBrightness.Click += new System.EventHandler(this.ButtonSetBrightness_Click);
            // 
            // buttonChooseColor
            // 
            this.buttonChooseColor.Location = new System.Drawing.Point(215, 43);
            this.buttonChooseColor.Name = "buttonChooseColor";
            this.buttonChooseColor.Size = new System.Drawing.Size(95, 23);
            this.buttonChooseColor.TabIndex = 7;
            this.buttonChooseColor.Text = "Choose Color";
            this.buttonChooseColor.UseVisualStyleBackColor = true;
            this.buttonChooseColor.Click += new System.EventHandler(this.ButtonChooseColor_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(215, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(95, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "000000";
            // 
            // buttonChangeColor
            // 
            this.buttonChangeColor.Location = new System.Drawing.Point(215, 72);
            this.buttonChangeColor.Name = "buttonChangeColor";
            this.buttonChangeColor.Size = new System.Drawing.Size(95, 23);
            this.buttonChangeColor.TabIndex = 9;
            this.buttonChangeColor.Text = "Change Color";
            this.buttonChangeColor.UseVisualStyleBackColor = true;
            this.buttonChangeColor.Click += new System.EventHandler(this.ButtonChangeColor_Click);
            // 
            // buttonWhite
            // 
            this.buttonWhite.Location = new System.Drawing.Point(12, 72);
            this.buttonWhite.Name = "buttonWhite";
            this.buttonWhite.Size = new System.Drawing.Size(96, 23);
            this.buttonWhite.TabIndex = 13;
            this.buttonWhite.Text = "White";
            this.buttonWhite.UseVisualStyleBackColor = true;
            this.buttonWhite.Click += new System.EventHandler(this.ButtonWhite_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(316, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 14;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "RGB LED Controller";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // ButtonColorRight
            // 
            this.ButtonColorRight.Location = new System.Drawing.Point(417, 43);
            this.ButtonColorRight.Name = "ButtonColorRight";
            this.ButtonColorRight.Size = new System.Drawing.Size(95, 23);
            this.ButtonColorRight.TabIndex = 16;
            this.ButtonColorRight.Text = "Right Color";
            this.ButtonColorRight.UseVisualStyleBackColor = true;
            this.ButtonColorRight.Click += new System.EventHandler(this.ButtonColorRight_Click);
            // 
            // buttonColorLeft
            // 
            this.buttonColorLeft.Location = new System.Drawing.Point(417, 14);
            this.buttonColorLeft.Name = "buttonColorLeft";
            this.buttonColorLeft.Size = new System.Drawing.Size(95, 23);
            this.buttonColorLeft.TabIndex = 17;
            this.buttonColorLeft.Text = "Left Color";
            this.buttonColorLeft.UseVisualStyleBackColor = true;
            this.buttonColorLeft.Click += new System.EventHandler(this.buttonColorLeft_Click);
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Location = new System.Drawing.Point(418, 72);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxLeft.TabIndex = 18;
            this.pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Location = new System.Drawing.Point(448, 72);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxRight.TabIndex = 19;
            this.pictureBoxRight.TabStop = false;
            // 
            // buttonSetDualColor
            // 
            this.buttonSetDualColor.Location = new System.Drawing.Point(478, 73);
            this.buttonSetDualColor.Name = "buttonSetDualColor";
            this.buttonSetDualColor.Size = new System.Drawing.Size(34, 23);
            this.buttonSetDualColor.TabIndex = 20;
            this.buttonSetDualColor.Text = "Set";
            this.buttonSetDualColor.UseVisualStyleBackColor = true;
            this.buttonSetDualColor.Click += new System.EventHandler(this.buttonSetDualColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 104);
            this.Controls.Add(this.buttonSetDualColor);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.buttonColorLeft);
            this.Controls.Add(this.ButtonColorRight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonWhite);
            this.Controls.Add(this.buttonChangeColor);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonChooseColor);
            this.Controls.Add(this.buttonSetBrightness);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.buttonBlue);
            this.Controls.Add(this.buttonGreen);
            this.Controls.Add(this.buttonRed);
            this.Controls.Add(this.buttonRainbow2);
            this.Controls.Add(this.buttonRainbow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(542, 143);
            this.MinimumSize = new System.Drawing.Size(542, 143);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RGB LED Controller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRainbow;
        private System.Windows.Forms.Button buttonRainbow2;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button buttonSetBrightness;
        private System.Windows.Forms.Button buttonChooseColor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonChangeColor;
        private System.Windows.Forms.Button buttonWhite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button ButtonColorRight;
        private System.Windows.Forms.Button buttonColorLeft;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Button buttonSetDualColor;
    }
}

