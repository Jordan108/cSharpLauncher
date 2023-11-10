using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace C_Launcher.Clases
{
    public class Files
    {
        private string xmlFilesPath = "System\\Elements.xml";

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
        public void SaveFiles(Files Class)
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
            string coverDir = "";
            if (Class.ImagePath != "") coverDir = saveCover(Class.Name, Class.ImagePath, Class.ID == -1, "element_");//si Class.ID == 1, se esta creando un elemento desde 0

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
        #endregion
    }
}
