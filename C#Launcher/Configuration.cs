using System;
using System.Windows.Forms;
using System.Xml;
using C_Launcher.Clases;
using CoverPadLauncher.Clases;

namespace CoverPadLauncher
{
    public partial class Configuration : Form
    {
        private string xmlSettingsPath = "System\\Settings.xml";
        //almaceno todas las configuraciones ya que se iran ocupando a medida que este la ventana abierta
        private Settings settings;

        public Configuration()
        {
            InitializeComponent();
            settings = loadSettingsXML();
            CustomComponents();
        }
        private void CustomComponents()
        {
            checkBoxPictureBoxRectangle.Checked = settings.PictureBoxName;
        }

        private Settings loadSettingsXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlSettingsPath);

            string xpath = "//Launcher/Settings";

            XmlNode root = doc.SelectSingleNode(xpath);

            int themeID = int.Parse(XMLDefaultReturn(root, "ThemeID", "0"));
            bool pictureBoxName = bool.Parse(XMLDefaultReturn(root, "boxName", "false"));

            Settings returnSet = new Settings(themeID, pictureBoxName);

            return returnSet;
        }

        private string XMLDefaultReturn(XmlNode node, string singleNode, string defaultValue)
        {
            XmlNode selectedNode = node.SelectSingleNode(singleNode);
            if (selectedNode != null)
            {
                return selectedNode.InnerText;
            }
            return defaultValue;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxPictureBoxRectangle_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
