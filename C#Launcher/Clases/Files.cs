using CoverPadLauncher.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace C_Launcher.Clases
{
    public class Files
    {
        //XML de los elementos
        private string xmlFilesPath = "System\\Elements.xml";
        //Ruta de los covers
        private string dirCoversPath = "System\\Covers";

        //Atributos
        private int id;
        private int idFather;
        private string name;
        //rutas de directorio
        private string filePath;
        private string programPath;
        private string cmdLine;
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
        private bool urlCheck;
        private int[] tagsId;
        private bool favorite;

        //Constructores
        public Files()
        {
            //Constructor para llamar a las funciones
        }

        public Files(int _id, int _idFather, string _name, string _imgPath, int _layout, string _filePath, string _programPath, string _cmd, bool _nBg, int _r, int _g, int _b, int _res, int _w, int _h, bool _url, int[] _tag, bool _fav)
        {
            id = _id;
            idFather = _idFather;
            name = _name;
            imagePath = _imgPath;
            imageLayout = _layout;
            filePath = _filePath;
            programPath = _programPath;
            cmdLine = _cmd;
            noBackground = _nBg;
            colRed = _r;
            colGreen = _g;
            colBlue = _b;
            resolution = _res;
            width = _w;
            height = _h;
            urlCheck = _url;
            tagsId = _tag;
            favorite = _fav;
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
        public string FilePath
        {
            set { filePath = value; }
            get { return filePath; }
        }
        public string ProgramPath
        {
            set { programPath = value; }
            get { return programPath; }
        }
        public string CMDLine
        {
            set { cmdLine = value; }
            get { return cmdLine; }
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
        public bool URLCheck
        {
            set { urlCheck = value; }
            get { return urlCheck; }
        }
        public int[] TagsID
        {
            set { tagsId = value; }
            get { return tagsId; }
        }
        public bool Favorite
        {
            set { favorite = value; }
            get { return favorite; }
        }
        #endregion

        #region Funciones
        #region  CRUD
        //Guardar un objeto Files en el archivo XML
        public void SaveFile(Files Class)
        {
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            if (!System.IO.File.Exists(xmlFilesPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlFilesPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilesPath);

            XmlElement file;
            //Creando un archivo totalmente nuevo
            if (Class.ID == -1)
            {
                XmlNodeList nodeList = xmlDoc.SelectNodes("//Launcher/file");

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
                file = xmlDoc.CreateElement("file");
                file.SetAttribute("id", maxId + 1 + "");//establecer el atributo id para facilitar la busqueda por xPath
                xmlDoc.DocumentElement.AppendChild(file);//agrega la coleccion al documento
            }
            else
            {
                //Editar colecciones
                string xpath = "//Launcher/file[@id='" + Class.ID + "']";
                file = xmlDoc.SelectSingleNode(xpath) as XmlElement;
                //Limpiarlo para agregarle las modificaciones
                file.RemoveAll();
                file.SetAttribute("id", Class.ID.ToString());
            }

            //Guardar la imagen
            GeneralFunctions gf = new GeneralFunctions();//Para llamar a SaveCover
            string coverDir = "";
            if (Class.ImagePath != "") coverDir = gf.SaveCover(Class.Name, Class.ImagePath, Class.ID == -1, "element_");//si Class.ID == 1, se esta creando un elemento desde 0

            //Elementos de ese file
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos de la coleccion a la coleccion
            XmlElement fileFather = xmlDoc.CreateElement("IDFather"); fileFather.InnerText = Class.IDFather.ToString(); file.AppendChild(fileFather);
            XmlElement fileName = xmlDoc.CreateElement("Name"); fileName.InnerText = Class.Name; file.AppendChild(fileName);
            XmlElement fileImage = xmlDoc.CreateElement("Image"); fileImage.InnerText = coverDir; file.AppendChild(fileImage);
            XmlElement fileLayout = xmlDoc.CreateElement("ImageLayout"); fileLayout.InnerText = Class.ImageLayout.ToString(); file.AppendChild(fileLayout);
            XmlElement filePath = xmlDoc.CreateElement("FilePath"); filePath.InnerText = Class.FilePath; file.AppendChild(filePath);
            XmlElement fileProgram = xmlDoc.CreateElement("ProgramPath"); fileProgram.InnerText = Class.ProgramPath; file.AppendChild(fileProgram);
            XmlElement filecmd = xmlDoc.CreateElement("CMDLine"); filecmd.InnerText = Class.CMDLine; file.AppendChild(filecmd);
            XmlElement fileBg = xmlDoc.CreateElement("WithoutBackground"); fileBg.InnerText = Class.Background.ToString(); file.AppendChild(fileBg);
            XmlElement fileBgRed = xmlDoc.CreateElement("BackgroundRed"); fileBgRed.InnerText = Class.ColorRed.ToString(); file.AppendChild(fileBgRed);
            XmlElement fileBgGreen = xmlDoc.CreateElement("BackgroundGreen"); fileBgGreen.InnerText = Class.ColorGreen.ToString(); file.AppendChild(fileBgGreen);
            XmlElement fileBgBlue = xmlDoc.CreateElement("BackgroundBlue"); fileBgBlue.InnerText = Class.ColorBlue.ToString(); file.AppendChild(fileBgBlue);
            XmlElement fileResolution = xmlDoc.CreateElement("CoverResolutionID"); fileResolution.InnerText = Class.ResolutionID.ToString(); file.AppendChild(fileResolution);
            XmlElement fileWith = xmlDoc.CreateElement("CoverWidth"); fileWith.InnerText = Class.Width.ToString(); file.AppendChild(fileWith);
            XmlElement fileHeight = xmlDoc.CreateElement("CoverHeight"); fileHeight.InnerText = Class.Height.ToString(); file.AppendChild(fileHeight);
            XmlElement fileURL = xmlDoc.CreateElement("URLCheck"); fileURL.InnerText = Class.URLCheck.ToString(); file.AppendChild(fileURL);
            //Guardar el array de tags
            XmlElement fileTags = xmlDoc.CreateElement("TagsID"); file.AppendChild(fileTags);
            foreach (int num in Class.TagsID)
            {
                XmlElement numArray = xmlDoc.CreateElement("id");
                numArray.InnerText = num.ToString();
                fileTags.AppendChild(numArray);
                //Console.WriteLine(num);
            }

            XmlElement fileFavorite = xmlDoc.CreateElement("Favorite"); fileFavorite.InnerText = Class.Favorite.ToString(); file.AppendChild(fileFavorite);

            xmlDoc.Save(xmlFilesPath);
        }

        //Buscar los datos de un elemento especifico
        public Files LoadFileData(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            GeneralFunctions gf = new GeneralFunctions();

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);
            XmlNode rootTag = doc.SelectSingleNode(xpath + "/TagsID");

            int idFather = int.Parse(gf.XMLDefaultReturn(root, "IDFather", "0"));
            string name = gf.XMLDefaultReturn(root, "Name", "");
            string imgPath = gf.XMLDefaultReturn(root, "Image", "");
            int imgLayout = int.Parse(gf.XMLDefaultReturn(root, "ImageLayout", "0"));
            string filePath = gf.XMLDefaultReturn(root, "FilePath", "");
            string programPath = gf.XMLDefaultReturn(root, "ProgramPath", "");
            string cmdLine = gf.XMLDefaultReturn(root, "CMDLine", "");
            bool background = bool.Parse(gf.XMLDefaultReturn(root, "WithoutBackground", "false"));
            int red = int.Parse(gf.XMLDefaultReturn(root, "BackgroundRed", "255"));
            int green = int.Parse(gf.XMLDefaultReturn(root, "BackgroundGreen", "255"));
            int blue = int.Parse(gf.XMLDefaultReturn(root, "BackgroundBlue", "255"));
            int resolution = int.Parse(gf.XMLDefaultReturn(root, "CoverResolutionID", "0"));
            int width = int.Parse(gf.XMLDefaultReturn(root, "CoverWidth", "200"));
            int height = int.Parse(gf.XMLDefaultReturn(root, "CoverHeight", "200"));
            bool urlCheck = bool.Parse(gf.XMLDefaultReturn(root, "URLCheck", "false"));
            int[] tagsArray = new int[] { };
            foreach (XmlNode tagid in rootTag)
            {
                //hacer un append al array
                tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
            }
            bool fav = bool.Parse(gf.XMLDefaultReturn(root, "Favorite", "false"));

            Files FileReturn = new Files(fileID, idFather, name, imgPath, imgLayout, filePath, programPath, cmdLine, background, red, green, blue, resolution, width, height, urlCheck, tagsArray, fav);

            return FileReturn;
        }

        //Buscar los datos de todos los elemtos del XML
        public Files[] LoadFiles(int arraySize)
        {
            Files[] fileData = new Files[arraySize];

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilesPath);

            int fileID = 1;
            for (int i = 0; i < arraySize; i++)
            {
                //Buscamos el elemento a modificar
                string xpath = "//Launcher/file[@id='" + fileID + "']";
                XmlNode root = xmlDoc.SelectSingleNode(xpath);

                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {
                    fileID++;
                    xpath = "//Launcher/file[@id='" + fileID + "']";
                    root = xmlDoc.SelectSingleNode(xpath);
                }

                fileData[i] = LoadFileData(fileID);

                fileID++;
            }

            return fileData;
        }

        //Cargar los elementos que tengan una coleccion padre especifica (se ocupa para editar multiples elementos)
        public Files[] LoadFilesInCollection(int colID, int fileSize)
        {
            Files[] fileData = new Files[fileSize];

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilesPath);

            GeneralFunctions gf = new GeneralFunctions();

            int fileID = 1;
            for (int i = 0; i < fileSize; i++)
            {
                //Buscamos el elemento a modificar
                string xpath = "//Launcher/file[@id='" + fileID + "']";
                string tagpath = "//Launcher/file/TagsID";
                XmlNode root = xmlDoc.SelectSingleNode(xpath);
                XmlNode rootTag = xmlDoc.SelectSingleNode(tagpath);

                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {
                    fileID++;
                    xpath = "//Launcher/file[@id='" + fileID + "']";
                    root = xmlDoc.SelectSingleNode(xpath);
                }

                //Solo iterar sobre los archivos que tengan de padre a la coleccion a editar
                int idFather = int.Parse(gf.XMLDefaultReturn(root, "IDFather", "0"));
                if (idFather != colID)
                {
                    fileID++;
                    continue;
                }

                string name = gf.XMLDefaultReturn(root, "Name", "");
                string imgPath = gf.XMLDefaultReturn(root, "Image", "");
                int imgLayout = int.Parse(gf.XMLDefaultReturn(root, "ImageLayout", "0"));
                string filePath = gf.XMLDefaultReturn(root, "FilePath", "");
                string programPath = gf.XMLDefaultReturn(root, "ProgramPath", "");
                string cmdLine = gf.XMLDefaultReturn(root, "CMDLine", "");
                bool background = bool.Parse(gf.XMLDefaultReturn(root, "WithoutBackground", "false"));
                int red = int.Parse(gf.XMLDefaultReturn(root, "BackgroundRed", "255"));
                int green = int.Parse(gf.XMLDefaultReturn(root, "BackgroundGreen", "255"));
                int blue = int.Parse(gf.XMLDefaultReturn(root, "BackgroundBlue", "255"));
                int resolution = int.Parse(gf.XMLDefaultReturn(root, "CoverResolutionID", "0"));
                int width = int.Parse(gf.XMLDefaultReturn(root, "CoverWidth", "200"));
                int height = int.Parse(gf.XMLDefaultReturn(root, "CoverHeight", "200"));
                bool urlCheck = bool.Parse(gf.XMLDefaultReturn(root, "URLCheck", "false"));
                int[] tagsArray = new int[] { };
                foreach (XmlNode tagid in rootTag)
                {
                    //hacer un append al array
                    tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
                }
                bool fav = bool.Parse(gf.XMLDefaultReturn(root, "Favorite", "false"));

                fileData[i] = new Files(fileID, idFather, name, imgPath, imgLayout, filePath, programPath, cmdLine, background, red, green, blue, resolution, width, height, urlCheck, tagsArray, fav);

                fileID++;
            }

            Files[] arrangedFiles = fileData.Where(elemento => elemento != null).ToArray();

            return arrangedFiles;
        }

        //Eliminar un elemento del archivo XML
        public void DeleteFile(int fileID)
        {
            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilesPath);

            //Buscamos el elemento a eliminar
            string xpath = "//Launcher/file[@id='" + fileID + "']"; //Buscar un elemento que se llame "ColeccionX" que tenga en el atributo id un 1
            XmlNode root = xmlDoc.SelectSingleNode(xpath);

            if (root != null)
            {
                //Eliminar la caratula solo si está ubicada en la carpeta "System"
                string imgDir = root.SelectSingleNode("Image").InnerText;
                if (imgDir != "")
                {
                    string folder = Path.GetDirectoryName(imgDir);
                    string workFolder = Directory.GetCurrentDirectory() + "\\" + dirCoversPath;

                    //Si la carpeta donde se ubica la imagen es System//Covers, eliminar el archivo
                    if (folder == workFolder)
                    {
                        try
                        {
                            //Solo eliminara el archivo si existe
                            if (File.Exists(imgDir))
                            {
                                // Eliminar el archivo
                                File.Delete(imgDir);
                            }
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("Error al eliminar el archivo: " + ex.Message);
                        }
                    }
                }

                root.ParentNode.RemoveChild(root);
            }

            xmlDoc.Save(xmlFilesPath);
        }
        #endregion

        #region get/set
        //Devuelve el tamaño (cantidad/largo) de elementos en el archivo XML
        public int GetFilesSize()
        {
            int size = 0;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilesPath);
                XmlNodeList filesElements = xmlDoc.SelectNodes("//*[@id]");
                size = filesElements.Count;
            }
            catch (Exception)
            {
                Console.WriteLine("No se encontro el fichero de los archivos, se creara uno nuevo");
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlFilesPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            return size;
        }

        //Devuelve si un archivo tiene el estado de favorito o no (buscando en el XML por su ID
        public bool GetFileFav(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            bool returnFav = false;

            if (root != null)
            {
                returnFav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);
            }

            //Llamar a la funcion para que empiece el proceso
            return returnFav;
        }

        //Establece en el archivo XML si un elemento tiene su estado de favorito
        public void SetFileFav(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            if (root != null)
            {
                bool returnFav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);

                if (returnFav == false) { root.SelectSingleNode("Favorite").InnerText = "True"; }
                else { root.SelectSingleNode("Favorite").InnerText = "False"; }

                doc.Save(xmlFilesPath);
            }
        }

        //Obtiene si un elemento tiene en True el url
        public bool GetFileURL(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            bool returnURL = false;

            if (root != null)
            {
                returnURL = bool.Parse(root.SelectSingleNode("URLCheck").InnerText);
            }

            //Llamar a la funcion para que empiece el proceso
            return returnURL;
        }

        //Obtiene el lanzador de un elemento
        public string GetFileProgram(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            string returnProgram = "";

            if (root != null)
            {
                returnProgram = root.SelectSingleNode("ProgramPath").InnerText;
            }

            //Llamar a la funcion para que empiece el proceso
            return returnProgram;
        }

        //Obtiene el directorio de un elemento
        public string getFileDir(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            string returnDir = "";

            if (root != null)
            {
                returnDir = root.SelectSingleNode("FilePath").InnerText;
            }

            //Llamar a la funcion para que empiece el proceso
            return returnDir;
        }
        #endregion
        #endregion
    }
}
