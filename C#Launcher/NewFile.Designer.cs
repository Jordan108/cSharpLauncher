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
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonColorPickIMG = new System.Windows.Forms.Button();
            this.checkBoxImageLocation = new System.Windows.Forms.CheckBox();
            this.addResolution = new System.Windows.Forms.Button();
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
            this.textBoxName.Location = new System.Drawing.Point(213, 14);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(361, 26);
            this.textBoxName.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(60, 14);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(119, 20);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Nombre archivo";
            // 
            // comboBoxFather
            // 
            this.comboBoxFather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFather.FormattingEnabled = true;
            this.comboBoxFather.Location = new System.Drawing.Point(213, 54);
            this.comboBoxFather.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxFather.Name = "comboBoxFather";
            this.comboBoxFather.Size = new System.Drawing.Size(361, 28);
            this.comboBoxFather.TabIndex = 2;
            // 
            // labelFather
            // 
            this.labelFather.AutoSize = true;
            this.labelFather.Location = new System.Drawing.Point(74, 58);
            this.labelFather.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFather.Name = "labelFather";
            this.labelFather.Size = new System.Drawing.Size(105, 20);
            this.labelFather.TabIndex = 3;
            this.labelFather.Text = "Padre archivo";
            // 
            // checkBoxURL
            // 
            this.checkBoxURL.AutoSize = true;
            this.checkBoxURL.Location = new System.Drawing.Point(213, 126);
            this.checkBoxURL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxURL.Name = "checkBoxURL";
            this.checkBoxURL.Size = new System.Drawing.Size(370, 24);
            this.checkBoxURL.TabIndex = 4;
            this.checkBoxURL.Text = "Utilizar una URL en vez de una ruta del sistema";
            this.checkBoxURL.UseVisualStyleBackColor = true;
            this.checkBoxURL.CheckedChanged += new System.EventHandler(this.checkBoxURL_CheckedChanged);
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(68, 158);
            this.labelFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(123, 20);
            this.labelFilePath.TabIndex = 5;
            this.labelFilePath.Text = "Ruta del archivo";
            // 
            // labelProgramPath
            // 
            this.labelProgramPath.AutoSize = true;
            this.labelProgramPath.Location = new System.Drawing.Point(60, 218);
            this.labelProgramPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProgramPath.Name = "labelProgramPath";
            this.labelProgramPath.Size = new System.Drawing.Size(134, 20);
            this.labelProgramPath.TabIndex = 6;
            this.labelProgramPath.Text = "Ruta del lanzador";
            // 
            // labelCMD
            // 
            this.labelCMD.AutoSize = true;
            this.labelCMD.Location = new System.Drawing.Point(33, 258);
            this.labelCMD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCMD.Name = "labelCMD";
            this.labelCMD.Size = new System.Drawing.Size(157, 20);
            this.labelCMD.TabIndex = 7;
            this.labelCMD.Text = "Argumentos de inicio";
            // 
            // labelOptional
            // 
            this.labelOptional.AutoSize = true;
            this.labelOptional.Location = new System.Drawing.Point(372, 189);
            this.labelOptional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOptional.Name = "labelOptional";
            this.labelOptional.Size = new System.Drawing.Size(71, 20);
            this.labelOptional.TabIndex = 8;
            this.labelOptional.Text = "Opcional";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(200, 154);
            this.textBoxFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(428, 26);
            this.textBoxFilePath.TabIndex = 9;
            // 
            // textBoxProgramPath
            // 
            this.textBoxProgramPath.Location = new System.Drawing.Point(200, 214);
            this.textBoxProgramPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxProgramPath.Name = "textBoxProgramPath";
            this.textBoxProgramPath.Size = new System.Drawing.Size(428, 26);
            this.textBoxProgramPath.TabIndex = 10;
            // 
            // textBoxCMD
            // 
            this.textBoxCMD.Location = new System.Drawing.Point(200, 254);
            this.textBoxCMD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCMD.Name = "textBoxCMD";
            this.textBoxCMD.Size = new System.Drawing.Size(428, 26);
            this.textBoxCMD.TabIndex = 11;
            // 
            // checkBoxFavorite
            // 
            this.checkBoxFavorite.AutoSize = true;
            this.checkBoxFavorite.Location = new System.Drawing.Point(603, 18);
            this.checkBoxFavorite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxFavorite.Name = "checkBoxFavorite";
            this.checkBoxFavorite.Size = new System.Drawing.Size(92, 24);
            this.checkBoxFavorite.TabIndex = 12;
            this.checkBoxFavorite.Text = "Favorito";
            this.checkBoxFavorite.UseVisualStyleBackColor = true;
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCover.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCover.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(300, 308);
            this.pictureBoxCover.TabIndex = 13;
            this.pictureBoxCover.TabStop = false;
            this.pictureBoxCover.MouseLeave += new System.EventHandler(this.pictureBoxCover_MouseLeave);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(9, 42);
            this.labelWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(55, 20);
            this.labelWidth.TabIndex = 14;
            this.labelWidth.Text = "Ancho";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(9, 100);
            this.labelHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(37, 20);
            this.labelHeight.TabIndex = 15;
            this.labelHeight.Text = "Alto";
            // 
            // groupBoxImageFormat
            // 
            this.groupBoxImageFormat.Controls.Add(this.radioButtonEstreched);
            this.groupBoxImageFormat.Controls.Add(this.radioButtonZoom);
            this.groupBoxImageFormat.Location = new System.Drawing.Point(78, 680);
            this.groupBoxImageFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxImageFormat.Name = "groupBoxImageFormat";
            this.groupBoxImageFormat.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxImageFormat.Size = new System.Drawing.Size(243, 109);
            this.groupBoxImageFormat.TabIndex = 16;
            this.groupBoxImageFormat.TabStop = false;
            this.groupBoxImageFormat.Text = "Formato de la imagen";
            // 
            // radioButtonEstreched
            // 
            this.radioButtonEstreched.AutoSize = true;
            this.radioButtonEstreched.Location = new System.Drawing.Point(9, 65);
            this.radioButtonEstreched.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonEstreched.Name = "radioButtonEstreched";
            this.radioButtonEstreched.Size = new System.Drawing.Size(80, 24);
            this.radioButtonEstreched.TabIndex = 1;
            this.radioButtonEstreched.Text = "Estirar";
            this.radioButtonEstreched.UseVisualStyleBackColor = true;
            this.radioButtonEstreched.CheckedChanged += new System.EventHandler(this.radioButtonEstreched_CheckedChanged);
            // 
            // radioButtonZoom
            // 
            this.radioButtonZoom.AutoSize = true;
            this.radioButtonZoom.Checked = true;
            this.radioButtonZoom.Location = new System.Drawing.Point(9, 29);
            this.radioButtonZoom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonZoom.Name = "radioButtonZoom";
            this.radioButtonZoom.Size = new System.Drawing.Size(152, 24);
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
            this.panelImageLimit.Location = new System.Drawing.Point(420, 392);
            this.panelImageLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelImageLimit.Name = "panelImageLimit";
            this.panelImageLimit.Size = new System.Drawing.Size(450, 462);
            this.panelImageLimit.TabIndex = 17;
            // 
            // numericWidthImage
            // 
            this.numericWidthImage.Location = new System.Drawing.Point(75, 38);
            this.numericWidthImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.numericWidthImage.Size = new System.Drawing.Size(180, 26);
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
            this.numericHeightImage.Location = new System.Drawing.Point(75, 89);
            this.numericHeightImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.numericHeightImage.Size = new System.Drawing.Size(180, 26);
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
            this.groupBoxSize.Location = new System.Drawing.Point(38, 489);
            this.groupBoxSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSize.Name = "groupBoxSize";
            this.groupBoxSize.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSize.Size = new System.Drawing.Size(342, 154);
            this.groupBoxSize.TabIndex = 21;
            this.groupBoxSize.TabStop = false;
            this.groupBoxSize.Text = "Tamaño en pixeles (100-300)";
            // 
            // buttonSearchFile
            // 
            this.buttonSearchFile.Location = new System.Drawing.Point(639, 151);
            this.buttonSearchFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSearchFile.Name = "buttonSearchFile";
            this.buttonSearchFile.Size = new System.Drawing.Size(112, 35);
            this.buttonSearchFile.TabIndex = 22;
            this.buttonSearchFile.Text = "Examinar...";
            this.buttonSearchFile.UseVisualStyleBackColor = true;
            this.buttonSearchFile.Click += new System.EventHandler(this.buttonSearchFile_Click);
            // 
            // buttonSearchProgram
            // 
            this.buttonSearchProgram.Location = new System.Drawing.Point(639, 214);
            this.buttonSearchProgram.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSearchProgram.Name = "buttonSearchProgram";
            this.buttonSearchProgram.Size = new System.Drawing.Size(112, 35);
            this.buttonSearchProgram.TabIndex = 23;
            this.buttonSearchProgram.Text = "Examinar...";
            this.buttonSearchProgram.UseVisualStyleBackColor = true;
            this.buttonSearchProgram.Click += new System.EventHandler(this.buttonSearchProgram_Click);
            // 
            // buttonSearchCover
            // 
            this.buttonSearchCover.Location = new System.Drawing.Point(420, 312);
            this.buttonSearchCover.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSearchCover.Name = "buttonSearchCover";
            this.buttonSearchCover.Size = new System.Drawing.Size(172, 35);
            this.buttonSearchCover.TabIndex = 24;
            this.buttonSearchCover.Text = "Seleccionar Caratula";
            this.buttonSearchCover.UseVisualStyleBackColor = true;
            this.buttonSearchCover.Click += new System.EventHandler(this.buttonSearchCover_Click);
            // 
            // buttonSetColor
            // 
            this.buttonSetColor.Location = new System.Drawing.Point(603, 312);
            this.buttonSetColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSetColor.Name = "buttonSetColor";
            this.buttonSetColor.Size = new System.Drawing.Size(178, 35);
            this.buttonSetColor.TabIndex = 25;
            this.buttonSetColor.Text = " Color de fondo";
            this.buttonSetColor.UseVisualStyleBackColor = true;
            this.buttonSetColor.Click += new System.EventHandler(this.buttonSetColor_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(130, 798);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 35);
            this.buttonSave.TabIndex = 26;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Location = new System.Drawing.Point(13, 417);
            this.comboBoxResolution.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(319, 28);
            this.comboBoxResolution.TabIndex = 27;
            this.comboBoxResolution.SelectedIndexChanged += new System.EventHandler(this.comboBoxResolution_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 392);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Resolucion";
            // 
            // buttonColorPickIMG
            // 
            this.buttonColorPickIMG.BackColor = System.Drawing.Color.Black;
            this.buttonColorPickIMG.Location = new System.Drawing.Point(790, 312);
            this.buttonColorPickIMG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonColorPickIMG.Name = "buttonColorPickIMG";
            this.buttonColorPickIMG.Size = new System.Drawing.Size(38, 38);
            this.buttonColorPickIMG.TabIndex = 29;
            this.buttonColorPickIMG.UseVisualStyleBackColor = false;
            // 
            // checkBoxImageLocation
            // 
            this.checkBoxImageLocation.AutoSize = true;
            this.checkBoxImageLocation.Location = new System.Drawing.Point(420, 357);
            this.checkBoxImageLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxImageLocation.Name = "checkBoxImageLocation";
            this.checkBoxImageLocation.Size = new System.Drawing.Size(316, 24);
            this.checkBoxImageLocation.TabIndex = 30;
            this.checkBoxImageLocation.Text = "Utilizar la imagen en su ubicacion actual";
            this.checkBoxImageLocation.UseVisualStyleBackColor = true;
            // 
            // addResolution
            // 
            this.addResolution.Location = new System.Drawing.Point(339, 417);
            this.addResolution.Name = "addResolution";
            this.addResolution.Size = new System.Drawing.Size(75, 28);
            this.addResolution.TabIndex = 31;
            this.addResolution.Text = "Añadir";
            this.addResolution.UseVisualStyleBackColor = true;
            this.addResolution.Click += new System.EventHandler(this.addResolution_Click);
            // 
            // NewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(882, 872);
            this.Controls.Add(this.addResolution);
            this.Controls.Add(this.checkBoxImageLocation);
            this.Controls.Add(this.buttonColorPickIMG);
            this.Controls.Add(this.label1);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonColorPickIMG;
        private System.Windows.Forms.CheckBox checkBoxImageLocation;
        private System.Windows.Forms.Button addResolution;
    }
}