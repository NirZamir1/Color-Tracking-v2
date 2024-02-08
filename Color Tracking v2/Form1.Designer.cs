namespace Color_Tracking_v2
{
    partial class Form1
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
            this.FHueBar = new System.Windows.Forms.HScrollBar();
            this.FhueText = new System.Windows.Forms.TextBox();
            this.IHueBar = new System.Windows.Forms.HScrollBar();
            this.IHueText = new System.Windows.Forms.TextBox();
            this.SatText = new System.Windows.Forms.TextBox();
            this.SatBar = new System.Windows.Forms.HScrollBar();
            this.lightText = new System.Windows.Forms.TextBox();
            this.LightnessBar = new System.Windows.Forms.HScrollBar();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // FHueBar
            // 
            this.FHueBar.Location = new System.Drawing.Point(1322, 64);
            this.FHueBar.Maximum = 109;
            this.FHueBar.Name = "FHueBar";
            this.FHueBar.Size = new System.Drawing.Size(330, 17);
            this.FHueBar.TabIndex = 1;
            this.FHueBar.Value = 100;
            this.FHueBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FHueBar_Scroll);
            // 
            // FhueText
            // 
            this.FhueText.Location = new System.Drawing.Point(1322, 23);
            this.FhueText.Name = "FhueText";
            this.FhueText.Size = new System.Drawing.Size(122, 23);
            this.FhueText.TabIndex = 2;
            this.FhueText.Text = "Finale hue";
            this.FhueText.TextChanged += new System.EventHandler(this.FhueText_TextChanged);
            // 
            // IHueBar
            // 
            this.IHueBar.Location = new System.Drawing.Point(1322, 147);
            this.IHueBar.Maximum = 109;
            this.IHueBar.Name = "IHueBar";
            this.IHueBar.Size = new System.Drawing.Size(330, 17);
            this.IHueBar.TabIndex = 3;
            this.IHueBar.Value = 100;
            this.IHueBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.IHueBar_Scroll);
            // 
            // IHueText
            // 
            this.IHueText.Location = new System.Drawing.Point(1322, 97);
            this.IHueText.Name = "IHueText";
            this.IHueText.Size = new System.Drawing.Size(122, 23);
            this.IHueText.TabIndex = 4;
            this.IHueText.Text = "Intial hue";
            this.IHueText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // SatText
            // 
            this.SatText.Location = new System.Drawing.Point(1322, 184);
            this.SatText.Name = "SatText";
            this.SatText.Size = new System.Drawing.Size(100, 23);
            this.SatText.TabIndex = 5;
            this.SatText.Text = "Saturation";
            // 
            // SatBar
            // 
            this.SatBar.Location = new System.Drawing.Point(1322, 229);
            this.SatBar.Maximum = 109;
            this.SatBar.Name = "SatBar";
            this.SatBar.Size = new System.Drawing.Size(330, 17);
            this.SatBar.TabIndex = 6;
            this.SatBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SatBar_Scroll);
            // 
            // lightText
            // 
            this.lightText.Location = new System.Drawing.Point(1322, 271);
            this.lightText.Name = "lightText";
            this.lightText.Size = new System.Drawing.Size(100, 23);
            this.lightText.TabIndex = 7;
            this.lightText.Text = "Lightness";
            // 
            // LightnessBar
            // 
            this.LightnessBar.Location = new System.Drawing.Point(1322, 313);
            this.LightnessBar.Maximum = 109;
            this.LightnessBar.Name = "LightnessBar";
            this.LightnessBar.Size = new System.Drawing.Size(330, 17);
            this.LightnessBar.TabIndex = 8;
            this.LightnessBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.LightnessBar_Scroll);
            // 
            // PictureBox2
            // 
            this.PictureBox2.Location = new System.Drawing.Point(12, 12);
            this.PictureBox2.MaximumSize = new System.Drawing.Size(1280, 720);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(1221, 716);
            this.PictureBox2.TabIndex = 9;
            this.PictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1634, 751);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.LightnessBar);
            this.Controls.Add(this.lightText);
            this.Controls.Add(this.SatBar);
            this.Controls.Add(this.SatText);
            this.Controls.Add(this.IHueText);
            this.Controls.Add(this.IHueBar);
            this.Controls.Add(this.FhueText);
            this.Controls.Add(this.FHueBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private HScrollBar FHueBar;
        private TextBox FhueText;
        private HScrollBar IHueBar;
        private TextBox IHueText;
        private TextBox SatText;
        private HScrollBar SatBar;
        private TextBox lightText;
        private HScrollBar LightnessBar;
        private PictureBox PictureBox2;
        private PictureBox pictureBox1;
    }
}