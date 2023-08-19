﻿namespace C_Launcher
{
    partial class Resolution
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
            this.buttonSearchSonCoverTest = new System.Windows.Forms.Button();
            this.panelSonImageLimit = new System.Windows.Forms.Panel();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.dataGridViewResolutions = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.buttonSaveRes = new System.Windows.Forms.Button();
            this.panelSonImageLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResolutions)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSearchSonCoverTest
            // 
            this.buttonSearchSonCoverTest.Location = new System.Drawing.Point(448, 12);
            this.buttonSearchSonCoverTest.Name = "buttonSearchSonCoverTest";
            this.buttonSearchSonCoverTest.Size = new System.Drawing.Size(170, 23);
            this.buttonSearchSonCoverTest.TabIndex = 17;
            this.buttonSearchSonCoverTest.Text = "Seleccionar Caratula de prueba";
            this.buttonSearchSonCoverTest.UseVisualStyleBackColor = true;
            this.buttonSearchSonCoverTest.Click += new System.EventHandler(this.buttonSearchSonCoverTest_Click);
            // 
            // panelSonImageLimit
            // 
            this.panelSonImageLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.panelSonImageLimit.Controls.Add(this.pictureBoxCover);
            this.panelSonImageLimit.Location = new System.Drawing.Point(371, 41);
            this.panelSonImageLimit.Name = "panelSonImageLimit";
            this.panelSonImageLimit.Size = new System.Drawing.Size(300, 300);
            this.panelSonImageLimit.TabIndex = 16;
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCover.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxCover.TabIndex = 0;
            this.pictureBoxCover.TabStop = false;
            this.pictureBoxCover.MouseLeave += new System.EventHandler(this.pictureBoxCover_MouseLeave);
            // 
            // dataGridViewResolutions
            // 
            this.dataGridViewResolutions.AllowUserToAddRows = false;
            this.dataGridViewResolutions.AllowUserToDeleteRows = false;
            this.dataGridViewResolutions.AllowUserToResizeColumns = false;
            this.dataGridViewResolutions.AllowUserToResizeRows = false;
            this.dataGridViewResolutions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.dataGridViewResolutions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResolutions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.width,
            this.height});
            this.dataGridViewResolutions.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewResolutions.MultiSelect = false;
            this.dataGridViewResolutions.Name = "dataGridViewResolutions";
            this.dataGridViewResolutions.Size = new System.Drawing.Size(344, 300);
            this.dataGridViewResolutions.TabIndex = 18;
            this.dataGridViewResolutions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewResolutions_CellClick);
            this.dataGridViewResolutions.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewResolutions_CellEndEdit);
            // 
            // name
            // 
            this.name.HeaderText = "Nombre";
            this.name.Name = "name";
            this.name.Width = 200;
            // 
            // width
            // 
            this.width.HeaderText = "Ancho";
            this.width.MaxInputLength = 3;
            this.width.Name = "width";
            this.width.Width = 50;
            // 
            // height
            // 
            this.height.HeaderText = "Alto";
            this.height.MaxInputLength = 3;
            this.height.Name = "height";
            this.height.Width = 50;
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(12, 12);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(75, 23);
            this.buttonAddRow.TabIndex = 19;
            this.buttonAddRow.Text = "Añadir";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Location = new System.Drawing.Point(93, 12);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteRow.TabIndex = 20;
            this.buttonDeleteRow.Text = "Eliminar";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // buttonSaveRes
            // 
            this.buttonSaveRes.Location = new System.Drawing.Point(12, 349);
            this.buttonSaveRes.Name = "buttonSaveRes";
            this.buttonSaveRes.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveRes.TabIndex = 21;
            this.buttonSaveRes.Text = "Guardar";
            this.buttonSaveRes.UseVisualStyleBackColor = true;
            this.buttonSaveRes.Click += new System.EventHandler(this.buttonSaveRes_Click);
            // 
            // Resolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(677, 380);
            this.Controls.Add(this.buttonSaveRes);
            this.Controls.Add(this.buttonDeleteRow);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.dataGridViewResolutions);
            this.Controls.Add(this.buttonSearchSonCoverTest);
            this.Controls.Add(this.panelSonImageLimit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Resolution";
            this.Text = "Resolutions";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Resolution_FormClosed);
            this.panelSonImageLimit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResolutions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearchSonCoverTest;
        private System.Windows.Forms.Panel panelSonImageLimit;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.DataGridView dataGridViewResolutions;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonDeleteRow;
        private System.Windows.Forms.Button buttonSaveRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn width;
        private System.Windows.Forms.DataGridViewTextBoxColumn height;
    }
}