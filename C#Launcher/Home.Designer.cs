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
            this.btnReloadView = new System.Windows.Forms.Button();
            this.btnHomeView = new System.Windows.Forms.Button();
            this.btnBackView = new System.Windows.Forms.Button();
            this.panelSide = new System.Windows.Forms.Panel();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.splitterLeft = new System.Windows.Forms.Splitter();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenarPanelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fechaDeCreacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarResolucionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.panelTop.Controls.Add(this.btnReloadView);
            this.panelTop.Controls.Add(this.btnHomeView);
            this.panelTop.Controls.Add(this.btnBackView);
            this.panelTop.Controls.Add(this.menuStripMain);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(770, 58);
            this.panelTop.TabIndex = 0;
            // 
            // btnReloadView
            // 
            this.btnReloadView.Location = new System.Drawing.Point(120, 29);
            this.btnReloadView.Name = "btnReloadView";
            this.btnReloadView.Size = new System.Drawing.Size(60, 23);
            this.btnReloadView.TabIndex = 2;
            this.btnReloadView.Text = "Recargar";
            this.btnReloadView.UseVisualStyleBackColor = true;
            this.btnReloadView.Click += new System.EventHandler(this.btnReloadView_Click);
            // 
            // btnHomeView
            // 
            this.btnHomeView.Location = new System.Drawing.Point(66, 29);
            this.btnHomeView.Name = "btnHomeView";
            this.btnHomeView.Size = new System.Drawing.Size(48, 23);
            this.btnHomeView.TabIndex = 1;
            this.btnHomeView.Text = "Home";
            this.btnHomeView.UseVisualStyleBackColor = true;
            this.btnHomeView.Click += new System.EventHandler(this.btnHomeView_Click);
            // 
            // btnBackView
            // 
            this.btnBackView.Location = new System.Drawing.Point(12, 29);
            this.btnBackView.Name = "btnBackView";
            this.btnBackView.Size = new System.Drawing.Size(48, 23);
            this.btnBackView.TabIndex = 0;
            this.btnBackView.Text = "Volver";
            this.btnBackView.UseVisualStyleBackColor = true;
            this.btnBackView.Click += new System.EventHandler(this.btnBackView_Click);
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 58);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(108, 494);
            this.panelSide.TabIndex = 1;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(108, 58);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(662, 494);
            this.flowLayoutPanelMain.TabIndex = 2;
            // 
            // splitterLeft
            // 
            this.splitterLeft.BackColor = System.Drawing.Color.Black;
            this.splitterLeft.Location = new System.Drawing.Point(108, 58);
            this.splitterLeft.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.splitterLeft.Name = "splitterLeft";
            this.splitterLeft.Size = new System.Drawing.Size(4, 494);
            this.splitterLeft.TabIndex = 3;
            this.splitterLeft.TabStop = false;
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.verToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(770, 24);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordenarPanelesToolStripMenuItem,
            this.administrarResolucionesToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // ordenarPanelesToolStripMenuItem
            // 
            this.ordenarPanelesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fechaDeCreacionToolStripMenuItem,
            this.nombreToolStripMenuItem});
            this.ordenarPanelesToolStripMenuItem.Name = "ordenarPanelesToolStripMenuItem";
            this.ordenarPanelesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.ordenarPanelesToolStripMenuItem.Text = "Ordenar paneles por";
            // 
            // fechaDeCreacionToolStripMenuItem
            // 
            this.fechaDeCreacionToolStripMenuItem.Name = "fechaDeCreacionToolStripMenuItem";
            this.fechaDeCreacionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fechaDeCreacionToolStripMenuItem.Text = "Fecha de creacion";
            // 
            // nombreToolStripMenuItem
            // 
            this.nombreToolStripMenuItem.Name = "nombreToolStripMenuItem";
            this.nombreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nombreToolStripMenuItem.Text = "Nombre";
            // 
            // administrarResolucionesToolStripMenuItem
            // 
            this.administrarResolucionesToolStripMenuItem.Name = "administrarResolucionesToolStripMenuItem";
            this.administrarResolucionesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.administrarResolucionesToolStripMenuItem.Text = "Administrar resoluciones";
            this.administrarResolucionesToolStripMenuItem.Click += new System.EventHandler(this.administrarResolucionesToolStripMenuItem_Click);
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
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Splitter splitterLeft;
        private System.Windows.Forms.Button btnBackView;
        private System.Windows.Forms.Button btnHomeView;
        private System.Windows.Forms.Button btnReloadView;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenarPanelesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fechaDeCreacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarResolucionesToolStripMenuItem;
    }
}