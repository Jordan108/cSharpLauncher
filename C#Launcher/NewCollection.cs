using C_Launcher.Clases;
using CoverPadLauncher;
using CoverPadLauncher.Clases;
using ImageMagick;//ImageMagick para poder manejar imagenes webp
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
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

        private string coverPath = "System\\Covers";
        private string xmlTagPath = "System\\Tags.xml";

        //Id de la coleccion, si es nuevo, -1, si no, se establece
        private int idCollection = -1;
        private string xmlImagePath;//Lo ocupare para editar la caratula
        //Creando un archivo desde 0

        //Datos default al crear una nueva coleccion (al editar obviamente no es necesario; no afecta a los datos de los hijos, por que esos lo tiene que editar el usuario)
        private int defaultFather, defaultRes, defaultImageLayout = 0;
        private int defaultWidth, defaultHeight = 200;

        
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

            //Verificar el check del fondo
            BackgroundColorCheck.Checked = colData.Background;
            
            //RGB
            //Color BackgroundCol = new Color();
            Color BackgroundCol = Color.FromArgb(255, colData.ColorRed, colData.ColorGreen, colData.ColorBlue);
            pictureBoxCoverCollection.BackColor = BackgroundCol;
            buttonColorPickIMG.BackColor = BackgroundCol;
            //Caratula
            //checkBoxImageLocation.Checked = true;
            numericColWidth.Value = colData.Width;
            numericColHeight.Value = colData.Height;
            pictureBoxCoverCollection.Width = colData.Width;
            pictureBoxCoverCollection.Height = colData.Height;
            if (colData.ImagePath != "")
            {
                try
                {
                    Image image;
                    image = loadImage(colData.ImagePath);
                    /*using (Stream stream = File.OpenRead(colData.ImagePath))
                    {
                        image = System.Drawing.Image.FromStream(stream);
                    }*/
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

            //Textbox hijos
            textBoxSonProgramPath.Text = colData.SonProgramPath;
            textBoxDefaultCMD.Text = colData.SonCMDLine;

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

            ///---------
            ///Escaneo
            ///---------
            checkBoxScanFolder.Checked = colData.ScanFolder;
            textBoxScanFolder.Text = colData.ScanPath;
            //Recorrer extensiones de escaneo
            string[] exts = colData.ScanOpenExtension;
            for(int i= 0; i< exts.Length; i++)
            {
                this.dataGridViewScanOpenExtension.Rows.Add(exts[i]);
                // this.dataGridViewFiles.Rows.Add(files[i].Name, files[i].URLCheck, files[i].FilePath, files[i].ProgramPath, files[i].CMDLine, files[i].Width, files[i].Height, null, files[i].ImagePath, null, files[i].Background, null);
            }
            

            numericScanStart.Value = colData.ScanStartNumber;

            //Etiquetas
            foreach (DataGridViewRow fila in dataGridViewTags.Rows)
            {
                string tagValor = fila.Tag?.ToString();

                if (int.TryParse(tagValor, out int tagNumero))//Verificar si el valor del tag se puede convertir a un int
                {
                    if (colData.TagsID.Contains(tagNumero))//Comprobar si el tag esta en el array
                    {
                        DataGridViewCheckBoxCell checkBoxCell = fila.Cells[0] as DataGridViewCheckBoxCell;
                        checkBoxCell.Value = true;
                    }
                }
            }
        }

        //Para reducir el tamaño de las imagenes del picture box
        private Image loadImage(string imagePath)
        {
            // Image image = null;

            // Carga la imagen original.
            Image originalImage;
            //Detectar si la imagen es webp (puede dar problemas, por lo que se tiene que utilizar imagemagick
            string ex = Path.GetExtension(imagePath);
            if (ex.ToLower() == ".webp")
            {
                using (MagickImage img = new MagickImage(imagePath))
                {
                    // Convierte la imagen WebP a un formato compatible con PictureBox (por ejemplo, JPEG)
                    // Para mostrar la imagen en el PictureBox
                    img.Format = MagickFormat.Jpeg;

                    // Convierte la imagen en un flujo de memoria
                    using (var memoryStream = new System.IO.MemoryStream())
                    {
                        img.Write(memoryStream);

                        // Carga el flujo de memoria en el PictureBox
                        originalImage = System.Drawing.Image.FromStream(memoryStream);//img;
                        //pictureBox1.Image = System.Drawing.Image.FromStream(memoryStream);
                    }
                }
            }
            else
            {
                // Carga la imagen original desde la ruta
                originalImage = Image.FromFile(imagePath);
            }

            // Calcula el nuevo tamaño manteniendo la relación de aspecto.
            int maxWidth = 300;
            int maxHeight = 300;
            int newWidth, newHeight;

            //Ajusta el tamaño de la imagen acordando un maximo entre 300x300 manteniendo una relacion de aspecto
            if (originalImage.Width > maxWidth || originalImage.Height > maxHeight)
            {
                double widthRatio = (double)maxWidth / originalImage.Width;
                double heightRatio = (double)maxHeight / originalImage.Height;
                double ratio = Math.Min(widthRatio, heightRatio);

                newWidth = (int)(originalImage.Width * ratio);
                newHeight = (int)(originalImage.Height * ratio);
            }
            else
            {
                newWidth = originalImage.Width;
                newHeight = originalImage.Height;
            }

            // Crea una nueva imagen con el tamaño ajustado.
            Image resizedImage = new Bitmap(newWidth, newHeight);

            // Dibuja la imagen original en la nueva imagen ajustandole el tamaño
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }
        private void CustomComponent()
        {
            //Establecer el tamaño de la ventana por defecto
            //this.Size = new Size(539, this.Height);

            //Manejar coverBox de la coleccion
            //Coleccion
            this.pictureBoxCoverCollection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverCollection_MouseDown);
            this.pictureBoxCoverCollection.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverCollection_MouseMove);
            this.pictureBoxCoverCollection.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverCollection_MouseUp);
            //Hijos de la coleccion
            this.pictureBoxCoverSon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverSon_MouseDown);
            this.pictureBoxCoverSon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverSon_MouseMove);
            this.pictureBoxCoverSon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCoverSon_MouseUp);

            loadTheme();

            loadXMLTags();//Cargar todas las etiquetas existentes y ponerlas dentro del datagridview

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

        private void loadTheme()
        {
            Configurations config = new Configurations();
            Themes theme = new Themes($"System\\Themes\\{config.ThemeName}.css");

            BackColor = theme.WindowBackground;

            //TextBox
            textBoxName.BackColor = theme.TextBoxBackground;
            textBoxName.ForeColor = theme.TextBoxText;
            textBoxScanFolder.BackColor = theme.TextBoxBackground;
            textBoxScanFolder.ForeColor = theme.TextBoxText;
            textBoxSonProgramPath.BackColor = theme.TextBoxBackground;
            textBoxSonProgramPath.ForeColor = theme.TextBoxText;
            textBoxDefaultCMD.BackColor = theme.TextBoxBackground;
            textBoxDefaultCMD.ForeColor = theme.TextBoxText;

            //Textos
            labelSonWarning.ForeColor = theme.LabelText;
            labelName.ForeColor = theme.LabelText;
            labelFather.ForeColor = theme.LabelText;
            checkBoxFavorite.ForeColor = theme.LabelText;
            checkBoxScanFolder.ForeColor = theme.LabelText;
            labelExecuteFile.ForeColor = theme.LabelText;
            labelContentLauncher.ForeColor = theme.LabelText;
            labelContentCMD.ForeColor = theme.LabelText;
            BackgroundColorCheck.ForeColor = theme.LabelText;
            labelResolutionCol.ForeColor = theme.LabelText;
            labelContentRes.ForeColor = theme.LabelText;
            groupBoxCover.ForeColor = theme.LabelText;
            labelColWidth.ForeColor = theme.LabelText;
            labelColHeight.ForeColor = theme.LabelText;
            groupBoxSon.ForeColor = theme.LabelText;
            labelSonWidth.ForeColor = theme.LabelText;
            labelSonHeight.ForeColor = theme.LabelText;
            groupBoxImageFormat.ForeColor = theme.LabelText;
            radioButtonColZoom.ForeColor = theme.LabelText;
            radioButtonColEstreched.ForeColor = theme.LabelText;
            radioButtonSonZoom.ForeColor = theme.LabelText;
            radioButtonSonEstreched.ForeColor = theme.LabelText;

            //Combobox
            comboBoxFather.BackColor = theme.ComboboxBackground;
            comboBoxFather.ForeColor = theme.ComboboxText;
            comboBoxResolutionCol.BackColor = theme.ComboboxBackground;
            comboBoxResolutionCol.ForeColor = theme.ComboboxText;
            comboBoxSonResolution.BackColor = theme.ComboboxBackground;
            comboBoxSonResolution.ForeColor = theme.ComboboxText;

            //Botones
            buttonSearchDir.BackColor = theme.ButtonBackground;
            buttonSearchDir.ForeColor = theme.ButtonText;
            buttonSearchProgram.BackColor = theme.ButtonBackground;
            buttonSearchProgram.ForeColor = theme.ButtonText;
            buttonSearchCover.BackColor = theme.ButtonBackground;
            buttonSearchCover.ForeColor = theme.ButtonText;
            buttonDeleteCover.BackColor = theme.ButtonBackground;
            buttonDeleteCover.ForeColor = theme.ButtonText;
            buttonBackgroundColor.BackColor = theme.ButtonBackground;
            buttonBackgroundColor.ForeColor = theme.ButtonText;
            buttonSearchSonCoverDefault.BackColor = theme.ButtonBackground;
            buttonSearchSonCoverDefault.ForeColor = theme.ButtonText;
            buttonDeleteTestCover.BackColor = theme.ButtonBackground;
            buttonDeleteTestCover.ForeColor = theme.ButtonText;
            addResolution.BackColor = theme.ButtonBackground;
            addResolution.ForeColor = theme.ButtonText;
            buttonSave.BackColor = theme.ButtonBackground;
            buttonSave.ForeColor = theme.ButtonText;

            //Numeric UpDown
            numericScanStart.BackColor = theme.NumericBackground;
            numericScanStart.ForeColor = theme.NumericText;
            numericColWidth.BackColor = theme.NumericBackground;
            numericColWidth.ForeColor = theme.NumericText;
            numericColHeight.BackColor = theme.NumericBackground;
            numericColHeight.ForeColor = theme.NumericText;
            numericSonWidth.BackColor = theme.NumericBackground;
            numericSonWidth.ForeColor = theme.NumericText;
            numericSonHeight.BackColor = theme.NumericBackground;
            numericSonHeight.ForeColor = theme.NumericText;

            //DataGridView
            dataGridViewTags.BackgroundColor = theme.DataGridBackground;
            dataGridViewTags.GridColor = theme.DataGridBorder;
            dataGridViewTags.DefaultCellStyle.BackColor = theme.DataGridCellBackground;
            dataGridViewTags.DefaultCellStyle.ForeColor = theme.DataGridCellText;
            dataGridViewTags.DefaultCellStyle.SelectionBackColor = theme.DataGridSelectedBackground;
            dataGridViewTags.DefaultCellStyle.SelectionForeColor = theme.DataGridSelectedText;

            dataGridViewScanOpenExtension.BackgroundColor = theme.DataGridBackground;
            dataGridViewScanOpenExtension.GridColor = theme.DataGridBorder;
            dataGridViewScanOpenExtension.DefaultCellStyle.BackColor = theme.DataGridCellBackground;
            dataGridViewScanOpenExtension.DefaultCellStyle.ForeColor = theme.DataGridCellText;
            dataGridViewScanOpenExtension.DefaultCellStyle.SelectionBackColor = theme.DataGridSelectedBackground;
            dataGridViewScanOpenExtension.DefaultCellStyle.SelectionForeColor = theme.DataGridSelectedText;

            //Paneles de las caratulas
            panelImageLimit.BackColor = theme.CoverPreviewBackground;
            panelSonImageLimit.BackColor = theme.CoverPreviewBackground;
        }

        #region Manejar archivos XML
        private void loadXMLTags()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlTagPath);

            //Recoger la cantidad de elementos que existen
            XmlNodeList tagElements = xmlDoc.SelectNodes("//*[@id]");
            int size = tagElements.Count;

            int tagID = 1;
            for (int i = 0; i < size; i++)
            {
                //Buscamos el elemento a recoger
                string xpath = "//Launcher/tag[@id='" + tagID + "']";
                XmlNode root = xmlDoc.SelectSingleNode(xpath);

                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {

                    tagID++;
                    xpath = "//Launcher/tag[@id='" + tagID + "']";
                    root = xmlDoc.SelectSingleNode(xpath);
                }

                string name = root.SelectSingleNode("Name").InnerText;


                this.dataGridViewTags.Rows.Add(false, name);
                DataGridViewRow selectedRow = dataGridViewTags.Rows[i];
                selectedRow.Tag = tagID;

                //Iterar al siguiente elemento
                tagID++;
            }
        }

        
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
            if (comboBoxResolutionCol.SelectedIndex == 0)
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

            if (resizing == 0)
            {
                if (pictureBoxCoverCollection.BackgroundImage != null)
                {
                    int Cwidth = pictureBoxCoverCollection.Width;
                    int Cheight = pictureBoxCoverCollection.Height;

                    Bitmap bitmap = new Bitmap(Cwidth, Cheight);

                    Rectangle rect = new Rectangle(0, 0, Cwidth, Cheight);

                    pictureBoxCoverCollection.DrawToBitmap(bitmap, rect);

                    Color color = bitmap.GetPixel(e.X, e.Y);

                    bitmap.Dispose();

                    pictureBoxCoverCollection.BackColor = color;
                    buttonColorPickIMG.BackColor = color;
                }
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
            else
            {
                //Controlando el tamaño
                if (comboBoxResolutionCol.SelectedIndex == 0)
                {
                    int margin = 10;

                    //Ancho (Mouse a la derecha)
                    if (e.X >= pictureBoxCoverCollection.Width - margin && e.Y < pictureBoxCoverCollection.Height - margin)
                    {
                        this.Cursor = Cursors.SizeWE;

                    }
                    //Alto (Mouse en la parte inferior)
                    else if (e.X < pictureBoxCoverCollection.Width - margin && e.Y >= pictureBoxCoverCollection.Height - margin)
                    {
                        this.Cursor = Cursors.SizeNS;

                    }
                    //Ajustando ambos (mouse en esquina inferior derecha)
                    else if (e.X >= pictureBoxCoverCollection.Width - margin && e.Y >= pictureBoxCoverCollection.Height - margin)
                    {
                        this.Cursor = Cursors.SizeNWSE;
                    }
                    else
                    {
                        this.Cursor = Cursors.Cross;
                    }
                } else
                {
                    this.Cursor = Cursors.Cross;
                }
            }
        }

        private void pictureBoxCoverCollection_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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
            if (comboBoxSonResolution.SelectedIndex == 0)
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
            else
            {
                //Controlando el tamaño
                if (comboBoxSonResolution.SelectedIndex == 0)
                {
                    int margin = 10;

                    //Ancho (Mouse a la derecha)
                    if (e.X >= pictureBoxCoverSon.Width - margin && e.Y < pictureBoxCoverSon.Height - margin)
                    {
                        this.Cursor = Cursors.SizeWE;

                    }
                    //Alto (Mouse en la parte inferior)
                    else if (e.X < pictureBoxCoverSon.Width - margin && e.Y >= pictureBoxCoverSon.Height - margin)
                    {
                        this.Cursor = Cursors.SizeNS;

                    }
                    //Ajustando ambos (mouse en esquina inferior derecha)
                    else if (e.X >= pictureBoxCoverSon.Width - margin && e.Y >= pictureBoxCoverSon.Height - margin)
                    {
                        this.Cursor = Cursors.SizeNWSE;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }

                }
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

        private void pictureBoxCoverSon_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        #endregion

        #endregion

        #region Caratula
        //Buscar caratula de la coleccion
        private void buttonSearchCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;*.webp;*.gif)|*.png;*.jpg;*.jpeg;*.webp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image;
                image = loadImage(openFileDialog.FileName);
                pictureBoxCoverCollection.BackgroundImage = image;
                pictureBoxCoverCollection.Tag = openFileDialog.FileName;
                image = null;
            }
        }

        //Borrar caratula de la coleccion
        private void buttonDeleteCover_Click(Object sender, EventArgs e)
        {
            pictureBoxCoverCollection.BackgroundImage = null;
            pictureBoxCoverCollection.Tag = null;
        }

        //Buscar caratula por defecto para el contenido
        private void buttonSearchSonCoverDefault_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;*.webp;*.gif)|*.png;*.jpg;*.jpeg;*.webp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image;
                image = loadImage(openFileDialog.FileName);
                pictureBoxCoverSon.BackgroundImage = image;
                image = null;
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


        private void buttonMoreOptions_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1081, this.Height);
        }

        private void checkBoxScanFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxScanFolder.Checked == true)
            {
                buttonSearchSonCoverDefault.Text = "Seleccionar Caratula por defecto";
                textBoxScanFolder.Enabled = true;
                buttonSearchDir.Enabled = true;


            } else
            {
                buttonSearchSonCoverDefault.Text = "Seleccionar Caratula de prueba";
                textBoxScanFolder.Enabled = false;
                buttonSearchDir.Enabled = false;
            }
            
        }

        private void buttonSearchDir_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Selecciona un directorio";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                textBoxScanFolder.Text = Path.GetDirectoryName(folderBrowser.FileName);
            }
        }

        private void addResolution_Click(object sender, EventArgs e)
        {
            Resolution res = new Resolution();
            res.ReturnedObject += Resolution_ReturnedObject; //Este script actualiza las resoluciones
            res.ShowDialog();
        }

        private void Resolution_ReturnedObject(object sender, bool e)
        {
            if (e == true)
            {
                //Actualizar las resoluciones despues de administrarlas
                #region Actualizar Resoluciones despues de administrarlas
                //Limpiar todo del combobox
                comboBoxResolutionCol.Items.Clear();
                comboBoxSonResolution.Items.Clear();
                //Agregando item default
                comboBoxResolutionCol.Items.Add("Ninguno");
                comboBoxSonResolution.Items.Add("Ninguno");
                comboBoxResolutionCol.SelectedIndex = 0;//Se selecciona despues
                comboBoxSonResolution.SelectedIndex = 0;//Se selecciona despues

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

                    comboBoxResolutionCol.Items.Add(name + " (" + width + " x" + height + ")");
                    comboBoxSonResolution.Items.Add(name + " (" + width + " x" + height + ")");
                    combResID[i - 1] = resID;
                    resID++;
                }

                //Buscar dentro del combobox de resoluciones el index de la resolucion
                int resIndex = Array.IndexOf(combResID, defaultRes);
                comboBoxResolutionCol.SelectedIndex = resIndex + 1;
                comboBoxSonResolution.SelectedIndex = resIndex + 1;

                if (resIndex + 1 > 0)
                {
                    groupBoxCover.Enabled = false;
                }
                #endregion
            }
        }

        private void buttonSearchProgram_Click(object sender, EventArgs e)
        {
            //No tiene filtro
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxSonProgramPath.Text = openFileDialog.FileName;
            }
        }

        private void buttonCoverOnline_Click(object sender, EventArgs e)
        {
            SearchCoversOnline sco = new SearchCoversOnline(textBoxName.Text, "Coleccion");
            sco.ReturnedObject += SearchCoverOnline_ReturnedObject;
            sco.ShowDialog();
        }

        private void SearchCoverOnline_ReturnedObject(object sender, string[,] e)
        {
            //Se pasa un string bidimensional, pero solo es un elemento
            textBoxName.Text = e[0, 0];
            pictureBoxCoverCollection.Tag = e[0, 1];

            //Descargar la caratula online
            try
            {
                // Descargar la imagen desde la URL
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(e[0, 1]);

                    // Crear un MemoryStream desde los bytes
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        // Crear una imagen desde el MemoryStream
                        Image image = Image.FromStream(ms);

                        // Mostrar la imagen en el PictureBox u otro control
                        pictureBoxCoverCollection.BackgroundImage = image;

                        // Realizar otras operaciones según sea necesario...
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo establecer la caratula de la url: \n{e[0, 1]}\n debido a: {ex}");
            }
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
                buttonColorPickIMG.BackColor = selectedColor;
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
            if ((comboBoxFather.SelectedIndex - 1) >= 0)
            {
                idFather = combID[comboBoxFather.SelectedIndex - 1];
            }

            int resID = 0;
            if ((comboBoxResolutionCol.SelectedIndex - 1) >= 0)
            {
                resID = combResID[comboBoxResolutionCol.SelectedIndex - 1];
            }

            int resSonID = 0;
            if ((comboBoxSonResolution.SelectedIndex - 1) >= 0)
            {
                resSonID = combResID[comboBoxSonResolution.SelectedIndex - 1];
                Console.WriteLine("selected indes: " + comboBoxSonResolution.SelectedIndex.ToString());
                Console.WriteLine("res son id comb res selected: " + resSonID);
            }

            //string nameCollection = textBoxName.Text;
            //Evitar que se guarde la imagen con caracteres invalidos
            //string cleanName = Path.GetInvalidFileNameChars().Aggregate(textBoxName.Text, (current, c) => current.Replace(c.ToString(), string.Empty));
            //string imgPath = "";
             
            //Guardar la imagen
            /*if (pictureBoxCoverCollection.Tag != null)
            {
                /*if (checkBoxImageLocation.Checked == true)
                {
                    imgPath = pictureBoxCoverCollection.Tag.ToString();
                }
                else
                {*/
                    //string outputFolder = System.Environment.CurrentDirectory + "\\System\\Covers";
                    /*string outputFolder = coverPath;

                    //Si estas creando un nuevo archivo, verificar si no existe un archivo con el mismo nombre, y si es asi, ponerle un iterador
                    if (idCollection == -1)
                    {
                        imgPath = returnImagePath(outputFolder, cleanName);
                    }
                    else
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

                        }
                        else
                        {
                            imgPath = returnImagePath(outputFolder, cleanName);
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
                        //Las imagenes webp no pueden ser copiadas y pegadas a un formato png, deben ser transformadas y guardadas dentro de un objeto
                        if (Path.GetExtension(source).ToLower() == ".webp")
                        {
                            Image saveImage;
                            using (MagickImage img = new MagickImage(source))
                            {
                                // Convierte la imagen WebP a un formato compatible con PictureBox (por ejemplo, JPEG)
                                // Para mostrar la imagen en el PictureBox
                                img.Format = MagickFormat.Png;

                                // Convierte la imagen en un flujo de memoria
                                using (var memoryStream = new System.IO.MemoryStream())
                                {
                                    img.Write(memoryStream);

                                    // Carga el flujo de memoria en el PictureBox
                                    saveImage = System.Drawing.Image.FromStream(memoryStream);//img;
                                }
                            }

                            if (saveImage != null)
                            {
                                saveImage.Save(imgPath, ImageFormat.Png);
                            }
                        }
                        else
                        {
                            System.IO.File.Copy(source, imgPath, true);
                        }
                    }
                //}
            }*/

            //Image layout
            int imgLayout = 0;
            if (radioButtonColEstreched.Checked == true) imgLayout = 1;

            bool background = BackgroundColorCheck.Checked;
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
            string sonProgramPath = textBoxSonProgramPath.Text;
            string sonCMDLine = textBoxDefaultCMD.Text;
            if (radioButtonSonEstreched.Checked == true) sonLayout = 1;

            //Guardar las etiquetas
            int[] saveTagsArray;
            List<int> dgValue = new List<int>();

            int[] scanTagsArray;
            List<int> dgScanTags = new List<int>();

            for (int i = 0; i < dataGridViewTags.RowCount; i++)
            {
                //Solo agregar las etiquetas que tengan el combobox en true
                if (Convert.ToBoolean(dataGridViewTags.Rows[i].Cells[0].Value?.ToString()))//Convert.ToBoolean transforma los null en false
                {
                    int rowID = int.Parse(dataGridViewTags.Rows[i].Tag.ToString());
                    dgValue.Add(rowID);
                }

                if (Convert.ToBoolean(dataGridViewTags.Rows[i].Cells[2].Value?.ToString()))
                {
                    int rowID = int.Parse(dataGridViewTags.Rows[i].Tag.ToString());
                    dgScanTags.Add(rowID);
                }
            }
            //Agregarlo como array
            saveTagsArray = dgValue.ToArray();//Las etiquetas de la coleccion en si
            scanTagsArray = dgScanTags.ToArray();//Las etiquetas que la coleccion mostrara automaticamente

            bool favorite = checkBoxFavorite.Checked;

            //Escaneo
            bool scanFolder = checkBoxScanFolder.Checked;
            string scanPath = textBoxScanFolder.Text;
            int scanStartNumber = (int)numericScanStart.Value;

            string[] scanOpenExtension;
            List<string> dgScanValue = new List<string>();
            

            //foreach (DataGridViewRow fila in dataGridViewScanOpenExtension.Rows)
            //{
            //No tomar la ultima celda, ya que siempre estara vacia
            for (int i = 0; i < dataGridViewScanOpenExtension.Rows.Count - 1; i++)
            {
                DataGridViewRow fila = dataGridViewScanOpenExtension.Rows[i];
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    string cell = celda.Value != null ? celda.Value.ToString() : string.Empty;
                    dgScanValue.Add(cell);
                }
            }

            //Agregarlo como array
            scanOpenExtension = dgScanValue.ToArray();

            string imageDir = pictureBoxCoverCollection.Tag != null ? pictureBoxCoverCollection.Tag.ToString() : "";

            Collections passCollection = new Collections(idCollection, idFather, textBoxName.Text, imageDir, imgLayout, background, R, G, B, resID, width, height, resSonID, sonWidth, sonHeight, sonLayout, sonProgramPath, sonCMDLine, saveTagsArray, scanTagsArray, favorite, scanFolder, scanPath, scanStartNumber, scanOpenExtension);
            ReturnedObject?.Invoke(this, passCollection);
            this.Close();
        }

        private void NewCollection_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pictureBoxCoverCollection.BackgroundImage != null) pictureBoxCoverCollection.BackgroundImage.Dispose();//Dejar de utilizar la imagen de fondo en memoria
            if (pictureBoxCoverSon.BackgroundImage != null) pictureBoxCoverSon.BackgroundImage.Dispose();//Dejar de utilizar la imagen de fondo en memoria
        }
    }
}
