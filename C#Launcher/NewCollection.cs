using C_Launcher.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Launcher
{
    public partial class NewCollection : Form
    {
        private int currentX, currentY;
        private int resizing = 0; // 0=no se esta ajustando; 1=ajustando ancho; 2=ajustando alto; 3=ajustando ambos
        private int currentSonX, currentSonY;
        private int resizingSon = 0; //mismos datos que original
        // public event EventHandler<Collections> ReturnedObject;
        public NewCollection()
        {
            InitializeComponent();
        }
    }
}
