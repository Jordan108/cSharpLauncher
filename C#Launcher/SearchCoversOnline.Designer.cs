﻿namespace CoverPadLauncher
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
            this.labelApi = new System.Windows.Forms.Label();
            this.groupBoxSteamDBRes = new System.Windows.Forms.GroupBox();
            this.radioButton1024x1024 = new System.Windows.Forms.RadioButton();
            this.radioButton512x512 = new System.Windows.Forms.RadioButton();
            this.radioButton660x930 = new System.Windows.Forms.RadioButton();
            this.radioButton342x482 = new System.Windows.Forms.RadioButton();
            this.radioButton920x430 = new System.Windows.Forms.RadioButton();
            this.radioButton460x215 = new System.Windows.Forms.RadioButton();
            this.radioButton600x900 = new System.Windows.Forms.RadioButton();
            this.buttonContinueType = new System.Windows.Forms.Button();
            this.groupBoxApi = new System.Windows.Forms.GroupBox();
            this.radioButtonBooks = new System.Windows.Forms.RadioButton();
            this.radioButtonComics = new System.Windows.Forms.RadioButton();
            this.radioButtonMangas = new System.Windows.Forms.RadioButton();
            this.radioButtonSeries = new System.Windows.Forms.RadioButton();
            this.radioButtonFilms = new System.Windows.Forms.RadioButton();
            this.radioButtonGames = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.labelChangeNameWarning = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxSteamDBRes.SuspendLayout();
            this.groupBoxApi.SuspendLayout();
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
            this.pictureBoxCover.Location = new System.Drawing.Point(443, 29);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxCover.TabIndex = 3;
            this.pictureBoxCover.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(-5, -25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(757, 510);
            this.tabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelApi);
            this.tabPage1.Controls.Add(this.groupBoxSteamDBRes);
            this.tabPage1.Controls.Add(this.buttonContinueType);
            this.tabPage1.Controls.Add(this.groupBoxApi);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(749, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tipo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelApi
            // 
            this.labelApi.AutoSize = true;
            this.labelApi.Location = new System.Drawing.Point(6, 3);
            this.labelApi.Name = "labelApi";
            this.labelApi.Size = new System.Drawing.Size(191, 13);
            this.labelApi.TabIndex = 3;
            this.labelApi.Text = "Api suministrada por SteamGridDB.com";
            this.labelApi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxSteamDBRes
            // 
            this.groupBoxSteamDBRes.Controls.Add(this.radioButton1024x1024);
            this.groupBoxSteamDBRes.Controls.Add(this.radioButton512x512);
            this.groupBoxSteamDBRes.Controls.Add(this.radioButton660x930);
            this.groupBoxSteamDBRes.Controls.Add(this.radioButton342x482);
            this.groupBoxSteamDBRes.Controls.Add(this.radioButton920x430);
            this.groupBoxSteamDBRes.Controls.Add(this.radioButton460x215);
            this.groupBoxSteamDBRes.Controls.Add(this.radioButton600x900);
            this.groupBoxSteamDBRes.Location = new System.Drawing.Point(418, 105);
            this.groupBoxSteamDBRes.Name = "groupBoxSteamDBRes";
            this.groupBoxSteamDBRes.Size = new System.Drawing.Size(281, 192);
            this.groupBoxSteamDBRes.TabIndex = 2;
            this.groupBoxSteamDBRes.TabStop = false;
            this.groupBoxSteamDBRes.Text = "Resoluciones";
            // 
            // radioButton1024x1024
            // 
            this.radioButton1024x1024.AutoSize = true;
            this.radioButton1024x1024.Location = new System.Drawing.Point(7, 162);
            this.radioButton1024x1024.Name = "radioButton1024x1024";
            this.radioButton1024x1024.Size = new System.Drawing.Size(158, 17);
            this.radioButton1024x1024.TabIndex = 6;
            this.radioButton1024x1024.Text = "1024x1024 (Cuadricular 1:1)";
            this.radioButton1024x1024.UseVisualStyleBackColor = true;
            this.radioButton1024x1024.CheckedChanged += new System.EventHandler(this.radioButton1024x1024_CheckedChanged);
            // 
            // radioButton512x512
            // 
            this.radioButton512x512.AutoSize = true;
            this.radioButton512x512.Location = new System.Drawing.Point(7, 139);
            this.radioButton512x512.Name = "radioButton512x512";
            this.radioButton512x512.Size = new System.Drawing.Size(146, 17);
            this.radioButton512x512.TabIndex = 5;
            this.radioButton512x512.Text = "512x512 (Cuadricular 1:1)";
            this.radioButton512x512.UseVisualStyleBackColor = true;
            this.radioButton512x512.CheckedChanged += new System.EventHandler(this.radioButton512x512_CheckedChanged);
            // 
            // radioButton660x930
            // 
            this.radioButton660x930.AutoSize = true;
            this.radioButton660x930.Location = new System.Drawing.Point(7, 115);
            this.radioButton660x930.Name = "radioButton660x930";
            this.radioButton660x930.Size = new System.Drawing.Size(155, 17);
            this.radioButton660x930.TabIndex = 4;
            this.radioButton660x930.Text = "660x930 (Galaxy 2.0 22:31)";
            this.radioButton660x930.UseVisualStyleBackColor = true;
            this.radioButton660x930.CheckedChanged += new System.EventHandler(this.radioButton660x930_CheckedChanged);
            // 
            // radioButton342x482
            // 
            this.radioButton342x482.AutoSize = true;
            this.radioButton342x482.Location = new System.Drawing.Point(7, 91);
            this.radioButton342x482.Name = "radioButton342x482";
            this.radioButton342x482.Size = new System.Drawing.Size(155, 17);
            this.radioButton342x482.TabIndex = 3;
            this.radioButton342x482.Text = "342x482 (Galaxy 2.0 22:31)";
            this.radioButton342x482.UseVisualStyleBackColor = true;
            this.radioButton342x482.CheckedChanged += new System.EventHandler(this.radioButton342x482_CheckedChanged);
            // 
            // radioButton920x430
            // 
            this.radioButton920x430.AutoSize = true;
            this.radioButton920x430.Location = new System.Drawing.Point(7, 67);
            this.radioButton920x430.Name = "radioButton920x430";
            this.radioButton920x430.Size = new System.Drawing.Size(152, 17);
            this.radioButton920x430.TabIndex = 2;
            this.radioButton920x430.Text = "920x430 (Horizontal 92:43)";
            this.radioButton920x430.UseVisualStyleBackColor = true;
            this.radioButton920x430.CheckedChanged += new System.EventHandler(this.radioButton920x430_CheckedChanged);
            // 
            // radioButton460x215
            // 
            this.radioButton460x215.AutoSize = true;
            this.radioButton460x215.Location = new System.Drawing.Point(7, 44);
            this.radioButton460x215.Name = "radioButton460x215";
            this.radioButton460x215.Size = new System.Drawing.Size(152, 17);
            this.radioButton460x215.TabIndex = 1;
            this.radioButton460x215.Text = "460x215 (Horizontal 92:43)";
            this.radioButton460x215.UseVisualStyleBackColor = true;
            this.radioButton460x215.CheckedChanged += new System.EventHandler(this.radioButton460x215_CheckedChanged);
            // 
            // radioButton600x900
            // 
            this.radioButton600x900.AutoSize = true;
            this.radioButton600x900.Checked = true;
            this.radioButton600x900.Location = new System.Drawing.Point(7, 20);
            this.radioButton600x900.Name = "radioButton600x900";
            this.radioButton600x900.Size = new System.Drawing.Size(128, 17);
            this.radioButton600x900.TabIndex = 0;
            this.radioButton600x900.TabStop = true;
            this.radioButton600x900.Text = "600x900 (Vertical 2:3)";
            this.radioButton600x900.UseVisualStyleBackColor = true;
            this.radioButton600x900.CheckedChanged += new System.EventHandler(this.radioButton600x900_CheckedChanged);
            // 
            // buttonContinueType
            // 
            this.buttonContinueType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContinueType.Location = new System.Drawing.Point(668, 417);
            this.buttonContinueType.Name = "buttonContinueType";
            this.buttonContinueType.Size = new System.Drawing.Size(75, 23);
            this.buttonContinueType.TabIndex = 1;
            this.buttonContinueType.Text = "Continuar";
            this.buttonContinueType.UseVisualStyleBackColor = true;
            this.buttonContinueType.Click += new System.EventHandler(this.buttonContinueType_Click);
            // 
            // groupBoxApi
            // 
            this.groupBoxApi.Controls.Add(this.radioButtonBooks);
            this.groupBoxApi.Controls.Add(this.radioButtonComics);
            this.groupBoxApi.Controls.Add(this.radioButtonMangas);
            this.groupBoxApi.Controls.Add(this.radioButtonSeries);
            this.groupBoxApi.Controls.Add(this.radioButtonFilms);
            this.groupBoxApi.Controls.Add(this.radioButtonGames);
            this.groupBoxApi.Location = new System.Drawing.Point(25, 105);
            this.groupBoxApi.Name = "groupBoxApi";
            this.groupBoxApi.Size = new System.Drawing.Size(200, 180);
            this.groupBoxApi.TabIndex = 0;
            this.groupBoxApi.TabStop = false;
            this.groupBoxApi.Text = "¿Que estas importando?";
            // 
            // radioButtonBooks
            // 
            this.radioButtonBooks.AutoSize = true;
            this.radioButtonBooks.Location = new System.Drawing.Point(7, 146);
            this.radioButtonBooks.Name = "radioButtonBooks";
            this.radioButtonBooks.Size = new System.Drawing.Size(53, 17);
            this.radioButtonBooks.TabIndex = 5;
            this.radioButtonBooks.TabStop = true;
            this.radioButtonBooks.Text = "Libros";
            this.radioButtonBooks.UseVisualStyleBackColor = true;
            this.radioButtonBooks.CheckedChanged += new System.EventHandler(this.radioButtonBooks_CheckedChanged);
            // 
            // radioButtonComics
            // 
            this.radioButtonComics.AutoSize = true;
            this.radioButtonComics.Location = new System.Drawing.Point(7, 123);
            this.radioButtonComics.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonComics.Name = "radioButtonComics";
            this.radioButtonComics.Size = new System.Drawing.Size(59, 17);
            this.radioButtonComics.TabIndex = 4;
            this.radioButtonComics.TabStop = true;
            this.radioButtonComics.Text = "Comics";
            this.radioButtonComics.UseVisualStyleBackColor = true;
            this.radioButtonComics.CheckedChanged += new System.EventHandler(this.radioButtonComics_CheckedChanged);
            // 
            // radioButtonMangas
            // 
            this.radioButtonMangas.AutoSize = true;
            this.radioButtonMangas.Location = new System.Drawing.Point(7, 102);
            this.radioButtonMangas.Name = "radioButtonMangas";
            this.radioButtonMangas.Size = new System.Drawing.Size(63, 17);
            this.radioButtonMangas.TabIndex = 3;
            this.radioButtonMangas.TabStop = true;
            this.radioButtonMangas.Text = "Mangas";
            this.radioButtonMangas.UseVisualStyleBackColor = true;
            this.radioButtonMangas.CheckedChanged += new System.EventHandler(this.radioButtonMangas_CheckedChanged);
            // 
            // radioButtonSeries
            // 
            this.radioButtonSeries.AutoSize = true;
            this.radioButtonSeries.Location = new System.Drawing.Point(7, 78);
            this.radioButtonSeries.Name = "radioButtonSeries";
            this.radioButtonSeries.Size = new System.Drawing.Size(54, 17);
            this.radioButtonSeries.TabIndex = 2;
            this.radioButtonSeries.TabStop = true;
            this.radioButtonSeries.Text = "Series";
            this.radioButtonSeries.UseVisualStyleBackColor = true;
            this.radioButtonSeries.CheckedChanged += new System.EventHandler(this.radioButtonSeries_CheckedChanged);
            // 
            // radioButtonFilms
            // 
            this.radioButtonFilms.AutoSize = true;
            this.radioButtonFilms.Location = new System.Drawing.Point(7, 54);
            this.radioButtonFilms.Name = "radioButtonFilms";
            this.radioButtonFilms.Size = new System.Drawing.Size(69, 17);
            this.radioButtonFilms.TabIndex = 1;
            this.radioButtonFilms.Text = "Películas";
            this.radioButtonFilms.UseVisualStyleBackColor = true;
            this.radioButtonFilms.CheckedChanged += new System.EventHandler(this.radioButtonFilms_CheckedChanged);
            // 
            // radioButtonGames
            // 
            this.radioButtonGames.AutoSize = true;
            this.radioButtonGames.Checked = true;
            this.radioButtonGames.Location = new System.Drawing.Point(7, 30);
            this.radioButtonGames.Name = "radioButtonGames";
            this.radioButtonGames.Size = new System.Drawing.Size(59, 17);
            this.radioButtonGames.TabIndex = 0;
            this.radioButtonGames.TabStop = true;
            this.radioButtonGames.Text = "Juegos";
            this.radioButtonGames.UseVisualStyleBackColor = true;
            this.radioButtonGames.CheckedChanged += new System.EventHandler(this.radioButtonGames_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.progressBarDownload);
            this.tabPage2.Controls.Add(this.labelChangeNameWarning);
            this.tabPage2.Controls.Add(this.buttonContinueName);
            this.tabPage2.Controls.Add(this.dataGridViewNames);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(749, 453);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Confirmar Nombre";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Location = new System.Drawing.Point(27, 404);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(629, 23);
            this.progressBarDownload.TabIndex = 8;
            this.progressBarDownload.Visible = false;
            // 
            // labelChangeNameWarning
            // 
            this.labelChangeNameWarning.AutoSize = true;
            this.labelChangeNameWarning.Location = new System.Drawing.Point(235, 27);
            this.labelChangeNameWarning.Name = "labelChangeNameWarning";
            this.labelChangeNameWarning.Size = new System.Drawing.Size(244, 13);
            this.labelChangeNameWarning.TabIndex = 7;
            this.labelChangeNameWarning.Text = "Puedes cambiar el nombre de los elementos ahora";
            // 
            // buttonContinueName
            // 
            this.buttonContinueName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContinueName.Location = new System.Drawing.Point(662, 404);
            this.buttonContinueName.Name = "buttonContinueName";
            this.buttonContinueName.Size = new System.Drawing.Size(75, 23);
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
            this.dataGridViewNames.Location = new System.Drawing.Point(27, 43);
            this.dataGridViewNames.MultiSelect = false;
            this.dataGridViewNames.Name = "dataGridViewNames";
            this.dataGridViewNames.RowHeadersVisible = false;
            this.dataGridViewNames.RowHeadersWidth = 62;
            this.dataGridViewNames.Size = new System.Drawing.Size(700, 355);
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
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(749, 467);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Descargar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labelCoverArraySelected
            // 
            this.labelCoverArraySelected.AutoSize = true;
            this.labelCoverArraySelected.Location = new System.Drawing.Point(585, 352);
            this.labelCoverArraySelected.Name = "labelCoverArraySelected";
            this.labelCoverArraySelected.Size = new System.Drawing.Size(24, 13);
            this.labelCoverArraySelected.TabIndex = 8;
            this.labelCoverArraySelected.Text = "1/1";
            // 
            // buttonCoverBack
            // 
            this.buttonCoverBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCoverBack.Location = new System.Drawing.Point(526, 346);
            this.buttonCoverBack.Name = "buttonCoverBack";
            this.buttonCoverBack.Size = new System.Drawing.Size(25, 25);
            this.buttonCoverBack.TabIndex = 7;
            this.buttonCoverBack.Text = "<";
            this.buttonCoverBack.UseVisualStyleBackColor = true;
            this.buttonCoverBack.Click += new System.EventHandler(this.buttonCoverBack_Click);
            // 
            // buttonCoverNext
            // 
            this.buttonCoverNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCoverNext.Location = new System.Drawing.Point(641, 346);
            this.buttonCoverNext.Name = "buttonCoverNext";
            this.buttonCoverNext.Size = new System.Drawing.Size(25, 25);
            this.buttonCoverNext.TabIndex = 6;
            this.buttonCoverNext.Text = ">";
            this.buttonCoverNext.UseVisualStyleBackColor = true;
            this.buttonCoverNext.Click += new System.EventHandler(this.buttonCoverNext_Click);
            // 
            // buttonFinish
            // 
            this.buttonFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFinish.Location = new System.Drawing.Point(668, 404);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(75, 23);
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
            this.dataGridViewCovers.Location = new System.Drawing.Point(16, 29);
            this.dataGridViewCovers.MultiSelect = false;
            this.dataGridViewCovers.Name = "dataGridViewCovers";
            this.dataGridViewCovers.RowHeadersWidth = 62;
            this.dataGridViewCovers.Size = new System.Drawing.Size(400, 355);
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
            // SearchCoversOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 471);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "SearchCoversOnline";
            this.Text = "Buscar caratulas online";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBoxSteamDBRes.ResumeLayout(false);
            this.groupBoxSteamDBRes.PerformLayout();
            this.groupBoxApi.ResumeLayout(false);
            this.groupBoxApi.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxApi;
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
        private System.Windows.Forms.Label labelChangeNameWarning;
        private System.Windows.Forms.Button buttonCoverBack;
        private System.Windows.Forms.Button buttonCoverNext;
        private System.Windows.Forms.Label labelCoverArraySelected;
        private System.Windows.Forms.RadioButton radioButtonMangas;
        private System.Windows.Forms.RadioButton radioButtonSeries;
        private System.Windows.Forms.RadioButton radioButtonComics;
        private System.Windows.Forms.RadioButton radioButtonBooks;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.GroupBox groupBoxSteamDBRes;
        private System.Windows.Forms.RadioButton radioButton1024x1024;
        private System.Windows.Forms.RadioButton radioButton512x512;
        private System.Windows.Forms.RadioButton radioButton660x930;
        private System.Windows.Forms.RadioButton radioButton342x482;
        private System.Windows.Forms.RadioButton radioButton920x430;
        private System.Windows.Forms.RadioButton radioButton460x215;
        private System.Windows.Forms.RadioButton radioButton600x900;
        private System.Windows.Forms.Label labelApi;
    }
}