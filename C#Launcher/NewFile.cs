using C_Launcher.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace C_Launcher
{
    public partial class NewFile : Form
    {
        private int currentX, currentY;
        private int resizing = 0; // 0=no se esta ajustando; 1=ajustando ancho; 2=ajustando alto; 3=ajustando ambos
        public event EventHandler<Files> ReturnedObject;
        private string xmlColPath = "System\\Collections.xml";//Para cargar el comboBox
        private int[] combID = new int[0];

        private int idFile = -1;//Si es un archivo nuevo -1, si no, se actualiza con el segundo constructor
        private string xmlImagePath;//Lo ocupare para editar la caratula
        //private Image imagen;

        //Creando un archivo desde 0
        public NewFile()
        {
            InitializeComponent();
            CustomComponent();
        }

        //Editando un archivo existente
        public NewFile(Files fileData)
        {
            InitializeComponent();
            CustomComponent();
            idFile = fileData.ID;//Actualizar la id para editarla
            textBoxName.Text = fileData.Name;
            checkBoxFavorite.Checked = fileData.Favorite;

            //Archivos
            checkBoxURL.Checked = fileData.URLCheck;
            if (checkBoxURL.Checked == true)
            {
                labelFilePath.Text = "URL";
                labelFilePath.Location = new Point(98, 164);
                buttonSearchFile.Enabled = false;
                labelOptional.Enabled = false;
                labelProgramPath.Enabled = false;
                textBoxProgramPath.Enabled = false;
                buttonSearchProgram.Enabled = false;
                labelCMD.Enabled = false;
                textBoxCMD.Enabled = false;
            }
            textBoxFilePath.Text = fileData.FilePath;
            textBoxProgramPath.Text = fileData.ProgramPath;
            textBoxCMD.Text = fileData.CMDLine;

            
            //Picture Box
            Color BackgroundCol = Color.FromArgb(255, fileData.ColorRed, fileData.ColorGreen, fileData.ColorBlue);
            pictureBoxCover.BackColor = BackgroundCol;
            //Caratula
            checkBoxImageLocation.Checked = true;
            numericWidthImage.Value = fileData.Width;
            numericHeightImage.Value = fileData.Height;
            pictureBoxCover.Width = fileData.Width;
            pictureBoxCover.Height = fileData.Height;
            if (fileData.ImagePath != "")
            {
                try
                {
                    Image image;
                    using (Stream stream = File.OpenRead(fileData.ImagePath))
                    {
                        image = System.Drawing.Image.FromStream(stream);
                    }
                    pictureBoxCover.BackgroundImage = image;
                    pictureBoxCover.Tag = fileData.ImagePath;
                    xmlImagePath = fileData.ImagePath;//Para editar la imagen
                    image = null;

                    //imagen = Image.FromFile(fileData.ImagePath);
                    //pictureBoxCover.BackgroundImage = imagen;
                    //pictureBoxCover.Tag = fileData.ImagePath;
                    Console.WriteLine("/////////////////Imagen " + fileData.ImagePath + " establecida//////////////////////");
                }
                catch //(Exception ex)
                {
                    Console.WriteLine("no se pudo establecer una imagen");
                }
            }

            if (fileData.ImageLayout == 1)
            {
                radioButtonEstreched.Checked = true;
                pictureBoxCover.BackgroundImageLayout = ImageLayout.Stretch;
            }

        }

        private void CustomComponent()
        {
            //Scripts para ajustar el tamaño del picture box
            this.pictureBoxCover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseDown);
            this.pictureBoxCover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseMove);
            this.pictureBoxCover.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseUp);

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
                Image image;
                using (Stream stream = File.OpenRead(openFileDialog.FileName))
                {
                    image = System.Drawing.Image.FromStream(stream);
                }
                pictureBoxCover.BackgroundImage = image;
                pictureBoxCover.Tag = openFileDialog.FileName;
                image = null;

                //imagen = Image.FromFile(openFileDialog.FileName);
                //pictureBoxCover.BackgroundImage = imagen;
                //pictureBoxCover.Tag = openFileDialog.FileName;//Establecer la ruta de la imagen
            }
            openFileDialog.Dispose();
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

        private void checkBoxURL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxURL.Checked == true)
            {
                labelFilePath.Text = "URL";
                labelFilePath.Location = new Point(98, 164);
                buttonSearchFile.Enabled = false;
                labelOptional.Enabled = false;
                labelProgramPath.Enabled = false;
                textBoxProgramPath.Enabled = false;
                buttonSearchProgram.Enabled = false;
                labelCMD.Enabled = false;
                textBoxCMD.Enabled = false;
            } else
            {
                labelFilePath.Text = "Ruta del archivo";
                labelFilePath.Location = new Point(45, 164);
                buttonSearchFile.Enabled = true;
                labelOptional.Enabled = true;
                labelProgramPath.Enabled = true;
                textBoxProgramPath.Enabled = true;
                buttonSearchProgram.Enabled = true;
                labelCMD.Enabled = true;
                textBoxCMD.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine(comboBoxFather.SelectedIndex - 1);
            int idFather = 0;
            if ((comboBoxFather.SelectedIndex - 1) > 0)
            {
                idFather = combID[comboBoxFather.SelectedIndex - 1];
            }
            string nameFile = textBoxName.Text;
            string imgPath = "";

            if (pictureBoxCover.Tag != null)
            {
                if (checkBoxImageLocation.Checked == true)
                {
                    imgPath = pictureBoxCover.Tag.ToString();
                } else
                {
                    string outputFolder = System.Environment.CurrentDirectory + "\\System\\Covers";

                    //Si estas creando un nuevo archivo, verificar si no existe un archivo con el mismo nombre, y si es asi, ponerle un iterador
                    if (idFile == -1)
                    {
                        imgPath = returnImagePath(outputFolder, textBoxName.Text);
                    } else
                    {
                        //Si estas editando un archivo, ocupar la misma direccion que en el xml, pues el nombre se decidio al crearlo (arriba)
                        if (xmlImagePath != null)
                        {
                            string systemCoverDir = System.Environment.CurrentDirectory + "\\System\\Covers";
                            string xmlDir = Path.GetDirectoryName(xmlImagePath);
                            if (xmlDir != systemCoverDir)
                            {
                                imgPath = returnImagePath(outputFolder, textBoxName.Text);
                            }
                            else
                            {
                                imgPath = xmlImagePath;//pictureBoxCover.Tag.ToString();
                            }
                        } else
                        {
                            imgPath = returnImagePath(outputFolder, textBoxName.Text);
                        }
                        
                    }

                    if (!Directory.Exists(outputFolder))
                    {
                        // Crea la carpeta si no existe
                        Directory.CreateDirectory(outputFolder);
                    }

                    string source = pictureBoxCover.Tag.ToString();
                    //Solo reemplazar una imagen si esta existe o si la imagen de origen no es la misma que el destino
                    if ((imgPath != "") && (imgPath != null) && (source != imgPath))
                    {
                        System.IO.File.Copy(source, imgPath, true);
                    }
                }
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


            Files passFile = new Files(idFile, idFather, nameFile, imgPath, imgLayout, filePath, programPath, cmdLine, R, G, B, resID, width, height, url, tagsArray, favorite);
            ReturnedObject?.Invoke(this, passFile);
            this.Close();
        }

        private string returnImagePath(string outputFolder, string fileName)
        {
            string destinationFile = outputFolder + "\\file_" + fileName + ".png";
            int i = 0;
            while (File.Exists(destinationFile))
            {
                i++;
                destinationFile = outputFolder + "\\file_" + fileName + "(" + i + ").png";//Se le cambia la extension a png
            }
            return destinationFile;
        }
    }
}
