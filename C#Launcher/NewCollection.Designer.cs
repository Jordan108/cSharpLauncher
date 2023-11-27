namespace C_Launcher
{
    partial class NewCollection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCollection));
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.comboBoxFather = new System.Windows.Forms.ComboBox();
            this.labelFather = new System.Windows.Forms.Label();
            this.comboBoxResolutionCol = new System.Windows.Forms.ComboBox();
            this.labelResolutionCol = new System.Windows.Forms.Label();
            this.groupBoxCover = new System.Windows.Forms.GroupBox();
            this.labelColHeight = new System.Windows.Forms.Label();
            this.labelColWidth = new System.Windows.Forms.Label();
            this.numericColHeight = new System.Windows.Forms.NumericUpDown();
            this.numericColWidth = new System.Windows.Forms.NumericUpDown();
            this.groupBoxImageFormat = new System.Windows.Forms.GroupBox();
            this.radioButtonColEstreched = new System.Windows.Forms.RadioButton();
            this.radioButtonColZoom = new System.Windows.Forms.RadioButton();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panelImageLimit = new System.Windows.Forms.Panel();
            this.pictureBoxCoverCollection = new System.Windows.Forms.PictureBox();
            this.checkBoxFavorite = new System.Windows.Forms.CheckBox();
            this.panelSonImageLimit = new System.Windows.Forms.Panel();
            this.pictureBoxCoverSon = new System.Windows.Forms.PictureBox();
            this.comboBoxSonResolution = new System.Windows.Forms.ComboBox();
            this.labelContentRes = new System.Windows.Forms.Label();
            this.groupBoxSonFormat = new System.Windows.Forms.GroupBox();
            this.radioButtonSonEstreched = new System.Windows.Forms.RadioButton();
            this.radioButtonSonZoom = new System.Windows.Forms.RadioButton();
            this.buttonSearchCover = new System.Windows.Forms.Button();
            this.buttonBackgroundColor = new System.Windows.Forms.Button();
            this.buttonSearchSonCoverDefault = new System.Windows.Forms.Button();
            this.buttonColorPickIMG = new System.Windows.Forms.Button();
            this.BackgroundColorCheck = new System.Windows.Forms.CheckBox();
            this.checkBoxScanFolder = new System.Windows.Forms.CheckBox();
            this.textBoxScanFolder = new System.Windows.Forms.TextBox();
            this.buttonSearchDir = new System.Windows.Forms.Button();
            this.dataGridViewScanOpenExtension = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericScanStart = new System.Windows.Forms.NumericUpDown();
            this.labelExecuteFile = new System.Windows.Forms.Label();
            this.buttonDeleteCover = new System.Windows.Forms.Button();
            this.buttonDeleteTestCover = new System.Windows.Forms.Button();
            this.dataGridViewTags = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.addResolution = new System.Windows.Forms.Button();
            this.labelContentLauncher = new System.Windows.Forms.Label();
            this.labelContentCMD = new System.Windows.Forms.Label();
            this.textBoxSonProgramPath = new System.Windows.Forms.TextBox();
            this.textBoxDefaultCMD = new System.Windows.Forms.TextBox();
            this.buttonSearchProgram = new System.Windows.Forms.Button();
            this.numericSonWidth = new System.Windows.Forms.NumericUpDown();
            this.numericSonHeight = new System.Windows.Forms.NumericUpDown();
            this.labelSonWidth = new System.Windows.Forms.Label();
            this.labelSonHeight = new System.Windows.Forms.Label();
            this.groupBoxSon = new System.Windows.Forms.GroupBox();
            this.labelSonWarning = new System.Windows.Forms.Label();
            this.buttonCoverOnline = new System.Windows.Forms.Button();
            this.groupBoxCover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericColHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColWidth)).BeginInit();
            this.groupBoxImageFormat.SuspendLayout();
            this.panelImageLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverCollection)).BeginInit();
            this.panelSonImageLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverSon)).BeginInit();
            this.groupBoxSonFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScanOpenExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScanStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSonWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSonHeight)).BeginInit();
            this.groupBoxSon.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxName.Location = new System.Drawing.Point(145, 21);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(245, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.ForeColor = System.Drawing.SystemColors.Window;
            this.labelName.Location = new System.Drawing.Point(40, 26);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(96, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Nombre coleccion:";
            // 
            // comboBoxFather
            // 
            this.comboBoxFather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.comboBoxFather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFather.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxFather.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxFather.FormattingEnabled = true;
            this.comboBoxFather.Location = new System.Drawing.Point(145, 47);
            this.comboBoxFather.Name = "comboBoxFather";
            this.comboBoxFather.Size = new System.Drawing.Size(245, 21);
            this.comboBoxFather.TabIndex = 2;
            // 
            // labelFather
            // 
            this.labelFather.AutoSize = true;
            this.labelFather.ForeColor = System.Drawing.SystemColors.Window;
            this.labelFather.Location = new System.Drawing.Point(49, 50);
            this.labelFather.Name = "labelFather";
            this.labelFather.Size = new System.Drawing.Size(87, 13);
            this.labelFather.TabIndex = 3;
            this.labelFather.Text = "Padre coleccion:";
            // 
            // comboBoxResolutionCol
            // 
            this.comboBoxResolutionCol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.comboBoxResolutionCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolutionCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxResolutionCol.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxResolutionCol.FormattingEnabled = true;
            this.comboBoxResolutionCol.Location = new System.Drawing.Point(12, 284);
            this.comboBoxResolutionCol.Name = "comboBoxResolutionCol";
            this.comboBoxResolutionCol.Size = new System.Drawing.Size(200, 21);
            this.comboBoxResolutionCol.TabIndex = 4;
            this.comboBoxResolutionCol.SelectedIndexChanged += new System.EventHandler(this.comboBoxResolutionCol_SelectedIndexChanged);
            // 
            // labelResolutionCol
            // 
            this.labelResolutionCol.AutoSize = true;
            this.labelResolutionCol.ForeColor = System.Drawing.SystemColors.Window;
            this.labelResolutionCol.Location = new System.Drawing.Point(9, 268);
            this.labelResolutionCol.Name = "labelResolutionCol";
            this.labelResolutionCol.Size = new System.Drawing.Size(109, 13);
            this.labelResolutionCol.TabIndex = 5;
            this.labelResolutionCol.Text = "Resolucion coleccion";
            // 
            // groupBoxCover
            // 
            this.groupBoxCover.Controls.Add(this.labelColHeight);
            this.groupBoxCover.Controls.Add(this.labelColWidth);
            this.groupBoxCover.Controls.Add(this.numericColHeight);
            this.groupBoxCover.Controls.Add(this.numericColWidth);
            this.groupBoxCover.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBoxCover.Location = new System.Drawing.Point(12, 345);
            this.groupBoxCover.Name = "groupBoxCover";
            this.groupBoxCover.Size = new System.Drawing.Size(200, 100);
            this.groupBoxCover.TabIndex = 6;
            this.groupBoxCover.TabStop = false;
            this.groupBoxCover.Text = "Tamaño en pixeles (100-300)";
            // 
            // labelColHeight
            // 
            this.labelColHeight.AutoSize = true;
            this.labelColHeight.Location = new System.Drawing.Point(8, 59);
            this.labelColHeight.Name = "labelColHeight";
            this.labelColHeight.Size = new System.Drawing.Size(28, 13);
            this.labelColHeight.TabIndex = 3;
            this.labelColHeight.Text = "Alto:";
            // 
            // labelColWidth
            // 
            this.labelColWidth.AutoSize = true;
            this.labelColWidth.Location = new System.Drawing.Point(8, 32);
            this.labelColWidth.Name = "labelColWidth";
            this.labelColWidth.Size = new System.Drawing.Size(41, 13);
            this.labelColWidth.TabIndex = 2;
            this.labelColWidth.Text = "Ancho:";
            // 
            // numericColHeight
            // 
            this.numericColHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.numericColHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericColHeight.ForeColor = System.Drawing.SystemColors.Window;
            this.numericColHeight.Location = new System.Drawing.Point(55, 59);
            this.numericColHeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericColHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericColHeight.Name = "numericColHeight";
            this.numericColHeight.Size = new System.Drawing.Size(120, 20);
            this.numericColHeight.TabIndex = 1;
            this.numericColHeight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericColHeight.ValueChanged += new System.EventHandler(this.numericColHeight_ValueChanged);
            // 
            // numericColWidth
            // 
            this.numericColWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.numericColWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericColWidth.ForeColor = System.Drawing.SystemColors.Window;
            this.numericColWidth.Location = new System.Drawing.Point(55, 32);
            this.numericColWidth.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericColWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericColWidth.Name = "numericColWidth";
            this.numericColWidth.Size = new System.Drawing.Size(120, 20);
            this.numericColWidth.TabIndex = 0;
            this.numericColWidth.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericColWidth.ValueChanged += new System.EventHandler(this.numericColWidth_ValueChanged);
            // 
            // groupBoxImageFormat
            // 
            this.groupBoxImageFormat.Controls.Add(this.radioButtonColEstreched);
            this.groupBoxImageFormat.Controls.Add(this.radioButtonColZoom);
            this.groupBoxImageFormat.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBoxImageFormat.Location = new System.Drawing.Point(12, 451);
            this.groupBoxImageFormat.Name = "groupBoxImageFormat";
            this.groupBoxImageFormat.Size = new System.Drawing.Size(200, 69);
            this.groupBoxImageFormat.TabIndex = 7;
            this.groupBoxImageFormat.TabStop = false;
            this.groupBoxImageFormat.Text = "Formato de la imagen";
            // 
            // radioButtonColEstreched
            // 
            this.radioButtonColEstreched.AutoSize = true;
            this.radioButtonColEstreched.Location = new System.Drawing.Point(11, 44);
            this.radioButtonColEstreched.Name = "radioButtonColEstreched";
            this.radioButtonColEstreched.Size = new System.Drawing.Size(63, 17);
            this.radioButtonColEstreched.TabIndex = 1;
            this.radioButtonColEstreched.Text = "Estirada";
            this.radioButtonColEstreched.UseVisualStyleBackColor = true;
            this.radioButtonColEstreched.CheckedChanged += new System.EventHandler(this.radioButtonColEstreched_CheckedChanged);
            // 
            // radioButtonColZoom
            // 
            this.radioButtonColZoom.AutoSize = true;
            this.radioButtonColZoom.Checked = true;
            this.radioButtonColZoom.Location = new System.Drawing.Point(11, 20);
            this.radioButtonColZoom.Name = "radioButtonColZoom";
            this.radioButtonColZoom.Size = new System.Drawing.Size(104, 17);
            this.radioButtonColZoom.TabIndex = 0;
            this.radioButtonColZoom.TabStop = true;
            this.radioButtonColZoom.Text = "Mantener escala";
            this.radioButtonColZoom.UseVisualStyleBackColor = true;
            this.radioButtonColZoom.CheckedChanged += new System.EventHandler(this.radioButtonColZoom_CheckedChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSave.Location = new System.Drawing.Point(12, 526);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(200, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panelImageLimit
            // 
            this.panelImageLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.panelImageLimit.Controls.Add(this.pictureBoxCoverCollection);
            this.panelImageLimit.Location = new System.Drawing.Point(218, 249);
            this.panelImageLimit.Name = "panelImageLimit";
            this.panelImageLimit.Size = new System.Drawing.Size(300, 300);
            this.panelImageLimit.TabIndex = 9;
            // 
            // pictureBoxCoverCollection
            // 
            this.pictureBoxCoverCollection.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxCoverCollection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCoverCollection.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCoverCollection.Name = "pictureBoxCoverCollection";
            this.pictureBoxCoverCollection.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxCoverCollection.TabIndex = 0;
            this.pictureBoxCoverCollection.TabStop = false;
            this.pictureBoxCoverCollection.MouseLeave += new System.EventHandler(this.pictureBoxCoverCollection_MouseLeave);
            // 
            // checkBoxFavorite
            // 
            this.checkBoxFavorite.AutoSize = true;
            this.checkBoxFavorite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxFavorite.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBoxFavorite.Location = new System.Drawing.Point(396, 24);
            this.checkBoxFavorite.Name = "checkBoxFavorite";
            this.checkBoxFavorite.Size = new System.Drawing.Size(61, 17);
            this.checkBoxFavorite.TabIndex = 10;
            this.checkBoxFavorite.Text = "Favorito";
            this.checkBoxFavorite.UseVisualStyleBackColor = true;
            // 
            // panelSonImageLimit
            // 
            this.panelSonImageLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.panelSonImageLimit.Controls.Add(this.pictureBoxCoverSon);
            this.panelSonImageLimit.Location = new System.Drawing.Point(739, 249);
            this.panelSonImageLimit.Name = "panelSonImageLimit";
            this.panelSonImageLimit.Size = new System.Drawing.Size(300, 300);
            this.panelSonImageLimit.TabIndex = 10;
            this.panelSonImageLimit.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSonImageLimit_Paint);
            // 
            // pictureBoxCoverSon
            // 
            this.pictureBoxCoverSon.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxCoverSon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCoverSon.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCoverSon.Name = "pictureBoxCoverSon";
            this.pictureBoxCoverSon.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxCoverSon.TabIndex = 0;
            this.pictureBoxCoverSon.TabStop = false;
            this.pictureBoxCoverSon.MouseLeave += new System.EventHandler(this.pictureBoxCoverSon_MouseLeave);
            // 
            // comboBoxSonResolution
            // 
            this.comboBoxSonResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.comboBoxSonResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSonResolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSonResolution.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxSonResolution.FormattingEnabled = true;
            this.comboBoxSonResolution.Location = new System.Drawing.Point(533, 318);
            this.comboBoxSonResolution.Name = "comboBoxSonResolution";
            this.comboBoxSonResolution.Size = new System.Drawing.Size(200, 21);
            this.comboBoxSonResolution.TabIndex = 11;
            this.comboBoxSonResolution.SelectedIndexChanged += new System.EventHandler(this.comboBoxSonResolution_SelectedIndexChanged);
            // 
            // labelContentRes
            // 
            this.labelContentRes.AutoSize = true;
            this.labelContentRes.ForeColor = System.Drawing.SystemColors.Window;
            this.labelContentRes.Location = new System.Drawing.Point(535, 302);
            this.labelContentRes.Name = "labelContentRes";
            this.labelContentRes.Size = new System.Drawing.Size(127, 13);
            this.labelContentRes.TabIndex = 12;
            this.labelContentRes.Text = "Resolucion del contenido";
            // 
            // groupBoxSonFormat
            // 
            this.groupBoxSonFormat.Controls.Add(this.radioButtonSonEstreched);
            this.groupBoxSonFormat.Controls.Add(this.radioButtonSonZoom);
            this.groupBoxSonFormat.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBoxSonFormat.Location = new System.Drawing.Point(533, 451);
            this.groupBoxSonFormat.Name = "groupBoxSonFormat";
            this.groupBoxSonFormat.Size = new System.Drawing.Size(200, 69);
            this.groupBoxSonFormat.TabIndex = 8;
            this.groupBoxSonFormat.TabStop = false;
            this.groupBoxSonFormat.Text = "Formato de la imagen";
            // 
            // radioButtonSonEstreched
            // 
            this.radioButtonSonEstreched.AutoSize = true;
            this.radioButtonSonEstreched.Location = new System.Drawing.Point(11, 44);
            this.radioButtonSonEstreched.Name = "radioButtonSonEstreched";
            this.radioButtonSonEstreched.Size = new System.Drawing.Size(63, 17);
            this.radioButtonSonEstreched.TabIndex = 1;
            this.radioButtonSonEstreched.Text = "Estirada";
            this.radioButtonSonEstreched.UseVisualStyleBackColor = true;
            this.radioButtonSonEstreched.CheckedChanged += new System.EventHandler(this.radioButtonSonEstreched_CheckedChanged);
            // 
            // radioButtonSonZoom
            // 
            this.radioButtonSonZoom.AutoSize = true;
            this.radioButtonSonZoom.Checked = true;
            this.radioButtonSonZoom.Location = new System.Drawing.Point(11, 20);
            this.radioButtonSonZoom.Name = "radioButtonSonZoom";
            this.radioButtonSonZoom.Size = new System.Drawing.Size(104, 17);
            this.radioButtonSonZoom.TabIndex = 0;
            this.radioButtonSonZoom.TabStop = true;
            this.radioButtonSonZoom.Text = "Mantener escala";
            this.radioButtonSonZoom.UseVisualStyleBackColor = true;
            this.radioButtonSonZoom.CheckedChanged += new System.EventHandler(this.radioButtonSonZoom_CheckedChanged);
            // 
            // buttonSearchCover
            // 
            this.buttonSearchCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSearchCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchCover.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSearchCover.Location = new System.Drawing.Point(219, 172);
            this.buttonSearchCover.Name = "buttonSearchCover";
            this.buttonSearchCover.Size = new System.Drawing.Size(118, 23);
            this.buttonSearchCover.TabIndex = 13;
            this.buttonSearchCover.Text = "Seleccionar Caratula";
            this.buttonSearchCover.UseVisualStyleBackColor = false;
            this.buttonSearchCover.Click += new System.EventHandler(this.buttonSearchCover_Click);
            // 
            // buttonBackgroundColor
            // 
            this.buttonBackgroundColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonBackgroundColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackgroundColor.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonBackgroundColor.Location = new System.Drawing.Point(340, 200);
            this.buttonBackgroundColor.Name = "buttonBackgroundColor";
            this.buttonBackgroundColor.Size = new System.Drawing.Size(117, 23);
            this.buttonBackgroundColor.TabIndex = 14;
            this.buttonBackgroundColor.Text = "Color de fondo";
            this.buttonBackgroundColor.UseVisualStyleBackColor = false;
            this.buttonBackgroundColor.Click += new System.EventHandler(this.buttonBackgroundColor_Click);
            // 
            // buttonSearchSonCoverDefault
            // 
            this.buttonSearchSonCoverDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSearchSonCoverDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchSonCoverDefault.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSearchSonCoverDefault.Location = new System.Drawing.Point(739, 220);
            this.buttonSearchSonCoverDefault.Name = "buttonSearchSonCoverDefault";
            this.buttonSearchSonCoverDefault.Size = new System.Drawing.Size(118, 23);
            this.buttonSearchSonCoverDefault.TabIndex = 15;
            this.buttonSearchSonCoverDefault.Text = "Seleccionar Caratula";
            this.buttonSearchSonCoverDefault.UseVisualStyleBackColor = false;
            this.buttonSearchSonCoverDefault.Click += new System.EventHandler(this.buttonSearchSonCoverDefault_Click);
            // 
            // buttonColorPickIMG
            // 
            this.buttonColorPickIMG.BackColor = System.Drawing.Color.Black;
            this.buttonColorPickIMG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColorPickIMG.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonColorPickIMG.Location = new System.Drawing.Point(463, 200);
            this.buttonColorPickIMG.Name = "buttonColorPickIMG";
            this.buttonColorPickIMG.Size = new System.Drawing.Size(23, 23);
            this.buttonColorPickIMG.TabIndex = 16;
            this.buttonColorPickIMG.UseVisualStyleBackColor = false;
            // 
            // BackgroundColorCheck
            // 
            this.BackgroundColorCheck.AutoSize = true;
            this.BackgroundColorCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackgroundColorCheck.ForeColor = System.Drawing.SystemColors.Window;
            this.BackgroundColorCheck.Location = new System.Drawing.Point(343, 226);
            this.BackgroundColorCheck.Name = "BackgroundColorCheck";
            this.BackgroundColorCheck.Size = new System.Drawing.Size(115, 17);
            this.BackgroundColorCheck.TabIndex = 33;
            this.BackgroundColorCheck.Text = "Fondo transparente";
            this.BackgroundColorCheck.UseVisualStyleBackColor = true;
            // 
            // checkBoxScanFolder
            // 
            this.checkBoxScanFolder.AutoSize = true;
            this.checkBoxScanFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxScanFolder.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBoxScanFolder.Location = new System.Drawing.Point(540, 21);
            this.checkBoxScanFolder.Name = "checkBoxScanFolder";
            this.checkBoxScanFolder.Size = new System.Drawing.Size(129, 17);
            this.checkBoxScanFolder.TabIndex = 36;
            this.checkBoxScanFolder.Text = "Escanear un directorio";
            this.checkBoxScanFolder.UseVisualStyleBackColor = true;
            this.checkBoxScanFolder.CheckedChanged += new System.EventHandler(this.checkBoxScanFolder_CheckedChanged);
            // 
            // textBoxScanFolder
            // 
            this.textBoxScanFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxScanFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxScanFolder.Enabled = false;
            this.textBoxScanFolder.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxScanFolder.Location = new System.Drawing.Point(675, 21);
            this.textBoxScanFolder.Name = "textBoxScanFolder";
            this.textBoxScanFolder.Size = new System.Drawing.Size(264, 20);
            this.textBoxScanFolder.TabIndex = 37;
            // 
            // buttonSearchDir
            // 
            this.buttonSearchDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSearchDir.Enabled = false;
            this.buttonSearchDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchDir.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSearchDir.Location = new System.Drawing.Point(945, 18);
            this.buttonSearchDir.Name = "buttonSearchDir";
            this.buttonSearchDir.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchDir.TabIndex = 38;
            this.buttonSearchDir.Text = "Examinar...";
            this.buttonSearchDir.UseVisualStyleBackColor = false;
            this.buttonSearchDir.Click += new System.EventHandler(this.buttonSearchDir_Click);
            // 
            // dataGridViewScanOpenExtension
            // 
            this.dataGridViewScanOpenExtension.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.dataGridViewScanOpenExtension.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScanOpenExtension.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewScanOpenExtension.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.dataGridViewScanOpenExtension.Location = new System.Drawing.Point(533, 73);
            this.dataGridViewScanOpenExtension.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewScanOpenExtension.MultiSelect = false;
            this.dataGridViewScanOpenExtension.Name = "dataGridViewScanOpenExtension";
            this.dataGridViewScanOpenExtension.RowHeadersVisible = false;
            this.dataGridViewScanOpenExtension.RowHeadersWidth = 62;
            this.dataGridViewScanOpenExtension.RowTemplate.Height = 28;
            this.dataGridViewScanOpenExtension.Size = new System.Drawing.Size(104, 203);
            this.dataGridViewScanOpenExtension.TabIndex = 39;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Extension";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            // 
            // numericScanStart
            // 
            this.numericScanStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.numericScanStart.ForeColor = System.Drawing.SystemColors.Window;
            this.numericScanStart.Location = new System.Drawing.Point(641, 47);
            this.numericScanStart.Margin = new System.Windows.Forms.Padding(2);
            this.numericScanStart.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericScanStart.Name = "numericScanStart";
            this.numericScanStart.Size = new System.Drawing.Size(42, 20);
            this.numericScanStart.TabIndex = 40;
            // 
            // labelExecuteFile
            // 
            this.labelExecuteFile.AutoSize = true;
            this.labelExecuteFile.ForeColor = System.Drawing.SystemColors.Window;
            this.labelExecuteFile.Location = new System.Drawing.Point(530, 50);
            this.labelExecuteFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExecuteFile.Name = "labelExecuteFile";
            this.labelExecuteFile.Size = new System.Drawing.Size(97, 13);
            this.labelExecuteFile.TabIndex = 41;
            this.labelExecuteFile.Text = "Ejecutar archivo n°";
            // 
            // buttonDeleteCover
            // 
            this.buttonDeleteCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonDeleteCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteCover.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonDeleteCover.Location = new System.Drawing.Point(219, 200);
            this.buttonDeleteCover.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteCover.Name = "buttonDeleteCover";
            this.buttonDeleteCover.Size = new System.Drawing.Size(118, 23);
            this.buttonDeleteCover.TabIndex = 42;
            this.buttonDeleteCover.Text = "Borrar caratula";
            this.buttonDeleteCover.UseVisualStyleBackColor = false;
            this.buttonDeleteCover.Click += new System.EventHandler(this.buttonDeleteCover_Click);
            // 
            // buttonDeleteTestCover
            // 
            this.buttonDeleteTestCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonDeleteTestCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteTestCover.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonDeleteTestCover.Location = new System.Drawing.Point(862, 220);
            this.buttonDeleteTestCover.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteTestCover.Name = "buttonDeleteTestCover";
            this.buttonDeleteTestCover.Size = new System.Drawing.Size(91, 23);
            this.buttonDeleteTestCover.TabIndex = 43;
            this.buttonDeleteTestCover.Text = "Borrar caratula";
            this.buttonDeleteTestCover.UseVisualStyleBackColor = false;
            // 
            // dataGridViewTags
            // 
            this.dataGridViewTags.AllowUserToAddRows = false;
            this.dataGridViewTags.AllowUserToDeleteRows = false;
            this.dataGridViewTags.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.dataGridViewTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.dataGridViewTextBoxColumn1,
            this.Column3});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTags.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTags.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.dataGridViewTags.Location = new System.Drawing.Point(1, 73);
            this.dataGridViewTags.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewTags.MultiSelect = false;
            this.dataGridViewTags.Name = "dataGridViewTags";
            this.dataGridViewTags.RowHeadersVisible = false;
            this.dataGridViewTags.RowHeadersWidth = 62;
            this.dataGridViewTags.RowTemplate.Height = 28;
            this.dataGridViewTags.Size = new System.Drawing.Size(213, 193);
            this.dataGridViewTags.TabIndex = 44;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Añadir";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Etiqueta";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Escanear";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 60;
            // 
            // addResolution
            // 
            this.addResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.addResolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addResolution.ForeColor = System.Drawing.SystemColors.Window;
            this.addResolution.Location = new System.Drawing.Point(12, 310);
            this.addResolution.Margin = new System.Windows.Forms.Padding(2);
            this.addResolution.Name = "addResolution";
            this.addResolution.Size = new System.Drawing.Size(200, 21);
            this.addResolution.TabIndex = 45;
            this.addResolution.Text = "Añadir";
            this.addResolution.UseVisualStyleBackColor = false;
            this.addResolution.Click += new System.EventHandler(this.addResolution_Click);
            // 
            // labelContentLauncher
            // 
            this.labelContentLauncher.AutoSize = true;
            this.labelContentLauncher.ForeColor = System.Drawing.SystemColors.Window;
            this.labelContentLauncher.Location = new System.Drawing.Point(645, 114);
            this.labelContentLauncher.Name = "labelContentLauncher";
            this.labelContentLauncher.Size = new System.Drawing.Size(157, 13);
            this.labelContentLauncher.TabIndex = 46;
            this.labelContentLauncher.Text = "Ruta del lanzador del contenido";
            // 
            // labelContentCMD
            // 
            this.labelContentCMD.AutoSize = true;
            this.labelContentCMD.ForeColor = System.Drawing.SystemColors.Window;
            this.labelContentCMD.Location = new System.Drawing.Point(645, 159);
            this.labelContentCMD.Name = "labelContentCMD";
            this.labelContentCMD.Size = new System.Drawing.Size(201, 13);
            this.labelContentCMD.TabIndex = 47;
            this.labelContentCMD.Text = "Parametros de lanzamiento del contenido";
            // 
            // textBoxSonProgramPath
            // 
            this.textBoxSonProgramPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxSonProgramPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSonProgramPath.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxSonProgramPath.Location = new System.Drawing.Point(648, 130);
            this.textBoxSonProgramPath.Name = "textBoxSonProgramPath";
            this.textBoxSonProgramPath.Size = new System.Drawing.Size(264, 20);
            this.textBoxSonProgramPath.TabIndex = 48;
            // 
            // textBoxDefaultCMD
            // 
            this.textBoxDefaultCMD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxDefaultCMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDefaultCMD.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxDefaultCMD.Location = new System.Drawing.Point(648, 175);
            this.textBoxDefaultCMD.Name = "textBoxDefaultCMD";
            this.textBoxDefaultCMD.Size = new System.Drawing.Size(264, 20);
            this.textBoxDefaultCMD.TabIndex = 49;
            // 
            // buttonSearchProgram
            // 
            this.buttonSearchProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSearchProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchProgram.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSearchProgram.Location = new System.Drawing.Point(918, 127);
            this.buttonSearchProgram.Name = "buttonSearchProgram";
            this.buttonSearchProgram.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchProgram.TabIndex = 50;
            this.buttonSearchProgram.Text = "Examinar...";
            this.buttonSearchProgram.UseVisualStyleBackColor = false;
            this.buttonSearchProgram.Click += new System.EventHandler(this.buttonSearchProgram_Click);
            // 
            // numericSonWidth
            // 
            this.numericSonWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.numericSonWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericSonWidth.ForeColor = System.Drawing.SystemColors.Window;
            this.numericSonWidth.Location = new System.Drawing.Point(55, 32);
            this.numericSonWidth.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericSonWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericSonWidth.Name = "numericSonWidth";
            this.numericSonWidth.Size = new System.Drawing.Size(120, 20);
            this.numericSonWidth.TabIndex = 0;
            this.numericSonWidth.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericSonWidth.ValueChanged += new System.EventHandler(this.numericSonWidth_ValueChanged);
            // 
            // numericSonHeight
            // 
            this.numericSonHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.numericSonHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericSonHeight.ForeColor = System.Drawing.SystemColors.Window;
            this.numericSonHeight.Location = new System.Drawing.Point(55, 59);
            this.numericSonHeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericSonHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericSonHeight.Name = "numericSonHeight";
            this.numericSonHeight.Size = new System.Drawing.Size(120, 20);
            this.numericSonHeight.TabIndex = 1;
            this.numericSonHeight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericSonHeight.ValueChanged += new System.EventHandler(this.numericSonHeight_ValueChanged);
            // 
            // labelSonWidth
            // 
            this.labelSonWidth.AutoSize = true;
            this.labelSonWidth.Location = new System.Drawing.Point(8, 32);
            this.labelSonWidth.Name = "labelSonWidth";
            this.labelSonWidth.Size = new System.Drawing.Size(41, 13);
            this.labelSonWidth.TabIndex = 2;
            this.labelSonWidth.Text = "Ancho:";
            // 
            // labelSonHeight
            // 
            this.labelSonHeight.AutoSize = true;
            this.labelSonHeight.Location = new System.Drawing.Point(8, 59);
            this.labelSonHeight.Name = "labelSonHeight";
            this.labelSonHeight.Size = new System.Drawing.Size(28, 13);
            this.labelSonHeight.TabIndex = 3;
            this.labelSonHeight.Text = "Alto:";
            // 
            // groupBoxSon
            // 
            this.groupBoxSon.Controls.Add(this.labelSonHeight);
            this.groupBoxSon.Controls.Add(this.labelSonWidth);
            this.groupBoxSon.Controls.Add(this.numericSonHeight);
            this.groupBoxSon.Controls.Add(this.numericSonWidth);
            this.groupBoxSon.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBoxSon.Location = new System.Drawing.Point(533, 345);
            this.groupBoxSon.Name = "groupBoxSon";
            this.groupBoxSon.Size = new System.Drawing.Size(200, 100);
            this.groupBoxSon.TabIndex = 7;
            this.groupBoxSon.TabStop = false;
            this.groupBoxSon.Text = "Tamaño en pixeles (100-300)";
            // 
            // labelSonWarning
            // 
            this.labelSonWarning.AutoSize = true;
            this.labelSonWarning.ForeColor = System.Drawing.SystemColors.Window;
            this.labelSonWarning.Location = new System.Drawing.Point(739, 202);
            this.labelSonWarning.Name = "labelSonWarning";
            this.labelSonWarning.Size = new System.Drawing.Size(225, 13);
            this.labelSonWarning.TabIndex = 51;
            this.labelSonWarning.Text = "La caratula seleccionada no sera almacenada";
            // 
            // buttonCoverOnline
            // 
            this.buttonCoverOnline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonCoverOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCoverOnline.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonCoverOnline.Location = new System.Drawing.Point(341, 172);
            this.buttonCoverOnline.Name = "buttonCoverOnline";
            this.buttonCoverOnline.Size = new System.Drawing.Size(145, 23);
            this.buttonCoverOnline.TabIndex = 52;
            this.buttonCoverOnline.Text = "Buscar Caratula Online";
            this.buttonCoverOnline.UseVisualStyleBackColor = false;
            this.buttonCoverOnline.Click += new System.EventHandler(this.buttonCoverOnline_Click);
            // 
            // NewCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(1047, 561);
            this.Controls.Add(this.buttonCoverOnline);
            this.Controls.Add(this.labelSonWarning);
            this.Controls.Add(this.buttonSearchProgram);
            this.Controls.Add(this.textBoxDefaultCMD);
            this.Controls.Add(this.textBoxSonProgramPath);
            this.Controls.Add(this.labelContentCMD);
            this.Controls.Add(this.labelContentLauncher);
            this.Controls.Add(this.addResolution);
            this.Controls.Add(this.dataGridViewTags);
            this.Controls.Add(this.buttonDeleteTestCover);
            this.Controls.Add(this.buttonDeleteCover);
            this.Controls.Add(this.labelExecuteFile);
            this.Controls.Add(this.numericScanStart);
            this.Controls.Add(this.dataGridViewScanOpenExtension);
            this.Controls.Add(this.buttonSearchDir);
            this.Controls.Add(this.textBoxScanFolder);
            this.Controls.Add(this.checkBoxScanFolder);
            this.Controls.Add(this.BackgroundColorCheck);
            this.Controls.Add(this.buttonColorPickIMG);
            this.Controls.Add(this.buttonSearchSonCoverDefault);
            this.Controls.Add(this.buttonBackgroundColor);
            this.Controls.Add(this.buttonSearchCover);
            this.Controls.Add(this.groupBoxSonFormat);
            this.Controls.Add(this.groupBoxSon);
            this.Controls.Add(this.labelContentRes);
            this.Controls.Add(this.comboBoxSonResolution);
            this.Controls.Add(this.panelSonImageLimit);
            this.Controls.Add(this.checkBoxFavorite);
            this.Controls.Add(this.panelImageLimit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxImageFormat);
            this.Controls.Add(this.groupBoxCover);
            this.Controls.Add(this.labelResolutionCol);
            this.Controls.Add(this.comboBoxResolutionCol);
            this.Controls.Add(this.labelFather);
            this.Controls.Add(this.comboBoxFather);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewCollection";
            this.Text = "Nueva Coleccion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewCollection_FormClosed);
            this.groupBoxCover.ResumeLayout(false);
            this.groupBoxCover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericColHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColWidth)).EndInit();
            this.groupBoxImageFormat.ResumeLayout(false);
            this.groupBoxImageFormat.PerformLayout();
            this.panelImageLimit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverCollection)).EndInit();
            this.panelSonImageLimit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverSon)).EndInit();
            this.groupBoxSonFormat.ResumeLayout(false);
            this.groupBoxSonFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScanOpenExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScanStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSonWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSonHeight)).EndInit();
            this.groupBoxSon.ResumeLayout(false);
            this.groupBoxSon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ComboBox comboBoxFather;
        private System.Windows.Forms.Label labelFather;
        private System.Windows.Forms.ComboBox comboBoxResolutionCol;
        private System.Windows.Forms.Label labelResolutionCol;
        private System.Windows.Forms.GroupBox groupBoxCover;
        private System.Windows.Forms.GroupBox groupBoxImageFormat;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panelImageLimit;
        private System.Windows.Forms.PictureBox pictureBoxCoverCollection;
        private System.Windows.Forms.Label labelColHeight;
        private System.Windows.Forms.Label labelColWidth;
        private System.Windows.Forms.NumericUpDown numericColHeight;
        private System.Windows.Forms.NumericUpDown numericColWidth;
        private System.Windows.Forms.RadioButton radioButtonColEstreched;
        private System.Windows.Forms.RadioButton radioButtonColZoom;
        private System.Windows.Forms.CheckBox checkBoxFavorite;
        private System.Windows.Forms.Panel panelSonImageLimit;
        private System.Windows.Forms.PictureBox pictureBoxCoverSon;
        private System.Windows.Forms.ComboBox comboBoxSonResolution;
        private System.Windows.Forms.Label labelContentRes;
        private System.Windows.Forms.GroupBox groupBoxSonFormat;
        private System.Windows.Forms.RadioButton radioButtonSonEstreched;
        private System.Windows.Forms.RadioButton radioButtonSonZoom;
        private System.Windows.Forms.Button buttonSearchCover;
        private System.Windows.Forms.Button buttonBackgroundColor;
        private System.Windows.Forms.Button buttonSearchSonCoverDefault;
        private System.Windows.Forms.Button buttonColorPickIMG;
        private System.Windows.Forms.CheckBox BackgroundColorCheck;
        private System.Windows.Forms.CheckBox checkBoxScanFolder;
        private System.Windows.Forms.TextBox textBoxScanFolder;
        private System.Windows.Forms.Button buttonSearchDir;
        private System.Windows.Forms.DataGridView dataGridViewScanOpenExtension;
        private System.Windows.Forms.NumericUpDown numericScanStart;
        private System.Windows.Forms.Label labelExecuteFile;
        private System.Windows.Forms.Button buttonDeleteCover;
        private System.Windows.Forms.Button buttonDeleteTestCover;
        private System.Windows.Forms.DataGridView dataGridViewTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.Button addResolution;
        private System.Windows.Forms.Label labelContentLauncher;
        private System.Windows.Forms.Label labelContentCMD;
        private System.Windows.Forms.TextBox textBoxSonProgramPath;
        private System.Windows.Forms.TextBox textBoxDefaultCMD;
        private System.Windows.Forms.Button buttonSearchProgram;
        private System.Windows.Forms.NumericUpDown numericSonWidth;
        private System.Windows.Forms.NumericUpDown numericSonHeight;
        private System.Windows.Forms.Label labelSonWidth;
        private System.Windows.Forms.Label labelSonHeight;
        private System.Windows.Forms.GroupBox groupBoxSon;
        private System.Windows.Forms.Label labelSonWarning;
        private System.Windows.Forms.Button buttonCoverOnline;
    }
}