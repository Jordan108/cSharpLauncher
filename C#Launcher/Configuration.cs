using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using C_Launcher.Clases;
using CoverPadLauncher.Clases;

namespace CoverPadLauncher
{
    public partial class Configuration : Form
    {
        //private string xmlSettingsPath = "System\\Settings.xml";
        //almaceno todas las configuraciones ya que se iran ocupando a medida que este la ventana abierta
        private Settings settings;

        public Configuration()
        {
            InitializeComponent();
            settings = new Settings();

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
            Settings classSettings = new Settings();
            classSettings.SaveSettings(settings);

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
