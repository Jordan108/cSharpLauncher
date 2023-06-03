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
        private string xmlColPath = "System\\Collections.xml";//Para cargar el comboBox de las colecciones
        private int[] combID = new int[0];//Para recoger el index
        private string xmlResPath = "System\\Resolutions.xml";//Cargar el combobox de las resoluciones
        private int[] combResID = new int[0];//Para recoger el index

        private string coverPath = "System\\Covers";

        private int idFile = -1;//Si es un archivo nuevo -1, si no, se actualiza con el segundo constructor
        private string xmlImagePath;//Lo ocupare para editar la caratula

        //Datos default al crear un nuevo archivo (al editar obviamente no es necesario)
        private int defaultFather, defaultRes, defaultImageLayout = 0;
        private int defaultWidth, defaultHeight = 200;


        //Creando un archivo desde 0
        public NewFile(int viewDepth, int ResId, int Width, int Height, int Layout)
        {
            InitializeComponent();
            this.defaultFather = viewDepth;
            this.defaultRes = ResId;
            this.defaultWidth = Width;
            this.defaultHeight = Height;
            this.defaultImageLayout = Layout;
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

            //Establecer los combobox seleccionados
            int fatherIndex = Array.IndexOf(combID, fileData.IDFather);
            int resolutionIndex = Array.IndexOf(combResID, fileData.ResolutionID);

            Console.WriteLine("father index: " + fatherIndex);
            Console.WriteLine("resolution index: " + resolutionIndex);
            //if (fatherIndex < 0) fatherIndex = 0;
            comboBoxFather.SelectedIndex = fatherIndex+1;
            //if (resolutionIndex < 0) resolutionIndex = 0;
            comboBoxResolution.SelectedIndex = resolutionIndex+1;

            

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
            buttonColorPickIMG.BackColor = BackgroundCol; //Definir los colores para el boton de colores


            //Caratula
            if (comboBoxResolution.SelectedIndex != 0)
            {
                groupBoxSize.Enabled = false;

                //Cargar la resolucion perteneciente a esa id
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlResPath);
                string xpath = "//Launcher/resolution[@id='" + fileData.ResolutionID + "']";
                XmlNode root = doc.SelectSingleNode(xpath);


                pictureBoxCover.Width = int.Parse(root.SelectSingleNode("Width").InnerText);
                pictureBoxCover.Height = int.Parse(root.SelectSingleNode("Height").InnerText);
            }
            else
            {
                pictureBoxCover.Width = fileData.Width;
                pictureBoxCover.Height = fileData.Height;
            }

            //checkBoxImageLocation.Checked = true;
            numericWidthImage.Value = fileData.Width;
            numericHeightImage.Value = fileData.Height;
            
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
            #region idFather
            //Agregando item default
            comboBoxFather.Items.Add("Ninguno");
            comboBoxFather.SelectedIndex = 0; //Se seleccionara despues
            

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

            int fatherIndex = Array.IndexOf(combID, defaultFather);
            comboBoxFather.SelectedIndex = fatherIndex+1;
            #endregion

            #region resoluciones
            //Agregando item default
            comboBoxResolution.Items.Add("Ninguno");
            comboBoxResolution.SelectedIndex = 0;//Se selecciona despues

           //Cargar el tamaño del xml de las resoluciones y adaptar el array a eso
            int resSize = LoadResolutionSize();
            Array.Resize(ref combResID, resSize);

            Console.WriteLine("SIZE RES: " + resSize.ToString());

            //Cargar las resoluciones al combobox
            int resID = 1;
            for (int i = 1; i < (resSize + 1); i++)
            {
                Console.WriteLine("iterando en: " + i + " sobre la id: " + resID);
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlResPath);

                string xpath = "//Launcher/resolution[@id='" + resID + "']";
                XmlNode root = doc.SelectSingleNode(xpath);
                while (root == null)
                {
                    resID++;
                    xpath = "//Launcher/resolution[@id='" + resID + "']";
                    root = doc.SelectSingleNode(xpath);
                }

                string name = root.SelectSingleNode("Name").InnerText;
                string width = root.SelectSingleNode("Width").InnerText;
                string height = root.SelectSingleNode("Height").InnerText;

                comboBoxResolution.Items.Add(name+" ("+width+" x"+height+")");
                combResID[i - 1] = resID;
                resID++;
            }

            //Buscar dentro del combobox de resoluciones el index de la resolucion
            int resIndex = Array.IndexOf(combResID, defaultRes);
            comboBoxResolution.SelectedIndex = resIndex + 1;

            if (resIndex+1 > 0)
            {
                groupBoxSize.Enabled = false;
            }
            #endregion

            #endregion

            #region pictureBox size/layout
            //Aqui se cargan los datos por default que fueron creados con la coleccion
            int w = this.defaultWidth;
            int h = this.defaultHeight;

            if (this.defaultWidth < 100) { w = 100; }
            if (this.defaultWidth > 300) { w = 300; }
            if (this.defaultHeight < 100) { h = 100; }
            if (this.defaultHeight > 300) { h = 300; }


            numericWidthImage.Value = w;
            numericHeightImage.Value = h;
            pictureBoxCover.Width = w;
            pictureBoxCover.Height = h;

            //Cargar el image layout
            if (this.defaultImageLayout == 1)
            {
                radioButtonEstreched.Checked = true;
                pictureBoxCover.BackgroundImageLayout = ImageLayout.Stretch;
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

        //Cargar el tamaño de elementos con id que existen en el xml de colecciones
        private int LoadResolutionSize()
        {
            int size = 0;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlResPath);
                XmlNodeList colElements = xmlDoc.SelectNodes("//*[@id]");
                size = colElements.Count;
            }
            catch (Exception)
            {
                Console.WriteLine("No se encontro el fichero de las colecciones, se creara uno nuevo");
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlResPath, settings))
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
            if (comboBoxResolution.SelectedIndex == 0)
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

            if (resizing == 0)
            {
                if (pictureBoxCover.BackgroundImage != null)
                {
                    //Bitmap bitmap = new Bitmap(pictureBoxCover.BackgroundImage);
                    //Color color = bitmap.GetPixel(e.X, e.Y);
                    //bitmap.Dispose();

                    // Actualiza el color en el Panel
                    

                    int Cwidth = pictureBoxCover.Width;
                    int Cheight = pictureBoxCover.Height;

                    Bitmap bitmap = new Bitmap(Cwidth, Cheight);

                    Rectangle rect = new Rectangle(0, 0, Cwidth, Cheight);

                    pictureBoxCover.DrawToBitmap(bitmap, rect);

                    Color color = bitmap.GetPixel(e.X, e.Y);

                    bitmap.Dispose();

                    pictureBoxCover.BackColor = color;
                    buttonColorPickIMG.BackColor = color;
                }
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
            } else
            {
                //Controlando el tamaño
                if (comboBoxResolution.SelectedIndex == 0)
                {
                    int margin = 10;

                    //Ancho (Mouse a la derecha)
                    if (e.X >= pictureBoxCover.Width - margin && e.Y < pictureBoxCover.Height - margin)
                    {
                        this.Cursor = Cursors.SizeWE;

                    }
                    //Alto (Mouse en la parte inferior)
                    else if (e.X < pictureBoxCover.Width - margin && e.Y >= pictureBoxCover.Height - margin)
                    {
                        this.Cursor = Cursors.SizeNS;

                    }
                    //Ajustando ambos (mouse en esquina inferior derecha)
                    else if (e.X >= pictureBoxCover.Width - margin && e.Y >= pictureBoxCover.Height - margin)
                    {
                        this.Cursor = Cursors.SizeNWSE;
                    } else
                    {
                        this.Cursor = Cursors.Cross;
                    }

                } else
                {
                    this.Cursor = Cursors.Cross;
                }
            }
        }

        //Cambiar el icono del mouse
        private void pictureBoxCover_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        //Combobox de la resolucion
        private void comboBoxResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bloquear el cambio de tamaños si ajustas una resolucion
            int cmbIndex = comboBoxResolution.SelectedIndex;
            Console.WriteLine("Valor combobox: " + cmbIndex);
            if (cmbIndex != 0)
            {
                groupBoxSize.Enabled = false;

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlResPath);

                string xpath = "//Launcher/resolution[@id='" + combResID[cmbIndex - 1] + "']";
                XmlNode root = doc.SelectSingleNode(xpath);

                int width = int.Parse(root.SelectSingleNode("Width").InnerText);
                int height = int.Parse(root.SelectSingleNode("Height").InnerText);

                //Cambiar el tamaño con respecto a la resolucion escogida
                pictureBoxCover.Width = width; pictureBoxCover.Height = height;

            }
            else
            {
                groupBoxSize.Enabled = true;

                //Devolverle el tamaño a la caratula con respecto a numeric image
                int width = Convert.ToInt32(numericWidthImage.Value);
                int height = Convert.ToInt32(numericHeightImage.Value);
                pictureBoxCover.Width = width; pictureBoxCover.Height = height;
            }
        }

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
                buttonColorPickIMG.BackColor = selectedColor;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine(comboBoxFather.SelectedIndex - 1);
            int idFather = 0;
            if ((comboBoxFather.SelectedIndex - 1) >= 0)
            {
                idFather = combID[comboBoxFather.SelectedIndex - 1];
            }

            int resID = 0;
            if ((comboBoxResolution.SelectedIndex - 1) >= 0)
            {
                resID = combResID[comboBoxResolution.SelectedIndex - 1];
            }

            string nameFile = textBoxName.Text;
            //Evitar que se guarde la imagen con caracteres invalidos
            string cleanName = Path.GetInvalidFileNameChars().Aggregate(textBoxName.Text, (current, c) => current.Replace(c.ToString(), string.Empty));
            string imgPath = "";

            if (pictureBoxCover.Tag != null)
            {
                if (checkBoxImageLocation.Checked == true)
                {
                    imgPath = pictureBoxCover.Tag.ToString();
                } else
                {
                    //string outputFolder = System.Environment.CurrentDirectory + "\\System\\Covers";
                    string outputFolder = coverPath;

                    //Si estas creando un nuevo archivo, verificar si no existe un archivo con el mismo nombre, y si es asi, ponerle un iterador
                    if (idFile == -1)
                    {
                        imgPath = returnImagePath(outputFolder, cleanName);
                    } else
                    {
                        //Si estas editando un archivo, ocupar la misma direccion que en el xml, pues el nombre se decidio al crearlo (arriba)
                        if (xmlImagePath != null)
                        {
                            //string systemCoverDir = System.Environment.CurrentDirectory + "\\System\\Covers";
                            string systemCoverDir = coverPath;
                            string xmlDir = Path.GetDirectoryName(xmlImagePath);
                            if (xmlDir != systemCoverDir)
                            {
                                imgPath = returnImagePath(outputFolder, cleanName);
                            }
                            else
                            {
                                imgPath = xmlImagePath;//pictureBoxCover.Tag.ToString();
                            }
                        } else
                        {
                            imgPath = returnImagePath(outputFolder, cleanName);
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
            int width = pictureBoxCover.Width;
            int height = pictureBoxCover.Height;
            bool url = checkBoxURL.Checked;
            int[] tagsArray = new int[] { 1, 2, 3};
            bool favorite = checkBoxFavorite.Checked;


            Files passFile = new Files(idFile, idFather, nameFile, imgPath, imgLayout, filePath, programPath, cmdLine, R, G, B, resID, width, height, url, tagsArray, favorite);
            ReturnedObject?.Invoke(this, passFile);
            this.Close();
        }

        //Liberar memoria de la caratula al cerrar el formulario
        private void NewFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pictureBoxCover.BackgroundImage != null) pictureBoxCover.BackgroundImage.Dispose();//Dejar de utilizar la imagen de fondo en memoria
        }
    }
}
