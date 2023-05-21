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

namespace C_Launcher
{
    public partial class NewCollection : Form
    {
        private int currentX, currentY;
        private int resizing = 0; // 0=no se esta ajustando; 1=ajustando ancho; 2=ajustando alto; 3=ajustando ambos
        private int currentSonX, currentSonY;
        private int resizingSon = 0; //mismos datos que original
        public event EventHandler<Collections> ReturnedObject;
        //Combobox del padre
        private string xmlColPath = "System\\Collections.xml";
        private int[] combID = new int[0];
        //Combobox de las resoluciones
        private string xmlResPath = "System\\Resolutions.xml";//Cargar el combobox de las resoluciones
        private int[] combResID = new int[0];//Para recoger el index
        //private int[] combResSonID = new int[0];//Para recoger el index de los archivos

        //Id de la coleccion, si es nuevo, -1, si no, se establece
        private int idCollection = -1;
        private string xmlImagePath;//Lo ocupare para editar la caratula
        //Creando un archivo desde 0

        //Datos default al crear una nueva coleccion (al editar obviamente no es necesario; no afecta a los datos de los hijos, por que esos lo tiene que editar el usuario)
        private int defaultFather, defaultRes, defaultImageLayout = 0;
        private int defaultWidth, defaultHeight = 100;
        public NewCollection(int viewDepth, int ResId, int Width, int Height, int Layout)
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
        public NewCollection(Collections colData)
        {
            InitializeComponent();
            CustomComponent();
            idCollection = colData.ID;//Actualizar la id para editarla
            textBoxName.Text = colData.Name;
            checkBoxFavorite.Checked = colData.Favorite;

            //Establecer los combobox seleccionados
            int fatherIndex = Array.IndexOf(combID, colData.IDFather);
            int resolutionIndex = Array.IndexOf(combResID, colData.ResolutionID);
            int resolutionSonIndex = Array.IndexOf(combResID, colData.SonResolution);

            Console.WriteLine("father index: " + fatherIndex);
            Console.WriteLine("resolution index: " + resolutionIndex);
            //if (fatherIndex < 0) fatherIndex = 0;
            comboBoxFather.SelectedIndex = fatherIndex + 1;
            //if (resolutionIndex < 0) resolutionIndex = 0;
            comboBoxResolutionCol.SelectedIndex = resolutionIndex + 1;
            comboBoxSonResolution.SelectedIndex = resolutionSonIndex + 1;

            //RGB
            //Color BackgroundCol = new Color();
            Color BackgroundCol = Color.FromArgb(255, colData.ColorRed, colData.ColorGreen, colData.ColorBlue);
            pictureBoxCoverCollection.BackColor = BackgroundCol;
            //Caratula
            checkBoxImageLocation.Checked = true;
            numericColWidth.Value = colData.Width;
            numericColHeight.Value = colData.Height;
            pictureBoxCoverCollection.Width = colData.Width;
            pictureBoxCoverCollection.Height = colData.Height;
            if (colData.ImagePath != "")
            {
                try
                {
                    Image image;
                    using (Stream stream = File.OpenRead(colData.ImagePath))
                    {
                        image = System.Drawing.Image.FromStream(stream);
                    }
                    pictureBoxCoverCollection.BackgroundImage = image;
                    pictureBoxCoverCollection.Tag = colData.ImagePath;
                    xmlImagePath = colData.ImagePath;//Para editar la imagen
                    image = null;
                    //Image imagen = Image.FromFile(colData.ImagePath);
                    //pictureBoxCoverCollection.BackgroundImage = imagen;
                    //pictureBoxCoverCollection.Tag = colData.ImagePath;
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
            int w = colData.SonWidth;
            int h = colData.SonHeight;

            if (w < 100) { w = 100; }
            if (w > 300) { w = 300; }
            if (h < 100) { h = 100; }
            if (h > 300) { h = 300; }

            numericSonWidth.Value = w;
            numericSonHeight.Value = h;
            pictureBoxCoverSon.Width = w;
            pictureBoxCoverSon.Height = h;
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
            comboBoxFather.SelectedIndex = fatherIndex + 1;
            #endregion

            #region resolution
            //Agregando item default
            comboBoxResolutionCol.Items.Add("Ninguno");
            comboBoxResolutionCol.SelectedIndex = 0; //Se selecciona despues

            comboBoxSonResolution.Items.Add("Ninguno");
            comboBoxSonResolution.SelectedIndex = 0;

            //Añadir las colecciones al comboBox de padres
            int resSize = LoadResolutionSize();
            Array.Resize(ref combResID, resSize);
            

            Console.WriteLine("SIZE RES: " + resSize.ToString());

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

                comboBoxResolutionCol.Items.Add(name + " (" + width + " x" + height + ")");
                comboBoxSonResolution.Items.Add(name + " (" + width + " x" + height + ")");
                combResID[i - 1] = resID;
                resID++;
            }

            //Buscar la resolucion default de esa coleccion
            int resIndex = Array.IndexOf(combResID, defaultRes);
            comboBoxResolutionCol.SelectedIndex = resIndex + 1;

            if (resIndex + 1 > 0)
            {
                groupBoxCover.Enabled = false;
            }
            #endregion
            #endregion

            #region pictureBox size/layout de la coleccion
            //Aqui se cargan los datos por default que fueron creados con la coleccion
            int w = this.defaultWidth;
            int h = this.defaultHeight;

            if (this.defaultWidth < 100) { w = 100; }
            if (this.defaultWidth > 300) { w = 300; }
            if (this.defaultHeight < 100) { h = 100; }
            if (this.defaultHeight > 300) { h = 300; }


            numericColWidth.Value = w;
            numericColHeight.Value = h;
            pictureBoxCoverCollection.Width = w;
            pictureBoxCoverCollection.Height = h;

            //Cargar el image layout
            if (this.defaultImageLayout == 1)
            {
                radioButtonColEstreched.Checked = true;
                pictureBoxCoverCollection.BackgroundImageLayout = ImageLayout.Stretch;
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

        #region Modificar coverbox
        #region Collection Coverbox
        //Combobox resolucion
        private void comboBoxResolutionCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bloquear el cambio de tamaños si ajustas una resolucion
            int cmbIndex = comboBoxResolutionCol.SelectedIndex;
            Console.WriteLine("Valor combobox: " + cmbIndex);
            if (cmbIndex != 0)
            {
                groupBoxCover.Enabled = false;

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlResPath);

                string xpath = "//Launcher/resolution[@id='" + combResID[cmbIndex - 1] + "']";
                XmlNode root = doc.SelectSingleNode(xpath);

                int width = int.Parse(root.SelectSingleNode("Width").InnerText);
                int height = int.Parse(root.SelectSingleNode("Height").InnerText);

                //Cambiar el tamaño con respecto a la resolucion escogida
                pictureBoxCoverCollection.Width = width; pictureBoxCoverCollection.Height = height;

            }
            else
            {
                groupBoxCover.Enabled = true;

                //Devolverle el tamaño a la caratula con respecto a numeric image
                int width = Convert.ToInt32(numericColWidth.Value);
                int height = Convert.ToInt32(numericColHeight.Value);
                pictureBoxCoverCollection.Width = width; pictureBoxCoverCollection.Height = height;
            }
        }

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
        //Combobox resolucion
        private void comboBoxSonResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bloquear el cambio de tamaños si ajustas una resolucion
            int cmbIndex = comboBoxSonResolution.SelectedIndex;
            Console.WriteLine("Valor combobox: " + cmbIndex);
            if (cmbIndex != 0)
            {
                groupBoxSon.Enabled = false;

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlResPath);

                string xpath = "//Launcher/resolution[@id='" + combResID[cmbIndex - 1] + "']";
                XmlNode root = doc.SelectSingleNode(xpath);

                int width = int.Parse(root.SelectSingleNode("Width").InnerText);
                int height = int.Parse(root.SelectSingleNode("Height").InnerText);

                //Cambiar el tamaño con respecto a la resolucion escogida
                pictureBoxCoverSon.Width = width; pictureBoxCoverSon.Height = height;

            }
            else
            {
                groupBoxSon.Enabled = true;

                //Devolverle el tamaño a la caratula con respecto a numeric image
                int width = Convert.ToInt32(numericSonWidth.Value);
                int height = Convert.ToInt32(numericSonHeight.Value);
                pictureBoxCoverSon.Width = width; pictureBoxCoverSon.Height = height;
            }
        }

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
                Image image;
                using (Stream stream = File.OpenRead(openFileDialog.FileName))
                {
                    image = System.Drawing.Image.FromStream(stream);
                }
                pictureBoxCoverCollection.BackgroundImage = image;
                pictureBoxCoverCollection.Tag = openFileDialog.FileName;
                image = null;

                //pictureBoxCoverCollection.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                //pictureBoxCoverCollection.Tag = openFileDialog.FileName;//Establecer la ruta de la imagen
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

        private void panelSonImageLimit_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private string returnImagePath(string outputFolder, string fileName)
        {
            string destinationFile = outputFolder + "\\col_" + fileName + ".png";
            int i = 0;
            while (File.Exists(destinationFile))
            {
                i++;
                destinationFile = outputFolder + "\\col_" + fileName + "(" + i + ").png";//Se le cambia la extension a png
            }
            return destinationFile;
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

            int resID = 0;
            if ((comboBoxResolutionCol.SelectedIndex - 1) > 0)
            {
                resID = combResID[comboBoxResolutionCol.SelectedIndex - 1];
            }

            int resSonID = 0;
            if ((comboBoxSonResolution.SelectedIndex - 1) > 0)
            {
                resSonID = combResID[comboBoxSonResolution.SelectedIndex - 1];
            }

            string nameCollection = textBoxName.Text;
            string imgPath = "";

            if (pictureBoxCoverCollection.Tag != null)
            {
                if (checkBoxImageLocation.Checked == true)
                {
                    imgPath = pictureBoxCoverCollection.Tag.ToString();
                }
                else
                {
                    string outputFolder = System.Environment.CurrentDirectory + "\\System\\Covers";

                    //Si estas creando un nuevo archivo, verificar si no existe un archivo con el mismo nombre, y si es asi, ponerle un iterador
                    if (idCollection == -1)
                    {
                        imgPath = returnImagePath(outputFolder, textBoxName.Text);
                    }
                    else
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

                        }
                        else
                        {
                            imgPath = returnImagePath(outputFolder, textBoxName.Text);
                        }

                    }

                    if (!Directory.Exists(outputFolder))
                    {
                        // Crea la carpeta si no existe
                        Directory.CreateDirectory(outputFolder);
                    }

                    string source = pictureBoxCoverCollection.Tag.ToString();
                    //Solo reemplazar una imagen si esta existe o si la imagen de origen no es la misma que el destino
                    if ((imgPath != "") && (imgPath != null) && (source != imgPath))
                    {
                        System.IO.File.Copy(source, imgPath, true);
                    }
                }
            }

            //Image layout
            int imgLayout = 0;
            if (radioButtonColEstreched.Checked == true) imgLayout = 1;

            int R = pictureBoxCoverCollection.BackColor.R;
            int G = pictureBoxCoverCollection.BackColor.G;
            int B = pictureBoxCoverCollection.BackColor.B;
            //Propiedades caratula 
            
            int width = pictureBoxCoverCollection.Width;
            int height = pictureBoxCoverCollection.Height;

            //Propiedades Hijos
            
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
