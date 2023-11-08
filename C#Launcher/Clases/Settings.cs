using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoverPadLauncher.Clases
{
    public class Settings
    {
        private int themeID;//El id del tema
        private bool pictureBoxName;//Mostrar siempre el rectangulo con el nombre de un pictureBox

        public Settings(int _themeId, bool _pictureBoxName)
        {
            this.themeID = _themeId;
            this.pictureBoxName = _pictureBoxName;
        }

        //Encapsulamiento
        public int ThemeID { 
            get { return themeID; } 
            set { themeID = value; } 
        }

        public bool PictureBoxName {
            get {  return pictureBoxName; } 
            set { pictureBoxName = value; } 
        }
    }
}
