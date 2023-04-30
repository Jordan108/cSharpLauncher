namespace C_Launcher
{
    partial class Home
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelSide = new System.Windows.Forms.Panel();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.splitterLeft = new System.Windows.Forms.Splitter();
            this.btnBackView = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.panelTop.Controls.Add(this.btnBackView);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(770, 64);
            this.panelTop.TabIndex = 0;
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 64);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(108, 488);
            this.panelSide.TabIndex = 1;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(108, 64);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(662, 488);
            this.flowLayoutPanelMain.TabIndex = 2;
            // 
            // splitterLeft
            // 
            this.splitterLeft.BackColor = System.Drawing.Color.Black;
            this.splitterLeft.Location = new System.Drawing.Point(108, 64);
            this.splitterLeft.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.splitterLeft.Name = "splitterLeft";
            this.splitterLeft.Size = new System.Drawing.Size(4, 488);
            this.splitterLeft.TabIndex = 3;
            this.splitterLeft.TabStop = false;
            // 
            // btnBackView
            // 
            this.btnBackView.Location = new System.Drawing.Point(12, 21);
            this.btnBackView.Name = "btnBackView";
            this.btnBackView.Size = new System.Drawing.Size(75, 23);
            this.btnBackView.TabIndex = 0;
            this.btnBackView.Text = "Volver";
            this.btnBackView.UseVisualStyleBackColor = true;
            this.btnBackView.Click += new System.EventHandler(this.btnBackView_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 552);
            this.Controls.Add(this.splitterLeft);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Controls.Add(this.panelSide);
            this.Controls.Add(this.panelTop);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Splitter splitterLeft;
        private System.Windows.Forms.Button btnBackView;
    }
}