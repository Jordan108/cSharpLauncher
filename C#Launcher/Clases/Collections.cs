namespace C_Launcher.Clases
{
    public class Collections
    {
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


        //Constructor
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
    }
}
