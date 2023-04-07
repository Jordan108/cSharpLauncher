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
    public partial class Home : Form
    {
         private PictureBox[] picBoxArr = new PictureBox[0];//Crear el array de picBox que se mantendra en memoria

        /*
         como hacer un get y un set de una clase

        Clase a = new clase()

        a.name = "value"; Set
        string name = a.name; Get
         */
        public Home()
        {
            InitializeComponent();
            loadPictureBox();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        #region controlar vista de usuario 
        private void loadPictureBox()
        {
           Array.Resize(ref picBoxArr, 4);

           for(int i = 0; i < picBoxArr.Length; i++)
            {
                picBoxArr[i] = new PictureBox();
                picBoxArr[i].Size = new Size(300, 300);
                picBoxArr[i].BackColor = Color.White;

                flowLayoutPanelMain.Controls.Add(picBoxArr[i]);
            }
        }
        #endregion
    }
}
