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
using System.Xml;

namespace C_Launcher
{
    public partial class NewCollection : Form
    {
        private int currentX, currentY;
        private int resizing = 0; // 0=no se esta ajustando; 1=ajustando ancho; 2=ajustando alto; 3=ajustando ambos
        private int currentSonX, currentSonY;
        private int resizingSon = 0; //mismos datos que original
        public event EventHandler<Collections> ReturnedObject;
        private string xmlColPath = "Collections.xml";
        private int[] combID = new int[0];

        //Id de la coleccion, si es nuevo, -1, si no, se establece
        private int idCollection = -1;
        public NewCollection()
        {
            InitializeComponent();
            CustomComponent();
        }

        public NewCollection(Collections colData)
        {
            InitializeComponent();
            CustomComponent();
            idCollection = colData.ID;//Actualizar la id para editarla
            textBoxName.Text = colData.Name;
            checkBoxFavorite.Checked = colData.Favorite;

            //RGB
            //Color BackgroundCol = new Color();
            Color BackgroundCol = Color.FromArgb(255, colData.ColorRed, colData.ColorGreen, colData.ColorBlue);
            pictureBoxCoverCollection.BackColor = BackgroundCol;
            //Caratula
            numericColWidth.Value = colData.Width;
            numericColHeight.Value = colData.Height;
            pictureBoxCoverCollection.Width = colData.Width;
            pictureBoxCoverCollection.Height = colData.Height;
            if (colData.ImagePath != "")
            {
                try
                {
                    Image imagen = Image.FromFile(colData.ImagePath);
                    pictureBoxCoverCollection.BackgroundImage = imagen;
                    pictureBoxCoverCollection.Tag = colData.ImagePath;
                    Console.WriteLine("/////////////////Imagen " + colData.ImagePath + " establecida//////////////////////");
                }
                catch //(Exception ex)
                {
                    Console.WriteLine("no se pudo establecer una imagen");
                }
            }

            if (colData.ImageLayout == 1)
            {
                radioButtonColEstreched.Checked = true;
                pictureBoxCoverCollection.BackgroundImageLayout = ImageLayout.Stretch;
            }

            //Caratula hijos
            numericSonWidth.Value = colData.SonWidth;
            numericSonHeight.Value = colData.SonHeight;
            pictureBoxCoverSon.Width = colData.SonWidth;
            pictureBoxCoverSon.Height = colData.SonHeight;
            if (colData.SonLayout == 1)
            {
                radioButtonSonEstreched.Checked = true;
                pictureBoxCoverSon.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void CustomComponent()
        {
            //Manejar coverBox de la coleccion
            //Coleccion
            this.pictureBoxCoverCollection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverCollection_MouseDown);
            this.pictureBoxCoverCollection.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverCollection_MouseMove);
            this.pictureBoxCoverCollection.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverCollection_MouseUp);
            //Hijos de la coleccion
            this.pictureBoxCoverSon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverSon_MouseDown);
            this.pictureBoxCoverSon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverSon_MouseMove);
            this.pictureBoxCoverSon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverSon_MouseUp);

            #region Combobox
            //Agregando item default
            comboBoxFather.Items.Add("Ninguno");
            comboBoxFather.SelectedIndex = 0;

            //Añadir las colecciones al comboBox de padres
            int colSize = LoadCollectionSize();
            Array.Resize(ref combID, colSize);

            Console.WriteLine("SIZE: " + colSize.ToString());

            int ColID = 1;
            for (int i = 1; i < (colSize + 1); i++)
            {
                Console.WriteLine("iterando en: " + i + " sobre la id: " + ColID);
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlColPath);

                string xpath = "//Launcher/collection[@id='" + ColID + "']";
                XmlNode root = doc.SelectSingleNode(xpath);
                while (root == null)
                {
                    ColID++;
                    xpath = "//Launcher/collection[@id='" + ColID + "']";
                    root = doc.SelectSingleNode(xpath);
                }

                string name = root.SelectSingleNode("Name").InnerText;

                comboBoxFather.Items.Add(name);
                combID[i - 1] = ColID;
                ColID++;
            }
            #endregion
        }

        #region Manejar archivos XML
        private int LoadCollectionSize()
        {
            int size = 0;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlColPath);
                XmlNodeList colElements = xmlDoc.SelectNodes("//*[@id]");
                size = colElements.Count;
            }
            catch (Exception)
            {
                Console.WriteLine("No se encontro el fichero de las colecciones, se creara uno nuevo");
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlColPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            return size;
        }
        #endregion

        #region Modificar ancho y alto de los coverbox
        #region Collection Coverbox
        private void pictureBoxCoverCollection_MouseDown(object sender, MouseEventArgs e)
        {
            int margin = 10;

            //Ancho (Mouse a la derecha)
            if (e.X >= pictureBoxCoverCollection.Width - margin && e.Y < pictureBoxCoverCollection.Height - margin)
            {
                //isResizing = true;
                resizing = 1;
                this.Cursor = Cursors.SizeWE;
                currentX = e.X;
                currentY = 0;

            }

            //Alto (Mouse en la parte inferior)
            if (e.X < pictureBoxCoverCollection.Width - margin && e.Y >= pictureBoxCoverCollection.Height - margin)
            {
                //isResizing = true;
                resizing = 2;
                this.Cursor = Cursors.SizeNS;
                currentX = 0;
                currentY = e.Y;

            }

            //Ajustando ambos (mouse en esquina inferior derecha)
            if (e.X >= pictureBoxCoverCollection.Width - margin && e.Y >= pictureBoxCoverCollection.Height - margin)
            {
                resizing = 3;
                this.Cursor = Cursors.SizeNWSE;
                currentX = e.X;
                currentY = e.Y;
            }
        }

        private void pictureBoxCoverCollection_MouseMove(object sender, MouseEventArgs e)
        {
            // Verifique si estamos cambiando el tamaño
            if (resizing > 0)
            {
                // Calcule el nuevo ancho y alto del PictureBox
                int newWidth = pictureBoxCoverCollection.Width + (e.X - currentX);
                int newHeight = pictureBoxCoverCollection.Height + (e.Y - currentY);

                //Ajustar los limites de ancho y alto
                if (newWidth < 100) newWidth = 100;
                if (newWidth > 300) newWidth = 300;
                if (newHeight < 100) newHeight = 100;
                if (newHeight > 300) newHeight = 300;



                // Establecer el nuevo ancho y alto del PictureBox
                if (resizing != 2)//No ajustar el ancho si solo estamos cambiando el alto
                {
                    pictureBoxCoverCollection.Width = newWidth;
                    numericColWidth.Value = newWidth;
                }
                if (resizing != 1)
                {
                    //No ajustar el alto si solo estamos cambiando el ancho
                    pictureBoxCoverCollection.Height = newHeight;
                    numericColHeight.Value = newHeight;
                }

                // Actualizar las coordenadas actuales del mouse
                if (resizing != 2) currentX = e.X;
                if (resizing != 1) currentY = e.Y;
            }
        }

        private void pictureBoxCoverCollection_MouseUp(object sender, MouseEventArgs e)
        {
            // Dejar de cambiar el tamaño
            resizing = 0;
            this.Cursor = Cursors.Arrow;
        }

        private void numericColWidth_ValueChanged(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(numericColWidth.Value);

            if (width < 100) width = 100;
            if (width > 300) width = 300;

            pictureBoxCoverCollection.Width = width;
        }

        private void numericColHeight_ValueChanged(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(numericColHeight.Value);

            if (height < 100) height = 100;
            if (height > 300) height = 300;

            pictureBoxCoverCollection.Height = height;
        }

        
        #endregion

        #region Son coverbox
        private void pictureBoxCoverSon_MouseDown(object sender, MouseEventArgs e)
        {
            int margin = 10;

            //Ancho (Mouse a la derecha)
            if (e.X >= pictureBoxCoverSon.Width - margin && e.Y < pictureBoxCoverSon.Height - margin)
            {
                resizingSon = 1;
                this.Cursor = Cursors.SizeWE;
                currentSonX = e.X;
                currentSonY = 0;

            }

            //Alto (Mouse en la parte inferior)
            if (e.X < pictureBoxCoverSon.Width - margin && e.Y >= pictureBoxCoverSon.Height - margin)
            {
                resizingSon = 2;
                this.Cursor = Cursors.SizeNS;
                currentSonX = 0;
                currentSonY = e.Y;

            }

            //Ajustando ambos (mouse en esquina inferior derecha)
            if (e.X >= pictureBoxCoverSon.Width - margin && e.Y >= pictureBoxCoverSon.Height - margin)
            {
                resizingSon = 3;
                this.Cursor = Cursors.SizeNWSE;
                currentSonX = e.X;
                currentSonY = e.Y;
            }
        }

        private void pictureBoxCoverSon_MouseMove(object sender, MouseEventArgs e)
        {
            // Verifique si estamos cambiando el tamaño
            if (resizingSon > 0)
            {
                // Calcule el nuevo ancho y alto del PictureBox
                int newWidth = pictureBoxCoverSon.Width + (e.X - currentSonX);
                int newHeight = pictureBoxCoverSon.Height + (e.Y - currentSonY);

                //Ajustar los limites de ancho y alto
                if (newWidth < 100) newWidth = 100;
                if (newWidth > 300) newWidth = 300;
                if (newHeight < 100) newHeight = 100;
                if (newHeight > 300) newHeight = 300;



                // Establecer el nuevo ancho y alto del PictureBox
                if (resizingSon != 2)//No ajustar el ancho si solo estamos cambiando el alto
                {
                    pictureBoxCoverSon.Width = newWidth;
                    numericSonWidth.Value = newWidth;
                }
                if (resizingSon != 1)
                {
                    //No ajustar el alto si solo estamos cambiando el ancho
                    pictureBoxCoverSon.Height = newHeight;
                    numericSonHeight.Value = newHeight;
                }

                // Actualizar las coordenadas actuales del mouse
                if (resizingSon != 2) currentSonX = e.X;
                if (resizingSon != 1) currentSonY = e.Y;
            }
        }

        private void pictureBoxCoverSon_MouseUp(object sender, MouseEventArgs e)
        {
            // Dejar de cambiar el tamaño
            resizingSon = 0;
            this.Cursor = Cursors.Arrow;
        }

        private void numericSonWidth_ValueChanged(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(numericSonWidth.Value);

            if (width < 100) width = 100;
            if (width > 300) width = 300;

            pictureBoxCoverSon.Width = width;
        }

        private void numericSonHeight_ValueChanged(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(numericSonHeight.Value);

            if (height < 100) height = 100;
            if (height > 300) height = 300;

            pictureBoxCoverSon.Height = height;
        }
        #endregion

        #endregion

        #region Caratula
        //Buscar caratula de la coleccion
        private void buttonSearchCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;)|*.png;*.jpg;*.jpeg;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCoverCollection.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                pictureBoxCoverCollection.Tag = openFileDialog.FileName;//Establecer la ruta de la imagen
            }
        }
       
        //Buscar caratula de prueba
        private void buttonSearchSonCoverTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;)|*.png;*.jpg;*.jpeg;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCoverSon.BackgroundImage = Image.FromFile(openFileDialog.FileName);
            }
        }

        #region Image layout cheked
        private void radioButtonColZoom_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxCoverCollection.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void radioButtonColEstreched_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxCoverCollection.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void radioButtonSonZoom_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxCoverSon.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void radioButtonSonEstreched_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxCoverSon.BackgroundImageLayout = ImageLayout.Stretch;
        }
        #endregion

        #endregion

        //Color picker
        private void buttonBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Aquí obtienes el color seleccionado
                Color selectedColor = colorDialog.Color;

                pictureBoxCoverCollection.BackColor = selectedColor;
            }
        }

        //Guardar coleccion
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine(comboBoxFather.SelectedIndex - 1);
            int idFather = 0;
            if ((comboBoxFather.SelectedIndex - 1) > 0)
            {
               idFather = combID[comboBoxFather.SelectedIndex - 1];
            }
            
            string nameCollection = textBoxName.Text;
            string imgPath = "";
            if (pictureBoxCoverCollection.Tag != null)
            {
                imgPath = pictureBoxCoverCollection.Tag.ToString();
            }

            //Image layout
            int imgLayout = 0;
            if (radioButtonColEstreched.Checked == true) imgLayout = 1;

            int R = pictureBoxCoverCollection.BackColor.R;
            int G = pictureBoxCoverCollection.BackColor.G;
            int B = pictureBoxCoverCollection.BackColor.B;
            //Propiedades caratula 
            int resID = 0;
            int width = pictureBoxCoverCollection.Width;
            int height = pictureBoxCoverCollection.Height;

            //Propiedades Hijos
            int resSonID = 0;
            int sonWidth = pictureBoxCoverSon.Width;
            int sonHeight = pictureBoxCoverSon.Height;
            int sonLayout = 0;
            if (radioButtonSonEstreched.Checked == true) sonLayout = 1;

            int[] tagsArray = new int[] { 1, 2, 3 };
            bool favorite = checkBoxFavorite.Checked;

            Collections passCollection = new Collections(idCollection, idFather, nameCollection, imgPath, imgLayout, R, G, B, resID, width, height, resSonID, sonWidth, sonHeight, sonLayout, tagsArray, favorite);
            ReturnedObject?.Invoke(this, passCollection);
            this.Close();
        }
    }
}
