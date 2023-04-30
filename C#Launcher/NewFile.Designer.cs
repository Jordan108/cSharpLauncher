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
            this.buttonSearchProgram = new System.Windows.Forms.Button();
            this.buttonSearchCover = new System.Windows.Forms.Button();
            this.buttonSetColor = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonColorPickIMG = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.groupBoxImageFormat.SuspendLayout();
            this.panelImageLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightImage)).BeginInit();
            this.groupBoxSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(142, 32);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(242, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(42, 35);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(82, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Nombre archivo";
            // 
            // comboBoxFather
            // 
            this.comboBoxFather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFather.FormattingEnabled = true;
            this.comboBoxFather.Location = new System.Drawing.Point(142, 58);
            this.comboBoxFather.Name = "comboBoxFather";
            this.comboBoxFather.Size = new System.Drawing.Size(242, 21);
            this.comboBoxFather.TabIndex = 2;
            // 
            // labelFather
            // 
            this.labelFather.AutoSize = true;
            this.labelFather.Location = new System.Drawing.Point(51, 60);
            this.labelFather.Name = "labelFather";
            this.labelFather.Size = new System.Drawing.Size(73, 13);
            this.labelFather.TabIndex = 3;
            this.labelFather.Text = "Padre archivo";
            // 
            // checkBoxURL
            // 
            this.checkBoxURL.AutoSize = true;
            this.checkBoxURL.Location = new System.Drawing.Point(142, 138);
            this.checkBoxURL.Name = "checkBoxURL";
            this.checkBoxURL.Size = new System.Drawing.Size(250, 17);
            this.checkBoxURL.TabIndex = 4;
            this.checkBoxURL.Text = "Utilizar una URL en vez de una ruta del sistema";
            this.checkBoxURL.UseVisualStyleBackColor = true;
            this.checkBoxURL.CheckedChanged += new System.EventHandler(this.checkBoxURL_CheckedChanged);
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(45, 163);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(85, 13);
            this.labelFilePath.TabIndex = 5;
            this.labelFilePath.Text = "Ruta del archivo";
            // 
            // labelProgramPath
            // 
            this.labelProgramPath.AutoSize = true;
            this.labelProgramPath.Location = new System.Drawing.Point(40, 208);
            this.labelProgramPath.Name = "labelProgramPath";
            this.labelProgramPath.Size = new System.Drawing.Size(90, 13);
            this.labelProgramPath.TabIndex = 6;
            this.labelProgramPath.Text = "Ruta del lanzador";
            // 
            // labelCMD
            // 
            this.labelCMD.AutoSize = true;
            this.labelCMD.Location = new System.Drawing.Point(25, 237);
            this.labelCMD.Name = "labelCMD";
            this.labelCMD.Size = new System.Drawing.Size(105, 13);
            this.labelCMD.TabIndex = 7;
            this.labelCMD.Text = "Argumentos de inicio";
            // 
            // labelOptional
            // 
            this.labelOptional.AutoSize = true;
            this.labelOptional.Location = new System.Drawing.Point(256, 192);
            this.labelOptional.Name = "labelOptional";
            this.labelOptional.Size = new System.Drawing.Size(49, 13);
            this.labelOptional.TabIndex = 8;
            this.labelOptional.Text = "Opcional";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(133, 161);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(287, 20);
            this.textBoxFilePath.TabIndex = 9;
            // 
            // textBoxProgramPath
            // 
            this.textBoxProgramPath.Location = new System.Drawing.Point(133, 208);
            this.textBoxProgramPath.Name = "textBoxProgramPath";
            this.textBoxProgramPath.Size = new System.Drawing.Size(287, 20);
            this.textBoxProgramPath.TabIndex = 10;
            // 
            // textBoxCMD
            // 
            this.textBoxCMD.Location = new System.Drawing.Point(133, 234);
            this.textBoxCMD.Name = "textBoxCMD";
            this.textBoxCMD.Size = new System.Drawing.Size(287, 20);
            this.textBoxCMD.TabIndex = 11;
            // 
            // checkBoxFavorite
            // 
            this.checkBoxFavorite.AutoSize = true;
            this.checkBoxFavorite.Location = new System.Drawing.Point(404, 32);
            this.checkBoxFavorite.Name = "checkBoxFavorite";
            this.checkBoxFavorite.Size = new System.Drawing.Size(64, 17);
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
            this.pictureBoxCover.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxCover.TabIndex = 13;
            this.pictureBoxCover.TabStop = false;
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
            this.groupBoxImageFormat.Location = new System.Drawing.Point(28, 530);
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
            this.panelImageLimit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelImageLimit.Controls.Add(this.pictureBoxCover);
            this.panelImageLimit.Location = new System.Drawing.Point(280, 344);
            this.panelImageLimit.Name = "panelImageLimit";
            this.panelImageLimit.Size = new System.Drawing.Size(300, 300);
            this.panelImageLimit.TabIndex = 17;
            // 
            // numericWidthImage
            // 
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
            100,
            0,
            0,
            0});
            this.numericWidthImage.ValueChanged += new System.EventHandler(this.numericWidthImage_ValueChanged);
            // 
            // numericHeightImage
            // 
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
            100,
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
            this.groupBoxSize.Location = new System.Drawing.Point(28, 402);
            this.groupBoxSize.Name = "groupBoxSize";
            this.groupBoxSize.Size = new System.Drawing.Size(228, 100);
            this.groupBoxSize.TabIndex = 21;
            this.groupBoxSize.TabStop = false;
            this.groupBoxSize.Text = "Tamaño en pixeles (100-300)";
            // 
            // buttonSearchFile
            // 
            this.buttonSearchFile.Location = new System.Drawing.Point(426, 158);
            this.buttonSearchFile.Name = "buttonSearchFile";
            this.buttonSearchFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchFile.TabIndex = 22;
            this.buttonSearchFile.Text = "Examinar...";
            this.buttonSearchFile.UseVisualStyleBackColor = true;
            this.buttonSearchFile.Click += new System.EventHandler(this.buttonSearchFile_Click);
            // 
            // buttonSearchProgram
            // 
            this.buttonSearchProgram.Location = new System.Drawing.Point(426, 206);
            this.buttonSearchProgram.Name = "buttonSearchProgram";
            this.buttonSearchProgram.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchProgram.TabIndex = 23;
            this.buttonSearchProgram.Text = "Examinar...";
            this.buttonSearchProgram.UseVisualStyleBackColor = true;
            this.buttonSearchProgram.Click += new System.EventHandler(this.buttonSearchProgram_Click);
            // 
            // buttonSearchCover
            // 
            this.buttonSearchCover.Location = new System.Drawing.Point(305, 315);
            this.buttonSearchCover.Name = "buttonSearchCover";
            this.buttonSearchCover.Size = new System.Drawing.Size(115, 23);
            this.buttonSearchCover.TabIndex = 24;
            this.buttonSearchCover.Text = "Seleccionar Caratula";
            this.buttonSearchCover.UseVisualStyleBackColor = true;
            this.buttonSearchCover.Click += new System.EventHandler(this.buttonSearchCover_Click);
            // 
            // buttonSetColor
            // 
            this.buttonSetColor.Location = new System.Drawing.Point(439, 286);
            this.buttonSetColor.Name = "buttonSetColor";
            this.buttonSetColor.Size = new System.Drawing.Size(119, 23);
            this.buttonSetColor.TabIndex = 25;
            this.buttonSetColor.Text = " Color de fondo";
            this.buttonSetColor.UseVisualStyleBackColor = true;
            this.buttonSetColor.Click += new System.EventHandler(this.buttonSetColor_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(78, 621);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 26;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(28, 360);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(228, 21);
            this.comboBox1.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Resolucion";
            // 
            // buttonColorPickIMG
            // 
            this.buttonColorPickIMG.Location = new System.Drawing.Point(519, 315);
            this.buttonColorPickIMG.Name = "buttonColorPickIMG";
            this.buttonColorPickIMG.Size = new System.Drawing.Size(39, 23);
            this.buttonColorPickIMG.TabIndex = 29;
            this.buttonColorPickIMG.UseVisualStyleBackColor = true;
            // 
            // NewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(592, 691);
            this.Controls.Add(this.buttonColorPickIMG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
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
            this.Name = "NewFile";
            this.Text = "NewFile";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.groupBoxImageFormat.ResumeLayout(false);
            this.groupBoxImageFormat.PerformLayout();
            this.panelImageLimit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightImage)).EndInit();
            this.groupBoxSize.ResumeLayout(false);
            this.groupBoxSize.PerformLayout();
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
        private System.Windows.Forms.Button buttonSearchProgram;
        private System.Windows.Forms.Button buttonSearchCover;
        private System.Windows.Forms.Button buttonSetColor;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonColorPickIMG;
    }
}