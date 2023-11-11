using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoverPadLauncher.Clases
{
    public class Scanneds
    {
        //Ruta del archivo XML
        private string xmlScannedPath = "System\\ScannedDirs.xml";

        //Atributos
        private string dir;//la id
        private string name;
        //Imagen
        private string imagePath;
        private int imageLayout;
        //Color de fondo del picture box
        private bool noBackground;
        private int colRed;
        private int colGreen;
        private int colBlue;
        //Tamaño del picture box
        private int resolution;//Guardo la resolucion para permitir que al momento de que el usuario cambie una resolucion, las colecciones se adapten automaticamente
        private int width;
        private int height;
        //Folders
        private int scanStartNumber;
        private string[] scanOpenExtension;

        //Constructores
        public Scanneds() { }//Constructor para llamar a las funciones
        public Scanneds(string _dir, string _name, string _imgPath, int _layout,  bool _nBg, int _r, int _g, int _b, int _res, int _w, int _h, int _scanStart, string[] scanExtensions)
        {
            dir = _dir;
            name = _name;
            imagePath = _imgPath;
            imageLayout = _layout;
            noBackground = _nBg;
            colRed = _r;
            colGreen = _g;
            colBlue = _b;
            resolution = _res;
            width = _w;
            height = _h;
            scanStartNumber = _scanStart;
            scanOpenExtension = scanExtensions;
        }

        //Encapsulamiento
        public string Dir
        {
            get { return dir; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string ImagePath
        {
            set { imagePath = value; }
            get { return imagePath; }
        }
        public int ImageLayout
        {
            set { imageLayout = value; }
            get { return imageLayout; }
        }

        public bool Background
        {
            set { noBackground = value; }
            get { return noBackground; }
        }
        public int ColorRed
        {
            set { colRed = value; }
            get { return colRed; }
        }
        public int ColorGreen
        {
            set { colGreen = value; }
            get { return colGreen; }
        }
        public int ColorBlue
        {
            set { colBlue = value; }
            get { return colBlue; }
        }
        public int ResolutionID
        {
            set { resolution = value; }
            get { return resolution; }
        }
        public int Width
        {
            set { width = value; }
            get { return width; }
        }
        public int Height
        {
            set { height = value; }
            get { return height; }
        }
        public int ScanStartNumber
        {
            set { scanStartNumber = value; }
            get { return scanStartNumber; }
        }

        public string[] ScanOpenExtension
        {
            set { scanOpenExtension = value; }
            get { return scanOpenExtension; }
        }

        #region Funciones
        public void SaveScanned(Scanneds Class)
        {
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            if (!System.IO.File.Exists(xmlScannedPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlScannedPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlScannedPath);

            XmlElement scan;

            //Editar/crear elemento
            string xpath = "//Launcher/scanned[@dir='" + Class.Dir + "']";

            scan = xmlDoc.SelectSingleNode(xpath) as XmlElement;
            //Si no lo encuentra en el archivo, crearlo
            if (scan == null)
            {
                scan = xmlDoc.CreateElement("scanned");
                scan.SetAttribute("dir", Class.Dir.ToString());
                xmlDoc.DocumentElement.AppendChild(scan);//agrega la coleccion al documento
            }
            else
            {
                //Limpiarlo para agregarle las modificaciones
                scan.RemoveAll();
                scan.SetAttribute("dir", Class.Dir.ToString());
            }



            //Elementos de ese scan
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos de la coleccion a la coleccion
            XmlElement scanName = xmlDoc.CreateElement("Name"); scanName.InnerText = Class.Name; scan.AppendChild(scanName);
            XmlElement scanImage = xmlDoc.CreateElement("Image"); scanImage.InnerText = Class.ImagePath; scan.AppendChild(scanImage);
            XmlElement scanLayout = xmlDoc.CreateElement("ImageLayout"); scanLayout.InnerText = Class.ImageLayout.ToString(); scan.AppendChild(scanLayout);
            XmlElement scanBg = xmlDoc.CreateElement("WithoutBackground"); scanBg.InnerText = Class.Background.ToString(); scan.AppendChild(scanBg);
            XmlElement scanBgRed = xmlDoc.CreateElement("BackgroundRed"); scanBgRed.InnerText = Class.ColorRed.ToString(); scan.AppendChild(scanBgRed);
            XmlElement scanBgGreen = xmlDoc.CreateElement("BackgroundGreen"); scanBgGreen.InnerText = Class.ColorGreen.ToString(); scan.AppendChild(scanBgGreen);
            XmlElement scanBgBlue = xmlDoc.CreateElement("BackgroundBlue"); scanBgBlue.InnerText = Class.ColorBlue.ToString(); scan.AppendChild(scanBgBlue);
            XmlElement scanResolution = xmlDoc.CreateElement("CoverResolutionID"); scanResolution.InnerText = Class.ResolutionID.ToString(); scan.AppendChild(scanResolution);
            XmlElement scanWith = xmlDoc.CreateElement("CoverWidth"); scanWith.InnerText = Class.Width.ToString(); scan.AppendChild(scanWith);
            XmlElement scanHeight = xmlDoc.CreateElement("CoverHeight"); scanHeight.InnerText = Class.Height.ToString(); scan.AppendChild(scanHeight);
            XmlElement scanStartNumber = xmlDoc.CreateElement("StartNumber"); scanStartNumber.InnerText = Class.ScanStartNumber.ToString(); scan.AppendChild(scanStartNumber);
            //Guardar el array de extensiones para los escaneos
            XmlElement scanOpenExtension = xmlDoc.CreateElement("OpenExtension"); scan.AppendChild(scanOpenExtension);
            foreach (string ext in Class.ScanOpenExtension)
            {
                XmlElement extArray = xmlDoc.CreateElement("extension");
                extArray.InnerText = ext.ToString();
                scanOpenExtension.AppendChild(extArray);
            }

            xmlDoc.Save(xmlScannedPath);
        }

        public Scanneds GetScannedData(string dirID)
        {
            if (System.IO.File.Exists(xmlScannedPath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlScannedPath);

                string xpath = "//Launcher/scanned[@dir='" + dirID + "']";

                XmlNode root = doc.SelectSingleNode(xpath);
                XmlNode rootScanExtension = doc.SelectSingleNode(xpath + "/OpenExtension");

                //Si root es null, significa que estamos tratando de editar un scanDir por primera vez (el null se maneja en ToolStripEditPictureBox_Click)
                if (root == null) return null;

                GeneralFunctions gf = new GeneralFunctions();

                string name = gf.XMLDefaultReturn(root, "Name", "");
                string imgPath = gf.XMLDefaultReturn(root, "Image", "");
                int imgLayout = int.Parse(gf.XMLDefaultReturn(root, "ImageLayout", "0"));
                bool background = bool.Parse(gf.XMLDefaultReturn(root, "WithoutBackground", "false"));
                int red = int.Parse(gf.XMLDefaultReturn(root, "BackgroundRed", "255"));
                int green = int.Parse(gf.XMLDefaultReturn(root, "BackgroundGreen", "255"));
                int blue = int.Parse(gf.XMLDefaultReturn(root, "BackgroundBlue", "255"));
                int resolution = int.Parse(gf.XMLDefaultReturn(root, "CoverResolutionID", "0"));
                int width = int.Parse(gf.XMLDefaultReturn(root, "CoverWidth", "200"));
                int height = int.Parse(gf.XMLDefaultReturn(root, "CoverHeight", "200"));


                int scanStartNumber = int.Parse(gf.XMLDefaultReturn(root, "StartNumber", "1"));
                string[] scanExtension = { };
                if (rootScanExtension != null)
                {
                    foreach (XmlNode extension in rootScanExtension)
                    {
                        scanExtension = scanExtension.Append(extension.InnerText).ToArray();
                    }
                }

                Scanneds ScanReturn = new Scanneds(dirID, name, imgPath, imgLayout, background, red, green, blue, resolution, width, height, scanStartNumber, scanExtension);

                return ScanReturn;
            }
            return null;
        }
        #endregion
    }
}
