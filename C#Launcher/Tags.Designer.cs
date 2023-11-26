namespace CoverPadLauncher
{
    partial class Tags
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
            this.dataGridViewTags = new System.Windows.Forms.DataGridView();
            this.textBoxTagName = new System.Windows.Forms.TextBox();
            this.addTag = new System.Windows.Forms.Button();
            this.deleteTag = new System.Windows.Forms.Button();
            this.saveForm = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTags)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTags
            // 
            this.dataGridViewTags.AllowUserToAddRows = false;
            this.dataGridViewTags.AllowUserToDeleteRows = false;
            this.dataGridViewTags.AllowUserToResizeColumns = false;
            this.dataGridViewTags.AllowUserToResizeRows = false;
            this.dataGridViewTags.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.dataGridViewTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewTags.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(37)))));
            this.dataGridViewTags.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewTags.MultiSelect = false;
            this.dataGridViewTags.Name = "dataGridViewTags";
            this.dataGridViewTags.RowHeadersVisible = false;
            this.dataGridViewTags.Size = new System.Drawing.Size(203, 426);
            this.dataGridViewTags.TabIndex = 0;
            this.dataGridViewTags.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTags_CellClick);
            // 
            // textBoxTagName
            // 
            this.textBoxTagName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.textBoxTagName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTagName.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxTagName.Location = new System.Drawing.Point(323, 28);
            this.textBoxTagName.Name = "textBoxTagName";
            this.textBoxTagName.Size = new System.Drawing.Size(154, 20);
            this.textBoxTagName.TabIndex = 1;
            // 
            // addTag
            // 
            this.addTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.addTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTag.ForeColor = System.Drawing.SystemColors.Window;
            this.addTag.Location = new System.Drawing.Point(221, 28);
            this.addTag.Name = "addTag";
            this.addTag.Size = new System.Drawing.Size(96, 22);
            this.addTag.TabIndex = 2;
            this.addTag.Text = "Añadir etiqueta";
            this.addTag.UseVisualStyleBackColor = false;
            this.addTag.Click += new System.EventHandler(this.addTag_Click);
            // 
            // deleteTag
            // 
            this.deleteTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.deleteTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteTag.ForeColor = System.Drawing.SystemColors.Window;
            this.deleteTag.Location = new System.Drawing.Point(221, 56);
            this.deleteTag.Name = "deleteTag";
            this.deleteTag.Size = new System.Drawing.Size(96, 23);
            this.deleteTag.TabIndex = 3;
            this.deleteTag.Text = "Eliminar etiqueta";
            this.deleteTag.UseVisualStyleBackColor = false;
            this.deleteTag.Click += new System.EventHandler(this.deleteTag_Click);
            // 
            // saveForm
            // 
            this.saveForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.saveForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveForm.ForeColor = System.Drawing.SystemColors.Window;
            this.saveForm.Location = new System.Drawing.Point(221, 415);
            this.saveForm.Name = "saveForm";
            this.saveForm.Size = new System.Drawing.Size(75, 23);
            this.saveForm.TabIndex = 4;
            this.saveForm.Text = "Guardar";
            this.saveForm.UseVisualStyleBackColor = false;
            this.saveForm.Click += new System.EventHandler(this.saveForm_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Etiqueta";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 200;
            // 
            // Tags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(485, 450);
            this.Controls.Add(this.saveForm);
            this.Controls.Add(this.deleteTag);
            this.Controls.Add(this.addTag);
            this.Controls.Add(this.textBoxTagName);
            this.Controls.Add(this.dataGridViewTags);
            this.Name = "Tags";
            this.Text = "Tags";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTags;
        private System.Windows.Forms.TextBox textBoxTagName;
        private System.Windows.Forms.Button addTag;
        private System.Windows.Forms.Button deleteTag;
        private System.Windows.Forms.Button saveForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}