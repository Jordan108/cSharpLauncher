namespace CoverPadLauncher
{
    partial class Configuration
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelTheme = new System.Windows.Forms.Label();
            this.comboBoxThemes = new System.Windows.Forms.ComboBox();
            this.checkBoxPictureBoxRectangle = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSave.Location = new System.Drawing.Point(585, 415);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(122, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Aplicar y Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonCancel.Location = new System.Drawing.Point(713, 415);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelTheme
            // 
            this.labelTheme.AutoSize = true;
            this.labelTheme.ForeColor = System.Drawing.SystemColors.Window;
            this.labelTheme.Location = new System.Drawing.Point(13, 47);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(40, 13);
            this.labelTheme.TabIndex = 2;
            this.labelTheme.Text = "Tema: ";
            // 
            // comboBoxThemes
            // 
            this.comboBoxThemes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.comboBoxThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThemes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxThemes.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxThemes.FormattingEnabled = true;
            this.comboBoxThemes.Location = new System.Drawing.Point(59, 45);
            this.comboBoxThemes.Name = "comboBoxThemes";
            this.comboBoxThemes.Size = new System.Drawing.Size(203, 21);
            this.comboBoxThemes.TabIndex = 3;
            this.comboBoxThemes.SelectedIndexChanged += new System.EventHandler(this.comboBoxThemes_SelectedIndexChanged);
            // 
            // checkBoxPictureBoxRectangle
            // 
            this.checkBoxPictureBoxRectangle.AutoSize = true;
            this.checkBoxPictureBoxRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxPictureBoxRectangle.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBoxPictureBoxRectangle.Location = new System.Drawing.Point(16, 72);
            this.checkBoxPictureBoxRectangle.Name = "checkBoxPictureBoxRectangle";
            this.checkBoxPictureBoxRectangle.Size = new System.Drawing.Size(290, 17);
            this.checkBoxPictureBoxRectangle.TabIndex = 4;
            this.checkBoxPictureBoxRectangle.Text = "Mostrar siempre el nombre de los elementos/colecciones";
            this.checkBoxPictureBoxRectangle.UseVisualStyleBackColor = true;
            this.checkBoxPictureBoxRectangle.CheckedChanged += new System.EventHandler(this.checkBoxPictureBoxRectangle_CheckedChanged);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxPictureBoxRectangle);
            this.Controls.Add(this.comboBoxThemes);
            this.Controls.Add(this.labelTheme);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Configuration";
            this.Text = "Configuración";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTheme;
        private System.Windows.Forms.ComboBox comboBoxThemes;
        private System.Windows.Forms.CheckBox checkBoxPictureBoxRectangle;
    }
}