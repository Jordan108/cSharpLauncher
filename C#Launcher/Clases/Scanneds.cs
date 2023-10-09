using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoverPadLauncher.Clases
{
    public class Scanneds
    {
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

        //Constructor
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
    }
}
