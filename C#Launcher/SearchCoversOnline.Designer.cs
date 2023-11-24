namespace CoverPadLauncher
{
    partial class SearchCoversOnline
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
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonContinueType = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonMangas = new System.Windows.Forms.RadioButton();
            this.radioButtonSeries = new System.Windows.Forms.RadioButton();
            this.radioButtonFilms = new System.Windows.Forms.RadioButton();
            this.radioButtonGames = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonContinueName = new System.Windows.Forms.Button();
            this.dataGridViewNames = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labelCoverArraySelected = new System.Windows.Forms.Label();
            this.buttonCoverBack = new System.Windows.Forms.Button();
            this.buttonCoverNext = new System.Windows.Forms.Button();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.dataGridViewCovers = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSelected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioButtonComics = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNames)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCovers)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCover.Location = new System.Drawing.Point(664, 45);
            this.pictureBoxCover.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(450, 462);
            this.pictureBoxCover.TabIndex = 3;
            this.pictureBoxCover.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(-6, -36);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1136, 783);
            this.tabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonContinueType);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1128, 750);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tipo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonContinueType
            // 
            this.buttonContinueType.Location = new System.Drawing.Point(1008, 555);
            this.buttonContinueType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonContinueType.Name = "buttonContinueType";
            this.buttonContinueType.Size = new System.Drawing.Size(112, 35);
            this.buttonContinueType.TabIndex = 1;
            this.buttonContinueType.Text = "Continuar";
            this.buttonContinueType.UseVisualStyleBackColor = true;
            this.buttonContinueType.Click += new System.EventHandler(this.buttonContinueType_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonComics);
            this.groupBox1.Controls.Add(this.radioButtonMangas);
            this.groupBox1.Controls.Add(this.radioButtonSeries);
            this.groupBox1.Controls.Add(this.radioButtonFilms);
            this.groupBox1.Controls.Add(this.radioButtonGames);
            this.groupBox1.Location = new System.Drawing.Point(30, 45);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(300, 277);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "¿Que estas importando?";
            // 
            // radioButtonMangas
            // 
            this.radioButtonMangas.AutoSize = true;
            this.radioButtonMangas.Location = new System.Drawing.Point(10, 157);
            this.radioButtonMangas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonMangas.Name = "radioButtonMangas";
            this.radioButtonMangas.Size = new System.Drawing.Size(91, 24);
            this.radioButtonMangas.TabIndex = 3;
            this.radioButtonMangas.TabStop = true;
            this.radioButtonMangas.Text = "Mangas";
            this.radioButtonMangas.UseVisualStyleBackColor = true;
            this.radioButtonMangas.CheckedChanged += new System.EventHandler(this.radioButtonMangas_CheckedChanged);
            // 
            // radioButtonSeries
            // 
            this.radioButtonSeries.AutoSize = true;
            this.radioButtonSeries.Location = new System.Drawing.Point(10, 120);
            this.radioButtonSeries.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonSeries.Name = "radioButtonSeries";
            this.radioButtonSeries.Size = new System.Drawing.Size(79, 24);
            this.radioButtonSeries.TabIndex = 2;
            this.radioButtonSeries.TabStop = true;
            this.radioButtonSeries.Text = "Series";
            this.radioButtonSeries.UseVisualStyleBackColor = true;
            this.radioButtonSeries.CheckedChanged += new System.EventHandler(this.radioButtonSeries_CheckedChanged);
            // 
            // radioButtonFilms
            // 
            this.radioButtonFilms.AutoSize = true;
            this.radioButtonFilms.Location = new System.Drawing.Point(10, 83);
            this.radioButtonFilms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonFilms.Name = "radioButtonFilms";
            this.radioButtonFilms.Size = new System.Drawing.Size(96, 24);
            this.radioButtonFilms.TabIndex = 1;
            this.radioButtonFilms.Text = "Peliculas";
            this.radioButtonFilms.UseVisualStyleBackColor = true;
            this.radioButtonFilms.CheckedChanged += new System.EventHandler(this.radioButtonFilms_CheckedChanged);
            // 
            // radioButtonGames
            // 
            this.radioButtonGames.AutoSize = true;
            this.radioButtonGames.Checked = true;
            this.radioButtonGames.Location = new System.Drawing.Point(10, 46);
            this.radioButtonGames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonGames.Name = "radioButtonGames";
            this.radioButtonGames.Size = new System.Drawing.Size(86, 24);
            this.radioButtonGames.TabIndex = 0;
            this.radioButtonGames.TabStop = true;
            this.radioButtonGames.Text = "Juegos";
            this.radioButtonGames.UseVisualStyleBackColor = true;
            this.radioButtonGames.CheckedChanged += new System.EventHandler(this.radioButtonGames_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.buttonContinueName);
            this.tabPage2.Controls.Add(this.dataGridViewNames);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1128, 696);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Confirmar Nombre";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Puedes cambiar el nombre de los elementos ahora";
            // 
            // buttonContinueName
            // 
            this.buttonContinueName.Location = new System.Drawing.Point(993, 622);
            this.buttonContinueName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonContinueName.Name = "buttonContinueName";
            this.buttonContinueName.Size = new System.Drawing.Size(112, 35);
            this.buttonContinueName.TabIndex = 6;
            this.buttonContinueName.Text = "Continuar";
            this.buttonContinueName.UseVisualStyleBackColor = true;
            this.buttonContinueName.Click += new System.EventHandler(this.buttonContinueName_Click);
            // 
            // dataGridViewNames
            // 
            this.dataGridViewNames.AllowUserToAddRows = false;
            this.dataGridViewNames.AllowUserToDeleteRows = false;
            this.dataGridViewNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnDir});
            this.dataGridViewNames.Location = new System.Drawing.Point(40, 66);
            this.dataGridViewNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewNames.MultiSelect = false;
            this.dataGridViewNames.Name = "dataGridViewNames";
            this.dataGridViewNames.RowHeadersVisible = false;
            this.dataGridViewNames.RowHeadersWidth = 62;
            this.dataGridViewNames.Size = new System.Drawing.Size(1050, 546);
            this.dataGridViewNames.TabIndex = 5;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Nombre a buscar";
            this.ColumnName.MinimumWidth = 8;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 200;
            // 
            // ColumnDir
            // 
            this.ColumnDir.HeaderText = "Ruta";
            this.ColumnDir.MinimumWidth = 8;
            this.ColumnDir.Name = "ColumnDir";
            this.ColumnDir.ReadOnly = true;
            this.ColumnDir.Width = 496;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labelCoverArraySelected);
            this.tabPage3.Controls.Add(this.buttonCoverBack);
            this.tabPage3.Controls.Add(this.buttonCoverNext);
            this.tabPage3.Controls.Add(this.buttonFinish);
            this.tabPage3.Controls.Add(this.dataGridViewCovers);
            this.tabPage3.Controls.Add(this.pictureBoxCover);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(1128, 696);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Descargar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labelCoverArraySelected
            // 
            this.labelCoverArraySelected.AutoSize = true;
            this.labelCoverArraySelected.Location = new System.Drawing.Point(878, 542);
            this.labelCoverArraySelected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCoverArraySelected.Name = "labelCoverArraySelected";
            this.labelCoverArraySelected.Size = new System.Drawing.Size(31, 20);
            this.labelCoverArraySelected.TabIndex = 8;
            this.labelCoverArraySelected.Text = "1/1";
            // 
            // buttonCoverBack
            // 
            this.buttonCoverBack.Location = new System.Drawing.Point(789, 532);
            this.buttonCoverBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCoverBack.Name = "buttonCoverBack";
            this.buttonCoverBack.Size = new System.Drawing.Size(38, 38);
            this.buttonCoverBack.TabIndex = 7;
            this.buttonCoverBack.Text = "<";
            this.buttonCoverBack.UseVisualStyleBackColor = true;
            this.buttonCoverBack.Click += new System.EventHandler(this.buttonCoverBack_Click);
            // 
            // buttonCoverNext
            // 
            this.buttonCoverNext.Location = new System.Drawing.Point(962, 532);
            this.buttonCoverNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCoverNext.Name = "buttonCoverNext";
            this.buttonCoverNext.Size = new System.Drawing.Size(38, 38);
            this.buttonCoverNext.TabIndex = 6;
            this.buttonCoverNext.Text = ">";
            this.buttonCoverNext.UseVisualStyleBackColor = true;
            this.buttonCoverNext.Click += new System.EventHandler(this.buttonCoverNext_Click);
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(1002, 622);
            this.buttonFinish.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(112, 35);
            this.buttonFinish.TabIndex = 5;
            this.buttonFinish.Text = "Finalizar";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // dataGridViewCovers
            // 
            this.dataGridViewCovers.AllowUserToAddRows = false;
            this.dataGridViewCovers.AllowUserToDeleteRows = false;
            this.dataGridViewCovers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCovers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.ColumnCount,
            this.ColumnSelected});
            this.dataGridViewCovers.Location = new System.Drawing.Point(24, 45);
            this.dataGridViewCovers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewCovers.MultiSelect = false;
            this.dataGridViewCovers.Name = "dataGridViewCovers";
            this.dataGridViewCovers.RowHeadersWidth = 62;
            this.dataGridViewCovers.Size = new System.Drawing.Size(600, 546);
            this.dataGridViewCovers.TabIndex = 4;
            this.dataGridViewCovers.SelectionChanged += new System.EventHandler(this.dataGridViewCovers_SelectionChanged);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 8;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 226;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Encontrados";
            this.ColumnCount.MinimumWidth = 8;
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.ReadOnly = true;
            this.ColumnCount.Width = 70;
            // 
            // ColumnSelected
            // 
            this.ColumnSelected.HeaderText = "Elegido";
            this.ColumnSelected.MinimumWidth = 8;
            this.ColumnSelected.Name = "ColumnSelected";
            this.ColumnSelected.ReadOnly = true;
            this.ColumnSelected.Width = 60;
            // 
            // radioButtonComics
            // 
            this.radioButtonComics.AutoSize = true;
            this.radioButtonComics.Location = new System.Drawing.Point(10, 190);
            this.radioButtonComics.Name = "radioButtonComics";
            this.radioButtonComics.Size = new System.Drawing.Size(86, 24);
            this.radioButtonComics.TabIndex = 4;
            this.radioButtonComics.TabStop = true;
            this.radioButtonComics.Text = "Comics";
            this.radioButtonComics.UseVisualStyleBackColor = true;
            this.radioButtonComics.CheckedChanged += new System.EventHandler(this.radioButtonComics_CheckedChanged);
            // 
            // SearchCoversOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 729);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SearchCoversOnline";
            this.Text = "SearchCoversOnline";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNames)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCovers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonContinueType;
        private System.Windows.Forms.RadioButton radioButtonFilms;
        private System.Windows.Forms.RadioButton radioButtonGames;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.DataGridView dataGridViewCovers;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonContinueName;
        private System.Windows.Forms.DataGridView dataGridViewNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCoverBack;
        private System.Windows.Forms.Button buttonCoverNext;
        private System.Windows.Forms.Label labelCoverArraySelected;
        private System.Windows.Forms.RadioButton radioButtonMangas;
        private System.Windows.Forms.RadioButton radioButtonSeries;
        private System.Windows.Forms.RadioButton radioButtonComics;
    }
}