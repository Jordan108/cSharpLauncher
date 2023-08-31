using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Launcher.Clases
{
    public class Files
    {
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

        //Constructor
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

        //Encapsulamiento
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
    }
}
