using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CoverPadLauncher.Clases;

namespace CoverPadLauncher
{
    public partial class Configuration : Form
    {
        //private string xmlSettingsPath = "System\\Settings.xml";
        //almaceno todas las configuraciones ya que se iran ocupando a medida que este la ventana abierta
        private Configurations settings;
        private string themeDir = "System\\Themes";
        public event EventHandler<Configurations> ReturnedObject;

        public Configuration(Configurations _settings)
        {
            InitializeComponent();
            settings = _settings;

            //Settings classSettings = new Settings();
            //settings = classSettings.LoadSettings();
            CustomComponents();
        }
        private void CustomComponents()
        {
            Console.WriteLine($"Settings: {settings.PictureBoxName}");
            checkBoxPictureBoxRectangle.Checked = settings.PictureBoxName;
            checkBoxUpdateCheck.Checked = settings.StartUpdate;
            loadWindowTheme();
            loadThemes();

            //Cargar el tema en el combobox
            comboBoxThemes.SelectedItem = settings.ThemeName;
        }

        //Cargar los temas existentes para el combobox
        private void loadThemes()
        {
            if (Directory.Exists(themeDir))
            {
                // Obtiene una lista de todos los archivos  en la carpeta
                string[] archivos = Directory.GetFiles(themeDir);
                //Filtra y obtiene solo los archivos css
                string[] filter = archivos.Where(x => x.EndsWith(".css")).ToArray();

                foreach (string theme in filter)
                {
                    comboBoxThemes.Items.Add(Path.GetFileNameWithoutExtension(theme));
                }
            }
        }

        private void loadWindowTheme()
        {
            Configurations config = new Configurations();
            Themes theme = new Themes($"System\\Themes\\{config.ThemeName}.css");

            BackColor = theme.WindowBackground;

            //Texto
            labelTheme.ForeColor = theme.LabelText;
            checkBoxPictureBoxRectangle.ForeColor = theme.LabelText;

            //Combobox
            comboBoxThemes.BackColor = theme.ComboboxBackground;
            comboBoxThemes.ForeColor = theme.ComboboxText;
            checkBoxUpdateCheck.BackColor = theme.ComboboxBackground;
            checkBoxUpdateCheck.ForeColor = theme.ComboboxText;

            //Botones
            buttonSave.BackColor = theme.ButtonBackground;
            buttonSave.ForeColor = theme.ButtonText;
            buttonCancel.BackColor = theme.ButtonBackground;
            buttonCancel.ForeColor = theme.ButtonText;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Se guardan los cambios en el xml
            Configurations classConfig = new Configurations();
            classConfig.SaveConfigurations(settings);

            //Tambien le pasamos los cambios al home
            ReturnedObject?.Invoke(this, settings);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxPictureBoxRectangle_CheckedChanged(object sender, EventArgs e)
        {
            //actualizar settings
            settings.PictureBoxName = checkBoxPictureBoxRectangle.Checked;
        }

        private void comboBoxThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Actualizar el tema
            settings.ThemeName = comboBoxThemes.GetItemText(comboBoxThemes.SelectedItem);
        }

        private void checkBoxUpdateCheck_CheckedChanged(object sender, EventArgs e)
        {
            //Actualizar settings
            settings.StartUpdate = checkBoxUpdateCheck.Checked;
        }
    }
}
