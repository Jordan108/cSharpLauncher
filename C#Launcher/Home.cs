﻿using C_Launcher.Clases;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace C_Launcher
{
    public partial class Home : Form
    {
        private PictureBox[] picBoxArr = new PictureBox[0];//Crear el array de picBox que se mantendra en memoria
        //Crea el array de las colecciones y los archivos (solo contendran las colecciones que se mostraran en en la vista)

        //Valores de settings
        private int WinWidht, WinHeight = 900;
        private int orderPanels = 0;
        private int formState = 1;
        private int viewDepth = 0;

        //Rutas de los archivos XML
        private string xmlColPath = "System\\Collections.xml";
        private string xmlFilesPath = "System\\Files.xml";
        private string xmlResPath = "System\\Resolutions.xml";
        private string xmlSettingsPath = "System\\Settings.xml";
        //Ruta de los covers
        private string dirCoversPath = "System\\Covers";

        //Mantener el tamaño de los archivos y colecciones
        private int colSize, fileSize = 0;
        
        //ToolStrip
        //Se define aqui para poder referenciarlo en la creacion de los paneles
        private ContextMenuStrip contextMenuPictureBox = new ContextMenuStrip();

        public Home()
        {
            InitializeComponent();
            //Verificar el contenido de la carpeta system, si no existe, crearlo
            verifySystemDir();
            //Cargar las opciones
            loadSettingXML();

            //Tool strip (click derecho)
            //Layout Panel
            ContextMenuStrip  contextMenuLayoutPanel   = new ContextMenuStrip();
            ToolStripMenuItem ToolStripAddCollection   = new ToolStripMenuItem();
            ToolStripMenuItem ToolStripAddFile         = new ToolStripMenuItem();
            ToolStripMenuItem ToolStripAddMultipleFile = new ToolStripMenuItem();
            ToolStripAddCollection.Text = "Crear coleccion";
            ToolStripAddCollection.Click += new EventHandler(ToolStripAddCollection_Click);
            ToolStripAddFile.Text = "Crear archivo";
            ToolStripAddFile.Click += new EventHandler(ToolStripAddFile_Click);
            ToolStripAddMultipleFile.Text = "Crear multiples archivos";
            ToolStripAddMultipleFile.Click += new EventHandler(ToolStripAddMultipleFiles_Click);
            contextMenuLayoutPanel.Items.AddRange(new ToolStripItem[] { ToolStripAddCollection, ToolStripAddFile, ToolStripAddMultipleFile });
            //Agregar al layout panel
            flowLayoutPanelMain.ContextMenuStrip = contextMenuLayoutPanel;

            //Se agregan cuando se crean
            //contextMenuPictureBox.Items.AddRange(new ToolStripItem[] { ToolStripFav, ToolStripEdit, ToolStripDelete });

            //Establecer barra de busqueda
            textBoxSearch.Text = "Buscar...";
            textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            textBoxSearch.KeyDown += new KeyEventHandler(SearchBarEnter);
            textBoxSearch.GotFocus += new EventHandler(SearchBarRemoveText);
            textBoxSearch.LostFocus += new EventHandler(SearchBarAddText);

            //Carga la cantidad de colecciones y archivos existentes
            colSize = LoadCollectionSize();
            fileSize = LoadFilesSize();

            loadTreeView(colSize);
            Console.WriteLine("tamaño col: " +  colSize);
            loadPictureBox(colSize, fileSize, false);
        }

        //Cuando la vista cargue
        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        #region ToolStrip
        #region panel ToolStrip

        //Crear una ventana para añadir varios archivos a la vez
        private void ToolStripAddMultipleFiles_Click(object sender, EventArgs e)
        {
            int defaultWidth = 200;
            int defaultHeight = 200;
            int defaultRes = 0;
            int defaultImageLayout = 0;

            //Si la profundidad es mayor a 0, buscar la coleccion con esa id en especifico y extraerle los valores default
            if (viewDepth > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlColPath);

                string xpath = "//Launcher/collection[@id='" + viewDepth + "']";
                XmlNode root = doc.SelectSingleNode(xpath);

                defaultRes = int.Parse(root.SelectSingleNode("CoverSonResolutionID").InnerText);
                defaultWidth = int.Parse(root.SelectSingleNode("CoverSonWidth").InnerText);
                defaultHeight = int.Parse(root.SelectSingleNode("CoverSonHeight").InnerText);
                defaultImageLayout = int.Parse(root.SelectSingleNode("SonImageLayout").InnerText);
            }


            NewMultipleFiles newMultFiles = new NewMultipleFiles(viewDepth, defaultRes, defaultWidth, defaultHeight, defaultImageLayout);
            newMultFiles.ReturnedObject += NewMultFiles_ReturnedObject;
            newMultFiles.ShowDialog();
        }

        //Crear la nueva ventana para añadir las colecciones
        private void ToolStripAddCollection_Click(object sender, EventArgs e)
        {
            int defaultWidth = 200;
            int defaultHeight = 200;
            int defaultRes = 0;
            int defaultImageLayout = 0;

            //Si la profundidad es mayor a 0, buscar la coleccion con esa id en especifico y extraerle los valores default
            if (viewDepth > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlColPath);

                string xpath = "//Launcher/collection[@id='" + viewDepth + "']";
                XmlNode root = doc.SelectSingleNode(xpath);

                defaultRes = int.Parse(root.SelectSingleNode("CoverSonResolutionID").InnerText);
                defaultWidth = int.Parse(root.SelectSingleNode("CoverSonWidth").InnerText);
                defaultHeight = int.Parse(root.SelectSingleNode("CoverSonHeight").InnerText);
                defaultImageLayout = int.Parse(root.SelectSingleNode("SonImageLayout").InnerText);
            }

            NewCollection newCollection = new NewCollection(viewDepth, defaultRes, defaultWidth, defaultHeight, defaultImageLayout);
            newCollection.ReturnedObject += NewCollection_ReturnedObject;
            newCollection.ShowDialog();
        }

        //Crear la nueva ventana para crear los archivos (individual)
        private void ToolStripAddFile_Click(object sender, EventArgs e)
        {
            int defaultWidth = 200; 
            int defaultHeight = 200;
            int defaultRes = 0;
            int defaultImageLayout = 0;

            //Si la profundidad es mayor a 0, buscar la coleccion con esa id en especifico y extraerle los valores default
            if (viewDepth > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlColPath);

                string xpath = "//Launcher/collection[@id='" + viewDepth + "']";
                XmlNode root = doc.SelectSingleNode(xpath);

                defaultRes = int.Parse(root.SelectSingleNode("CoverSonResolutionID").InnerText);
                defaultWidth = int.Parse(root.SelectSingleNode("CoverSonWidth").InnerText);
                defaultHeight = int.Parse(root.SelectSingleNode("CoverSonHeight").InnerText);
                defaultImageLayout = int.Parse(root.SelectSingleNode("SonImageLayout").InnerText);
            }
            

            NewFile newFile = new NewFile(viewDepth, defaultRes, defaultWidth, defaultHeight, defaultImageLayout);
            newFile.ReturnedObject += NewFile_ReturnedObject;
            newFile.ShowDialog();
        }

        //Editar el picture box
        private void ToolStripEditPictureBox_Click(object sender, EventArgs e)
        {
            //Recojer los datos del picture box
            PictureBox pic = (PictureBox)contextMenuPictureBox.SourceControl;
            string id = pic.Tag.ToString();
            string boxType = pic.AccessibleDescription;

            Console.WriteLine("id del context menu " + id);
            //destroyPictureBox();

            //PictureBox pictureBox = (PictureBox)sender;
            if (boxType == "file")
            {
                Files file = searchFileData(int.Parse(id));

                NewFile editFile = new NewFile(file);
                editFile.ReturnedObject += NewFile_ReturnedObject;
                editFile.ShowDialog();
            }
            else if (boxType == "collection")
            {
                Collections col = searchCollectionData(int.Parse(id));

                NewCollection editCollection = new NewCollection(col);
                editCollection.ReturnedObject += NewCollection_ReturnedObject;
                editCollection.ShowDialog();
            }
        }

        //Editar los archivos de esa coleccion picture box
        private void ToolStripEditMultiplePictureBox_Click(object sender, EventArgs e)
        {
            //Recojer los datos del picture box
            PictureBox pic = (PictureBox)contextMenuPictureBox.SourceControl;
            string id = pic.Tag.ToString();
            string boxType = pic.AccessibleDescription;

            //Lo hago solo por si acaso
            if (boxType == "collection")
            {
                int defaultWidth = 200;
                int defaultHeight = 200;
                int defaultRes = 0;
                int defaultImageLayout = 0;

                //Si la profundidad es mayor a 0, buscar la coleccion con esa id en especifico y extraerle los valores default
                if (viewDepth > 0)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlColPath);

                    string xpath = "//Launcher/collection[@id='" + id + "']";
                    XmlNode root = doc.SelectSingleNode(xpath);

                    defaultRes = int.Parse(root.SelectSingleNode("CoverSonResolutionID").InnerText);
                    defaultWidth = int.Parse(root.SelectSingleNode("CoverSonWidth").InnerText);
                    defaultHeight = int.Parse(root.SelectSingleNode("CoverSonHeight").InnerText);
                    defaultImageLayout = int.Parse(root.SelectSingleNode("SonImageLayout").InnerText);
                }

                Files[] files = searchFilesInCollection(int.Parse(id));

                if (files.Length <= 0)
                {
                    MessageBox.Show("Esta coleccion no tiene archivos para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
                NewMultipleFiles editFilesCollection = new NewMultipleFiles(files, int.Parse(id), defaultRes, defaultWidth, defaultHeight, defaultImageLayout);
                editFilesCollection.ReturnedObject += NewMultFiles_ReturnedObject;
                editFilesCollection.ShowDialog();
            } else
            {
                MessageBox.Show("No se puede editar los archivos de algo que no es una coleccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Eliminar el picture box
        private void ToolStripDeletePictureBox_Click(object sender, EventArgs e)
        {
            //Recojer los datos del picture box
            PictureBox pic = (PictureBox)contextMenuPictureBox.SourceControl;
            string id = pic.Tag.ToString();
            string boxType = pic.AccessibleDescription;

            Console.WriteLine("id del context menu " + id);
            //destroyPictureBox();

            //PictureBox pictureBox = (PictureBox)sender;
            var result = MessageBox.Show("Estas seguro de querer eliminar "+pic.Name.ToString(),"Eliminar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (boxType == "file")
                {
                    deleteFile(int.Parse(id));
                }
                else if (boxType == "collection")
                {
                    deleteCollection(int.Parse(id));
                }
            }

            
        }

        //Cambiar el fav de un picture box
        private void ToolStripFavSetPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)contextMenuPictureBox.SourceControl;
            int idBox = int.Parse(pic.Tag.ToString());//no se puede transformar un objeto a int, pero si a un string
            string boxType = pic.AccessibleDescription;//Recoje el tipo de picture box para buscar en el array especifico (col/file)

            if (boxType == "file")
            {
                setFileFav(idBox);
                Console.WriteLine("set fav " + boxType + " | " + idBox);
                if (viewDepth == -1) loadView(colSize, fileSize);
            }
            else if (boxType == "collection")
            {
                setColeFav(idBox);
                Console.WriteLine("set fav " + boxType + " | " + idBox);
                if (viewDepth == -1) loadView(colSize, fileSize);
            }
        }
        #endregion

        #region navbar ToolStrip
        //Administrar las resoluciones
        private void administrarResolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resolution res = new Resolution();
            res.ReturnedObject += Resolution_ReturnedObject;
            res.ShowDialog();
        }

        private void abrirLaCarpetaSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificar la existencia de la carpeta System
                if (!Directory.Exists("System"))
                {
                    // Crea la carpeta si no existe
                    Directory.CreateDirectory("System");
                }

                string systemDir = Directory.GetCurrentDirectory() + "\\System";
                Process.Start("explorer.exe", systemDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la carpeta: " + ex.Message);
            }
        }

        //Ordenar paneles
        //Ordenarlos por ID (orderPanels 0)
        private void fechaDeCreacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!fechaDeCreacionToolStripMenuItem.Checked)
            {
                fechaDeCreacionToolStripMenuItem.Checked = true;
                nombreToolStripMenuItem.Checked = false;
                orderPanels = 0;
                loadPictureBox(colSize, fileSize, false);
            }
        }

        //ordenarlos por nombre (orderPanels 1)
        private void nombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!nombreToolStripMenuItem.Checked) {
                nombreToolStripMenuItem.Checked = true;
                fechaDeCreacionToolStripMenuItem.Checked = false;
                orderPanels = 1;
                loadPictureBox(colSize, fileSize, false);
            }
            
        }
        #endregion
        #endregion

        #region Manejar interaccion entre ventanas
        private void NewCollection_ReturnedObject(object sender, Collections e)
        {
            SaveXMLCollection(e);
            loadView(colSize, fileSize);
        }

        private void Resolution_ReturnedObject(object sender, bool e)
        {
            if (e == true)
            {
                loadView(colSize, fileSize);
            }
        }

        private void NewFile_ReturnedObject(object sender, Files e)
        {
            //Guarda los archivos XML
            SaveXMLFile(e);
            //Carga de nuevo el flow layout
            loadView(colSize, fileSize);
        }

        private void NewMultFiles_ReturnedObject(object sender, Files[] e)
        {
            for (int i = 0; i < e.Length; i++)
            {
                //Guarda 1x1 los archivos
                SaveXMLFile(e[i]);
            }
            //Carga de nuevo el flow layout
            loadView(colSize, fileSize);
        }
        #endregion

        #region Interaccion pictureBox
        //Empezar un proceso al hacer click a un archivo
        private void startProcess(string file, string program, string cmdLine, bool url)
        {
            //bool url = true;

            //file y program se deben de formatear
            string fileExe = file;
            string fileDir = "";
            string programDir = "";
            //string cmdLine = "";//es necesario establecerlo como "", por default es null, pero si alguien escribe algo y lo borra quedara como "" y complicara las validaciones

            //Crear el process start
            Process process = new Process();

            //es necesario comprobar si es una URL o un archivo del sistema, 
            if (url == false)
            {
                //Solo formatear la ruta del archivo si este no es un URL
                try
                {
                    fileExe = Path.GetFullPath(file);
                    fileDir = Path.GetDirectoryName(file);
                    if (program != "") programDir = Path.GetFullPath(program);
                }
                catch
                {
                    MessageBox.Show("Error al intentar buscar los directorios, revisa si los archivos existen en el directorio especificado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Intentar ejecutar los archivos/URL
            try
            {
                //Intentar abrir solo un archivo o abrir una URL
                if ((programDir == "") || (url == true))
                {
                    Console.WriteLine("abriendo un archivo o URL");
                    Console.WriteLine(fileExe);

                    ProcessStartInfo startInfo = new ProcessStartInfo(fileExe);//Ruta del archivo o URL

                    if (url == false)
                    {
                        //Establecer el directorio de trabajo del archivo a ejecutar
                        startInfo.WorkingDirectory = fileDir;//Es necesario para que se tome cual es el directorio donde se ejecuta el archivo y pueda tomar los archivos de esa zona
                        //Utilizar los CMD arguments si es que tiene
                        startInfo.Arguments = cmdLine;
                    }

                    process.StartInfo = startInfo;
                    process.Start();
                    //Intentar abrir un archivo utilizando un programa
                }
                else
                {
                    Console.WriteLine("abriendo un programa");

                    ProcessStartInfo startInfo = new ProcessStartInfo(programDir);//Ruta del programa con el que se abrira el archivo

                    //Si no tienes cmdLines
                    if (cmdLine == "")
                    {
                        //Se utilizara como argumento del programa el archivo que se quiere abrir
                        startInfo.Arguments = "\"" + fileExe + "\"";
                    }
                    else
                    {
                        startInfo.Arguments = "\"" + fileExe + "\"" + " " + cmdLine;
                    }

                    process.StartInfo = startInfo;
                    process.Start();
                }
            }
            //En caso de errores
            catch (Exception ex)
            {
                if (url)
                {
                    MessageBox.Show("error abrir URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Error con URL
                    Console.WriteLine("error: " + ex);
                }
                else MessageBox.Show("error abrir archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Error con archivos/programas/cmdLine

            }

        }

        //Mostrar el nombre del panel al pasar el mouse por encima
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string picName = pictureBox.Name;

            Graphics g = pictureBox.CreateGraphics();//Crear graphics

            // Dibujar un rectángulo negro en el PictureBox
            Color Bcolor = Color.FromArgb(180, Color.Black);
            SolidBrush RectBrush = new SolidBrush(Bcolor);
            g.FillRectangle(RectBrush, 0, pictureBox.Height - (pictureBox.Height / 3), pictureBox.Width, pictureBox.Height);

            //Dibujar el texto
            Font font = new Font("Arial", 8);
            SolidBrush FontBrush = new SolidBrush(Color.White);
            StringFormat drawFormat = new StringFormat();
            RectangleF fontRect = new RectangleF(0, pictureBox.Height - (pictureBox.Height / 3), pictureBox.Width, pictureBox.Height / 3);
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            drawFormat.FormatFlags = StringFormatFlags.LineLimit;
            drawFormat.Trimming = StringTrimming.EllipsisCharacter;
            g.DrawString(picName, font, FontBrush, fontRect, drawFormat);

            FontBrush.Dispose();
            RectBrush.Dispose();//Dejar de ocupar pincel
            g.Dispose();//Dejar de ocupar graphics
        }

        //Dejar de mostrar el nombre
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Invalidate();//Vuelve a dibujar el control otra vez, eliminando cualquier graphics
        }

        //Clickear para ejecutar el archivo o entrar en la coleccion
        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pictureBox = (PictureBox)sender;
                int idBox = int.Parse(pictureBox.Tag.ToString());//no se puede transformar un objeto a int, pero si a un string
                string boxType = pictureBox.AccessibleDescription;//Recoje el tipo de picture box para buscar en el array especifico (col/file)

                //Console.WriteLine("boxtype: " + boxType);
                Console.WriteLine("boxtype: " + boxType);

                if (boxType == "file")
                {
                    //Dentro de la funcion se buscara los procesos asociados al archivo y llamara a start process
                    Console.WriteLine("Buscar id: " + idBox);
                    searchFileProcess(idBox);

                }
                else if (boxType == "collection")
                {
                    //Cambiar la profundidad
                    viewDepth = idBox;
                    Console.WriteLine("new view depth: " + idBox);
                    loadPictureBox(colSize, fileSize, false);
                }
            }
                
        }

        //Intervenir en el contextMenu
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox pictureBox = (PictureBox)sender;
                int idBox = int.Parse(pictureBox.Tag.ToString());//no se puede transformar un objeto a int, pero si a un string
                string boxType = pictureBox.AccessibleDescription;//Recoje el tipo de picture box para buscar en el array especifico (col/file)
                bool fav = false;

                //Picture Box
                ToolStripMenuItem ToolStripEdit = new ToolStripMenuItem();
                ToolStripMenuItem ToolStripDelete = new ToolStripMenuItem();
                ToolStripMenuItem ToolStripFav = new ToolStripMenuItem();
                ToolStripEdit.Text = "Editar";
                ToolStripEdit.Click += new EventHandler(ToolStripEditPictureBox_Click);
                ToolStripDelete.Text = "Eliminar";
                ToolStripDelete.Click += new EventHandler(ToolStripDeletePictureBox_Click);
                ToolStripFav.Text = "Agregar a Favoritos";
                ToolStripFav.Click += new EventHandler(ToolStripFavSetPictureBox_Click);

                //Crear un contextMenu local para modificarlo a gusto
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();//pictureBox.ContextMenuStrip;
                contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripFav, ToolStripEdit, ToolStripDelete });

                if (boxType == "file")
                {
                    //Dentro de la funcion se buscara los procesos asociados al archivo y llamara a start process
                    fav = getFileFav(idBox);
                }
                else if (boxType == "collection")
                {
                    ToolStripMenuItem ToolStripEditAll = new ToolStripMenuItem();
                    ToolStripEditAll.Text = "Editar todos los archivos de la coleccion";
                    ToolStripEditAll.Click += new EventHandler(ToolStripEditMultiplePictureBox_Click);

                    fav = getColeFav(idBox);
                    contextMenuStrip.Items.Add(ToolStripEditAll);
                }

                

                // Accede al ToolStripMenuItem dentro del ContextMenuStrip
                ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)contextMenuStrip.Items[0];//depende del orden establecido en la linea 75

                // Cambia el atributo "Text" del ToolStripMenuItem según el valor del "Tag" del PictureBox
                if (fav == false)
                {
                    toolStripMenuItem.Text = "Agregar a favoritos";
                }
                else if (fav == true)
                {
                    toolStripMenuItem.Text = "Quitar de favoritos";
                }

                // Muestra el ContextMenuStrip
                contextMenuStrip.Show(pictureBox, e.Location);
            }
        }
        #endregion

        #region Controlar vista
        #region Barra de busqueda
        //Quitar el placeholder cuando se quiere buscar algo
        public void SearchBarRemoveText(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "Buscar...")
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        //Colocar el placeholder si es que no hay nada escrito y se pierde el foco
        public void SearchBarAddText(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Length  == 0)
            {
                textBoxSearch.Text = "Buscar...";
                textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            }
        }

        //Buscar al hacer enter
        private void SearchBarEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadPictureBox(colSize, fileSize, true);
            }
            
        }
        #endregion
        private void destroyPictureBox()
        {
            //remueve todos los paneles del control
            for (int i=0; i< picBoxArr.Length; i++)
            {
                if (picBoxArr[i].BackgroundImage != null) picBoxArr[i].BackgroundImage.Dispose();//Dejar de utilizar la imagen de fondo en memoria
                flowLayoutPanelMain.Controls.Remove(picBoxArr[i]);
            }

            //Remueve los bitmap
            /*
             for each (auto bitmap in bitmaps) {
			    //System::Drawing::Graphics::FromImage(bitmap);
			    delete bitmap; //Eliminar los objetos bitmap (las caratulas) de la memoria 
			    bitmap = nullptr;
		    }

		    bitmaps->Clear();
             */

        }

        private void loadView(int colSize, int fileSize)
        {
            loadPictureBox(colSize, fileSize, false);
            loadTreeView(colSize);
        }

        private void loadPictureBox(int colSize, int fileSize, bool filter)
        {
            flowLayoutPanelMain.SuspendLayout();

            //Primero remueve todos los paneles del control
            destroyPictureBox();

            //Luego carga todos los archivos en los arrays
            Collections[] colls = new Collections[colSize];
            colls = LoadCollections(colSize);

            Files[] files = new Files[fileSize];
            files = LoadFiles(fileSize);
            
            //Hacer el array tan largo como las colecciones y archivos existentes (despues se optimiza)
            Array.Resize(ref picBoxArr, colSize + fileSize);

            int pL = 0;//largo de los pictureBox de esa profundidad

            #region Colecciones
            //Recorrer todos el array de las colecciones
            for (int i = 0; i < colls.Length; i++)
            {
                bool addCollection = false;//Me permite añadir varias condicionales dentro de un mismo if

                if (filter)
                {
                    //Verifica si el nombre de la coleccion contiene alguno de los elementos del textbox
                    string nom = colls[i].Name.ToLower();
                    string search = textBoxSearch.Text.ToLower();

                    if (nom.Contains(search) && ((viewDepth == colls[i].IDFather) || (viewDepth == -1 && colls[i].Favorite == true))) addCollection = true;

                } else
                {
                    if ((viewDepth == colls[i].IDFather) || (viewDepth == -1 && colls[i].Favorite == true)) addCollection = true;
                }

                //Solo agregar las colecciones que coincidan con la profundidad actual o que sea la profundidad de favoritos (-1) y tengan el bool
                if (addCollection)
                {
                    //Image imagen = Image.FromFile(colls[i].ImagePath);
                    //Definir el picture box
                    picBoxArr[pL] = new PictureBox
                    {
                        AccessibleDescription = "collection",//Aqui se indica que tipo de picture box es (coleccion / archivo)
                        Name = colls[i].Name,//Aqui se guarda el nombre de la coleccion
                        Size = new Size(colls[i].Width, colls[i].Height),
                        BackColor = Color.FromArgb(colls[i].ColorRed, colls[i].ColorGreen, colls[i].ColorBlue),
                        Tag = colls[i].ID,//Aqui se guarda en que espacio del array estamos buscando//colls[i].ID,
                    };

                    //Establecer formato de imagen (como tiene validaciones, no puedo meterlo en el paquete de arriba)
                    if (colls[i].ImagePath != "")
                    {
                        try
                        {
                            Image image;
                            using (Stream stream = File.OpenRead(colls[i].ImagePath))
                            {
                                image = System.Drawing.Image.FromStream(stream);
                            }
                            picBoxArr[pL].BackgroundImage = image;
                            image = null;

                            //Image imagen = Image.FromFile(colls[i].ImagePath);
                            //picBoxArr[pL].BackgroundImage = imagen;
                            //imagen.Dispose();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("no se pudo establecer una imagen en coleccion " + i + " | " + ex.ToString());
                        }
                    } else
                    {
                        Console.WriteLine("No se pudo cargar la imagen de la id"+i+"por que no habia string en: " + colls[i].ImagePath);
                    }
                    
                   
                    //Formato de la imagen
                    if (colls[i].ImageLayout == 0)
                    {
                        picBoxArr[pL].BackgroundImageLayout = ImageLayout.Zoom;
                    } else
                    {
                        picBoxArr[pL].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //picBoxArr[pL].Click +=
                    picBoxArr[pL].MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
                    picBoxArr[pL].MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
                    picBoxArr[pL].MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Click);
                    picBoxArr[pL].MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);


                    picBoxArr[pL].ContextMenuStrip = contextMenuPictureBox;

                    //Se integraran despues de ordenarlos
                    //flowLayoutPanelMain.Controls.Add(picBoxArr[pL]);

                    pL++;//iterar en el array de paneles
                }
            }

            #endregion

            #region archivos
            //Recorrer todo el array de los files
            for (int f = 0; f < files.Length; f++)
            {
                bool addFile = false;//Me permite añadir varias condicionales dentro de un mismo if

                if (filter)
                {
                    //Verifica si el nombre de la coleccion contiene alguno de los elementos del textbox
                    string nom = files[f].Name.ToLower();
                    string search = textBoxSearch.Text.ToLower();

                    if (nom.Contains(search) && ((viewDepth == files[f].IDFather) || (viewDepth == -1 && files[f].Favorite == true))) addFile = true;

                }
                else
                {
                    if ((viewDepth == files[f].IDFather) || (viewDepth == -1 && files[f].Favorite == true)) addFile = true;
                }

                //Solo agregar las colecciones que coincidan con la profundidad actual o que si estamos en favoritos (-1) tengan el bool en true
                if (addFile)
                {
                    int fileW = 100;
                    int fileH = 100;

                    if (files[f].ResolutionID == 0)
                    {
                        fileW = files[f].Width;
                        fileH = files[f].Height;
                    } else
                    {
                        try
                        {
                            //Cargar la resolucion perteneciente a esa id
                            XmlDocument doc = new XmlDocument();
                            doc.Load(xmlResPath);
                            string xpath = "//Launcher/resolution[@id='" + files[f].ResolutionID + "']";
                            XmlNode root = doc.SelectSingleNode(xpath);

                            fileW = int.Parse(root.SelectSingleNode("Width").InnerText);
                            fileH = int.Parse(root.SelectSingleNode("Height").InnerText);
                        } catch (Exception ex)
                        {
                            Console.WriteLine("\n///////\nNo se pudo cargar la resolucion del archivo xml\nerror\n"+ex);
                        }
                        
                    }

                    //Definir el picture box
                    picBoxArr[pL] = new PictureBox
                    {
                        AccessibleDescription = "file",//Aqui se indica que tipo de picture box es (coleccion / archivo)//,
                        Name = files[f].Name,
                        Size = new Size(fileW, fileH),
                        BackColor = Color.FromArgb(files[f].ColorRed, files[f].ColorGreen, files[f].ColorBlue),
                        /*
                        BackgroundImage = imagen,
                        */
                        //Text = "file",//Aqui se indica que tipo de picture box es (coleccion / archivo)
                        Tag = files[f].ID,//Aqui indico que espacio de su array estamos buscando //Aqui se guarda la id del archivo, para que cuando se haga click, se busque en el array lo que tiene y se abra
                    };

                    //Establecer formato de imagen (como tiene validaciones, no puedo meterlo en el paquete de arriba)
                    if (files[f].ImagePath != "")
                    {
                        try
                        {
                            Image image;
                            using (Stream stream = File.OpenRead(files[f].ImagePath))
                            {
                                image = System.Drawing.Image.FromStream(stream);
                            }
                            picBoxArr[pL].BackgroundImage = image;
                            image = null;
                            //Image imagen = Image.FromFile(files[f].ImagePath);
                            //picBoxArr[pL].BackgroundImage = imagen;
                            // imagen.Dispose();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("no se pudo establecer una imagen en archivo " + f + " | " + ex.ToString());
                        }
                    }

                    //Formato de la imagen
                    if (files[f].ImageLayout == 0)
                    {
                        picBoxArr[pL].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else
                    {
                        picBoxArr[pL].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //agregar la funcionalidad
                    picBoxArr[pL].MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
                    picBoxArr[pL].MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
                    picBoxArr[pL].MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Click);
                    picBoxArr[pL].MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
                    picBoxArr[pL].ContextMenuStrip = contextMenuPictureBox;

                    //Se integraran despues de ordenarlos
                    //flowLayoutPanelMain.Controls.Add(picBoxArr[pL]);
                    pL++;//iterar en el array de paneles
                }
            }
            #endregion

            #region Ordenar el array
            //Optimizar el tamaño del array
            Array.Resize(ref picBoxArr, pL);

            //Ordenar los paneles por orden alfabetico
            if (orderPanels == 1)
            {
                picBoxArr = orderPBoxName(picBoxArr);
            }


            //Insertar los paneles ya ordenados
            for (int i = 0; i < picBoxArr.Length; i++)
            {
                //pan[i]->BackgroundImage->HorizontalResolution ; Obtener el tamaño de la imagen dentro del panel
                flowLayoutPanelMain.Controls.Add(picBoxArr[i]);
            }
            #endregion

            flowLayoutPanelMain.ResumeLayout();
        }

        private void loadTreeView(int colSize)
        {
            //Cargar todas las colecciones
            Collections[] colls = new Collections[colSize];
            colls = LoadCollections(colSize);
            treeViewMain.Nodes.Clear();//Limpiar todo el treeview
            //Crear el nodo de favoritos
            TreeNode fvNode = new TreeNode("Favoritos");  fvNode.Tag = -1; treeViewMain.Nodes.Add(fvNode);
            for (int i = 0; i < colls.Length; i++)
            {
                //Cargar sub nodos
                if (colls[i].IDFather != 0)
                {
                    //Buscar entre todos los nodos principales
                    foreach(TreeNode nodeF in treeViewMain.Nodes)
                    {
                        if (nodeF.Tag.Equals(colls[i].IDFather))
                        {
                            TreeNode subNode = new TreeNode(colls[i].Name);
                            subNode.Tag = colls[i].ID;
                            nodeF.Nodes.Add(subNode);
                            break;//frenar el foreach
                        }
                        searchSubNode(nodeF, colls[i].IDFather, colls[i].ID, colls[i].Name);                        
                    }
                } else
                {
                    //Cargar nodos de profundidad principal (idFather = 0)


                    TreeNode node = new TreeNode(colls[i].Name);

                    // Asignar una etiqueta al nodo
                    node.Tag = colls[i].ID;

                    // Agregar el nodo al TreeView
                    treeViewMain.Nodes.Add(node);
                }
            }
            //Expandir el tree view para ver todos los nodos
            treeViewMain.ExpandAll();

        }

        private void searchSubNode(TreeNode node, int tagId, int collId, string collName)
        {
            foreach(TreeNode subnodo in node.Nodes) {
                if (subnodo.Tag.Equals(tagId))
                {
                    //MessageBox::Show("el tag del sub nodo: " + subnodo->Tag + " coincide con el tag: " + tagId);
                    TreeNode subSubNode = new TreeNode(collName);
                    subSubNode.Tag = collId;
                    subnodo.Nodes.Add(subSubNode);
                    break;//frenar el foreach

                }
                searchSubNode(subnodo, tagId, collId, collName);
            }
        }

        //Navegar entre nodos
        private void treeViewMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            object tag = e.Node.Tag;
            if (tag != null)
            {
                int depth = int.Parse(tag.ToString());
                viewDepth = depth;
                loadPictureBox(colSize, fileSize, false);
            }
        }

        //Funcion que ordena el array de los paneles por orden alfabetico (Ordenamiento por Inserción)
        private PictureBox[] orderPBoxName(PictureBox[] pArray)
        {
            int i, pos;// pos es la posicion actual que se esta iterando
            PictureBox aux;//auxiliar para ayudar al intercambio de las posiciones

            //String::Compare verifica el orden alfabetico de strings
            //<0 si la primera cadena es menor que la segunda
            //0 si son iguales
            //>0 si la primera es mayor que la segunda

            //Ordenamiento por Inserción
            for (i = 0; i < pArray.Length; i++)
            {
                pos = i;
                aux = pArray[i];//Pasar el panel actual al auxiliar para hacer el intercambio

                while ((pos > 0) && (String.Compare(pArray[pos - 1].Name, aux.Name) > 0))
                {
                    //Si la cadena izq, es mayor que la derecha, cambiar
                    pArray[pos] = pArray[pos - 1];
                    pos--;
                }
                pArray[pos] = aux;//Refrescar en cada iteracion
            }
            return pArray;
        }

        private void btnBackView_Click(object sender, EventArgs e)
        {
            if (viewDepth > 0)//No volver atras si estas en el menu base
            {
                //Buscar con la profundidad el idPadre de la coleccion actual
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlColPath);

                string xpath = "//Launcher/collection[@id='" + viewDepth + "']";
                XmlNode root = doc.SelectSingleNode(xpath);
                int id = int.Parse(root.SelectSingleNode("IDFather").InnerText);
                viewDepth = id;
                loadPictureBox(colSize, fileSize, false);
            }
        }

        private void btnHomeView_Click(object sender, EventArgs e)
        {
            if (viewDepth != 0)
            {
                viewDepth = 0;
                loadPictureBox(colSize, fileSize, false);
            }
        }

        private void btnReloadView_Click(object sender, EventArgs e)
        {
            colSize = LoadCollectionSize();
            fileSize = LoadFilesSize();
            loadView(colSize, fileSize);
        }
        #endregion

        #region Manejar datos XML
        #region Archivos
        //Cargar el tamaño de elementos con id que existen en el xml de archivos
        private int LoadFilesSize()
        {
            int size = 0;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilesPath);
                XmlNodeList filesElements = xmlDoc.SelectNodes("//*[@id]");
                size = filesElements.Count;
            }
            catch (Exception)
            {
                Console.WriteLine("No se encontro el fichero de los archivos, se creara uno nuevo");
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlFilesPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            return size;
        }

        //Cargar todos los archivos del xml en un objeto files array
        private Files[] LoadFiles(int arraySize)
        {
            Files[] fileData = new Files[arraySize];

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilesPath);

            int fileID = 1;
            for (int i = 0; i < arraySize; i++)
            {
                //Buscamos el elemento a modificar
                string xpath = "//Launcher/file[@id='" + fileID + "']";
                string tagpath = "//Launcher/file/TagsID";
                XmlNode root = xmlDoc.SelectSingleNode(xpath);
                XmlNode rootTag = xmlDoc.SelectSingleNode(tagpath);

                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {
                    fileID++;
                    xpath = "//Launcher/file[@id='" + fileID + "']";
                    root = xmlDoc.SelectSingleNode(xpath);
                }

                int idFather = int.Parse(root.SelectSingleNode("IDFather").InnerText);
                string name = root.SelectSingleNode("Name").InnerText;
                string imgPath = root.SelectSingleNode("Image").InnerText;
                int imgLayout = int.Parse(root.SelectSingleNode("ImageLayout").InnerText);
                string filePath = root.SelectSingleNode("FilePath").InnerText;
                string programPath = root.SelectSingleNode("ProgramPath").InnerText;
                string cmdLine = root.SelectSingleNode("CMDLine").InnerText;
                int red = int.Parse(root.SelectSingleNode("BackgroundRed").InnerText);
                int green = int.Parse(root.SelectSingleNode("BackgroundGreen").InnerText);
                int blue = int.Parse(root.SelectSingleNode("BackgroundBlue").InnerText);
                int resolution = int.Parse(root.SelectSingleNode("CoverResolutionID").InnerText);
                int width = int.Parse(root.SelectSingleNode("CoverWidth").InnerText);
                int height = int.Parse(root.SelectSingleNode("CoverHeight").InnerText);
                bool urlCheck = bool.Parse(root.SelectSingleNode("URLCheck").InnerText);
                int[] tagsArray = new int[] { };
                foreach (XmlNode tagid in rootTag)
                {
                    //hacer un append al array
                    tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
                }
                bool fav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);

                fileData[i] = new Files(fileID, idFather, name, imgPath, imgLayout, filePath, programPath, cmdLine, red, green, blue, resolution, width, height, urlCheck, tagsArray, fav);

                fileID++;
            }

            return fileData;
        }

        private void SaveXMLFile(Files Class)
        {
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            if (!File.Exists(xmlFilesPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlFilesPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilesPath);

            XmlElement file;
            //Creando un archivo totalmente nuevo
            if (Class.ID == -1)
            {
                XmlNodeList nodeList = xmlDoc.SelectNodes("//Launcher/file");

                //Itera para encontrar el id mas alto
                int maxId = 0;
                foreach (XmlNode node in nodeList)
                {
                    int currentId;
                    if (int.TryParse(node.Attributes["id"].Value, out currentId))
                    {
                        if (currentId > maxId)
                        {
                            maxId = currentId;
                        }
                    }
                }

                //Crea una coleccion/archivo nueva
                file = xmlDoc.CreateElement("file");
                file.SetAttribute("id", maxId + 1 + "");//establecer el atributo id para facilitar la busqueda por xPath
                xmlDoc.DocumentElement.AppendChild(file);//agrega la coleccion al documento
            }
            else
            {
                //Editar colecciones
                string xpath = "//Launcher/file[@id='" + Class.ID + "']";
                file = xmlDoc.SelectSingleNode(xpath) as XmlElement;
                //Limpiarlo para agregarle las modificaciones
                file.RemoveAll();
                file.SetAttribute("id", Class.ID.ToString());
            }

            //Elementos de ese file
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos de la coleccion a la coleccion
            XmlElement fileFather = xmlDoc.CreateElement("IDFather"); fileFather.InnerText = Class.IDFather.ToString(); file.AppendChild(fileFather);
            XmlElement fileName = xmlDoc.CreateElement("Name"); fileName.InnerText = Class.Name; file.AppendChild(fileName);
            XmlElement fileImage = xmlDoc.CreateElement("Image"); fileImage.InnerText = Class.ImagePath; file.AppendChild(fileImage);
            XmlElement fileLayout = xmlDoc.CreateElement("ImageLayout"); fileLayout.InnerText = Class.ImageLayout.ToString(); file.AppendChild(fileLayout);
            XmlElement filePath = xmlDoc.CreateElement("FilePath"); filePath.InnerText = Class.FilePath; file.AppendChild(filePath);
            XmlElement fileProgram = xmlDoc.CreateElement("ProgramPath"); fileProgram.InnerText = Class.ProgramPath; file.AppendChild(fileProgram);
            XmlElement filecmd = xmlDoc.CreateElement("CMDLine"); filecmd.InnerText = Class.CMDLine; file.AppendChild(filecmd);
            XmlElement fileBgRed = xmlDoc.CreateElement("BackgroundRed"); fileBgRed.InnerText = Class.ColorRed.ToString(); file.AppendChild(fileBgRed);
            XmlElement fileBgGreen = xmlDoc.CreateElement("BackgroundGreen"); fileBgGreen.InnerText = Class.ColorGreen.ToString(); file.AppendChild(fileBgGreen);
            XmlElement fileBgBlue = xmlDoc.CreateElement("BackgroundBlue"); fileBgBlue.InnerText = Class.ColorBlue.ToString(); file.AppendChild(fileBgBlue);
            XmlElement fileResolution = xmlDoc.CreateElement("CoverResolutionID"); fileResolution.InnerText = Class.ResolutionID.ToString(); file.AppendChild(fileResolution);
            XmlElement fileWith = xmlDoc.CreateElement("CoverWidth"); fileWith.InnerText = Class.Width.ToString(); file.AppendChild(fileWith);
            XmlElement fileHeight = xmlDoc.CreateElement("CoverHeight"); fileHeight.InnerText = Class.Height.ToString(); file.AppendChild(fileHeight);
            XmlElement fileURL = xmlDoc.CreateElement("URLCheck"); fileURL.InnerText = Class.URLCheck.ToString(); file.AppendChild(fileURL);
            //Guardar el array de tags
            XmlElement fileTags = xmlDoc.CreateElement("TagsID"); file.AppendChild(fileTags);
            foreach (int num in Class.TagsID)
            {
                XmlElement numArray = xmlDoc.CreateElement("id");
                numArray.InnerText = num.ToString();
                fileTags.AppendChild(numArray);
                //Console.WriteLine(num);
            }

            XmlElement fileFavorite = xmlDoc.CreateElement("Favorite"); fileFavorite.InnerText = Class.Favorite.ToString(); file.AppendChild(fileFavorite);

            xmlDoc.Save(xmlFilesPath);

            //Actualizar la cantidad de archivos
            fileSize = LoadFilesSize();
            viewDepth = Class.IDFather;
        }

        //Cargar los datos de un archivo especifico
        private void searchFileProcess(int fileID)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            string filePath = "";
            string programPath = "";
            string cmdLine = "";
            bool urlCheck = false;

            if (root != null)
            {
                filePath = root.SelectSingleNode("FilePath").InnerText;
                programPath = root.SelectSingleNode("ProgramPath").InnerText;
                cmdLine = root.SelectSingleNode("CMDLine").InnerText;
                urlCheck = bool.Parse(root.SelectSingleNode("URLCheck").InnerText);
                /*foreach (XmlNode rootxml in root.ChildNodes)
                {
                    // Hacer algo con el nodo, por ejemplo imprimir su nombre
                    //Console.WriteLine(rootxml.Name + " | " + rootxml.InnerText);
                    switch (rootxml.Name)
                    {
                        case "FilePath": filePath = rootxml.InnerText; break;
                        case "ProgramPath": programPath = rootxml.InnerText; break;
                        case "CMDLine": cmdLine = rootxml.InnerText; break;
                        case "URLCheck": urlCheck = bool.Parse(rootxml.InnerText); break;
                    }
                }*/
            }

            //Llamar a la funcion para que empiece el proceso
            startProcess(filePath, programPath, cmdLine, urlCheck);

            //return fileData;
        }
        
        private bool getFileFav(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            bool returnFav = false;

            if (root != null)
            {
                returnFav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);
            }

            //Llamar a la funcion para que empiece el proceso
            return returnFav;
        }

        private void setFileFav(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            if (root != null)
            {
                bool returnFav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);

                if (returnFav == false) { root.SelectSingleNode("Favorite").InnerText = "True"; }
                else { root.SelectSingleNode("Favorite").InnerText = "False"; }

                doc.Save(xmlFilesPath);
            }
        }

        private Files searchFileData(int fileID)
        {
            Console.WriteLine("Buscando en el archivo con id: " + fileID);
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            string tagpath = "//Launcher/file/TagsID";
            XmlNode root = doc.SelectSingleNode(xpath);
            XmlNode rootTag = doc.SelectSingleNode(tagpath);

            int idFather = int.Parse(root.SelectSingleNode("IDFather").InnerText);
            string name = root.SelectSingleNode("Name").InnerText;
            string imgPath = root.SelectSingleNode("Image").InnerText;
            int imgLayout = int.Parse(root.SelectSingleNode("ImageLayout").InnerText);
            string filePath = root.SelectSingleNode("FilePath").InnerText;
            string programPath = root.SelectSingleNode("ProgramPath").InnerText;
            string cmdLine = root.SelectSingleNode("CMDLine").InnerText;
            int red = int.Parse(root.SelectSingleNode("BackgroundRed").InnerText);
            int green = int.Parse(root.SelectSingleNode("BackgroundGreen").InnerText);
            int blue = int.Parse(root.SelectSingleNode("BackgroundBlue").InnerText);
            int resolution = int.Parse(root.SelectSingleNode("CoverResolutionID").InnerText);
            int width = int.Parse(root.SelectSingleNode("CoverWidth").InnerText);
            int height = int.Parse(root.SelectSingleNode("CoverHeight").InnerText);
            bool urlCheck = bool.Parse(root.SelectSingleNode("URLCheck").InnerText);
            int[] tagsArray = new int[] { };
            foreach (XmlNode tagid in rootTag)
            {
                //hacer un append al array
                tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
            }
            bool fav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);

            /*foreach (XmlNode rootxml in root.ChildNodes)
            {
                switch (rootxml.Name)
                {
                    case "IDFather": idFather = int.Parse(rootxml.InnerText); break;
                    case "Name": name = rootxml.InnerText; break;
                    case "Image": imgPath = rootxml.InnerText; break;
                    case "ImageLayout": imgLayout = int.Parse(rootxml.InnerText); break;
                    case "FilePath": filePath = rootxml.InnerText; break;
                    case "ProgramPath": programPath = rootxml.InnerText; break;
                    case "CMDLine": cmdLine = rootxml.InnerText; break;
                    case "BackgroundRed": red = int.Parse(rootxml.InnerText); break;
                    case "BackgroundGreen": green = int.Parse(rootxml.InnerText); break;
                    case "BackgroundBlue": blue = int.Parse(rootxml.InnerText); break;
                    case "CoverResolutionID": resolution = int.Parse(rootxml.InnerText); break;
                    case "CoverWidth": width = int.Parse(rootxml.InnerText); break;
                    case "CoverHeight": height = int.Parse(rootxml.InnerText); break;
                    case "URLCheck": urlCheck = bool.Parse(rootxml.InnerText); break;
                    case "TagsID":
                        //leer los tags dentro del elemento
                        foreach (XmlNode tagid in rootxml)
                        {
                            //hacer un append al array
                            tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
                        }
                        break;
                    case "Favorite": fav = bool.Parse(rootxml.InnerText); break;
                }
            }*/

            Files FileReturn = new Files(fileID, idFather, name, imgPath, imgLayout, filePath, programPath, cmdLine, red, green, blue, resolution, width, height, urlCheck, tagsArray, fav);

            return FileReturn;
        }

        private void deleteFile(int fileID)
        {
            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilesPath);

            //Buscamos el elemento a eliminar
            string xpath = "//Launcher/file[@id='" + fileID + "']"; //Buscar un elemento que se llame "ColeccionX" que tenga en el atributo id un 1
            XmlNode root = xmlDoc.SelectSingleNode(xpath);

            //Eliminar la caratula solo si está ubicada en la carpeta "System"

            string imgDir = root.SelectSingleNode("Image").InnerText;
            if (imgDir != "")
            {
                string folder = Path.GetDirectoryName(imgDir);
                string workFolder = Directory.GetCurrentDirectory() + "\\" + dirCoversPath;

                //Si la carpeta donde se ubica la imagen es System//Covers, eliminar el archivo
                if (folder == workFolder)
                {
                    try
                    {
                        //Solo eliminara el archivo si existe
                        if (File.Exists(imgDir))
                        {
                            // Eliminar el archivo
                            File.Delete(imgDir);
                        }
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("Error al eliminar el archivo: " + ex.Message);
                    }
                }
            }
            

            if (root != null)
            {
                root.ParentNode.RemoveChild(root);
            }

            xmlDoc.Save(xmlFilesPath);

            colSize = LoadCollectionSize();
            fileSize = LoadFilesSize();
            loadPictureBox(colSize, fileSize, false);
        }
        #endregion

        #region Colecciones
        //Cargar el tamaño de elementos con id que existen en el xml de colecciones
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

        private bool getColeFav(int colID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlColPath);

            string xpath = "//Launcher/collection[@id='" + colID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            bool returnFav = false;

            if (root != null)
            {
                returnFav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);
            }

            //Llamar a la funcion para que empiece el proceso
            return returnFav;
        }

        private void setColeFav(int colID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlColPath);

            string xpath = "//Launcher/collection[@id='" + colID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            if (root != null)
            {
                bool returnFav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);

                if (returnFav == false) { root.SelectSingleNode("Favorite").InnerText = "True"; }
                else { root.SelectSingleNode("Favorite").InnerText = "False"; }

                doc.Save(xmlColPath);
            }
        }

        private void SaveXMLCollection(Collections Class)
        {
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            if (!File.Exists(xmlColPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlColPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlColPath);

            XmlElement coleccion;
            //Crear colecciones nuevas
            if (Class.ID == -1)
            {
                XmlNodeList nodeList = xmlDoc.SelectNodes("//Launcher/collection");

                //Itera para encontrar el id mas alto
                int maxId = 0;
                foreach (XmlNode node in nodeList)
                {
                    int currentId;
                    if (int.TryParse(node.Attributes["id"].Value, out currentId))
                    {
                        if (currentId > maxId)
                        {
                            maxId = currentId;
                        }
                    }
                }

                //Crea una coleccion/archivo nueva
                coleccion = xmlDoc.CreateElement("collection");
                coleccion.SetAttribute("id", maxId + 1 + "");//establecer el atributo id para facilitar la busqueda por xPath
                xmlDoc.DocumentElement.AppendChild(coleccion);//agrega la coleccion al documento
            }
            else
            {
                //Editar colecciones
                string xpath = "//Launcher/collection[@id='" + Class.ID + "']";
                coleccion = xmlDoc.SelectSingleNode(xpath) as XmlElement;
                //Limpiarlo para agregarle las modificaciones
                coleccion.RemoveAll();
                coleccion.SetAttribute("id", Class.ID.ToString());
            }

            //Elementos de esa coleccion
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos de la coleccion a la coleccion
            XmlElement colFather = xmlDoc.CreateElement("IDFather"); colFather.InnerText = Class.IDFather.ToString(); coleccion.AppendChild(colFather);
            XmlElement colName = xmlDoc.CreateElement("Name"); colName.InnerText = Class.Name; coleccion.AppendChild(colName);
            XmlElement colImage = xmlDoc.CreateElement("Image"); colImage.InnerText = Class.ImagePath; coleccion.AppendChild(colImage);
            XmlElement colLayout = xmlDoc.CreateElement("ImageLayout"); colLayout.InnerText = Class.ImageLayout.ToString(); coleccion.AppendChild(colLayout);
            XmlElement colBgRed = xmlDoc.CreateElement("BackgroundRed"); colBgRed.InnerText = Class.ColorRed.ToString(); coleccion.AppendChild(colBgRed);
            XmlElement colBgGreen = xmlDoc.CreateElement("BackgroundGreen"); colBgGreen.InnerText = Class.ColorGreen.ToString(); coleccion.AppendChild(colBgGreen);
            XmlElement colBgBlue = xmlDoc.CreateElement("BackgroundBlue"); colBgBlue.InnerText = Class.ColorBlue.ToString(); coleccion.AppendChild(colBgBlue);
            XmlElement colResolution = xmlDoc.CreateElement("CoverResolutionID"); colResolution.InnerText = Class.ResolutionID.ToString(); coleccion.AppendChild(colResolution);
            XmlElement colWith = xmlDoc.CreateElement("CoverWidth"); colWith.InnerText = Class.Width.ToString(); coleccion.AppendChild(colWith);
            XmlElement colHeight = xmlDoc.CreateElement("CoverHeight"); colHeight.InnerText = Class.Height.ToString(); coleccion.AppendChild(colHeight);
            XmlElement colSonResolution = xmlDoc.CreateElement("CoverSonResolutionID"); colSonResolution.InnerText = Class.SonResolution.ToString(); coleccion.AppendChild(colSonResolution);
            XmlElement colSonWidth = xmlDoc.CreateElement("CoverSonWidth"); colSonWidth.InnerText = Class.SonWidth.ToString(); coleccion.AppendChild(colSonWidth);
            XmlElement colSonHeight = xmlDoc.CreateElement("CoverSonHeight"); colSonHeight.InnerText = Class.SonHeight.ToString(); coleccion.AppendChild(colSonHeight);
            XmlElement colSonLayout = xmlDoc.CreateElement("SonImageLayout"); colSonLayout.InnerText = Class.ImageLayout.ToString(); coleccion.AppendChild(colSonLayout);
            //Guardar el array de tags
            XmlElement colTags = xmlDoc.CreateElement("TagsID"); coleccion.AppendChild(colTags);
            foreach (int num in Class.TagsID)
            {
                XmlElement numArray = xmlDoc.CreateElement("id");
                numArray.InnerText = num.ToString();
                colTags.AppendChild(numArray);
                //Console.WriteLine(num);
            }
            XmlElement colFavorite = xmlDoc.CreateElement("Favorite"); colFavorite.InnerText = Class.Favorite.ToString(); coleccion.AppendChild(colFavorite);

            xmlDoc.Save(xmlColPath);

            //Actualizar cantidad de colecciones
            colSize = LoadCollectionSize();
        }


        //cargar las colecciones del xml en un objeto collections array
        private Collections[] LoadCollections(int arraySize)
        {
            Collections[] colData = new Collections[arraySize];

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlColPath);


            int fileID = 1;
            for (int i = 0; i < arraySize; i++)
            {
                //Buscamos el elemento a modificar
                string xpath = "//Launcher/collection[@id='" + fileID + "']";
                string tagpath = "//Launcher/collection/TagsID";
                XmlNode root = xmlDoc.SelectSingleNode(xpath);
                XmlNode rootTag = xmlDoc.SelectSingleNode(tagpath);

                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {
                    fileID++;
                    xpath = "//Launcher/collection[@id='" + fileID + "']";
                    
                    root = xmlDoc.SelectSingleNode(xpath);
                }

                int idFather = int.Parse(root.SelectSingleNode("IDFather").InnerText);
                string name = root.SelectSingleNode("Name").InnerText;
                string imgPath = root.SelectSingleNode("Image").InnerText;
                int imgLayout = int.Parse(root.SelectSingleNode("ImageLayout").InnerText);
                int red = int.Parse(root.SelectSingleNode("BackgroundRed").InnerText);
                int green = int.Parse(root.SelectSingleNode("BackgroundGreen").InnerText);
                int blue = int.Parse(root.SelectSingleNode("BackgroundBlue").InnerText);
                int resolution = int.Parse(root.SelectSingleNode("CoverResolutionID").InnerText);
                int width = int.Parse(root.SelectSingleNode("CoverWidth").InnerText);
                int height = int.Parse(root.SelectSingleNode("CoverHeight").InnerText);
                int sonRes = int.Parse(root.SelectSingleNode("CoverSonResolutionID").InnerText);
                int sonWidth = int.Parse(root.SelectSingleNode("CoverSonWidth").InnerText);
                int sonHeight = int.Parse(root.SelectSingleNode("CoverSonHeight").InnerText);
                int sonLayout = int.Parse(root.SelectSingleNode("SonImageLayout").InnerText);
                int[] tagsArray = { };
                foreach (XmlNode tagid in rootTag)
                {
                    //string[] strArray = rootxml.InnerText.Split(' ');
                    //tagsArray = strArray.Select(s => int.Parse(s)).ToArray();
                    //break;
                    //hacer un append al array
                    tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
                }
                bool fav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);

                //"1, 3, 4, 5, 6, 9, 10, 14, 23"
                //Navegar entre todos los elementos que contenga el elemento base del xml
                /*foreach (XmlNode rootxml in root.ChildNodes)
                {
                    //Console.WriteLine(rootxml.Name + " | " + rootxml.InnerText);
                    switch (rootxml.Name)
                    {
                        case "IDFather": idFather = int.Parse(rootxml.InnerText); break;
                        case "Name": name = rootxml.InnerText; break;
                        case "Image": imgPath = rootxml.InnerText; break;
                        case "ImageLayout": imgLayout = int.Parse(rootxml.InnerText); break;
                        case "BackgroundRed": red = int.Parse(rootxml.InnerText); break;
                        case "BackgroundGreen": green = int.Parse(rootxml.InnerText); break;
                        case "BackgroundBlue": blue = int.Parse(rootxml.InnerText); break;
                        case "CoverResolutionID": resolution = int.Parse(rootxml.InnerText); break;
                        case "CoverWidth": width = int.Parse(rootxml.InnerText); break;
                        case "CoverHeight": height = int.Parse(rootxml.InnerText); break;
                        case "CoverSonResolutionID": sonRes = int.Parse(rootxml.InnerText); break;
                        case "CoverSonWidth": sonWidth = int.Parse(rootxml.InnerText); break;
                        case "CoverSonHeight": sonHeight = int.Parse(rootxml.InnerText); break;
                        case "SonImageLayout": sonLayout = int.Parse(rootxml.InnerText); break;
                        case "TagsID":
                            string[] strArray = rootxml.InnerText.Split(' ');
                            tagsArray = strArray.Select(s => int.Parse(s)).ToArray();
                            break;
                        case "Favorite": fav = bool.Parse(rootxml.InnerText); break;
                    }
                }*/

                colData[i] = new Collections(fileID, idFather, name, imgPath, imgLayout, red, green, blue, resolution, width, height, sonRes, sonWidth, sonHeight, sonLayout, tagsArray, fav);

                fileID++;
            }

            return colData;
        }

        private Collections searchCollectionData(int colID)
        {
            Console.WriteLine("buscando en coleccion con id " + colID);
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlColPath);

            string xpath = "//Launcher/collection[@id='" + colID + "']";
            string tagpath = "//Launcher/collection/TagsID";
            XmlNode root = doc.SelectSingleNode(xpath);
            XmlNode rootTag = doc.SelectSingleNode(tagpath);

            int idFather = int.Parse(root.SelectSingleNode("IDFather").InnerText);
            string name = root.SelectSingleNode("Name").InnerText;
            string imgPath = root.SelectSingleNode("Image").InnerText;
            int imgLayout = int.Parse(root.SelectSingleNode("ImageLayout").InnerText);
            int red = int.Parse(root.SelectSingleNode("BackgroundRed").InnerText);
            int green = int.Parse(root.SelectSingleNode("BackgroundGreen").InnerText);
            int blue = int.Parse(root.SelectSingleNode("BackgroundBlue").InnerText);
            int resolution = int.Parse(root.SelectSingleNode("CoverResolutionID").InnerText);
            int width = int.Parse(root.SelectSingleNode("CoverWidth").InnerText);
            int height = int.Parse(root.SelectSingleNode("CoverHeight").InnerText);
            int sonRes = int.Parse(root.SelectSingleNode("CoverSonResolutionID").InnerText);
            int sonWidth = int.Parse(root.SelectSingleNode("CoverSonWidth").InnerText);
            int sonHeight = int.Parse(root.SelectSingleNode("CoverSonHeight").InnerText);
            int sonLayout = int.Parse(root.SelectSingleNode("SonImageLayout").InnerText);
            int[] tagsArray = { };
            foreach (XmlNode tagid in rootTag)
            {
                tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
            }
            bool fav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);


            Collections colReturn = new Collections(colID, idFather, name, imgPath, imgLayout, red, green, blue, resolution, width, height, sonRes, sonWidth, sonHeight, sonLayout, tagsArray, fav);

            return colReturn;
        }

        private Files[] searchFilesInCollection(int colID)
        {
            Files[] fileData = new Files[fileSize];

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilesPath);

            int fileID = 1;
            for (int i = 0; i < fileSize; i++)
            {
                //Buscamos el elemento a modificar
                string xpath = "//Launcher/file[@id='" + fileID + "']";
                string tagpath = "//Launcher/file/TagsID";
                XmlNode root = xmlDoc.SelectSingleNode(xpath);
                XmlNode rootTag = xmlDoc.SelectSingleNode(tagpath);

                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {
                    fileID++;
                    xpath = "//Launcher/file[@id='" + fileID + "']";
                    root = xmlDoc.SelectSingleNode(xpath);
                }

                //Solo iterar sobre los archivos que tengan de padre a la coleccion a editar
                int idFather = int.Parse(root.SelectSingleNode("IDFather").InnerText);
                if (idFather != colID)
                {
                    fileID++;
                    continue;
                }
                
                string name = root.SelectSingleNode("Name").InnerText;
                string imgPath = root.SelectSingleNode("Image").InnerText;
                int imgLayout = int.Parse(root.SelectSingleNode("ImageLayout").InnerText);
                string filePath = root.SelectSingleNode("FilePath").InnerText;
                string programPath = root.SelectSingleNode("ProgramPath").InnerText;
                string cmdLine = root.SelectSingleNode("CMDLine").InnerText;
                int red = int.Parse(root.SelectSingleNode("BackgroundRed").InnerText);
                int green = int.Parse(root.SelectSingleNode("BackgroundGreen").InnerText);
                int blue = int.Parse(root.SelectSingleNode("BackgroundBlue").InnerText);
                int resolution = int.Parse(root.SelectSingleNode("CoverResolutionID").InnerText);
                int width = int.Parse(root.SelectSingleNode("CoverWidth").InnerText);
                int height = int.Parse(root.SelectSingleNode("CoverHeight").InnerText);
                bool urlCheck = bool.Parse(root.SelectSingleNode("URLCheck").InnerText);
                int[] tagsArray = new int[] { };
                foreach (XmlNode tagid in rootTag)
                {
                    //hacer un append al array
                    tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
                }
                bool fav = bool.Parse(root.SelectSingleNode("Favorite").InnerText);

                fileData[i] = new Files(fileID, idFather, name, imgPath, imgLayout, filePath, programPath, cmdLine, red, green, blue, resolution, width, height, urlCheck, tagsArray, fav);

                fileID++;
            }

            Files[] arrangedFiles = fileData.Where(elemento => elemento != null).ToArray();

            return arrangedFiles;
        }

        private void deleteCollection(int colID)
        {
            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlColPath);

            //Buscamos el elemento a eliminar
            string xpath = "//Launcher/collection[@id='" + colID + "']";  //Buscar un elemento que se llame "ColeccionX" que tenga en el atributo id un 1
            XmlNode root = xmlDoc.SelectSingleNode(xpath);

            if (root != null)
            {
                root.ParentNode.RemoveChild(root);
            }

            xmlDoc.Save(xmlColPath);

            colSize = LoadCollectionSize();
            fileSize = LoadFilesSize();
            loadPictureBox(colSize, fileSize, false);
        }
        #endregion

        #region Settings
        //Cargar las configuraciones de settings
        private void loadSettingXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlSettingsPath);

            string xpath = "//Launcher/settings";
            string winpath = "//Launcher/settings/WindowSize";
            XmlNode root = xmlDoc.SelectSingleNode(xpath);
            XmlNode rootWin = xmlDoc.SelectSingleNode(winpath);

            //Cargar la ultima profundidad utilizada
            int ldepth = 0;
            try { if (root.SelectSingleNode("LastDepth") != null) ldepth = int.Parse(root.SelectSingleNode("LastDepth").InnerText); }
            finally { viewDepth = ldepth; }

            //Cargar el ancho del treenode
            int tWidth = 100;
            try { if (root.SelectSingleNode("TreeWidth") != null) tWidth = int.Parse(root.SelectSingleNode("TreeWidth").InnerText); }
            finally { treeViewMain.Width = tWidth; }

            //Cargar el orden de los paneles
            int pOrder = 0;
            try { if (root.SelectSingleNode("PanelOrder") != null) pOrder = int.Parse(root.SelectSingleNode("PanelOrder").InnerText); }
            finally {
                if (pOrder == 1)
                {
                    nombreToolStripMenuItem.Checked = true;
                    fechaDeCreacionToolStripMenuItem.Checked = false;
                }
                orderPanels = pOrder; 
            }

            //Cargar las opciones de la ventana (estan en un sub nodo)
            //Ancho de la ventana
            int wWidth = 688;
            try { if (rootWin.SelectSingleNode("Width") != null) wWidth = int.Parse(rootWin.SelectSingleNode("Width").InnerText); }
            finally { WinWidht = wWidth; }
            //Alto de la ventana
            int wHeight = 412;
            try { if (rootWin.SelectSingleNode("Height") != null) wHeight = int.Parse(rootWin.SelectSingleNode("Height").InnerText); }
            finally { WinHeight = wHeight; }
            //Si esta o no maximizado
            int wMax = 0;
            try { if (rootWin.SelectSingleNode("MxScreen") != null)  wMax = int.Parse(rootWin.SelectSingleNode("MxScreen").InnerText); }
            finally {
                if (wMax < 0 || wMax > 1) wMax = 1;
                formState = wMax; 
            }


            //Verificar los datos y establecerlos
            if (viewDepth < -1) viewDepth = 0;//Si es menor a -1(favoritos) dejarlo en 0
            if (orderPanels < 0) orderPanels = 0;
            if (WinWidht < 300) WinWidht = 300; Width = WinWidht;
            if (WinHeight < 300) WinHeight = 300; Height = WinHeight;
            if (formState == 0) WindowState =  FormWindowState.Normal; else WindowState = FormWindowState.Maximized;
        }

        //Guardar las configuraciones de settings
        private void saveSettingsXML()
        {
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            if (!File.Exists(xmlSettingsPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlSettingsPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlSettingsPath);
            XmlNode root = xmlDoc.DocumentElement;
            root.RemoveAll();

            XmlElement set;

            //Crea una coleccion/archivo nueva
            set = xmlDoc.CreateElement("settings");
            xmlDoc.DocumentElement.AppendChild(set);//agrega la coleccion al documento

            //Ultima profundidad/coleccion abierta
            XmlElement lDepth = xmlDoc.CreateElement("LastDepth"); lDepth.InnerText = viewDepth.ToString(); set.AppendChild(lDepth);

            //Guardar la resolucion (ancho, alto, Pantalla completa)
            XmlElement winSize = xmlDoc.CreateElement("WindowSize"); set.AppendChild(winSize);

            WinWidht = Width;
            WinHeight = Height;
            if (WindowState == FormWindowState.Minimized)
            {
                //Restaura el tamaño de la ventana antes de ser minimizada
                WinWidht = RestoreBounds.Width;
                WinHeight = RestoreBounds.Height;
            }

            XmlElement winWidth = xmlDoc.CreateElement("Width"); winWidth.InnerText = WinWidht.ToString(); winSize.AppendChild(winWidth);
            XmlElement winHeight = xmlDoc.CreateElement("Height"); winHeight.InnerText = WinHeight.ToString(); winSize.AppendChild(winHeight);

            int mx = 1;
            if (WindowState == FormWindowState.Normal) mx = 0;
            XmlElement winScreen = xmlDoc.CreateElement("MxScreen"); winScreen.InnerText = mx.ToString(); winSize.AppendChild(winScreen);

            //Guardar tamaño de treenode
            XmlElement treeWidth = xmlDoc.CreateElement("TreeWidth"); treeWidth.InnerText = treeViewMain.Width.ToString(); set.AppendChild(treeWidth);


            //Guardar como se ordenan los paneles
            XmlElement pOrder = xmlDoc.CreateElement("PanelOrder"); pOrder.InnerText = orderPanels.ToString(); set.AppendChild(pOrder);

            xmlDoc.Save(xmlSettingsPath);
        }

        private void labelTest_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion

        #region Manejar archivos en general
        private void verifySystemDir()
        {
            //Verificar la existencia de la carpeta System
            if (!Directory.Exists("System"))
            {
                // Crea la carpeta si no existe
                Directory.CreateDirectory("System");
            }

            //Verificar la existencia de la carpeta de los covers
            if (!Directory.Exists(dirCoversPath))
            {
                // Crea la carpeta si no existe
                Directory.CreateDirectory(dirCoversPath);
            }

            //Verificar la existencia del XML Files
            if (!File.Exists(xmlFilesPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlFilesPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Verificar la existencia del XML Collections
            if (!File.Exists(xmlColPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlColPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Verificar la existencia del XML Resolutions
            if (!File.Exists(xmlResPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlResPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Verificar la existencia del xml settings
            if (!File.Exists(xmlSettingsPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlSettingsPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }

                //Cargar el archivo XML
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlSettingsPath);

                XmlElement set;

                //Crea una coleccion/archivo nueva
                set = xmlDoc.CreateElement("settings");
                xmlDoc.DocumentElement.AppendChild(set);//agrega la coleccion al documento

                //Ultima profundidad/coleccion abierta
                XmlElement lDepth = xmlDoc.CreateElement("LastDepth"); lDepth.InnerText = "0"; set.AppendChild(lDepth);

               //Guardar la resolucion (ancho, alto, Pantalla completa)
                XmlElement winSize = xmlDoc.CreateElement("WindowSize"); set.AppendChild(winSize);
                    XmlElement winWidth = xmlDoc.CreateElement("Width"); winWidth.InnerText = WinWidht.ToString();  winSize.AppendChild(winWidth);
                    XmlElement winHeight = xmlDoc.CreateElement("Height"); winHeight.InnerText = WinHeight.ToString();  winSize.AppendChild(winHeight);
                    XmlElement winScreen = xmlDoc.CreateElement("MxScreen"); winScreen.InnerText = "1";  winSize.AppendChild(winScreen);

                //Guardar tamaño de treenode
                XmlElement treeWidth = xmlDoc.CreateElement("TreeWidth"); treeWidth.InnerText = "100"; set.AppendChild(treeWidth);

                //Guardar como se ordenan los paneles
                XmlElement pOrder = xmlDoc.CreateElement("PanelOrder"); pOrder.InnerText = "0"; set.AppendChild(pOrder);

                xmlDoc.Save(xmlSettingsPath);
            }

            

        }
        #endregion

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveSettingsXML();
        }
    }
}
