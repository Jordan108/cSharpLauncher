using CoverPadLauncher.Properties;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CoverPadLauncher.Clases
{
    public class Configurations
    {
        private string xmlSettingsPath = "System\\Settings.xml";

        //Atributos
        private string themeName;//El id del tema
        private bool pictureBoxName;//Mostrar siempre el rectangulo con el nombre de un pictureBox
        private int lastDepth; //ultima profundidad abierta (ultima coleccion)
        private int windowsWidth;//Ancho de la ventana
        private int windowsHeight;//Alto de la ventana
        private int windowsMaxScreen;//Tiene que ser numerico, no me acuerdo por que, pero tiene que ser numerico
        private int treeViewWidth;//Ancho del treeview
        private int panelOrder;//Orden de los paneles
        private int searchFilter;//Tipo de filtro de busqueda

        //Constructor que llama los datos desde el XML
        public Configurations() 
        {
            LoadConfigurations();
        }

        //Constructor al que le pasamos los datos
        public Configurations(string themeName, bool pictureBoxName, int lastDepth, int windowsWidth, int windowsHeight, int windowsMaxScreen, int treeViewWidth, int panelOrder, int searchFilter)
        {
            this.themeName = themeName;
            this.pictureBoxName = pictureBoxName;
            this.lastDepth = lastDepth;
            this.windowsWidth = windowsWidth;
            this.windowsHeight = windowsHeight;
            this.windowsMaxScreen = windowsMaxScreen;
            this.treeViewWidth = treeViewWidth;
            this.panelOrder = panelOrder;
            this.searchFilter = searchFilter;
        }

        #region Encapsulamiento
        public string ThemeName { 
            get { return themeName; } 
            set { themeName = value; } 
        }

        public bool PictureBoxName {
            get {  return pictureBoxName; } 
            set { pictureBoxName = value; } 
        }

        public int LastDepth
        {
            get { return lastDepth; } 
            set { lastDepth = value; }
        }

        public int WindowsWidth
        {
            get { return windowsWidth; } 
            set { windowsWidth = value; }
        }

        public int WindowsHeight
        {
            get { return windowsHeight; }
            set { windowsHeight = value; }
        }
                
        public int WindowsMaxScreen
        {
            get { return windowsMaxScreen; } set { windowsMaxScreen = value; }
        }

        public int TreeViewWidth
        {
            get { return treeViewWidth; }
            set { treeViewWidth = value; }
        }

        public int PanelOrder
        {
            get { return panelOrder; }
            set { panelOrder = value;  }
        }

        public int SearchFilter
        {
            get { return searchFilter; }
            set { searchFilter = value; }
        }
        #endregion

        #region funciones de guardado/cargado
        public void LoadConfigurations()
        {
            GeneralFunctions gf = new GeneralFunctions();//Para llamar a XMLDefaultReturn

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlSettingsPath);

            string xpath = "//Launcher/settings";
            XmlNode root = doc.SelectSingleNode(xpath);
            XmlNode rootWin = doc.SelectSingleNode(xpath+"/WindowSize");

            string themeName = gf.XMLDefaultReturn(root, "ThemeName", "Default");
            bool pictureBoxName = bool.Parse(gf.XMLDefaultReturn(root, "BoxName", "false"));

            //Cargar la ultima profundidad utilizada
            int lastDepth = int.Parse(gf.XMLDefaultReturn(root, "LastDepth", "0"));
            if (lastDepth < -1) lastDepth = 0;//Si es menor a -1(favoritos) dejarlo en 0

            //Cargar las opciones de la ventana (estan en un sub nodo)
            //Ancho de la ventana
            int windowsWidth = int.Parse(gf.XMLDefaultReturn(rootWin, "Width", "688"));
            if (windowsWidth < 300) windowsWidth = 300;
            int windowsHeight = int.Parse(gf.XMLDefaultReturn(rootWin, "Height", "412"));
            if (windowsHeight < 300) windowsHeight = 300;
            int windowsMaxScreen = int.Parse(gf.XMLDefaultReturn(rootWin, "MxScreen", "0"));
            if (windowsMaxScreen < 0 || windowsMaxScreen > 1) windowsMaxScreen = 1;

            //Cargar el ancho del treenode
            int treeViewWidth = int.Parse(gf.XMLDefaultReturn(root, "TreeWidth", "100"));
            if (treeViewWidth < 97) treeViewWidth = 97;

            //Cargar el orden de los paneles
            int panelOrder = int.Parse(gf.XMLDefaultReturn(root, "PanelOrder", "0"));
            if (panelOrder < 0) panelOrder = 0;

            //Cargar el tipo de filtro a utilizar en la barra de busqueda
            int searchFilter = int.Parse(gf.XMLDefaultReturn(root, "SearchFilter", "0"));


            //Actualizar los atributos de la clase
            this.themeName = themeName;
            this.pictureBoxName = pictureBoxName;
            this.lastDepth = lastDepth;
            this.windowsWidth = windowsWidth;
            this.windowsHeight = windowsHeight;
            this.windowsMaxScreen = windowsMaxScreen;
            this.treeViewWidth = treeViewWidth;
            this.panelOrder = panelOrder;
            this.searchFilter = searchFilter;
        }

        public void SaveConfigurations(Configurations settings)
        {
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            if (!System.IO.File.Exists(xmlSettingsPath))
            {
                XmlWriterSettings settingsX = new XmlWriterSettings();
                settingsX.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlSettingsPath, settingsX))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlSettingsPath);

            XmlElement sett;

            //Editar/crear elemento xml
            string xpath = "//Launcher/settings";

            sett = xmlDoc.SelectSingleNode(xpath) as XmlElement;
            //Si no lo encuentra en el archivo, crearlo
            if (sett == null)
            {
                sett = xmlDoc.CreateElement("settings");
                xmlDoc.DocumentElement.AppendChild(sett);//agrega la coleccion al documento
            }
            else
            {
                //Limpiarlo para agregarle las modificaciones
                sett.RemoveAll();
            }

            //Elementos de settings
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos
            XmlElement settThemeID = xmlDoc.CreateElement("ThemeName"); settThemeID.InnerText = settings.ThemeName; sett.AppendChild(settThemeID);
            XmlElement settBoxName = xmlDoc.CreateElement("BoxName"); settBoxName.InnerText = settings.PictureBoxName.ToString(); sett.AppendChild(settBoxName);
            XmlElement settLastDepth = xmlDoc.CreateElement("LastDepth"); settLastDepth.InnerText = settings.LastDepth.ToString(); sett.AppendChild(settLastDepth);
            //Guardar la resolucion (ancho, alto, Pantalla completa)
            XmlElement winSize = xmlDoc.CreateElement("WindowSize"); sett.AppendChild(winSize);
            XmlElement settWindowsWidth = xmlDoc.CreateElement("Width"); settWindowsWidth.InnerText = settings.WindowsWidth.ToString(); winSize.AppendChild(settWindowsWidth);
            XmlElement settWindowsHeight = xmlDoc.CreateElement("Height"); settWindowsHeight.InnerText = settings.WindowsHeight.ToString(); winSize.AppendChild(settWindowsHeight);
            XmlElement settWindowsMaxScreen = xmlDoc.CreateElement("MxScreen"); settWindowsMaxScreen.InnerText = settings.WindowsMaxScreen.ToString(); winSize.AppendChild(settWindowsMaxScreen);

            XmlElement settTreeViewWidth = xmlDoc.CreateElement("TreeWidth"); settTreeViewWidth.InnerText = settings.TreeViewWidth.ToString(); sett.AppendChild(settTreeViewWidth);
            XmlElement settPanelOrder = xmlDoc.CreateElement("PanelOrder"); settPanelOrder.InnerText = settings.PanelOrder.ToString(); sett.AppendChild(settPanelOrder);
            XmlElement settSearchFilter = xmlDoc.CreateElement("SearchFilter"); settSearchFilter.InnerText = settings.SearchFilter.ToString(); sett.AppendChild(settSearchFilter);

            xmlDoc.Save(xmlSettingsPath);
        }

        //Esta funcion deberia pasarla a una clase de funciones
        /*private string XMLDefaultReturn(XmlNode node, string singleNode, string defaultValue)
        {
            XmlNode selectedNode = node.SelectSingleNode(singleNode);
            if (selectedNode != null)
            {
                return selectedNode.InnerText;
            }
            return defaultValue;
        }*/
        #endregion
    }
}
