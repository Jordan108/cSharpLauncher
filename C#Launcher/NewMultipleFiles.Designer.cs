namespace C_Launcher
{
    partial class NewMultipleFiles
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
            this.dataGridViewFiles = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCMD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnCover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFormat = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelFather = new System.Windows.Forms.Label();
            this.comboBoxFather = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGlobalResolution = new System.Windows.Forms.Button();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.textBoxGlobalLauncher = new System.Windows.Forms.TextBox();
            this.labelGlobalLauncher = new System.Windows.Forms.Label();
            this.buttonDeleteGlobalLauncher = new System.Windows.Forms.Button();
            this.buttonGlobalCMD = new System.Windows.Forms.Button();
            this.labelGlobalCMD = new System.Windows.Forms.Label();
            this.textBoxGlobalCMD = new System.Windows.Forms.TextBox();
            this.buttonGlobalLauncher = new System.Windows.Forms.Button();
            this.comboBoxImageFormat = new System.Windows.Forms.ComboBox();
            this.labelGlobalImageFormat = new System.Windows.Forms.Label();
            this.buttonGlobalImageFormat = new System.Windows.Forms.Button();
            this.addResolution = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFiles
            // 
            this.dataGridViewFiles.AllowUserToAddRows = false;
            this.dataGridViewFiles.AllowUserToResizeColumns = false;
            this.dataGridViewFiles.AllowUserToResizeRows = false;
            this.dataGridViewFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.dataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnCheckBox,
            this.ColumnFile,
            this.ColumnProgram,
            this.ColumnCMD,
            this.ColumnWidth,
            this.ColumnHeight,
            this.ColumnRes,
            this.ColumnCover,
            this.ColumnFormat,
            this.ColumnColor});
            this.dataGridViewFiles.Location = new System.Drawing.Point(8, 77);
            this.dataGridViewFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewFiles.Name = "dataGridViewFiles";
            this.dataGridViewFiles.RowHeadersWidth = 62;
            this.dataGridViewFiles.RowTemplate.Height = 28;
            this.dataGridViewFiles.Size = new System.Drawing.Size(1215, 521);
            this.dataGridViewFiles.TabIndex = 0;
            this.dataGridViewFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFiles_CellClick);
            this.dataGridViewFiles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFiles_CellEndEdit);
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Nombre";
            this.ColumnName.MinimumWidth = 8;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnName.Width = 150;
            // 
            // ColumnCheckBox
            // 
            this.ColumnCheckBox.HeaderText = "URL";
            this.ColumnCheckBox.MinimumWidth = 8;
            this.ColumnCheckBox.Name = "ColumnCheckBox";
            this.ColumnCheckBox.Width = 50;
            // 
            // ColumnFile
            // 
            this.ColumnFile.HeaderText = "Ruta archivo";
            this.ColumnFile.MinimumWidth = 8;
            this.ColumnFile.Name = "ColumnFile";
            this.ColumnFile.ReadOnly = true;
            this.ColumnFile.Width = 150;
            // 
            // ColumnProgram
            // 
            this.ColumnProgram.HeaderText = "Ruta lanzador";
            this.ColumnProgram.MinimumWidth = 8;
            this.ColumnProgram.Name = "ColumnProgram";
            this.ColumnProgram.ReadOnly = true;
            this.ColumnProgram.Width = 150;
            // 
            // ColumnCMD
            // 
            this.ColumnCMD.HeaderText = "Argumentos de inicio";
            this.ColumnCMD.MinimumWidth = 8;
            this.ColumnCMD.Name = "ColumnCMD";
            this.ColumnCMD.Width = 150;
            // 
            // ColumnWidth
            // 
            this.ColumnWidth.HeaderText = "Ancho";
            this.ColumnWidth.MinimumWidth = 8;
            this.ColumnWidth.Name = "ColumnWidth";
            this.ColumnWidth.Width = 50;
            // 
            // ColumnHeight
            // 
            this.ColumnHeight.HeaderText = "Alto";
            this.ColumnHeight.MinimumWidth = 8;
            this.ColumnHeight.Name = "ColumnHeight";
            this.ColumnHeight.Width = 50;
            // 
            // ColumnRes
            // 
            this.ColumnRes.HeaderText = "Resolucion";
            this.ColumnRes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.ColumnRes.MinimumWidth = 8;
            this.ColumnRes.Name = "ColumnRes";
            this.ColumnRes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnRes.Width = 150;
            // 
            // ColumnCover
            // 
            this.ColumnCover.HeaderText = "Caratula";
            this.ColumnCover.MinimumWidth = 8;
            this.ColumnCover.Name = "ColumnCover";
            this.ColumnCover.ReadOnly = true;
            this.ColumnCover.Width = 150;
            // 
            // ColumnFormat
            // 
            this.ColumnFormat.HeaderText = "Formato de imagen";
            this.ColumnFormat.MinimumWidth = 8;
            this.ColumnFormat.Name = "ColumnFormat";
            this.ColumnFormat.Width = 150;
            // 
            // ColumnColor
            // 
            this.ColumnColor.HeaderText = "Color de fondo";
            this.ColumnColor.MinimumWidth = 8;
            this.ColumnColor.Name = "ColumnColor";
            this.ColumnColor.ReadOnly = true;
            this.ColumnColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnColor.Width = 75;
            // 
            // labelFather
            // 
            this.labelFather.AutoSize = true;
            this.labelFather.ForeColor = System.Drawing.SystemColors.Window;
            this.labelFather.Location = new System.Drawing.Point(59, 9);
            this.labelFather.Name = "labelFather";
            this.labelFather.Size = new System.Drawing.Size(73, 13);
            this.labelFather.TabIndex = 4;
            this.labelFather.Text = "Padre archivo";
            // 
            // comboBoxFather
            // 
            this.comboBoxFather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.comboBoxFather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFather.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxFather.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxFather.FormattingEnabled = true;
            this.comboBoxFather.Location = new System.Drawing.Point(17, 22);
            this.comboBoxFather.Name = "comboBoxFather";
            this.comboBoxFather.Size = new System.Drawing.Size(175, 21);
            this.comboBoxFather.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSave.Location = new System.Drawing.Point(8, 603);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 27;
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
            this.comboBoxResolution.Location = new System.Drawing.Point(200, 22);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(136, 21);
            this.comboBoxResolution.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(229, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Resolucion global";
            // 
            // buttonGlobalResolution
            // 
            this.buttonGlobalResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonGlobalResolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGlobalResolution.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonGlobalResolution.Location = new System.Drawing.Point(263, 49);
            this.buttonGlobalResolution.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonGlobalResolution.Name = "buttonGlobalResolution";
            this.buttonGlobalResolution.Size = new System.Drawing.Size(73, 24);
            this.buttonGlobalResolution.TabIndex = 30;
            this.buttonGlobalResolution.Text = "Establecer";
            this.buttonGlobalResolution.UseVisualStyleBackColor = false;
            this.buttonGlobalResolution.Click += new System.EventHandler(this.buttonGlobalResolution_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddRow.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonAddRow.Location = new System.Drawing.Point(17, 49);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(93, 24);
            this.buttonAddRow.TabIndex = 31;
            this.buttonAddRow.Text = "Añadir archivos";
            this.buttonAddRow.UseVisualStyleBackColor = false;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonDeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteRow.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonDeleteRow.Location = new System.Drawing.Point(116, 49);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(76, 24);
            this.buttonDeleteRow.TabIndex = 32;
            this.buttonDeleteRow.Text = "Eliminar fila";
            this.buttonDeleteRow.UseVisualStyleBackColor = false;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // textBoxGlobalLauncher
            // 
            this.textBoxGlobalLauncher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxGlobalLauncher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGlobalLauncher.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxGlobalLauncher.Location = new System.Drawing.Point(471, 22);
            this.textBoxGlobalLauncher.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxGlobalLauncher.Name = "textBoxGlobalLauncher";
            this.textBoxGlobalLauncher.ReadOnly = true;
            this.textBoxGlobalLauncher.Size = new System.Drawing.Size(129, 20);
            this.textBoxGlobalLauncher.TabIndex = 33;
            this.textBoxGlobalLauncher.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxGlobalLauncher.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxGlobalLauncher_MouseClick);
            // 
            // labelGlobalLauncher
            // 
            this.labelGlobalLauncher.AutoSize = true;
            this.labelGlobalLauncher.ForeColor = System.Drawing.SystemColors.Window;
            this.labelGlobalLauncher.Location = new System.Drawing.Point(476, 9);
            this.labelGlobalLauncher.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGlobalLauncher.Name = "labelGlobalLauncher";
            this.labelGlobalLauncher.Size = new System.Drawing.Size(121, 13);
            this.labelGlobalLauncher.TabIndex = 34;
            this.labelGlobalLauncher.Text = "Ruta del lanzador global";
            // 
            // buttonDeleteGlobalLauncher
            // 
            this.buttonDeleteGlobalLauncher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonDeleteGlobalLauncher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteGlobalLauncher.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonDeleteGlobalLauncher.Location = new System.Drawing.Point(548, 49);
            this.buttonDeleteGlobalLauncher.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDeleteGlobalLauncher.Name = "buttonDeleteGlobalLauncher";
            this.buttonDeleteGlobalLauncher.Size = new System.Drawing.Size(49, 24);
            this.buttonDeleteGlobalLauncher.TabIndex = 35;
            this.buttonDeleteGlobalLauncher.Text = "Borrar";
            this.buttonDeleteGlobalLauncher.UseVisualStyleBackColor = false;
            this.buttonDeleteGlobalLauncher.Click += new System.EventHandler(this.buttonDeleteGlobalLauncher_Click);
            // 
            // buttonGlobalCMD
            // 
            this.buttonGlobalCMD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonGlobalCMD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGlobalCMD.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonGlobalCMD.Location = new System.Drawing.Point(632, 49);
            this.buttonGlobalCMD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonGlobalCMD.Name = "buttonGlobalCMD";
            this.buttonGlobalCMD.Size = new System.Drawing.Size(67, 24);
            this.buttonGlobalCMD.TabIndex = 36;
            this.buttonGlobalCMD.Text = "Establecer";
            this.buttonGlobalCMD.UseVisualStyleBackColor = false;
            this.buttonGlobalCMD.Click += new System.EventHandler(this.buttonGlobalCMD_Click);
            // 
            // labelGlobalCMD
            // 
            this.labelGlobalCMD.AutoSize = true;
            this.labelGlobalCMD.ForeColor = System.Drawing.SystemColors.Window;
            this.labelGlobalCMD.Location = new System.Drawing.Point(601, 9);
            this.labelGlobalCMD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGlobalCMD.Name = "labelGlobalCMD";
            this.labelGlobalCMD.Size = new System.Drawing.Size(131, 13);
            this.labelGlobalCMD.TabIndex = 37;
            this.labelGlobalCMD.Text = "Argumento de inicio global";
            // 
            // textBoxGlobalCMD
            // 
            this.textBoxGlobalCMD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxGlobalCMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGlobalCMD.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxGlobalCMD.Location = new System.Drawing.Point(603, 22);
            this.textBoxGlobalCMD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxGlobalCMD.Name = "textBoxGlobalCMD";
            this.textBoxGlobalCMD.Size = new System.Drawing.Size(129, 20);
            this.textBoxGlobalCMD.TabIndex = 38;
            // 
            // buttonGlobalLauncher
            // 
            this.buttonGlobalLauncher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonGlobalLauncher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGlobalLauncher.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonGlobalLauncher.Location = new System.Drawing.Point(469, 49);
            this.buttonGlobalLauncher.Name = "buttonGlobalLauncher";
            this.buttonGlobalLauncher.Size = new System.Drawing.Size(75, 24);
            this.buttonGlobalLauncher.TabIndex = 39;
            this.buttonGlobalLauncher.Text = "Establecer";
            this.buttonGlobalLauncher.UseVisualStyleBackColor = false;
            this.buttonGlobalLauncher.Click += new System.EventHandler(this.buttonGlobalLauncher_Click);
            // 
            // comboBoxImageFormat
            // 
            this.comboBoxImageFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.comboBoxImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxImageFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxImageFormat.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxImageFormat.FormattingEnabled = true;
            this.comboBoxImageFormat.Location = new System.Drawing.Point(343, 22);
            this.comboBoxImageFormat.Name = "comboBoxImageFormat";
            this.comboBoxImageFormat.Size = new System.Drawing.Size(121, 21);
            this.comboBoxImageFormat.TabIndex = 40;
            // 
            // labelGlobalImageFormat
            // 
            this.labelGlobalImageFormat.AutoSize = true;
            this.labelGlobalImageFormat.ForeColor = System.Drawing.SystemColors.Window;
            this.labelGlobalImageFormat.Location = new System.Drawing.Point(340, 9);
            this.labelGlobalImageFormat.Name = "labelGlobalImageFormat";
            this.labelGlobalImageFormat.Size = new System.Drawing.Size(128, 13);
            this.labelGlobalImageFormat.TabIndex = 41;
            this.labelGlobalImageFormat.Text = "Formato de imagen global";
            // 
            // buttonGlobalImageFormat
            // 
            this.buttonGlobalImageFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonGlobalImageFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGlobalImageFormat.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonGlobalImageFormat.Location = new System.Drawing.Point(365, 49);
            this.buttonGlobalImageFormat.Name = "buttonGlobalImageFormat";
            this.buttonGlobalImageFormat.Size = new System.Drawing.Size(75, 24);
            this.buttonGlobalImageFormat.TabIndex = 42;
            this.buttonGlobalImageFormat.Text = "Establecer";
            this.buttonGlobalImageFormat.UseVisualStyleBackColor = false;
            this.buttonGlobalImageFormat.Click += new System.EventHandler(this.buttonGlobalImageFormat_Click);
            // 
            // addResolution
            // 
            this.addResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.addResolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addResolution.ForeColor = System.Drawing.SystemColors.Window;
            this.addResolution.Location = new System.Drawing.Point(201, 49);
            this.addResolution.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addResolution.Name = "addResolution";
            this.addResolution.Size = new System.Drawing.Size(50, 24);
            this.addResolution.TabIndex = 43;
            this.addResolution.Text = "Añadir";
            this.addResolution.UseVisualStyleBackColor = false;
            this.addResolution.Click += new System.EventHandler(this.addResolution_Click);
            // 
            // NewMultipleFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(1256, 631);
            this.Controls.Add(this.addResolution);
            this.Controls.Add(this.buttonGlobalImageFormat);
            this.Controls.Add(this.labelGlobalImageFormat);
            this.Controls.Add(this.comboBoxImageFormat);
            this.Controls.Add(this.buttonGlobalLauncher);
            this.Controls.Add(this.textBoxGlobalCMD);
            this.Controls.Add(this.labelGlobalCMD);
            this.Controls.Add(this.buttonGlobalCMD);
            this.Controls.Add(this.buttonDeleteGlobalLauncher);
            this.Controls.Add(this.labelGlobalLauncher);
            this.Controls.Add(this.textBoxGlobalLauncher);
            this.Controls.Add(this.buttonDeleteRow);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.buttonGlobalResolution);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxResolution);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxFather);
            this.Controls.Add(this.labelFather);
            this.Controls.Add(this.dataGridViewFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NewMultipleFiles";
            this.Text = "Nuevos Elementos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFiles;
        private System.Windows.Forms.Label labelFather;
        private System.Windows.Forms.ComboBox comboBoxFather;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGlobalResolution;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonDeleteRow;
        private System.Windows.Forms.TextBox textBoxGlobalLauncher;
        private System.Windows.Forms.Label labelGlobalLauncher;
        private System.Windows.Forms.Button buttonDeleteGlobalLauncher;
        private System.Windows.Forms.Button buttonGlobalCMD;
        private System.Windows.Forms.Label labelGlobalCMD;
        private System.Windows.Forms.TextBox textBoxGlobalCMD;
        private System.Windows.Forms.Button buttonGlobalLauncher;
        private System.Windows.Forms.ComboBox comboBoxImageFormat;
        private System.Windows.Forms.Label labelGlobalImageFormat;
        private System.Windows.Forms.Button buttonGlobalImageFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCMD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHeight;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCover;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColor;
        private System.Windows.Forms.Button addResolution;
    }
}