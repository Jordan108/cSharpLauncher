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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSon = new System.Windows.Forms.GroupBox();
            this.labelSonHeight = new System.Windows.Forms.Label();
            this.labelSonWidth = new System.Windows.Forms.Label();
            this.numericSonHeight = new System.Windows.Forms.NumericUpDown();
            this.numericSonWidth = new System.Windows.Forms.NumericUpDown();
            this.groupBoxSonFormat = new System.Windows.Forms.GroupBox();
            this.radioButtonSonEstreched = new System.Windows.Forms.RadioButton();
            this.radioButtonSonZoom = new System.Windows.Forms.RadioButton();
            this.buttonSearchCover = new System.Windows.Forms.Button();
            this.buttonBackgroundColor = new System.Windows.Forms.Button();
            this.buttonSearchSonCoverTest = new System.Windows.Forms.Button();
            this.buttonColorPickIMG = new System.Windows.Forms.Button();
            this.checkBoxImageLocation = new System.Windows.Forms.CheckBox();
            this.groupBoxCover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericColHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColWidth)).BeginInit();
            this.groupBoxImageFormat.SuspendLayout();
            this.panelImageLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverCollection)).BeginInit();
            this.panelSonImageLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverSon)).BeginInit();
            this.groupBoxSon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSonHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSonWidth)).BeginInit();
            this.groupBoxSonFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(145, 35);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(245, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(31, 38);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(96, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Nombre coleccion:";
            // 
            // comboBoxFather
            // 
            this.comboBoxFather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFather.FormattingEnabled = true;
            this.comboBoxFather.Location = new System.Drawing.Point(145, 62);
            this.comboBoxFather.Name = "comboBoxFather";
            this.comboBoxFather.Size = new System.Drawing.Size(245, 21);
            this.comboBoxFather.TabIndex = 2;
            // 
            // labelFather
            // 
            this.labelFather.AutoSize = true;
            this.labelFather.Location = new System.Drawing.Point(40, 65);
            this.labelFather.Name = "labelFather";
            this.labelFather.Size = new System.Drawing.Size(87, 13);
            this.labelFather.TabIndex = 3;
            this.labelFather.Text = "Padre coleccion:";
            // 
            // comboBoxResolutionCol
            // 
            this.comboBoxResolutionCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolutionCol.FormattingEnabled = true;
            this.comboBoxResolutionCol.Location = new System.Drawing.Point(12, 165);
            this.comboBoxResolutionCol.Name = "comboBoxResolutionCol";
            this.comboBoxResolutionCol.Size = new System.Drawing.Size(200, 21);
            this.comboBoxResolutionCol.TabIndex = 4;
            this.comboBoxResolutionCol.SelectedIndexChanged += new System.EventHandler(this.comboBoxResolutionCol_SelectedIndexChanged);
            // 
            // labelResolutionCol
            // 
            this.labelResolutionCol.AutoSize = true;
            this.labelResolutionCol.Location = new System.Drawing.Point(40, 149);
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
            this.groupBoxCover.Location = new System.Drawing.Point(12, 203);
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
            this.groupBoxImageFormat.Location = new System.Drawing.Point(12, 309);
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
            this.buttonSave.Location = new System.Drawing.Point(52, 448);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panelImageLimit
            // 
            this.panelImageLimit.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelImageLimit.Controls.Add(this.pictureBoxCoverCollection);
            this.panelImageLimit.Location = new System.Drawing.Point(218, 165);
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
            this.checkBoxFavorite.Location = new System.Drawing.Point(396, 34);
            this.checkBoxFavorite.Name = "checkBoxFavorite";
            this.checkBoxFavorite.Size = new System.Drawing.Size(64, 17);
            this.checkBoxFavorite.TabIndex = 10;
            this.checkBoxFavorite.Text = "Favorito";
            this.checkBoxFavorite.UseVisualStyleBackColor = true;
            // 
            // panelSonImageLimit
            // 
            this.panelSonImageLimit.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSonImageLimit.Controls.Add(this.pictureBoxCoverSon);
            this.panelSonImageLimit.Location = new System.Drawing.Point(739, 165);
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
            this.comboBoxSonResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSonResolution.FormattingEnabled = true;
            this.comboBoxSonResolution.Location = new System.Drawing.Point(533, 165);
            this.comboBoxSonResolution.Name = "comboBoxSonResolution";
            this.comboBoxSonResolution.Size = new System.Drawing.Size(200, 21);
            this.comboBoxSonResolution.TabIndex = 11;
            this.comboBoxSonResolution.SelectedIndexChanged += new System.EventHandler(this.comboBoxSonResolution_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(585, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Resolucion hijos";
            // 
            // groupBoxSon
            // 
            this.groupBoxSon.Controls.Add(this.labelSonHeight);
            this.groupBoxSon.Controls.Add(this.labelSonWidth);
            this.groupBoxSon.Controls.Add(this.numericSonHeight);
            this.groupBoxSon.Controls.Add(this.numericSonWidth);
            this.groupBoxSon.Location = new System.Drawing.Point(533, 192);
            this.groupBoxSon.Name = "groupBoxSon";
            this.groupBoxSon.Size = new System.Drawing.Size(200, 100);
            this.groupBoxSon.TabIndex = 7;
            this.groupBoxSon.TabStop = false;
            this.groupBoxSon.Text = "Tamaño en pixeles (100-300)";
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
            // labelSonWidth
            // 
            this.labelSonWidth.AutoSize = true;
            this.labelSonWidth.Location = new System.Drawing.Point(8, 32);
            this.labelSonWidth.Name = "labelSonWidth";
            this.labelSonWidth.Size = new System.Drawing.Size(41, 13);
            this.labelSonWidth.TabIndex = 2;
            this.labelSonWidth.Text = "Ancho:";
            // 
            // numericSonHeight
            // 
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
            // numericSonWidth
            // 
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
            // groupBoxSonFormat
            // 
            this.groupBoxSonFormat.Controls.Add(this.radioButtonSonEstreched);
            this.groupBoxSonFormat.Controls.Add(this.radioButtonSonZoom);
            this.groupBoxSonFormat.Location = new System.Drawing.Point(533, 309);
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
            this.buttonSearchCover.Location = new System.Drawing.Point(218, 109);
            this.buttonSearchCover.Name = "buttonSearchCover";
            this.buttonSearchCover.Size = new System.Drawing.Size(128, 23);
            this.buttonSearchCover.TabIndex = 13;
            this.buttonSearchCover.Text = "Seleccionar Caratula";
            this.buttonSearchCover.UseVisualStyleBackColor = true;
            this.buttonSearchCover.Click += new System.EventHandler(this.buttonSearchCover_Click);
            // 
            // buttonBackgroundColor
            // 
            this.buttonBackgroundColor.Location = new System.Drawing.Point(361, 109);
            this.buttonBackgroundColor.Name = "buttonBackgroundColor";
            this.buttonBackgroundColor.Size = new System.Drawing.Size(99, 23);
            this.buttonBackgroundColor.TabIndex = 14;
            this.buttonBackgroundColor.Text = "Color de fondo";
            this.buttonBackgroundColor.UseVisualStyleBackColor = true;
            this.buttonBackgroundColor.Click += new System.EventHandler(this.buttonBackgroundColor_Click);
            // 
            // buttonSearchSonCoverTest
            // 
            this.buttonSearchSonCoverTest.Location = new System.Drawing.Point(802, 136);
            this.buttonSearchSonCoverTest.Name = "buttonSearchSonCoverTest";
            this.buttonSearchSonCoverTest.Size = new System.Drawing.Size(170, 23);
            this.buttonSearchSonCoverTest.TabIndex = 15;
            this.buttonSearchSonCoverTest.Text = "Seleccionar Caratula de prueba";
            this.buttonSearchSonCoverTest.UseVisualStyleBackColor = true;
            this.buttonSearchSonCoverTest.Click += new System.EventHandler(this.buttonSearchSonCoverTest_Click);
            // 
            // buttonColorPickIMG
            // 
            this.buttonColorPickIMG.BackColor = System.Drawing.Color.Black;
            this.buttonColorPickIMG.Location = new System.Drawing.Point(466, 109);
            this.buttonColorPickIMG.Name = "buttonColorPickIMG";
            this.buttonColorPickIMG.Size = new System.Drawing.Size(25, 25);
            this.buttonColorPickIMG.TabIndex = 16;
            this.buttonColorPickIMG.UseVisualStyleBackColor = false;
            // 
            // checkBoxImageLocation
            // 
            this.checkBoxImageLocation.AutoSize = true;
            this.checkBoxImageLocation.Location = new System.Drawing.Point(218, 140);
            this.checkBoxImageLocation.Name = "checkBoxImageLocation";
            this.checkBoxImageLocation.Size = new System.Drawing.Size(215, 17);
            this.checkBoxImageLocation.TabIndex = 17;
            this.checkBoxImageLocation.Text = "Utilizar la imagen en su ubicacion actual";
            this.checkBoxImageLocation.UseVisualStyleBackColor = true;
            // 
            // NewCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 483);
            this.Controls.Add(this.checkBoxImageLocation);
            this.Controls.Add(this.buttonColorPickIMG);
            this.Controls.Add(this.buttonSearchSonCoverTest);
            this.Controls.Add(this.buttonBackgroundColor);
            this.Controls.Add(this.buttonSearchCover);
            this.Controls.Add(this.groupBoxSonFormat);
            this.Controls.Add(this.groupBoxSon);
            this.Controls.Add(this.label1);
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
            this.Name = "NewCollection";
            this.Text = "NewCollection";
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
            this.groupBoxSon.ResumeLayout(false);
            this.groupBoxSon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSonHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSonWidth)).EndInit();
            this.groupBoxSonFormat.ResumeLayout(false);
            this.groupBoxSonFormat.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSon;
        private System.Windows.Forms.Label labelSonHeight;
        private System.Windows.Forms.Label labelSonWidth;
        private System.Windows.Forms.NumericUpDown numericSonHeight;
        private System.Windows.Forms.NumericUpDown numericSonWidth;
        private System.Windows.Forms.GroupBox groupBoxSonFormat;
        private System.Windows.Forms.RadioButton radioButtonSonEstreched;
        private System.Windows.Forms.RadioButton radioButtonSonZoom;
        private System.Windows.Forms.Button buttonSearchCover;
        private System.Windows.Forms.Button buttonBackgroundColor;
        private System.Windows.Forms.Button buttonSearchSonCoverTest;
        private System.Windows.Forms.Button buttonColorPickIMG;
        private System.Windows.Forms.CheckBox checkBoxImageLocation;
    }
}