namespace Princeware_Encryption
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.PRINCEWARE_GIF = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PRINCEWARE_GIF)).BeginInit();
            this.SuspendLayout();
            // 
            // PRINCEWARE_GIF
            // 
            this.PRINCEWARE_GIF.ErrorImage = ((System.Drawing.Image)(resources.GetObject("PRINCEWARE_GIF.ErrorImage")));
            this.PRINCEWARE_GIF.Image = ((System.Drawing.Image)(resources.GetObject("PRINCEWARE_GIF.Image")));
            this.PRINCEWARE_GIF.InitialImage = ((System.Drawing.Image)(resources.GetObject("PRINCEWARE_GIF.InitialImage")));
            this.PRINCEWARE_GIF.Location = new System.Drawing.Point(12, 12);
            this.PRINCEWARE_GIF.Name = "PRINCEWARE_GIF";
            this.PRINCEWARE_GIF.Size = new System.Drawing.Size(598, 409);
            this.PRINCEWARE_GIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PRINCEWARE_GIF.TabIndex = 0;
            this.PRINCEWARE_GIF.TabStop = false;
            this.PRINCEWARE_GIF.Click += new System.EventHandler(this.PRINCEWARE_GIF_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(622, 433);
            this.Controls.Add(this.PRINCEWARE_GIF);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "PRINCEWARE";
            ((System.ComponentModel.ISupportInitialize)(this.PRINCEWARE_GIF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PRINCEWARE_GIF;
    }
}