using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        //Datos
        private int[] tagsId;
        private bool favorite;


        //Constructor
        public Collections(int _id, int _idFather, string _name, string _imgPath, int _layout, int _r, int _g, int _b, int _res, int _w, int _h, int _sRint, int _sW, int _sH, int _sL, int [] _tag, bool _fav)
        {
            id = _id; 
            idFather = _idFather; 
            name = _name; 
            imagePath = _imgPath;
            imageLayout = _layout;
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
