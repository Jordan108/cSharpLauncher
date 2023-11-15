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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnBackView = new System.Windows.Forms.Button();
            this.btnHomeView = new System.Windows.Forms.Button();
            this.btnReloadView = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirLaCarpetaSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenarPanelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fechaDeCreacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtroDeBusquedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchFromActualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchActualtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAlltoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarResolucionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarEtiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelDepth = new System.Windows.Forms.Label();
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
            this.panelTop.Controls.Add(this.btnBackView);
            this.panelTop.Controls.Add(this.btnHomeView);
            this.panelTop.Controls.Add(this.btnReloadView);
            this.panelTop.Controls.Add(this.textBoxSearch);
            this.panelTop.Controls.Add(this.menuStripMain);
            this.panelTop.Controls.Add(this.labelDepth);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(901, 58);
            this.panelTop.TabIndex = 0;
            // 
            // btnBackView
            // 
            this.btnBackView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.btnBackView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackView.ForeColor = System.Drawing.SystemColors.Window;
            this.btnBackView.Location = new System.Drawing.Point(12, 29);
            this.btnBackView.Name = "btnBackView";
            this.btnBackView.Size = new System.Drawing.Size(48, 23);
            this.btnBackView.TabIndex = 0;
            this.btnBackView.Text = "Volver";
            this.btnBackView.UseVisualStyleBackColor = false;
            this.btnBackView.Click += new System.EventHandler(this.btnBackView_Click);
            // 
            // btnHomeView
            // 
            this.btnHomeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.btnHomeView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomeView.ForeColor = System.Drawing.SystemColors.Window;
            this.btnHomeView.Location = new System.Drawing.Point(66, 29);
            this.btnHomeView.Name = "btnHomeView";
            this.btnHomeView.Size = new System.Drawing.Size(48, 23);
            this.btnHomeView.TabIndex = 1;
            this.btnHomeView.Text = "Inicio";
            this.btnHomeView.UseVisualStyleBackColor = false;
            this.btnHomeView.Click += new System.EventHandler(this.btnHomeView_Click);
            // 
            // btnReloadView
            // 
            this.btnReloadView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.btnReloadView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadView.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReloadView.Location = new System.Drawing.Point(120, 29);
            this.btnReloadView.Name = "btnReloadView";
            this.btnReloadView.Size = new System.Drawing.Size(60, 23);
            this.btnReloadView.TabIndex = 2;
            this.btnReloadView.Text = "Recargar";
            this.btnReloadView.UseVisualStyleBackColor = false;
            this.btnReloadView.Click += new System.EventHandler(this.btnReloadView_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxSearch.Location = new System.Drawing.Point(755, 31);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(139, 20);
            this.textBoxSearch.TabIndex = 4;
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.verToolStripMenuItem,
            this.herramientasToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStripMain.Size = new System.Drawing.Size(901, 24);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirLaCarpetaSystemToolStripMenuItem});
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirLaCarpetaSystemToolStripMenuItem
            // 
            this.abrirLaCarpetaSystemToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.abrirLaCarpetaSystemToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.abrirLaCarpetaSystemToolStripMenuItem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.abrirLaCarpetaSystemToolStripMenuItem.Name = "abrirLaCarpetaSystemToolStripMenuItem";
            this.abrirLaCarpetaSystemToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.abrirLaCarpetaSystemToolStripMenuItem.Size = new System.Drawing.Size(195, 20);
            this.abrirLaCarpetaSystemToolStripMenuItem.Text = "Abrir la carpeta System";
            this.abrirLaCarpetaSystemToolStripMenuItem.Click += new System.EventHandler(this.abrirLaCarpetaSystemToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordenarPanelesToolStripMenuItem,
            this.filtroDeBusquedaToolStripMenuItem,
            this.administrarResolucionesToolStripMenuItem,
            this.administrarEtiquetasToolStripMenuItem});
            this.verToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.verToolStripMenuItem.Text = "Vista";
            // 
            // ordenarPanelesToolStripMenuItem
            // 
            this.ordenarPanelesToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ordenarPanelesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fechaDeCreacionToolStripMenuItem,
            this.nombreToolStripMenuItem});
            this.ordenarPanelesToolStripMenuItem.Name = "ordenarPanelesToolStripMenuItem";
            this.ordenarPanelesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.ordenarPanelesToolStripMenuItem.Text = "Ordenar paneles por";
            // 
            // fechaDeCreacionToolStripMenuItem
            // 
            this.fechaDeCreacionToolStripMenuItem.Checked = true;
            this.fechaDeCreacionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fechaDeCreacionToolStripMenuItem.Name = "fechaDeCreacionToolStripMenuItem";
            this.fechaDeCreacionToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.fechaDeCreacionToolStripMenuItem.Text = "Fecha de creacion";
            this.fechaDeCreacionToolStripMenuItem.Click += new System.EventHandler(this.fechaDeCreacionToolStripMenuItem_Click);
            // 
            // nombreToolStripMenuItem
            // 
            this.nombreToolStripMenuItem.Name = "nombreToolStripMenuItem";
            this.nombreToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.nombreToolStripMenuItem.Text = "Nombre";
            this.nombreToolStripMenuItem.Click += new System.EventHandler(this.nombreToolStripMenuItem_Click);
            // 
            // filtroDeBusquedaToolStripMenuItem
            // 
            this.filtroDeBusquedaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchFromActualToolStripMenuItem,
            this.searchActualtoolStripMenuItem,
            this.searchAlltoolStripMenuItem});
            this.filtroDeBusquedaToolStripMenuItem.Name = "filtroDeBusquedaToolStripMenuItem";
            this.filtroDeBusquedaToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.filtroDeBusquedaToolStripMenuItem.Text = "Filtro de busqueda";
            // 
            // searchFromActualToolStripMenuItem
            // 
            this.searchFromActualToolStripMenuItem.Checked = true;
            this.searchFromActualToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchFromActualToolStripMenuItem.Name = "searchFromActualToolStripMenuItem";
            this.searchFromActualToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.searchFromActualToolStripMenuItem.Text = "Desde profundidad actual";
            this.searchFromActualToolStripMenuItem.Click += new System.EventHandler(this.searchFromActualToolStripMenuItem_Click);
            // 
            // searchActualtoolStripMenuItem
            // 
            this.searchActualtoolStripMenuItem.Name = "searchActualtoolStripMenuItem";
            this.searchActualtoolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.searchActualtoolStripMenuItem.Text = "Solo profundidad actual";
            this.searchActualtoolStripMenuItem.Click += new System.EventHandler(this.searchActualtoolStripMenuItem_Click);
            // 
            // searchAlltoolStripMenuItem
            // 
            this.searchAlltoolStripMenuItem.Name = "searchAlltoolStripMenuItem";
            this.searchAlltoolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.searchAlltoolStripMenuItem.Text = "Todo";
            this.searchAlltoolStripMenuItem.Click += new System.EventHandler(this.searchAlltoolStripMenuItem_Click);
            // 
            // administrarResolucionesToolStripMenuItem
            // 
            this.administrarResolucionesToolStripMenuItem.Name = "administrarResolucionesToolStripMenuItem";
            this.administrarResolucionesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.administrarResolucionesToolStripMenuItem.Text = "Administrar resoluciones";
            this.administrarResolucionesToolStripMenuItem.Click += new System.EventHandler(this.administrarResolucionesToolStripMenuItem_Click);
            // 
            // administrarEtiquetasToolStripMenuItem
            // 
            this.administrarEtiquetasToolStripMenuItem.Name = "administrarEtiquetasToolStripMenuItem";
            this.administrarEtiquetasToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.administrarEtiquetasToolStripMenuItem.Text = "Administrar etiquetas";
            this.administrarEtiquetasToolStripMenuItem.Click += new System.EventHandler(this.administrarEtiquetasToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracionesToolStripMenuItem});
            this.herramientasToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // configuracionesToolStripMenuItem
            // 
            this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
            this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.configuracionesToolStripMenuItem.Text = "Configuraciones";
            this.configuracionesToolStripMenuItem.Click += new System.EventHandler(this.configuracionesToolStripMenuItem_Click);
            // 
            // labelDepth
            // 
            this.labelDepth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDepth.AutoSize = true;
            this.labelDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDepth.ForeColor = System.Drawing.Color.White;
            this.labelDepth.Location = new System.Drawing.Point(434, 29);
            this.labelDepth.Name = "labelDepth";
            this.labelDepth.Size = new System.Drawing.Size(68, 25);
            this.labelDepth.TabIndex = 5;
            this.labelDepth.Text = "Inicio";
            this.labelDepth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(105, 58);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(796, 586);
            this.flowLayoutPanelMain.TabIndex = 2;
            // 
            // treeViewMain
            // 
            this.treeViewMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.treeViewMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewMain.ForeColor = System.Drawing.Color.Black;
            this.treeViewMain.FullRowSelect = true;
            this.treeViewMain.HideSelection = false;
            this.treeViewMain.ItemHeight = 25;
            this.treeViewMain.Location = new System.Drawing.Point(0, 58);
            this.treeViewMain.MinimumSize = new System.Drawing.Size(97, 4);
            this.treeViewMain.Name = "treeViewMain";
            this.treeViewMain.Size = new System.Drawing.Size(100, 586);
            this.treeViewMain.TabIndex = 0;
            this.treeViewMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMain_AfterSelect);
            this.treeViewMain.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewMain_NodeMouseClick);
            this.treeViewMain.MouseLeave += new System.EventHandler(this.treeViewMain_MouseLeave);
            this.treeViewMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeViewMain_MouseMove);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(72)))), ((int)(((byte)(85)))));
            this.splitter1.Location = new System.Drawing.Point(100, 58);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 586);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 644);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeViewMain);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(352, 294);
            this.Name = "Home";
            this.Text = "Cover Pad Launcher 0.1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Home_FormClosed);
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
        private System.Windows.Forms.Label labelDepth;
        private System.Windows.Forms.ToolStripMenuItem filtroDeBusquedaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchFromActualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchActualtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAlltoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarEtiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionesToolStripMenuItem;
    }
}