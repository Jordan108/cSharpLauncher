namespace CoverPadLauncher
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelTittle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkWebPage = new System.Windows.Forms.LinkLabel();
            this.linkSource = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelDescription.Location = new System.Drawing.Point(206, 116);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(531, 120);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = resources.GetString("labelDescription.Text");
            // 
            // labelTittle
            // 
            this.labelTittle.AutoSize = true;
            this.labelTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
            this.labelTittle.Location = new System.Drawing.Point(202, 45);
            this.labelTittle.Name = "labelTittle";
            this.labelTittle.Size = new System.Drawing.Size(365, 44);
            this.labelTittle.TabIndex = 1;
            this.labelTittle.Text = "Cover Pad Launcher";
            this.labelTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 148);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // linkWebPage
            // 
            this.linkWebPage.AutoSize = true;
            this.linkWebPage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkWebPage.LinkColor = System.Drawing.Color.Blue;
            this.linkWebPage.Location = new System.Drawing.Point(334, 285);
            this.linkWebPage.Name = "linkWebPage";
            this.linkWebPage.Size = new System.Drawing.Size(63, 13);
            this.linkWebPage.TabIndex = 3;
            this.linkWebPage.TabStop = true;
            this.linkWebPage.Text = "Página web";
            // 
            // linkSource
            // 
            this.linkSource.AutoSize = true;
            this.linkSource.Location = new System.Drawing.Point(403, 285);
            this.linkSource.Name = "linkSource";
            this.linkSource.Size = new System.Drawing.Size(73, 13);
            this.linkSource.TabIndex = 4;
            this.linkSource.TabStop = true;
            this.linkSource.Text = "Código fuente";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 311);
            this.Controls.Add(this.linkSource);
            this.Controls.Add(this.linkWebPage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelTittle);
            this.Controls.Add(this.labelDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "About";
            this.Text = "Acerca de Cover Pad Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelTittle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkWebPage;
        private System.Windows.Forms.LinkLabel linkSource;
    }
}