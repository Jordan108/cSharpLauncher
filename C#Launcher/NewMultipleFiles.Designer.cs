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
            this.buttonGlobalLauncher = new System.Windows.Forms.Button();
            this.buttonGlobalCMD = new System.Windows.Forms.Button();
            this.labelGlobalCMD = new System.Windows.Forms.Label();
            this.textBoxGlobalCMD = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFiles
            // 
            this.dataGridViewFiles.AllowUserToAddRows = false;
            this.dataGridViewFiles.AllowUserToResizeColumns = false;
            this.dataGridViewFiles.AllowUserToResizeRows = false;
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
            this.ColumnCover});
            this.dataGridViewFiles.Location = new System.Drawing.Point(11, 148);
            this.dataGridViewFiles.Name = "dataGridViewFiles";
            this.dataGridViewFiles.RowHeadersWidth = 62;
            this.dataGridViewFiles.RowTemplate.Height = 28;
            this.dataGridViewFiles.Size = new System.Drawing.Size(1202, 343);
            this.dataGridViewFiles.TabIndex = 0;
            this.dataGridViewFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFiles_CellClick);
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
            this.ColumnWidth.Width = 75;
            // 
            // ColumnHeight
            // 
            this.ColumnHeight.HeaderText = "Alto";
            this.ColumnHeight.MinimumWidth = 8;
            this.ColumnHeight.Name = "ColumnHeight";
            this.ColumnHeight.Width = 75;
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
            // labelFather
            // 
            this.labelFather.AutoSize = true;
            this.labelFather.Location = new System.Drawing.Point(105, 40);
            this.labelFather.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFather.Name = "labelFather";
            this.labelFather.Size = new System.Drawing.Size(105, 20);
            this.labelFather.TabIndex = 4;
            this.labelFather.Text = "Padre archivo";
            // 
            // comboBoxFather
            // 
            this.comboBoxFather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFather.FormattingEnabled = true;
            this.comboBoxFather.Location = new System.Drawing.Point(25, 65);
            this.comboBoxFather.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxFather.Name = "comboBoxFather";
            this.comboBoxFather.Size = new System.Drawing.Size(261, 28);
            this.comboBoxFather.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(25, 527);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 35);
            this.buttonSave.TabIndex = 27;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Location = new System.Drawing.Point(301, 65);
            this.comboBoxResolution.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(202, 28);
            this.comboBoxResolution.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Resolucion global";
            // 
            // buttonGlobalResolution
            // 
            this.buttonGlobalResolution.Location = new System.Drawing.Point(337, 101);
            this.buttonGlobalResolution.Name = "buttonGlobalResolution";
            this.buttonGlobalResolution.Size = new System.Drawing.Size(109, 37);
            this.buttonGlobalResolution.TabIndex = 30;
            this.buttonGlobalResolution.Text = "Establecer";
            this.buttonGlobalResolution.UseVisualStyleBackColor = true;
            this.buttonGlobalResolution.Click += new System.EventHandler(this.buttonGlobalResolution_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(25, 105);
            this.buttonAddRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(125, 35);
            this.buttonAddRow.TabIndex = 31;
            this.buttonAddRow.Text = "Añadir archivos";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Location = new System.Drawing.Point(158, 105);
            this.buttonDeleteRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(128, 35);
            this.buttonDeleteRow.TabIndex = 32;
            this.buttonDeleteRow.Text = "Eliminar fila";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // textBoxGlobalLauncher
            // 
            this.textBoxGlobalLauncher.Location = new System.Drawing.Point(544, 67);
            this.textBoxGlobalLauncher.Name = "textBoxGlobalLauncher";
            this.textBoxGlobalLauncher.Size = new System.Drawing.Size(176, 26);
            this.textBoxGlobalLauncher.TabIndex = 33;
            // 
            // labelGlobalLauncher
            // 
            this.labelGlobalLauncher.AutoSize = true;
            this.labelGlobalLauncher.Location = new System.Drawing.Point(540, 40);
            this.labelGlobalLauncher.Name = "labelGlobalLauncher";
            this.labelGlobalLauncher.Size = new System.Drawing.Size(180, 20);
            this.labelGlobalLauncher.TabIndex = 34;
            this.labelGlobalLauncher.Text = "Ruta del lanzador global";
            // 
            // buttonGlobalLauncher
            // 
            this.buttonGlobalLauncher.Location = new System.Drawing.Point(582, 99);
            this.buttonGlobalLauncher.Name = "buttonGlobalLauncher";
            this.buttonGlobalLauncher.Size = new System.Drawing.Size(102, 37);
            this.buttonGlobalLauncher.TabIndex = 35;
            this.buttonGlobalLauncher.Text = "Establecer";
            this.buttonGlobalLauncher.UseVisualStyleBackColor = true;
            // 
            // buttonGlobalCMD
            // 
            this.buttonGlobalCMD.Location = new System.Drawing.Point(790, 99);
            this.buttonGlobalCMD.Name = "buttonGlobalCMD";
            this.buttonGlobalCMD.Size = new System.Drawing.Size(101, 35);
            this.buttonGlobalCMD.TabIndex = 36;
            this.buttonGlobalCMD.Text = "Establecer";
            this.buttonGlobalCMD.UseVisualStyleBackColor = true;
            // 
            // labelGlobalCMD
            // 
            this.labelGlobalCMD.AutoSize = true;
            this.labelGlobalCMD.Location = new System.Drawing.Point(739, 40);
            this.labelGlobalCMD.Name = "labelGlobalCMD";
            this.labelGlobalCMD.Size = new System.Drawing.Size(195, 20);
            this.labelGlobalCMD.TabIndex = 37;
            this.labelGlobalCMD.Text = "Argumento de inicio global";
            // 
            // textBoxGlobalCMD
            // 
            this.textBoxGlobalCMD.Location = new System.Drawing.Point(743, 67);
            this.textBoxGlobalCMD.Name = "textBoxGlobalCMD";
            this.textBoxGlobalCMD.Size = new System.Drawing.Size(191, 26);
            this.textBoxGlobalCMD.TabIndex = 38;
            // 
            // NewMultipleFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 600);
            this.Controls.Add(this.textBoxGlobalCMD);
            this.Controls.Add(this.labelGlobalCMD);
            this.Controls.Add(this.buttonGlobalCMD);
            this.Controls.Add(this.buttonGlobalLauncher);
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
            this.Name = "NewMultipleFiles";
            this.Text = "NewMultipleFiles";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCMD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHeight;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCover;
        private System.Windows.Forms.TextBox textBoxGlobalLauncher;
        private System.Windows.Forms.Label labelGlobalLauncher;
        private System.Windows.Forms.Button buttonGlobalLauncher;
        private System.Windows.Forms.Button buttonGlobalCMD;
        private System.Windows.Forms.Label labelGlobalCMD;
        private System.Windows.Forms.TextBox textBoxGlobalCMD;
    }
}