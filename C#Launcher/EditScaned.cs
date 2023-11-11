using CoverPadLauncher.Clases;
using C_Launcher.Clases;
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using ImageMagick;
using System.Linq;//Aggregate
using System.Windows.Forms;
using System.Xml;


namespace CoverPadLauncher
{
    public partial class EditScaned : Form
    {
        private int currentX, currentY;
        private int resizing = 0; // 0=no se esta ajustando; 1=ajustando ancho; 2=ajustando alto; 3=ajustando ambos
        public event EventHandler<Scanneds> ReturnedObject;
        private string dirScan;
        private string xmlResPath = "System\\Resolutions.xml";//Cargar el combobox de las resoluciones
        private int[] combResID = new int[0];//Para recoger el index

        private string coverPath = "System\\Covers";
        private string xmlImagePath;//Lo ocupare para editar la caratula

        //Datos default
        private int defaultRes, defaultImageLayout = 0;
        private int defaultWidth, defaultHeight = 200;

        //public EditScaned(){ InitializeComponent(); }
        public EditScaned(Scanneds scanData)
        {
            InitializeComponent();
            CustomComponent();

            //Verificar si es un archivo o un directorio (para ocultar algunos elementos
            //Recoger los atributos del directorio
            FileAttributes attr = File.GetAttributes(scanData.Dir);

            //Saber si es un archivo
            if ((attr & FileAttributes.Directory) != FileAttributes.Directory){
                //Ocultar el dataGridView para el filtro de extensiones
                dataGridViewScanOpenExtension.Enabled = false;
                dataGridViewScanOpenExtension.Visible = false;

                //Ocultar el numero de archivo a abrir
                labelScanStart.Visible = false;
                numericScanStart.Enabled = false;
                numericScanStart.Visible = false;
            }

            dirScan = scanData.Dir;
            textBoxName.Text = scanData.Name;
            int resolutionIndex = Array.IndexOf(combResID, scanData.ResolutionID);
            comboBoxResolution.SelectedIndex = resolutionIndex + 1;

            //Verificar el check del fondo
            BackgroundColorCheck.Checked = scanData.Background;

            //Picture Box
            Color BackgroundCol = Color.FromArgb(255, scanData.ColorRed, scanData.ColorGreen, scanData.ColorBlue);
            pictureBoxCover.BackColor = BackgroundCol;
            buttonColorPickIMG.BackColor = BackgroundCol; //Definir los colores para el boton de colores

            #region Caratula
            if (comboBoxResolution.SelectedIndex != 0)
            {
                groupBoxSize.Enabled = false;

                //Cargar la resolucion perteneciente a esa id
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlResPath);
                string xpath = "//Launcher/resolution[@id='" + scanData.ResolutionID + "']";
                XmlNode root = doc.SelectSingleNode(xpath);
                int resWidth = int.Parse(root.SelectSingleNode("Width").InnerText);
                int resHeight = int.Parse(root.SelectSingleNode("Height").InnerText);

                pictureBoxCover.Width = resWidth;
                pictureBoxCover.Height = resHeight;
                numericWidthImage.Value = resWidth;
                numericHeightImage.Value = resHeight;
            }
            else
            {
                pictureBoxCover.Width = scanData.Width;
                pictureBoxCover.Height = scanData.Height;
                //checkBoxImageLocation.Checked = true;
                numericWidthImage.Value = scanData.Width;
                numericHeightImage.Value = scanData.Height;
            }



            if (scanData.ImagePath != "")
            {
                try
                {
                    Image image;
                    image = loadImage(scanData.ImagePath);
                    /*using (Stream stream = File.OpenRead(fileData.ImagePath))
                    {
                        image = System.Drawing.Image.FromStream(stream);
                    }*/
                    pictureBoxCover.BackgroundImage = image;
                    pictureBoxCover.Tag = scanData.ImagePath;
                    xmlImagePath = scanData.ImagePath;//Para editar la imagen
                    image = null;
                }
                catch //(Exception ex)
                {
                    Console.WriteLine("no se pudo establecer una imagen");
                }
            }

            if (scanData.ImageLayout == 1)
            {
                radioButtonEstreched.Checked = true;
                pictureBoxCover.BackgroundImageLayout = ImageLayout.Stretch;
            }
            #endregion

            numericScanStart.Value = scanData.ScanStartNumber;

            //Recorrer extensiones de escaneo
            string[] exts = scanData.ScanOpenExtension;
            for (int i = 0; i < exts.Length; i++)
            {
                this.dataGridViewScanOpenExtension.Rows.Add(exts[i]);
            }
        }

        private void CustomComponent()
        {
            //Scripts para ajustar el tamaño del picture box
            this.pictureBoxCover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseDown);
            this.pictureBoxCover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseMove);
            this.pictureBoxCover.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseUp);



            #region Combobox
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

                comboBoxResolution.Items.Add(name + " (" + width + " x" + height + ")");
                combResID[i - 1] = resID;
                resID++;
            }

            //Buscar dentro del combobox de resoluciones el index de la resolucion
            int resIndex = Array.IndexOf(combResID, defaultRes);
            comboBoxResolution.SelectedIndex = resIndex + 1;

            if (resIndex + 1 > 0)
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
            }
            else
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
                    }
                    else
                    {
                        this.Cursor = Cursors.Cross;
                    }

                }
                else
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

        private void addResolution_Click(object sender, EventArgs e)
        {
            C_Launcher.Resolution res = new C_Launcher.Resolution();
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
                comboBoxResolution.Items.Clear();
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

                    comboBoxResolution.Items.Add(name + " (" + width + " x" + height + ")");
                    combResID[i - 1] = resID;
                    resID++;
                }

                //Buscar dentro del combobox de resoluciones el index de la resolucion
                int resIndex = Array.IndexOf(combResID, defaultRes);
                comboBoxResolution.SelectedIndex = resIndex + 1;

                if (resIndex + 1 > 0)
                {
                    groupBoxSize.Enabled = false;
                }
                #endregion
            }
        }

        //Buscar caratula y establecerla
        private void buttonSearchCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;*.webp;)|*.png;*.jpg;*.jpeg;*.webp;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image;
                image = loadImage(openFileDialog.FileName);
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

        private void buttonSave_Click(object sender, System.EventArgs e)
        {

            int resID = 0;
            if ((comboBoxResolution.SelectedIndex - 1) >= 0)
            {
                resID = combResID[comboBoxResolution.SelectedIndex - 1];
            }

            string nameScan = textBoxName.Text;

            //Evitar que se guarde la imagen con caracteres invalidos
            string cleanName = Path.GetInvalidFileNameChars().Aggregate(textBoxName.Text, (current, c) => current.Replace(c.ToString(), string.Empty));
            string imgPath = "";

            //Guardar la imagen
            if (pictureBoxCover.Tag != null)
            {
                if (checkBoxImageLocation.Checked == true)
                {
                    //Ocupar la imagen en su ubicacion actual
                    imgPath = pictureBoxCover.Tag.ToString();
                }
                else
                {
                    //Mover la imagen hacia la carpeta covers y transformarla a .png
                    //string outputFolder = System.Environment.CurrentDirectory + "\\System\\Covers";
                    string outputFolder = coverPath;

                    
                    
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


                    if (!Directory.Exists(outputFolder))
                    {
                        // Crea la carpeta Systems/Covers si no existe
                        Directory.CreateDirectory(outputFolder);
                    }

                    string source = pictureBoxCover.Tag.ToString();

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
                }
            }

            //Image layout
            int imgLayout = 0;
            if (radioButtonEstreched.Checked == true) imgLayout = 1;

            bool background = BackgroundColorCheck.Checked;
            int R = pictureBoxCover.BackColor.R;
            int G = pictureBoxCover.BackColor.G;
            int B = pictureBoxCover.BackColor.B;
            int width = pictureBoxCover.Width;
            int height = pictureBoxCover.Height;

            //Escaneo
            int scanStartNumber = 1;

            scanStartNumber = Convert.ToInt32(Math.Round(numericScanStart.Value));
            if (scanStartNumber == 0) scanStartNumber = 1;

            string[] scanOpenExtension;
            List<string> dgScanValue = new List<string>();

            //Extensiones que abrira la carpeta (solo disponible si no es un archivo)
            foreach (DataGridViewRow fila in dataGridViewScanOpenExtension.Rows)
            {
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    string cell = celda.Value != null ? celda.Value.ToString() : string.Empty;
                    dgScanValue.Add(cell);
                }
            }

            //Agregarlo como array
            scanOpenExtension = dgScanValue.ToArray();


            Scanneds passScan = new Scanneds(dirScan, nameScan, imgPath, imgLayout, background, R, G, B, resID, width, height, scanStartNumber, scanOpenExtension);
            ReturnedObject?.Invoke(this, passScan);
            this.Close();
        }
    }
}
