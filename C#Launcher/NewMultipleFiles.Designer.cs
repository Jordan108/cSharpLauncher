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
            this.labelFather = new System.Windows.Forms.Label();
            this.comboBoxFather = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCMD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnCover = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.buttonSave.Location = new System.Drawing.Point(330, 526);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 35);
            this.buttonSave.TabIndex = 27;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Location = new System.Drawing.Point(315, 65);
            this.comboBoxResolution.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(250, 28);
            this.comboBoxResolution.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Resolucion global";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 28);
            this.button1.TabIndex = 30;
            this.button1.Text = "Establecer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(441, 103);
            this.buttonAddRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(112, 35);
            this.buttonAddRow.TabIndex = 31;
            this.buttonAddRow.Text = "Añadir";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Location = new System.Drawing.Point(572, 103);
            this.buttonDeleteRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(112, 35);
            this.buttonDeleteRow.TabIndex = 32;
            this.buttonDeleteRow.Text = "Eliminar";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
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
            this.ColumnCheckBox.Width = 75;
            // 
            // ColumnFile
            // 
            this.ColumnFile.HeaderText = "Ruta archivo";
            this.ColumnFile.MinimumWidth = 8;
            this.ColumnFile.Name = "ColumnFile";
            this.ColumnFile.Width = 150;
            // 
            // ColumnProgram
            // 
            this.ColumnProgram.HeaderText = "Ruta lanzador";
            this.ColumnProgram.MinimumWidth = 8;
            this.ColumnProgram.Name = "ColumnProgram";
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
            this.ColumnCover.Width = 150;
            // 
            // NewMultipleFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 600);
            this.Controls.Add(this.buttonDeleteRow);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
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
    }
}