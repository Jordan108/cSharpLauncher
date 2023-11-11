using System;
using System.Windows.Forms;
using CoverPadLauncher.Clases;

namespace CoverPadLauncher
{
    public partial class Configuration : Form
    {
        //private string xmlSettingsPath = "System\\Settings.xml";
        //almaceno todas las configuraciones ya que se iran ocupando a medida que este la ventana abierta
        private Configurations settings;
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
    }
}
