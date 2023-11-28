namespace CoverPadLauncher
{
    partial class EditScaned
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
            this.panelImageLimit = new System.Windows.Forms.Panel();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.buttonSearchCover = new System.Windows.Forms.Button();
            this.buttonSetColor = new System.Windows.Forms.Button();
            this.buttonColorPickIMG = new System.Windows.Forms.Button();
            this.BackgroundColorCheck = new System.Windows.Forms.CheckBox();
            this.labelResolution = new System.Windows.Forms.Label();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.addResolution = new System.Windows.Forms.Button();
            this.groupBoxSize = new System.Windows.Forms.GroupBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.numericHeightImage = new System.Windows.Forms.NumericUpDown();
            this.numericWidthImage = new System.Windows.Forms.NumericUpDown();
            this.labelHeight = new System.Windows.Forms.Label();
            this.groupBoxImageFormat = new System.Windows.Forms.GroupBox();
            this.radioButtonEstreched = new System.Windows.Forms.RadioButton();
            this.radioButtonZoom = new System.Windows.Forms.RadioButton();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelScanStart = new System.Windows.Forms.Label();
            this.numericScanStart = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewScanOpenExtension = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxImageLocation = new System.Windows.Forms.CheckBox();
            this.panelImageLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.groupBoxSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthImage)).BeginInit();
            this.groupBoxImageFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericScanStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScanOpenExtension)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(59, 25);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(232, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.ForeColor = System.Drawing.SystemColors.Window;
            this.labelName.Location = new System.Drawing.Point(9, 28);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Nombre";
            // 
            // panelImageLimit
            // 
            this.panelImageLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.panelImageLimit.Controls.Add(this.pictureBoxCover);
            this.panelImageLimit.Location = new System.Drawing.Point(303, 202);
            this.panelImageLimit.Name = "panelImageLimit";
            this.panelImageLimit.Size = new System.Drawing.Size(300, 300);
            this.panelImageLimit.TabIndex = 18;
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
            // buttonSearchCover
            // 
            this.buttonSearchCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSearchCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchCover.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSearchCover.Location = new System.Drawing.Point(303, 153);
            this.buttonSearchCover.Name = "buttonSearchCover";
            this.buttonSearchCover.Size = new System.Drawing.Size(115, 23);
            this.buttonSearchCover.TabIndex = 25;
            this.buttonSearchCover.Text = "Seleccionar Caratula";
            this.buttonSearchCover.UseVisualStyleBackColor = false;
            this.buttonSearchCover.Click += new System.EventHandler(this.buttonSearchCover_Click);
            // 
            // buttonSetColor
            // 
            this.buttonSetColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSetColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetColor.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSetColor.Location = new System.Drawing.Point(424, 153);
            this.buttonSetColor.Name = "buttonSetColor";
            this.buttonSetColor.Size = new System.Drawing.Size(93, 23);
            this.buttonSetColor.TabIndex = 26;
            this.buttonSetColor.Text = " Color de fondo";
            this.buttonSetColor.UseVisualStyleBackColor = false;
            this.buttonSetColor.Click += new System.EventHandler(this.buttonSetColor_Click);
            // 
            // buttonColorPickIMG
            // 
            this.buttonColorPickIMG.BackColor = System.Drawing.Color.Black;
            this.buttonColorPickIMG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColorPickIMG.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonColorPickIMG.Location = new System.Drawing.Point(523, 153);
            this.buttonColorPickIMG.Name = "buttonColorPickIMG";
            this.buttonColorPickIMG.Size = new System.Drawing.Size(25, 25);
            this.buttonColorPickIMG.TabIndex = 30;
            this.buttonColorPickIMG.UseVisualStyleBackColor = false;
            // 
            // BackgroundColorCheck
            // 
            this.BackgroundColorCheck.AutoSize = true;
            this.BackgroundColorCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackgroundColorCheck.ForeColor = System.Drawing.SystemColors.Window;
            this.BackgroundColorCheck.Location = new System.Drawing.Point(303, 130);
            this.BackgroundColorCheck.Name = "BackgroundColorCheck";
            this.BackgroundColorCheck.Size = new System.Drawing.Size(115, 17);
            this.BackgroundColorCheck.TabIndex = 33;
            this.BackgroundColorCheck.Text = "Fondo transparente";
            this.BackgroundColorCheck.UseVisualStyleBackColor = true;
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.ForeColor = System.Drawing.SystemColors.Window;
            this.labelResolution.Location = new System.Drawing.Point(12, 182);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(60, 13);
            this.labelResolution.TabIndex = 34;
            this.labelResolution.Text = "Resolucion";
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.comboBoxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxResolution.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Location = new System.Drawing.Point(12, 202);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(214, 21);
            this.comboBoxResolution.TabIndex = 35;
            this.comboBoxResolution.SelectedIndexChanged += new System.EventHandler(this.comboBoxResolution_SelectedIndexChanged);
            // 
            // addResolution
            // 
            this.addResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.addResolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addResolution.ForeColor = System.Drawing.SystemColors.Window;
            this.addResolution.Location = new System.Drawing.Point(241, 201);
            this.addResolution.Margin = new System.Windows.Forms.Padding(2);
            this.addResolution.Name = "addResolution";
            this.addResolution.Size = new System.Drawing.Size(50, 21);
            this.addResolution.TabIndex = 32;
            this.addResolution.Text = "Añadir";
            this.addResolution.UseVisualStyleBackColor = false;
            this.addResolution.Click += new System.EventHandler(this.addResolution_Click);
            // 
            // groupBoxSize
            // 
            this.groupBoxSize.Controls.Add(this.labelWidth);
            this.groupBoxSize.Controls.Add(this.numericHeightImage);
            this.groupBoxSize.Controls.Add(this.numericWidthImage);
            this.groupBoxSize.Controls.Add(this.labelHeight);
            this.groupBoxSize.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBoxSize.Location = new System.Drawing.Point(12, 244);
            this.groupBoxSize.Name = "groupBoxSize";
            this.groupBoxSize.Size = new System.Drawing.Size(279, 100);
            this.groupBoxSize.TabIndex = 36;
            this.groupBoxSize.TabStop = false;
            this.groupBoxSize.Text = "Tamaño en pixeles (100-300)";
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
            this.groupBoxImageFormat.Location = new System.Drawing.Point(53, 350);
            this.groupBoxImageFormat.Name = "groupBoxImageFormat";
            this.groupBoxImageFormat.Size = new System.Drawing.Size(157, 71);
            this.groupBoxImageFormat.TabIndex = 21;
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
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSave.Location = new System.Drawing.Point(98, 475);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 27;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelScanStart
            // 
            this.labelScanStart.AutoSize = true;
            this.labelScanStart.ForeColor = System.Drawing.SystemColors.Window;
            this.labelScanStart.Location = new System.Drawing.Point(339, 28);
            this.labelScanStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScanStart.Name = "labelScanStart";
            this.labelScanStart.Size = new System.Drawing.Size(97, 13);
            this.labelScanStart.TabIndex = 42;
            this.labelScanStart.Text = "Ejecutar archivo n°";
            // 
            // numericScanStart
            // 
            this.numericScanStart.Location = new System.Drawing.Point(440, 26);
            this.numericScanStart.Margin = new System.Windows.Forms.Padding(2);
            this.numericScanStart.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericScanStart.Name = "numericScanStart";
            this.numericScanStart.Size = new System.Drawing.Size(42, 20);
            this.numericScanStart.TabIndex = 43;
            // 
            // dataGridViewScanOpenExtension
            // 
            this.dataGridViewScanOpenExtension.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.dataGridViewScanOpenExtension.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScanOpenExtension.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewScanOpenExtension.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.dataGridViewScanOpenExtension.Location = new System.Drawing.Point(499, 11);
            this.dataGridViewScanOpenExtension.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewScanOpenExtension.MultiSelect = false;
            this.dataGridViewScanOpenExtension.Name = "dataGridViewScanOpenExtension";
            this.dataGridViewScanOpenExtension.RowHeadersVisible = false;
            this.dataGridViewScanOpenExtension.RowHeadersWidth = 62;
            this.dataGridViewScanOpenExtension.RowTemplate.Height = 28;
            this.dataGridViewScanOpenExtension.Size = new System.Drawing.Size(104, 115);
            this.dataGridViewScanOpenExtension.TabIndex = 44;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Extension";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            // 
            // checkBoxImageLocation
            // 
            this.checkBoxImageLocation.AutoSize = true;
            this.checkBoxImageLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxImageLocation.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBoxImageLocation.Location = new System.Drawing.Point(302, 182);
            this.checkBoxImageLocation.Name = "checkBoxImageLocation";
            this.checkBoxImageLocation.Size = new System.Drawing.Size(212, 17);
            this.checkBoxImageLocation.TabIndex = 45;
            this.checkBoxImageLocation.Text = "Utilizar la imagen en su ubicacion actual";
            this.checkBoxImageLocation.UseVisualStyleBackColor = true;
            // 
            // EditScaned
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(615, 510);
            this.Controls.Add(this.checkBoxImageLocation);
            this.Controls.Add(this.dataGridViewScanOpenExtension);
            this.Controls.Add(this.numericScanStart);
            this.Controls.Add(this.labelScanStart);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxImageFormat);
            this.Controls.Add(this.groupBoxSize);
            this.Controls.Add(this.addResolution);
            this.Controls.Add(this.comboBoxResolution);
            this.Controls.Add(this.labelResolution);
            this.Controls.Add(this.BackgroundColorCheck);
            this.Controls.Add(this.buttonColorPickIMG);
            this.Controls.Add(this.buttonSetColor);
            this.Controls.Add(this.buttonSearchCover);
            this.Controls.Add(this.panelImageLimit);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "EditScaned";
            this.Text = "Editar elemento escaneado";
            this.panelImageLimit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.groupBoxSize.ResumeLayout(false);
            this.groupBoxSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthImage)).EndInit();
            this.groupBoxImageFormat.ResumeLayout(false);
            this.groupBoxImageFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericScanStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScanOpenExtension)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panelImageLimit;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Button buttonSearchCover;
        private System.Windows.Forms.Button buttonSetColor;
        private System.Windows.Forms.Button buttonColorPickIMG;
        private System.Windows.Forms.CheckBox BackgroundColorCheck;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.Button addResolution;
        private System.Windows.Forms.GroupBox groupBoxSize;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.NumericUpDown numericHeightImage;
        private System.Windows.Forms.NumericUpDown numericWidthImage;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.GroupBox groupBoxImageFormat;
        private System.Windows.Forms.RadioButton radioButtonEstreched;
        private System.Windows.Forms.RadioButton radioButtonZoom;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelScanStart;
        private System.Windows.Forms.NumericUpDown numericScanStart;
        private System.Windows.Forms.DataGridView dataGridViewScanOpenExtension;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.CheckBox checkBoxImageLocation;
    }
}