namespace C_Launcher
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
            this.pictureBoxCoverSon = new System.Windows.Forms.PictureBox();
            this.dataGridViewResolutions = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageLayout = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panelSonImageLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverSon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResolutions)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSearchSonCoverTest
            // 
            this.buttonSearchSonCoverTest.Location = new System.Drawing.Point(557, 109);
            this.buttonSearchSonCoverTest.Name = "buttonSearchSonCoverTest";
            this.buttonSearchSonCoverTest.Size = new System.Drawing.Size(170, 23);
            this.buttonSearchSonCoverTest.TabIndex = 17;
            this.buttonSearchSonCoverTest.Text = "Seleccionar Caratula de prueba";
            this.buttonSearchSonCoverTest.UseVisualStyleBackColor = true;
            this.buttonSearchSonCoverTest.Click += new System.EventHandler(this.buttonSearchSonCoverTest_Click);
            // 
            // panelSonImageLimit
            // 
            this.panelSonImageLimit.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSonImageLimit.Controls.Add(this.pictureBoxCoverSon);
            this.panelSonImageLimit.Location = new System.Drawing.Point(494, 138);
            this.panelSonImageLimit.Name = "panelSonImageLimit";
            this.panelSonImageLimit.Size = new System.Drawing.Size(300, 300);
            this.panelSonImageLimit.TabIndex = 16;
            // 
            // pictureBoxCoverSon
            // 
            this.pictureBoxCoverSon.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxCoverSon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCoverSon.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCoverSon.Name = "pictureBoxCoverSon";
            this.pictureBoxCoverSon.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxCoverSon.TabIndex = 0;
            this.pictureBoxCoverSon.TabStop = false;
            // 
            // dataGridViewResolutions
            // 
            this.dataGridViewResolutions.AllowUserToResizeColumns = false;
            this.dataGridViewResolutions.AllowUserToResizeRows = false;
            this.dataGridViewResolutions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResolutions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.width,
            this.height,
            this.imageLayout});
            this.dataGridViewResolutions.Location = new System.Drawing.Point(12, 138);
            this.dataGridViewResolutions.Name = "dataGridViewResolutions";
            this.dataGridViewResolutions.Size = new System.Drawing.Size(445, 300);
            this.dataGridViewResolutions.TabIndex = 18;
            this.dataGridViewResolutions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewResolutions_CellClick);
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
            // imageLayout
            // 
            this.imageLayout.HeaderText = "Formato";
            this.imageLayout.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.imageLayout.Name = "imageLayout";
            // 
            // Resolutions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewResolutions);
            this.Controls.Add(this.buttonSearchSonCoverTest);
            this.Controls.Add(this.panelSonImageLimit);
            this.Name = "Resolutions";
            this.Text = "Resolutions";
            this.panelSonImageLimit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverSon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResolutions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearchSonCoverTest;
        private System.Windows.Forms.Panel panelSonImageLimit;
        private System.Windows.Forms.PictureBox pictureBoxCoverSon;
        private System.Windows.Forms.DataGridView dataGridViewResolutions;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn width;
        private System.Windows.Forms.DataGridViewTextBoxColumn height;
        private System.Windows.Forms.DataGridViewComboBoxColumn imageLayout;
    }
}