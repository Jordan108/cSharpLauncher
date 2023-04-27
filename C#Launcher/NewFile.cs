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
using System.Xml.Linq;

namespace C_Launcher
{
    public partial class NewFile : Form
    {
        private int currentX, currentY;
        private int resizing = 0; // 0=no se esta ajustando; 1=ajustando ancho; 2=ajustando alto; 3=ajustando ambos
        public event EventHandler<Files> ReturnedObject;


        public NewFile()
        {
            InitializeComponent();
            //Scripts para ajustar el tamaño del picture box
            this.pictureBoxCover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseDown);
            this.pictureBoxCover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseMove);
            this.pictureBoxCover.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseUp);
        }

        #region Buscar archivos y programas
        private void buttonSearchFile_Click(object sender, EventArgs e)
        {
            //No tiene filtro
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog.FileName;
            }
        }

        private void buttonSearchProgram_Click(object sender, EventArgs e)
        {
            //No tiene filtro
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxProgramPath.Text = openFileDialog.FileName;
            }
        }

        #endregion

        #region Modificar picturebox/caratula

        #region Modificar ancho/alto
        private void pictureBoxCover_MouseDown(object sender, MouseEventArgs e)
        {
            int margin = 10;

            //Ancho (Mouse a la derecha)
            if (e.X >= pictureBoxCover.Width - margin && e.Y < pictureBoxCover.Height - margin)
            {
                //isResizing = true;
                resizing = 1;
                this.Cursor = Cursors.SizeWE;
                currentX = e.X;
                currentY = 0;

            }

            //Alto (Mouse en la parte inferior)
            if (e.X < pictureBoxCover.Width - margin && e.Y >= pictureBoxCover.Height - margin)
            {
                //isResizing = true;
                resizing = 2;
                this.Cursor = Cursors.SizeNS;
                currentX = 0;
                currentY = e.Y;

            }

            //Ajustando ambos (mouse en esquina inferior derecha)
            if (e.X >= pictureBoxCover.Width - margin && e.Y >= pictureBoxCover.Height - margin)
            {
                resizing = 3;
                this.Cursor = Cursors.SizeNWSE;
                currentX = e.X;
                currentY = e.Y;
            }
        }

        private void pictureBoxCover_MouseMove(object sender, MouseEventArgs e)
        {
            // Verifique si estamos cambiando el tamaño
            if (resizing > 0)
            {
                // Calcule el nuevo ancho y alto del PictureBox
                int newWidth = pictureBoxCover.Width + (e.X - currentX);
                int newHeight = pictureBoxCover.Height + (e.Y - currentY);

                //Ajustar los limites de ancho y alto
                if (newWidth < 100) newWidth = 100;
                if (newWidth > 300) newWidth = 300;
                if (newHeight < 100) newHeight = 100;
                if (newHeight > 300) newHeight = 300;



                // Establecer el nuevo ancho y alto del PictureBox
                if (resizing != 2)//No ajustar el ancho si solo estamos cambiando el alto
                {
                    pictureBoxCover.Width = newWidth;
                    numericWidthImage.Value = newWidth;
                }
                if (resizing != 1)
                {
                    //No ajustar el alto si solo estamos cambiando el ancho
                    pictureBoxCover.Height = newHeight;
                    numericHeightImage.Value = newHeight;
                }

                // Actualizar las coordenadas actuales del mouse
                if (resizing != 2) currentX = e.X;
                if (resizing != 1) currentY = e.Y;
            }
        }

        private void pictureBoxCover_MouseUp(object sender, MouseEventArgs e)
        {
            // Dejar de cambiar el tamaño
            resizing = 0;
            this.Cursor = Cursors.Arrow;
        }

        private void numericWidthImage_ValueChanged(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(numericWidthImage.Value);

            if (width < 100) width = 100;
            if (width > 300) width = 300;


            pictureBoxCover.Width = width;
        }

        private void numericHeightImage_ValueChanged(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(numericHeightImage.Value);

            if (height < 100) height = 100;
            if (height > 300) height = 300;


            pictureBoxCover.Height = height;
        }
        #endregion

        //Image layout
        private void radioButtonZoom_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxCover.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void radioButtonEstreched_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxCover.BackgroundImageLayout = ImageLayout.Stretch;
        }

        //Buscar caratula y establecerla
        private void buttonSearchCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;)|*.png;*.jpg;*.jpeg;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCover.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                pictureBoxCover.Tag = openFileDialog.FileName;//Establecer la ruta de la imagen
            }
        }

        //Color picker
        private void buttonSetColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Aquí obtienes el color seleccionado
                Color selectedColor = colorDialog.Color;

                pictureBoxCover.BackColor = selectedColor;
            }
        }
        #endregion

        

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int idFather = 0;
            string nameFile = textBoxName.Text;
            string imgPath = "";
            if (pictureBoxCover.Tag != null)
            {
                imgPath = pictureBoxCover.Tag.ToString();
            }

            //Image layout
            int imgLayout = 0;
            if (radioButtonEstreched.Checked == true) imgLayout = 1;

            string filePath = textBoxFilePath.Text;
            string programPath = textBoxProgramPath.Text;
            string cmdLine = textBoxCMD.Text;
            int R = pictureBoxCover.BackColor.R;
            int G = pictureBoxCover.BackColor.G;
            int B = pictureBoxCover.BackColor.B;
            int resID = 0;
            int width = pictureBoxCover.Width;
            int height = pictureBoxCover.Height;
            bool url = checkBoxURL.Checked;
            int[] tagsArray = new int[] { 1, 2, 3};
            bool favorite = checkBoxFavorite.Checked;

            Files passFile = new Files(-1, idFather, nameFile, imgPath, imgLayout, filePath, programPath, cmdLine, R, G, B, resID, width, height, url, tagsArray, favorite);
            ReturnedObject?.Invoke(this, passFile);
            this.Close();
        }
    }
}
