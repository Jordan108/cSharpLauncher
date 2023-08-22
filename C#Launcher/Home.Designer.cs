﻿namespace C_Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panelTop = new System.Windows.Forms.Panel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.btnReloadView = new System.Windows.Forms.Button();
            this.btnHomeView = new System.Windows.Forms.Button();
            this.btnBackView = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirLaCarpetaSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenarPanelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fechaDeCreacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarResolucionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelTop.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.panelTop.Controls.Add(this.textBoxSearch);
            this.panelTop.Controls.Add(this.btnReloadView);
            this.panelTop.Controls.Add(this.btnHomeView);
            this.panelTop.Controls.Add(this.btnBackView);
            this.panelTop.Controls.Add(this.menuStripMain);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1100, 89);
            this.panelTop.TabIndex = 0;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxSearch.Location = new System.Drawing.Point(880, 48);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(206, 26);
            this.textBoxSearch.TabIndex = 4;
            // 
            // btnReloadView
            // 
            this.btnReloadView.Location = new System.Drawing.Point(180, 45);
            this.btnReloadView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReloadView.Name = "btnReloadView";
            this.btnReloadView.Size = new System.Drawing.Size(90, 35);
            this.btnReloadView.TabIndex = 2;
            this.btnReloadView.Text = "Recargar";
            this.btnReloadView.UseVisualStyleBackColor = true;
            this.btnReloadView.Click += new System.EventHandler(this.btnReloadView_Click);
            // 
            // btnHomeView
            // 
            this.btnHomeView.Location = new System.Drawing.Point(99, 45);
            this.btnHomeView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHomeView.Name = "btnHomeView";
            this.btnHomeView.Size = new System.Drawing.Size(72, 35);
            this.btnHomeView.TabIndex = 1;
            this.btnHomeView.Text = "Inicio";
            this.btnHomeView.UseVisualStyleBackColor = true;
            this.btnHomeView.Click += new System.EventHandler(this.btnHomeView_Click);
            // 
            // btnBackView
            // 
            this.btnBackView.Location = new System.Drawing.Point(18, 45);
            this.btnBackView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBackView.Name = "btnBackView";
            this.btnBackView.Size = new System.Drawing.Size(72, 35);
            this.btnBackView.TabIndex = 0;
            this.btnBackView.Text = "Volver";
            this.btnBackView.UseVisualStyleBackColor = true;
            this.btnBackView.Click += new System.EventHandler(this.btnBackView_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStripMain.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.verToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1100, 35);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirLaCarpetaSystemToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirLaCarpetaSystemToolStripMenuItem
            // 
            this.abrirLaCarpetaSystemToolStripMenuItem.Name = "abrirLaCarpetaSystemToolStripMenuItem";
            this.abrirLaCarpetaSystemToolStripMenuItem.Size = new System.Drawing.Size(296, 34);
            this.abrirLaCarpetaSystemToolStripMenuItem.Text = "Abrir la carpeta System";
            this.abrirLaCarpetaSystemToolStripMenuItem.Click += new System.EventHandler(this.abrirLaCarpetaSystemToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordenarPanelesToolStripMenuItem,
            this.administrarResolucionesToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(53, 29);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // ordenarPanelesToolStripMenuItem
            // 
            this.ordenarPanelesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fechaDeCreacionToolStripMenuItem,
            this.nombreToolStripMenuItem});
            this.ordenarPanelesToolStripMenuItem.Name = "ordenarPanelesToolStripMenuItem";
            this.ordenarPanelesToolStripMenuItem.Size = new System.Drawing.Size(309, 34);
            this.ordenarPanelesToolStripMenuItem.Text = "Ordenar paneles por";
            // 
            // fechaDeCreacionToolStripMenuItem
            // 
            this.fechaDeCreacionToolStripMenuItem.Checked = true;
            this.fechaDeCreacionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fechaDeCreacionToolStripMenuItem.Name = "fechaDeCreacionToolStripMenuItem";
            this.fechaDeCreacionToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.fechaDeCreacionToolStripMenuItem.Text = "Fecha de creacion";
            this.fechaDeCreacionToolStripMenuItem.Click += new System.EventHandler(this.fechaDeCreacionToolStripMenuItem_Click);
            // 
            // nombreToolStripMenuItem
            // 
            this.nombreToolStripMenuItem.Name = "nombreToolStripMenuItem";
            this.nombreToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.nombreToolStripMenuItem.Text = "Nombre";
            this.nombreToolStripMenuItem.Click += new System.EventHandler(this.nombreToolStripMenuItem_Click);
            // 
            // administrarResolucionesToolStripMenuItem
            // 
            this.administrarResolucionesToolStripMenuItem.Name = "administrarResolucionesToolStripMenuItem";
            this.administrarResolucionesToolStripMenuItem.Size = new System.Drawing.Size(309, 34);
            this.administrarResolucionesToolStripMenuItem.Text = "Administrar resoluciones";
            this.administrarResolucionesToolStripMenuItem.Click += new System.EventHandler(this.administrarResolucionesToolStripMenuItem_Click);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(156, 89);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(944, 634);
            this.flowLayoutPanelMain.TabIndex = 2;
            // 
            // treeViewMain
            // 
            this.treeViewMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.treeViewMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewMain.ForeColor = System.Drawing.Color.Black;
            this.treeViewMain.Location = new System.Drawing.Point(0, 89);
            this.treeViewMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeViewMain.MinimumSize = new System.Drawing.Size(144, 4);
            this.treeViewMain.Name = "treeViewMain";
            this.treeViewMain.Size = new System.Drawing.Size(148, 634);
            this.treeViewMain.TabIndex = 0;
            this.treeViewMain.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewMain_NodeMouseClick);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(72)))), ((int)(((byte)(85)))));
            this.splitter1.Location = new System.Drawing.Point(148, 89);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 634);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 723);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeViewMain);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(520, 431);
            this.Name = "Home";
            this.Text = "C# Launcher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Home_FormClosed);
            this.Load += new System.EventHandler(this.Home_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
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
        private System.Windows.Forms.ToolStripMenuItem abrirLaCarpetaSystemToolStripMenuItem;
        private System.Windows.Forms.TreeView treeViewMain;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}