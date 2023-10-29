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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tabPageSistema = new System.Windows.Forms.TabPage();
            this.tabPageInterfaz = new System.Windows.Forms.TabPage();
            this.labelInterfazTema = new System.Windows.Forms.Label();
            this.comboBoxInterfazTema = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tabPageInterfaz.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(123)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSave.Location = new System.Drawing.Point(632, 415);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Guardar";
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageSistema);
            this.tabControl.Controls.Add(this.tabPageInterfaz);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 397);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.tabPageGeneral.ForeColor = System.Drawing.SystemColors.Window;
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(768, 371);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            // 
            // tabPageSistema
            // 
            this.tabPageSistema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.tabPageSistema.ForeColor = System.Drawing.SystemColors.Window;
            this.tabPageSistema.Location = new System.Drawing.Point(4, 22);
            this.tabPageSistema.Name = "tabPageSistema";
            this.tabPageSistema.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSistema.Size = new System.Drawing.Size(768, 371);
            this.tabPageSistema.TabIndex = 1;
            this.tabPageSistema.Text = "Sistema";
            // 
            // tabPageInterfaz
            // 
            this.tabPageInterfaz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.tabPageInterfaz.Controls.Add(this.comboBoxInterfazTema);
            this.tabPageInterfaz.Controls.Add(this.labelInterfazTema);
            this.tabPageInterfaz.ForeColor = System.Drawing.SystemColors.Window;
            this.tabPageInterfaz.Location = new System.Drawing.Point(4, 22);
            this.tabPageInterfaz.Name = "tabPageInterfaz";
            this.tabPageInterfaz.Size = new System.Drawing.Size(768, 371);
            this.tabPageInterfaz.TabIndex = 2;
            this.tabPageInterfaz.Text = "Interfaz";
            // 
            // labelInterfazTema
            // 
            this.labelInterfazTema.AutoSize = true;
            this.labelInterfazTema.Location = new System.Drawing.Point(18, 30);
            this.labelInterfazTema.Name = "labelInterfazTema";
            this.labelInterfazTema.Size = new System.Drawing.Size(37, 13);
            this.labelInterfazTema.TabIndex = 0;
            this.labelInterfazTema.Text = "Tema:";
            // 
            // comboBoxInterfazTema
            // 
            this.comboBoxInterfazTema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterfazTema.FormattingEnabled = true;
            this.comboBoxInterfazTema.Items.AddRange(new object[] {
            "Oscuro",
            "Claro"});
            this.comboBoxInterfazTema.Location = new System.Drawing.Point(72, 27);
            this.comboBoxInterfazTema.Name = "comboBoxInterfazTema";
            this.comboBoxInterfazTema.Size = new System.Drawing.Size(152, 21);
            this.comboBoxInterfazTema.TabIndex = 1;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Name = "Configuration";
            this.Text = "Configuración";
            this.tabControl.ResumeLayout(false);
            this.tabPageInterfaz.ResumeLayout(false);
            this.tabPageInterfaz.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageSistema;
        private System.Windows.Forms.TabPage tabPageInterfaz;
        private System.Windows.Forms.ComboBox comboBoxInterfazTema;
        private System.Windows.Forms.Label labelInterfazTema;
    }
}