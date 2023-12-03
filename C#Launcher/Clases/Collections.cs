using System.Xml;
using System;
using CoverPadLauncher.Clases;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Windows.Forms;

namespace C_Launcher.Clases
{
    public class Collections
    {
        //XML de las colecciones
        private string xmlColPath = "System\\Collections.xml";
        //XML de los elementos (para eliminar los que esten dentro de las colecciones)
        private string xmlFilesPath = "System\\Elements.xml";
        //Ruta de los covers
        private string dirCoversPath = "System\\Covers";

        //Atributos
        private int id;
        private int idFather;
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
        //Tamaño del pictureBox de los hijos + formato
        private int sonResolution;
        private int sonWidth;
        private int sonHeight;
        private int sonImageLayout;
        private string sonProgramPath;
        private string sonCMDLine;
        //Datos
        private int[] tagsId;
        private int[] scanTags;
        private bool favorite;
        //Coleccion automatica
        private bool scanFolder;
        private string scanPath;
        private int scanStartNumber;
        private string[] scanOpenExtension;


        //Constructores
        public Collections() { }//Constructor para llamar a las funciones

        public Collections(int _id, int _idFather, string _name, string _imgPath, int _layout, bool _nBg, int _r, int _g, int _b, int _res, int _w, int _h, int _sRint, int _sW, int _sH, int _sL, string _sLP, string _sCMD, int[] _tag, int[] _scanTag, bool _fav, bool _scan, string _scanPath, int _scanStartNumber, string[] _scanOpenExtension)
        {
            id = _id; 
            idFather = _idFather; 
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
            sonResolution = _sRint;
            sonWidth = _sW;
            sonHeight = _sH;
            sonImageLayout = _sL;
            sonProgramPath = _sLP;
            sonCMDLine = _sCMD;
            tagsId = _tag;
            scanTags = _scanTag;
            favorite = _fav;
            scanFolder = _scan;
            scanPath = _scanPath;
            scanStartNumber = _scanStartNumber;
            scanOpenExtension = _scanOpenExtension;
        }

        #region Encapsulamiento
        public int ID
        {
            get { return id; }
        }
        public int IDFather
        {
            set { idFather = value; }
            get { return idFather; }
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
        public int SonResolution
        {
            set { sonResolution = value; }
            get { return sonResolution; }
        }
        public int SonWidth
        {
            set { sonWidth = value; }
            get { return sonWidth; }
        }
        public int SonHeight
        {
            set { sonHeight = value; }
            get { return sonHeight; }
        }
        public int SonLayout
        {
            set { sonImageLayout = value; }
            get { return sonImageLayout; }
        }
        public string SonProgramPath
        {
            set { sonProgramPath = value; } 
            get { return sonProgramPath; }
        }
        public string SonCMDLine
        {
            set { sonCMDLine = value; }
            get { return sonCMDLine; }
        }
        public int[] TagsID
        {
            set { tagsId = value; }
            get { return tagsId; }
        }

        public int[] ScanTags
        {
            set { scanTags = value; }
            get { return scanTags; }
        }
        public bool Favorite
        {
            set { favorite = value; }
            get { return favorite; }
        }

        public bool ScanFolder
        {
            set { scanFolder = value; }
            get { return scanFolder; }
        }

        public string ScanPath
        {
            set { scanPath = value; }
            get { return scanPath; }
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
        #endregion

        #region Funciones
        #region CRUD
        //Guardar una coleccion en el archivo XML
        public void SaveCollection(Collections Class)
        {
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            if (!System.IO.File.Exists(xmlColPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlColPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlColPath);

            XmlElement coleccion;

            //Crear colecciones nuevas
            if (Class.ID == -1)
            {
                XmlNodeList nodeList = xmlDoc.SelectNodes("//Launcher/collection");

                //Itera para encontrar el id mas alto
                int maxId = 0;
                foreach (XmlNode node in nodeList)
                {
                    int currentId;
                    if (int.TryParse(node.Attributes["id"].Value, out currentId))
                    {
                        if (currentId > maxId)
                        {
                            maxId = currentId;
                        }
                    }
                }

                //Crea una coleccion/archivo nueva
                coleccion = xmlDoc.CreateElement("collection");
                coleccion.SetAttribute("id", maxId + 1 + "");//establecer el atributo id para facilitar la busqueda por xPath
                xmlDoc.DocumentElement.AppendChild(coleccion);//agrega la coleccion al documento
            }
            else
            {
                //Editar colecciones
                string xpath = "//Launcher/collection[@id='" + Class.ID + "']";
                coleccion = xmlDoc.SelectSingleNode(xpath) as XmlElement;
                //Limpiarlo para agregarle las modificaciones
                coleccion.RemoveAll();
                coleccion.SetAttribute("id", Class.ID.ToString());
            }

            //Guardar la imagen
            GeneralFunctions gf = new GeneralFunctions();
            string coverDir = "";
            if (Class.ImagePath != "") coverDir = gf.SaveCover(Class.Name, Class.ImagePath, Class.ID == -1, "collection_");//si Class.ID == 1, se esta creando un elemento desde 0


            //Elementos de esa coleccion
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos de la coleccion a la coleccion
            XmlElement colFather = xmlDoc.CreateElement("IDFather"); colFather.InnerText = Class.IDFather.ToString(); coleccion.AppendChild(colFather);
            XmlElement colName = xmlDoc.CreateElement("Name"); colName.InnerText = Class.Name; coleccion.AppendChild(colName);
            XmlElement colImage = xmlDoc.CreateElement("Image"); colImage.InnerText = coverDir; coleccion.AppendChild(colImage);
            XmlElement colLayout = xmlDoc.CreateElement("ImageLayout"); colLayout.InnerText = Class.ImageLayout.ToString(); coleccion.AppendChild(colLayout);
            XmlElement colBg = xmlDoc.CreateElement("WithoutBackground"); colBg.InnerText = Class.Background.ToString(); coleccion.AppendChild(colBg);
            XmlElement colBgRed = xmlDoc.CreateElement("BackgroundRed"); colBgRed.InnerText = Class.ColorRed.ToString(); coleccion.AppendChild(colBgRed);
            XmlElement colBgGreen = xmlDoc.CreateElement("BackgroundGreen"); colBgGreen.InnerText = Class.ColorGreen.ToString(); coleccion.AppendChild(colBgGreen);
            XmlElement colBgBlue = xmlDoc.CreateElement("BackgroundBlue"); colBgBlue.InnerText = Class.ColorBlue.ToString(); coleccion.AppendChild(colBgBlue);
            XmlElement colResolution = xmlDoc.CreateElement("CoverResolutionID"); colResolution.InnerText = Class.ResolutionID.ToString(); coleccion.AppendChild(colResolution);
            XmlElement colWith = xmlDoc.CreateElement("CoverWidth"); colWith.InnerText = Class.Width.ToString(); coleccion.AppendChild(colWith);
            XmlElement colHeight = xmlDoc.CreateElement("CoverHeight"); colHeight.InnerText = Class.Height.ToString(); coleccion.AppendChild(colHeight);
            XmlElement colSonResolution = xmlDoc.CreateElement("CoverSonResolutionID"); colSonResolution.InnerText = Class.SonResolution.ToString(); coleccion.AppendChild(colSonResolution);
            XmlElement colSonWidth = xmlDoc.CreateElement("CoverSonWidth"); colSonWidth.InnerText = Class.SonWidth.ToString(); coleccion.AppendChild(colSonWidth);
            XmlElement colSonHeight = xmlDoc.CreateElement("CoverSonHeight"); colSonHeight.InnerText = Class.SonHeight.ToString(); coleccion.AppendChild(colSonHeight);
            XmlElement colSonLayout = xmlDoc.CreateElement("SonImageLayout"); colSonLayout.InnerText = Class.sonImageLayout.ToString(); coleccion.AppendChild(colSonLayout);
            XmlElement colSonProgramPath = xmlDoc.CreateElement("SonProgramPath"); colSonProgramPath.InnerText = Class.SonProgramPath.ToString(); coleccion.AppendChild(colSonProgramPath);
            XmlElement colSonCMDLine = xmlDoc.CreateElement("SonCMDLine"); colSonCMDLine.InnerText = Class.SonCMDLine.ToString(); coleccion.AppendChild(colSonCMDLine);
            //Guardar el array de las etiquetas
            XmlElement colTags = xmlDoc.CreateElement("TagsID"); coleccion.AppendChild(colTags);
            foreach (int num in Class.TagsID)
            {
                XmlElement numArray = xmlDoc.CreateElement("id");
                numArray.InnerText = num.ToString();
                colTags.AppendChild(numArray);
            }
            //Guardar el array de las etiquetas a escanear
            XmlElement colTagsScan = xmlDoc.CreateElement("ScanTagsID"); coleccion.AppendChild(colTagsScan);
            foreach (int num in Class.ScanTags)
            {
                XmlElement numArray = xmlDoc.CreateElement("id");
                numArray.InnerText = num.ToString();
                colTagsScan.AppendChild(numArray);
            }
            XmlElement colFavorite = xmlDoc.CreateElement("Favorite"); colFavorite.InnerText = Class.Favorite.ToString(); coleccion.AppendChild(colFavorite);
            XmlElement colScanFolder = xmlDoc.CreateElement("ScanFolder"); colScanFolder.InnerText = Class.ScanFolder.ToString(); coleccion.AppendChild(colScanFolder);
            XmlElement colScanPath = xmlDoc.CreateElement("ScanPath"); colScanPath.InnerText = Class.ScanPath.ToString(); coleccion.AppendChild(colScanPath);
            XmlElement colScanStartNumber = xmlDoc.CreateElement("ScanStartNumber"); colScanStartNumber.InnerText = Class.ScanStartNumber.ToString(); coleccion.AppendChild(colScanStartNumber);
            //Guardar el array de extensiones para los escaneos
            XmlElement colScanOpenExtension = xmlDoc.CreateElement("ScanOpenExtension"); coleccion.AppendChild(colScanOpenExtension);
            foreach (string ext in Class.ScanOpenExtension)
            {
                XmlElement extArray = xmlDoc.CreateElement("extension");
                extArray.InnerText = ext.ToString();
                colScanOpenExtension.AppendChild(extArray);
            }

            xmlDoc.Save(xmlColPath);
        }

        //Cargar una coleccion especifica desde el xml 
        public Collections LoadCollectionData(int colID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlColPath);

            string xpath = "//Launcher/collection[@id='" + colID + "']";

            XmlNode root = doc.SelectSingleNode(xpath);
            XmlNode rootTag = doc.SelectSingleNode(xpath + "/TagsID");
            XmlNode rootTagScan = doc.SelectSingleNode(xpath + "/ScanTagsID");
            XmlNode rootScanExtension = doc.SelectSingleNode(xpath + "/ScanOpenExtension");

            GeneralFunctions gf = new GeneralFunctions();

            int idFather = int.Parse(gf.XMLDefaultReturn(root, "IDFather", "0"));
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
            int sonRes = int.Parse(gf.XMLDefaultReturn(root, "CoverSonResolutionID", "0"));
            int sonWidth = int.Parse(gf.XMLDefaultReturn(root, "CoverSonWidth", "200"));
            int sonHeight = int.Parse(gf.XMLDefaultReturn(root, "CoverSonHeight", "200"));
            int sonLayout = int.Parse(gf.XMLDefaultReturn(root, "SonImageLayout", "0"));
            string sonProgramPath = gf.XMLDefaultReturn(root, "SonProgramPath", "");
            string sonCMDLine = gf.XMLDefaultReturn(root, "SonCMDLine", "");

            int[] tagsArray = { };
            if (rootTag != null)
            {
                foreach (XmlNode tagid in rootTag)
                {
                    tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
                }
            }
            int[] tagsScan = { };
            if (rootTagScan != null)
            {
                foreach (XmlNode tagid in rootTagScan)
                {
                    tagsScan = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
                }
            }
            bool fav = bool.Parse(gf.XMLDefaultReturn(root, "Favorite", "false"));
            bool scanFold = bool.Parse(gf.XMLDefaultReturn(root, "ScanFolder", "false"));
            string scanPath = gf.XMLDefaultReturn(root, "ScanPath", "");
            int scanStartNumber = int.Parse(gf.XMLDefaultReturn(root, "ScanStartNumber", "1"));
            string[] scanExtension = { };
            if (rootScanExtension != null)
            {
                foreach (XmlNode extension in rootScanExtension)
                {
                    scanExtension = scanExtension.Append(extension.InnerText).ToArray();
                }
            }

            Collections colReturn = new Collections(colID, idFather, name, imgPath, imgLayout, background, red, green, blue, resolution, width, height, sonRes, sonWidth, sonHeight, sonLayout, sonProgramPath, sonCMDLine, tagsArray, tagsScan, fav, scanFold, scanPath, scanStartNumber, scanExtension);

            return colReturn;
        }

        //Cargar las colecciones del archivo XML
        public Collections[] LoadCollections(int arraySize)
        {
            Collections[] colData = new Collections[arraySize];

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlColPath);


            int colID = 1;
            for (int i = 0; i < arraySize; i++)
            {
                //Buscamos el elemento a modificar
                string xpath = "//Launcher/collection[@id='" + colID + "']";
                XmlNode root = xmlDoc.SelectSingleNode(xpath);


                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {
                    colID++;
                    xpath = "//Launcher/collection[@id='" + colID + "']";

                    root = xmlDoc.SelectSingleNode(xpath);
                }

                colData[i] = LoadCollectionData(colID);

                colID++;
            }

            return colData;
        }

        //Eliminar una coleccion especifica del archivo XML
        public void DeleteCollection(int colID)
        {
            //cargar xml con linq
            XDocument xmlDoc = XDocument.Load(xmlColPath);

            Console.Write($"\n/////////////////////////////////////////////\nColeccion a eliminar {colID}\n////////////////////////////////////////////////////\n");
            // Eliminar la coleccion principal
            /* var deleteColl = xmlDoc.Descendants("collection")
                 .Where(e => e.Attribute("id").Value == colID.ToString()).Remove();*/

            XElement deleteColl = xmlDoc.Root.Elements("collection")
            .FirstOrDefault(e => e.Attribute("id")?.Value == colID.ToString());

            if (deleteColl != null)
            {
                //Eliminar la caratula solo si está ubicada en la carpeta "System"
                string imgDir = deleteColl.Attribute("Image")?.Value;
                if (imgDir != "")
                {
                    string folder = Directory.GetCurrentDirectory() + "\\" + Path.GetDirectoryName(imgDir);
                    string workFolder = Directory.GetCurrentDirectory() + "\\" + dirCoversPath;

                    //Si la carpeta donde se ubica la imagen es System//Covers, eliminar el archivo
                    if (folder == workFolder)
                    {
                        string fullImagePath = Directory.GetCurrentDirectory() + "\\" + imgDir;
                        try
                        {
                            //Solo eliminara el archivo si existe
                            if (File.Exists(fullImagePath))
                            {
                                // Eliminar el archivo
                                File.Delete(fullImagePath);
                            }
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("Error al eliminar el archivo: " + ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"la imagen: {imgDir}\nQue esta en: {folder}\nNo se encuentra en: {workFolder}");
                    }
                }

                deleteColl.Remove();
            }


            //Buscar todos los archivos que esten dentro de esa coleccion y eliminarlo
            XDocument xmlFileDoc = XDocument.Load(xmlFilesPath);

            List<XElement> filesToDelete = xmlFileDoc.Root.Elements("file")//xmlFileDoc.Root.Elements()
            .Where(e => e.Element("IDFather")?.Value == colID.ToString())
            .ToList();

            foreach (var file in filesToDelete)
            {
                //Eliminar el elemento
                //deleteFile(int.Parse(file.Attribute("id").Value));

                Files classFile = new Files();
                classFile.DeleteFile(int.Parse(file.Attribute("id").Value));//Eliminar el archivo
            }


            //Buscar todos los descendientes de esa coleccion
            List<XElement> collsToDelete = xmlDoc.Root.Elements("collection")//xmlDoc.Root.Elements()
            .Where(e => e.Element("IDFather")?.Value == colID.ToString())
            .ToList();


            foreach (var coll in collsToDelete)
            {
                // Llamar recursivamente a la función para eliminar los descendientes
                DeleteCollection(int.Parse(coll.Attribute("id").Value));
            }


            xmlDoc.Save(xmlColPath);
        }
        #endregion

        #region get/set
        //Devuelve el tamaño (cantidad/largo) de colecciones en el archivo XML
        public int GetCollectionsSize()
        {
            int size = 0;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlColPath);
                XmlNodeList colElements = xmlDoc.SelectNodes("//*[@id]");
                size = colElements.Count;
            }
            catch (Exception)
            {
                Console.WriteLine("No se encontro el fichero de las colecciones, se creara uno nuevo");
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlColPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            return size;
        }

        public bool GetColeFav(int colID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlColPath);

            string xpath = "//Launcher/collection[@id='" + colID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            bool returnFav = false;

            if (root != null)
            {
                returnFav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);
            }

            //Llamar a la funcion para que empiece el proceso
            return returnFav;
        }

        public void SetColeFav(int colID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlColPath);

            string xpath = "//Launcher/collection[@id='" + colID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            if (root != null)
            {
                bool returnFav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);

                if (returnFav == false) { root.SelectSingleNode("Favorite").InnerText = "True"; }
                else { root.SelectSingleNode("Favorite").InnerText = "False"; }

                doc.Save(xmlColPath);
            }
        }

        public string[] GetColeScanExtension(int colID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlColPath);

            string xpath = "//Launcher/collection[@id='" + colID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            List<string> extValues = new List<string>();
            if (root != null)
            {
                //returnExt.Append(root.SelectSingleNode("ScanOpenExtension").InnerText);

                XmlNode rootScanExtension = doc.SelectSingleNode("//Launcher/collection/ScanOpenExtension");
                if (rootScanExtension != null)
                {
                    foreach (XmlNode extension in rootScanExtension)
                    {
                        extValues.Add(extension.InnerText);
                    }
                }
            }

            string[] returnExt = extValues.ToArray();

            return returnExt;
        }

        public int GetColeScanStartNumber(int colID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlColPath);

            string xpath = "//Launcher/collection[@id='" + colID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            int returnNumber = 0;

            try
            {
                returnNumber = int.Parse(root.SelectSingleNode("ScanStartNumber").InnerText);
            }
            catch (Exception) { }

            //Llamar a la funcion para que empiece el proceso
            return returnNumber;
        }
        #endregion
        #endregion
    }
}
