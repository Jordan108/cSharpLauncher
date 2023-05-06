using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Launcher.Clases
{
    public class Resolutions
    {
        //Atributos
        private int id;
        private string name;
        private int width;
        private int height;
        private int imageLayout;

        public Resolutions(int id, string name, int width, int height, int imageLayout)
        {
            this.id = id;
            this.name = name;
            this.width = width;
            this.height = height;
            this.imageLayout = imageLayout;
        }

        //Encapsulamiento
        public int ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set{ height = value; }
        }

        public int ImageLayout
        {
            get { return imageLayout; }
            set { imageLayout = value; }
        }
    }
}
