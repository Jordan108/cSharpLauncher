namespace C_Launcher
{
    partial class NewFile
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.comboBoxFather = new System.Windows.Forms.ComboBox();
            this.labelFather = new System.Windows.Forms.Label();
            this.checkBoxURL = new System.Windows.Forms.CheckBox();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.labelProgramPath = new System.Windows.Forms.Label();
            this.labelCMD = new System.Windows.Forms.Label();
            this.labelOptional = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.textBoxProgramPath = new System.Windows.Forms.TextBox();
            this.textBoxCMD = new System.Windows.Forms.TextBox();
            this.checkBoxFavorite = new System.Windows.Forms.CheckBox();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.groupBoxImageFormat = new System.Windows.Forms.GroupBox();
            this.radioButtonEstreched = new System.Windows.Forms.RadioButton();
            this.radioButtonZoom = new System.Windows.Forms.RadioButton();
            this.panelImageLimit = new System.Windows.Forms.Panel();
            this.numericWidthImage = new System.Windows.Forms.NumericUpDown();
            this.numericHeightImage = new System.Windows.Forms.NumericUpDown();
            this.groupBoxSize = new System.Windows.Forms.GroupBox();
            this.buttonSearchFile = new System.Windows.Forms.Button();
            this.buttonSearchCover = new System.Windows.Forms.Button();
            this.buttonSetColor = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.labelResolution = new System.Windows.Forms.Label();
            this.buttonColorPickIMG = new System.Windows.Forms.Button();
            this.addResolution = new System.Windows.Forms.Button();
            this.BackgroundColorCheck = new System.Windows.Forms.CheckBox();
            this.buttonSearchProgram = new System.Windows.Forms.Button();
            this.buttonEraseCover = new System.Windows.Forms.Button();
            this.dataGridViewTags = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCoverOnline = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.groupBoxImageFormat.SuspendLayout();
            this.panelImageLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightImage)).BeginInit();
            this.groupBoxSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTags)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxName.Location = new System.Drawing.Point(142, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(242, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.ForeColor = System.Drawing.SystemColors.Window;
            this.labelName.Location = new System.Drawing.Point(40, 11);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(90, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Nombre elemento";
            // 
            // comboBoxFather
            // 
            this.comboBoxFather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.comboBoxFather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFather.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxFather.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxFather.FormattingEnabled = true;
            this.comboBoxFather.Location = new System.Drawing.Point(142, 35);
            this.comboBoxFather.Name = "comboBoxFather";
            this.comboBoxFather.Size = new System.Drawing.Size(242, 21);
            this.comboBoxFather.TabIndex = 2;
            // 
            // labelFather
            // 
            this.labelFather.AutoSize = true;
            this.labelFather.ForeColor = System.Drawing.SystemColors.Window;
            this.labelFather.Location = new System.Drawing.Point(32, 38);
            this.labelFather.Name = "labelFather";
            this.labelFather.Size = new System.Drawing.Size(98, 13);
            this.labelFather.TabIndex = 3;
            this.labelFather.Text = "Padre del elemento";
            // 
            // checkBoxURL
            // 
            this.checkBoxURL.AutoSize = true;
            this.checkBoxURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxURL.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBoxURL.Location = new System.Drawing.Point(142, 82);
            this.checkBoxURL.Name = "checkBoxURL";
            this.checkBoxURL.Size = new System.Drawing.Size(247, 17);
            this.checkBoxURL.TabIndex = 4;
            this.checkBoxURL.Text = "Utilizar una URL en vez de una ruta del sistema";
            this.checkBoxURL.UseVisualStyleBackColor = true;
            this.checkBoxURL.CheckedChanged += new System.EventHandler(this.checkBoxURL_CheckedChanged);
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.ForeColor = System.Drawing.SystemColors.Window;
            this.labelFilePath.Location = new System.Drawing.Point(45, 103);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(85, 13);
            this.labelFilePath.TabIndex = 5;
            this.labelFilePath.Text = "Ruta del archivo";
            // 
            // labelProgramPath
            // 
            this.labelProgramPath.AutoSize = true;
            this.labelProgramPath.ForeColor = System.Drawing.SystemColors.Window;
            this.labelProgramPath.Location = new System.Drawing.Point(40, 142);
            this.labelProgramPath.Name = "labelProgramPath";
            this.labelProgramPath.Size = new System.Drawing.Size(90, 13);
            this.labelProgramPath.TabIndex = 6;
            this.labelProgramPath.Text = "Ruta del lanzador";
            // 
            // labelCMD
            // 
            this.labelCMD.AutoSize = true;
            this.labelCMD.ForeColor = System.Drawing.SystemColors.Window;
            this.labelCMD.Location = new System.Drawing.Point(3, 167);
            this.labelCMD.Name = "labelCMD";
            this.labelCMD.Size = new System.Drawing.Size(134, 13);
            this.labelCMD.TabIndex = 7;
            this.labelCMD.Text = "Parametros de lanzamiento";
            // 
            // labelOptional
            // 
            this.labelOptional.AutoSize = true;
            this.labelOptional.ForeColor = System.Drawing.SystemColors.Window;
            this.labelOptional.Location = new System.Drawing.Point(248, 123);
            this.labelOptional.Name = "labelOptional";
            this.labelOptional.Size = new System.Drawing.Size(49, 13);
            this.labelOptional.TabIndex = 8;
            this.labelOptional.Text = "Opcional";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFilePath.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxFilePath.Location = new System.Drawing.Point(142, 100);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(287, 20);
            this.textBoxFilePath.TabIndex = 9;
            // 
            // textBoxProgramPath
            // 
            this.textBoxProgramPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxProgramPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProgramPath.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxProgramPath.Location = new System.Drawing.Point(142, 140);
            this.textBoxProgramPath.Name = "textBoxProgramPath";
            this.textBoxProgramPath.Size = new System.Drawing.Size(287, 20);
            this.textBoxProgramPath.TabIndex = 10;
            // 
            // textBoxCMD
            // 
            this.textBoxCMD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxCMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCMD.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxCMD.Location = new System.Drawing.Point(142, 165);
            this.textBoxCMD.Name = "textBoxCMD";
            this.textBoxCMD.Size = new System.Drawing.Size(287, 20);
            this.textBoxCMD.TabIndex = 11;
            // 
            // checkBoxFavorite
            // 
            this.checkBoxFavorite.AutoSize = true;
            this.checkBoxFavorite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBoxFavorite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxFavorite.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBoxFavorite.Location = new System.Drawing.Point(402, 12);
            this.checkBoxFavorite.Name = "checkBoxFavorite";
            this.checkBoxFavorite.Size = new System.Drawing.Size(61, 17);
            this.checkBoxFavorite.TabIndex = 12;
            this.checkBoxFavorite.Text = "Favorito";
            this.checkBoxFavorite.UseVisualStyleBackColor = true;
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCover.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxCover.TabIndex = 13;
            this.pictureBoxCover.TabStop = false;
            this.pictureBoxCover.MouseLeave += new System.EventHandler(this.pictureBoxCover_MouseLeave);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(6, 27);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(38, 13);
            this.labelWidth.TabIndex = 14;
            this.labelWidth.Text = "Ancho";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(6, 65);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(25, 13);
            this.labelHeight.TabIndex = 15;
            this.labelHeight.Text = "Alto";
            // 
            // groupBoxImageFormat
            // 
            this.groupBoxImageFormat.Controls.Add(this.radioButtonEstreched);
            this.groupBoxImageFormat.Controls.Add(this.radioButtonZoom);
            this.groupBoxImageFormat.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBoxImageFormat.Location = new System.Drawing.Point(52, 447);
            this.groupBoxImageFormat.Name = "groupBoxImageFormat";
            this.groupBoxImageFormat.Size = new System.Drawing.Size(162, 71);
            this.groupBoxImageFormat.TabIndex = 16;
            this.groupBoxImageFormat.TabStop = false;
            this.groupBoxImageFormat.Text = "Formato de la imagen";
            // 
            // radioButtonEstreched
            // 
            this.radioButtonEstreched.AutoSize = true;
            this.radioButtonEstreched.Location = new System.Drawing.Point(6, 42);
            this.radioButtonEstreched.Name = "radioButtonEstreched";
            this.radioButtonEstreched.Size = new System.Drawing.Size(54, 17);
            this.radioButtonEstreched.TabIndex = 1;
            this.radioButtonEstreched.Text = "Estirar";
            this.radioButtonEstreched.UseVisualStyleBackColor = true;
            this.radioButtonEstreched.CheckedChanged += new System.EventHandler(this.radioButtonEstreched_CheckedChanged);
            // 
            // radioButtonZoom
            // 
            this.radioButtonZoom.AutoSize = true;
            this.radioButtonZoom.Checked = true;
            this.radioButtonZoom.Location = new System.Drawing.Point(6, 19);
            this.radioButtonZoom.Name = "radioButtonZoom";
            this.radioButtonZoom.Size = new System.Drawing.Size(104, 17);
            this.radioButtonZoom.TabIndex = 0;
            this.radioButtonZoom.TabStop = true;
            this.radioButtonZoom.Text = "Mantener escala";
            this.radioButtonZoom.UseVisualStyleBackColor = true;
            this.radioButtonZoom.CheckedChanged += new System.EventHandler(this.radioButtonZoom_CheckedChanged);
            // 
            // panelImageLimit
            // 
            this.panelImageLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.panelImageLimit.Controls.Add(this.pictureBoxCover);
            this.panelImageLimit.Location = new System.Drawing.Point(280, 280);
            this.panelImageLimit.Name = "panelImageLimit";
            this.panelImageLimit.Size = new System.Drawing.Size(300, 300);
            this.panelImageLimit.TabIndex = 17;
            // 
            // numericWidthImage
            // 
            this.numericWidthImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.numericWidthImage.ForeColor = System.Drawing.SystemColors.Window;
            this.numericWidthImage.Location = new System.Drawing.Point(50, 25);
            this.numericWidthImage.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericWidthImage.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericWidthImage.Name = "numericWidthImage";
            this.numericWidthImage.Size = new System.Drawing.Size(120, 20);
            this.numericWidthImage.TabIndex = 19;
            this.numericWidthImage.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericWidthImage.ValueChanged += new System.EventHandler(this.numericWidthImage_ValueChanged);
            // 
            // numericHeightImage
            // 
            this.numericHeightImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.numericHeightImage.ForeColor = System.Drawing.SystemColors.Window;
            this.numericHeightImage.Location = new System.Drawing.Point(50, 58);
            this.numericHeightImage.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericHeightImage.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericHeightImage.Name = "numericHeightImage";
            this.numericHeightImage.Size = new System.Drawing.Size(120, 20);
            this.numericHeightImage.TabIndex = 20;
            this.numericHeightImage.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericHeightImage.ValueChanged += new System.EventHandler(this.numericHeightImage_ValueChanged);
            // 
            // groupBoxSize
            // 
            this.groupBoxSize.Controls.Add(this.labelWidth);
            this.groupBoxSize.Controls.Add(this.numericHeightImage);
            this.groupBoxSize.Controls.Add(this.numericWidthImage);
            this.groupBoxSize.Controls.Add(this.labelHeight);
            this.groupBoxSize.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBoxSize.Location = new System.Drawing.Point(25, 324);
            this.groupBoxSize.Name = "groupBoxSize";
            this.groupBoxSize.Size = new System.Drawing.Size(228, 100);
            this.groupBoxSize.TabIndex = 21;
            this.groupBoxSize.TabStop = false;
            this.groupBoxSize.Text = "Tamaño en pixeles (100-300)";
            // 
            // buttonSearchFile
            // 
            this.buttonSearchFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSearchFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchFile.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSearchFile.Location = new System.Drawing.Point(435, 98);
            this.buttonSearchFile.Name = "buttonSearchFile";
            this.buttonSearchFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchFile.TabIndex = 22;
            this.buttonSearchFile.Text = "Examinar...";
            this.buttonSearchFile.UseVisualStyleBackColor = false;
            this.buttonSearchFile.Click += new System.EventHandler(this.buttonSearchFile_Click);
            // 
            // buttonSearchCover
            // 
            this.buttonSearchCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSearchCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchCover.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSearchCover.Location = new System.Drawing.Point(281, 228);
            this.buttonSearchCover.Name = "buttonSearchCover";
            this.buttonSearchCover.Size = new System.Drawing.Size(115, 23);
            this.buttonSearchCover.TabIndex = 24;
            this.buttonSearchCover.Text = "Seleccionar Caratula";
            this.buttonSearchCover.UseVisualStyleBackColor = false;
            this.buttonSearchCover.Click += new System.EventHandler(this.buttonSearchCover_Click);
            // 
            // buttonSetColor
            // 
            this.buttonSetColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSetColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetColor.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSetColor.Location = new System.Drawing.Point(400, 255);
            this.buttonSetColor.Name = "buttonSetColor";
            this.buttonSetColor.Size = new System.Drawing.Size(116, 23);
            this.buttonSetColor.TabIndex = 25;
            this.buttonSetColor.Text = " Color de fondo";
            this.buttonSetColor.UseVisualStyleBackColor = false;
            this.buttonSetColor.Click += new System.EventHandler(this.buttonSetColor_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSave.Location = new System.Drawing.Point(98, 554);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 26;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.comboBoxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxResolution.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Location = new System.Drawing.Point(6, 271);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(214, 21);
            this.comboBoxResolution.TabIndex = 27;
            this.comboBoxResolution.SelectedIndexChanged += new System.EventHandler(this.comboBoxResolution_SelectedIndexChanged);
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.ForeColor = System.Drawing.SystemColors.Window;
            this.labelResolution.Location = new System.Drawing.Point(84, 255);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(60, 13);
            this.labelResolution.TabIndex = 28;
            this.labelResolution.Text = "Resolucion";
            // 
            // buttonColorPickIMG
            // 
            this.buttonColorPickIMG.BackColor = System.Drawing.Color.Black;
            this.buttonColorPickIMG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColorPickIMG.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonColorPickIMG.Location = new System.Drawing.Point(522, 255);
            this.buttonColorPickIMG.Name = "buttonColorPickIMG";
            this.buttonColorPickIMG.Size = new System.Drawing.Size(23, 23);
            this.buttonColorPickIMG.TabIndex = 29;
            this.buttonColorPickIMG.UseVisualStyleBackColor = false;
            // 
            // addResolution
            // 
            this.addResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.addResolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addResolution.ForeColor = System.Drawing.SystemColors.Window;
            this.addResolution.Location = new System.Drawing.Point(226, 271);
            this.addResolution.Margin = new System.Windows.Forms.Padding(2);
            this.addResolution.Name = "addResolution";
            this.addResolution.Size = new System.Drawing.Size(50, 21);
            this.addResolution.TabIndex = 31;
            this.addResolution.Text = "Añadir";
            this.addResolution.UseVisualStyleBackColor = false;
            this.addResolution.Click += new System.EventHandler(this.addResolution_Click);
            // 
            // BackgroundColorCheck
            // 
            this.BackgroundColorCheck.AutoSize = true;
            this.BackgroundColorCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.BackgroundColorCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackgroundColorCheck.ForeColor = System.Drawing.SystemColors.Window;
            this.BackgroundColorCheck.Location = new System.Drawing.Point(549, 258);
            this.BackgroundColorCheck.Name = "BackgroundColorCheck";
            this.BackgroundColorCheck.Size = new System.Drawing.Size(115, 17);
            this.BackgroundColorCheck.TabIndex = 32;
            this.BackgroundColorCheck.Text = "Fondo transparente";
            this.BackgroundColorCheck.UseVisualStyleBackColor = false;
            // 
            // buttonSearchProgram
            // 
            this.buttonSearchProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSearchProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchProgram.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSearchProgram.Location = new System.Drawing.Point(435, 140);
            this.buttonSearchProgram.Name = "buttonSearchProgram";
            this.buttonSearchProgram.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchProgram.TabIndex = 23;
            this.buttonSearchProgram.Text = "Examinar...";
            this.buttonSearchProgram.UseVisualStyleBackColor = false;
            this.buttonSearchProgram.Click += new System.EventHandler(this.buttonSearchProgram_Click);
            // 
            // buttonEraseCover
            // 
            this.buttonEraseCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonEraseCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEraseCover.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonEraseCover.Location = new System.Drawing.Point(281, 255);
            this.buttonEraseCover.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEraseCover.Name = "buttonEraseCover";
            this.buttonEraseCover.Size = new System.Drawing.Size(114, 23);
            this.buttonEraseCover.TabIndex = 44;
            this.buttonEraseCover.Text = "Borrar caratula";
            this.buttonEraseCover.UseVisualStyleBackColor = false;
            this.buttonEraseCover.Click += new System.EventHandler(this.buttonEraseCover_Click);
            // 
            // dataGridViewTags
            // 
            this.dataGridViewTags.AllowUserToAddRows = false;
            this.dataGridViewTags.AllowUserToDeleteRows = false;
            this.dataGridViewTags.AllowUserToResizeColumns = false;
            this.dataGridViewTags.AllowUserToResizeRows = false;
            this.dataGridViewTags.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.dataGridViewTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1});
            this.dataGridViewTags.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.dataGridViewTags.Location = new System.Drawing.Point(598, 13);
            this.dataGridViewTags.MultiSelect = false;
            this.dataGridViewTags.Name = "dataGridViewTags";
            this.dataGridViewTags.RowHeadersVisible = false;
            this.dataGridViewTags.Size = new System.Drawing.Size(203, 238);
            this.dataGridViewTags.TabIndex = 45;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Añadir";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Etiqueta";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // buttonCoverOnline
            // 
            this.buttonCoverOnline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonCoverOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCoverOnline.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonCoverOnline.Location = new System.Drawing.Point(400, 228);
            this.buttonCoverOnline.Name = "buttonCoverOnline";
            this.buttonCoverOnline.Size = new System.Drawing.Size(145, 23);
            this.buttonCoverOnline.TabIndex = 46;
            this.buttonCoverOnline.Text = "Buscar Caratula Online";
            this.buttonCoverOnline.UseVisualStyleBackColor = false;
            this.buttonCoverOnline.Click += new System.EventHandler(this.buttonCoverOnline_Click);
            // 
            // NewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(815, 587);
            this.Controls.Add(this.buttonCoverOnline);
            this.Controls.Add(this.dataGridViewTags);
            this.Controls.Add(this.buttonEraseCover);
            this.Controls.Add(this.BackgroundColorCheck);
            this.Controls.Add(this.addResolution);
            this.Controls.Add(this.buttonColorPickIMG);
            this.Controls.Add(this.labelResolution);
            this.Controls.Add(this.comboBoxResolution);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonSetColor);
            this.Controls.Add(this.buttonSearchCover);
            this.Controls.Add(this.buttonSearchProgram);
            this.Controls.Add(this.buttonSearchFile);
            this.Controls.Add(this.groupBoxSize);
            this.Controls.Add(this.panelImageLimit);
            this.Controls.Add(this.groupBoxImageFormat);
            this.Controls.Add(this.checkBoxFavorite);
            this.Controls.Add(this.textBoxCMD);
            this.Controls.Add(this.textBoxProgramPath);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.labelOptional);
            this.Controls.Add(this.labelCMD);
            this.Controls.Add(this.labelProgramPath);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.checkBoxURL);
            this.Controls.Add(this.labelFather);
            this.Controls.Add(this.comboBoxFather);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewFile";
            this.Text = "Nuevo Elemento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewFile_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.groupBoxImageFormat.ResumeLayout(false);
            this.groupBoxImageFormat.PerformLayout();
            this.panelImageLimit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightImage)).EndInit();
            this.groupBoxSize.ResumeLayout(false);
            this.groupBoxSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ComboBox comboBoxFather;
        private System.Windows.Forms.Label labelFather;
        private System.Windows.Forms.CheckBox checkBoxURL;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Label labelProgramPath;
        private System.Windows.Forms.Label labelCMD;
        private System.Windows.Forms.Label labelOptional;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.TextBox textBoxProgramPath;
        private System.Windows.Forms.TextBox textBoxCMD;
        private System.Windows.Forms.CheckBox checkBoxFavorite;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.GroupBox groupBoxImageFormat;
        private System.Windows.Forms.RadioButton radioButtonEstreched;
        private System.Windows.Forms.RadioButton radioButtonZoom;
        private System.Windows.Forms.Panel panelImageLimit;
        private System.Windows.Forms.NumericUpDown numericWidthImage;
        private System.Windows.Forms.NumericUpDown numericHeightImage;
        private System.Windows.Forms.GroupBox groupBoxSize;
        private System.Windows.Forms.Button buttonSearchFile;
        private System.Windows.Forms.Button buttonSearchCover;
        private System.Windows.Forms.Button buttonSetColor;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.Button buttonColorPickIMG;
        private System.Windows.Forms.Button addResolution;
        private System.Windows.Forms.CheckBox BackgroundColorCheck;
        private System.Windows.Forms.Button buttonSearchProgram;
        private System.Windows.Forms.Button buttonEraseCover;
        private System.Windows.Forms.DataGridView dataGridViewTags;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button buttonCoverOnline;
    }
}