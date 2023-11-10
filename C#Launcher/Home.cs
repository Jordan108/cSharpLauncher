﻿using C_Launcher.Clases;

//using C_Launcher.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
//using System.Reflection.Emit;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using ImageMagick;
using System.Collections.Generic;
using CoverPadLauncher;
using CoverPadLauncher.Clases;
using System.Drawing.Imaging;
//mediaToolKit para manejar archivos de video y extraer sus caratulas
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using CoverPadLauncher.Clases.Controles;

namespace C_Launcher
{

    public partial class Home : Form
    {
        private PictureBox[] picBoxArr = new PictureBox[0];//Crear el array de picBox que se mantendra en memoria
        //Crea el array de las colecciones y los archivos (solo contendran las colecciones que se mostraran en en la vista)

        //Valores de settings
        //private int WinWidht, WinHeight = 900;
        //private int orderPanels = 0;
        //private int formState = 1;
        private int viewDepth = 0;//-1 = favoritos | 0 = inicio
        //private int searchType = 0;//0 = Buscara desde esa coleccion para adentro | 1 = buscara solo en esa coleccion (no sub colecciones) | 2 = buscara en todos los ficheros xml
        private CoverPadLauncher.Clases.Settings settings;

        //Rutas de los archivos XML
        private string xmlColPath = "System\\Collections.xml";
        private string xmlFilesPath = "System\\Elements.xml";
        private string xmlResPath = "System\\Resolutions.xml";
        //private string xmlSettingsPath = "System\\Settings.xml";
        private string xmlTagPath = "System\\Tags.xml";
        private string xmlScannedPath = "System\\ScannedDirs.xml";
        //Ruta de los covers
        private string dirCoversPath = "System\\Covers";
        //Ruta de los elementos del sistema (iconos y demas)
        private string[] imgResourceIcons = { 
            "System\\Resources\\CollectionIcon.png" ,//0
            "System\\Resources\\ScanFileIcon.png", //1
            "System\\Resources\\ScanDirIcon.png",//2
            "System\\Resources\\CreateIcon.png",//3
            "System\\Resources\\DeleteIcon.png",//4
            "System\\Resources\\EditIcon.png",//5
            "System\\Resources\\FavoriteIcon.png",//6
            "System\\Resources\\FavoriteIcon2.png",//7
            "System\\Resources\\UbicationIcon.png", //8
            "System\\Resources\\OpenIcon.png" //9
        };

        //Escaneo de directorio
        private List<string> scanDepth = new List<string>();

        //Mantener el tamaño de los archivos, colecciones y escaneados
        private int colSize, fileSize = 0;
        
        //ToolStrip
        //Se define aqui para poder referenciarlo en la creacion de los paneles
        private ContextMenuStrip contextMenuPictureBox = new ContextMenuStrip();
        //Treeview
        private TreeNode lastHoveredNode = null; // Para realizar un seguimiento del nodo que se encuentra actualmente bajo el mouse.

        public Home()
        {
            InitializeComponent();
            //Verificar el contenido de la carpeta system, si no existe, crearlo
            verifySystemDir();
            //Cargar las opciones
            loadSettingXML();

            //Tool strip (click derecho)
            //flow Layout Panel Tool Strip
            ContextMenuStrip  contextMenuLayoutPanel   = new ContextMenuStrip();
            ToolStripMenuItem ToolStripAddCollection   = new ToolStripMenuItem();
            ToolStripMenuItem ToolStripAddFile         = new ToolStripMenuItem();
            ToolStripMenuItem ToolStripAddMultipleFile = new ToolStripMenuItem();
            ToolStripMenuItem ToolStripEditAllElements = new ToolStripMenuItem();
            ToolStripAddFile.Text = "Crear elemento";
            ToolStripAddFile.Image = Image.FromFile(imgResourceIcons[3]);
            ToolStripAddFile.Click += new EventHandler(ToolStripAddFile_Click);
            ToolStripAddCollection.Text = "Crear coleccion";
            ToolStripAddCollection.Image = Image.FromFile(imgResourceIcons[3]);
            ToolStripAddCollection.Click += new EventHandler(ToolStripAddCollection_Click);
            ToolStripAddMultipleFile.Text = "Crear multiples elementos";
            ToolStripAddMultipleFile.Image = Image.FromFile(imgResourceIcons[3]);
            ToolStripAddMultipleFile.Click += new EventHandler(ToolStripAddMultipleFiles_Click);
            ToolStripEditAllElements.Text = "Editar todos los elementos de la coleccion";
            ToolStripEditAllElements.Image = Image.FromFile(imgResourceIcons[5]);
            ToolStripEditAllElements.Click += new EventHandler(ToolStripEditMultipleFlowLayoutPanel_Click);
            contextMenuLayoutPanel.Items.AddRange(new ToolStripItem[] { ToolStripAddFile, ToolStripAddCollection, ToolStripAddMultipleFile, ToolStripEditAllElements });
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
            loadPictureBox(colSize, fileSize, false);
            menuStripMain.Renderer = new MyRenderer();

            treeViewMain.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            treeViewMain.DrawNode += new DrawTreeNodeEventHandler(treeViewMain_DrawNode);
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

                defaultRes = int.Parse(XMLDefaultReturn(root, "CoverSonResolutionID", "0"));
                defaultWidth = int.Parse(XMLDefaultReturn(root, "CoverSonWidth", "200"));
                defaultHeight = int.Parse(XMLDefaultReturn(root, "CoverSonHeight", "200"));
                defaultImageLayout = int.Parse(XMLDefaultReturn(root, "SonImageLayout", "0"));
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

                defaultRes = int.Parse(XMLDefaultReturn(root, "CoverSonResolutionID", "0"));
                defaultWidth = int.Parse(XMLDefaultReturn(root, "CoverSonWidth", "200"));
                defaultHeight = int.Parse(XMLDefaultReturn(root, "CoverSonHeight", "200"));
                defaultImageLayout = int.Parse(XMLDefaultReturn(root, "SonImageLayout", "0"));
            }

            NewCollection newCollection = new NewCollection(viewDepth, defaultRes, defaultWidth, defaultHeight, defaultImageLayout);
            newCollection.ReturnedObject += NewCollection_ReturnedObject;
            newCollection.ShowDialog();
        }

        //Crear la nueva ventana para crear los archivos (individual)
        private void ToolStripAddFile_Click(object sender, EventArgs e)
        {
            int defaultRes = 0;
            int defaultImageLayout = 0;
            int defaultWidth = 200;
            int defaultHeight = 200;
            string defaultProgramPath = "";
            string defaultCMDLine = "";


            //Si la profundidad es mayor a 0, buscar la coleccion con esa id en especifico y extraerle los valores default
            if (viewDepth > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlColPath);

                string xpath = "//Launcher/collection[@id='" + viewDepth + "']";
                XmlNode root = doc.SelectSingleNode(xpath);

                defaultRes = int.Parse(XMLDefaultReturn(root, "CoverSonResolutionID", "0"));
                defaultWidth = int.Parse(XMLDefaultReturn(root, "CoverSonWidth", "200"));
                defaultHeight = int.Parse(XMLDefaultReturn(root, "CoverSonHeight", "200"));
                defaultImageLayout = int.Parse(XMLDefaultReturn(root, "SonImageLayout", "0"));
                defaultProgramPath = XMLDefaultReturn(root, "SonProgramPath", "");
                defaultCMDLine = XMLDefaultReturn(root, "SonCMDLine", "");
            }

            NewFile newFile = new NewFile(viewDepth, defaultRes, defaultWidth, defaultHeight, defaultImageLayout, defaultProgramPath, defaultCMDLine);
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
            if (boxType == "file") {
                Files file = searchFileData(int.Parse(id));

                NewFile editFile = new NewFile(file);
                editFile.ReturnedObject += NewFile_ReturnedObject;
                editFile.ShowDialog();
            } else if (boxType == "collection") {
                Collections col = searchCollectionData(int.Parse(id));

                NewCollection editCollection = new NewCollection(col);
                editCollection.ReturnedObject += NewCollection_ReturnedObject;
                editCollection.ShowDialog();
            } else if (boxType == "automaticFile" || boxType == "automaticFolder") {
                Scanneds scanned = searchScanData(id);

                //Si scanned es null, significa que estamos tratando de editar un scanElement que aun no a sido editado anteriormente
                if (scanned == null)
                {
                    string[] def = { };
                    string imgPath = "";

                    if (boxType == "automaticFolder")
                    {
                        string[] subArchivos = Directory.GetFiles(id);
                        if (subArchivos.Length > 0)
                        {
                            //string rutasImagen = subArchivos.Where(ruta => checkImage(ruta));
                            imgPath = subArchivos.FirstOrDefault(ruta => checkImage(ruta));
                        }
                    }
                    

                        scanned = new Scanneds(id, pic.Name, imgPath, 0, false, 0, 0, 0, 0, pic.Width, pic.Height, 1, def);
                }

                EditScaned editScan = new EditScaned(scanned);
                editScan.ReturnedObject += EditScanned_ReturnedObject;
                editScan.ShowDialog();

            } 

        }

        //Editar los archivos de la coleccion desde el flow layout panel
        private void ToolStripEditMultipleFlowLayoutPanel_Click(object sender, EventArgs e)
        {
            string id = viewDepth.ToString();

            editMultipleElementsFromCollection(id);
        }

        //Editar los archivos de esa coleccion picture box
        private void ToolStripEditMultiplePictureBox_Click(object sender, EventArgs e)
        {
            string id;
            string boxType;
            //Recojer los datos del picture box
            try
            {
                PictureBox pic = (PictureBox)contextMenuPictureBox.SourceControl;
                id = pic.Tag.ToString();
                boxType = pic.AccessibleDescription;
                Console.WriteLine("picture Box EditMultiple");
            }
            catch (Exception)
            {
                //Si no recoje un picture box, significa que estamos recogiendo desde el flow layout panel (aunque este tenga su propia funcion, es un porsiacaso)
                id = viewDepth.ToString();
                boxType = "collection";
            }

            

            //Lo hago solo por si acaso
            if (boxType == "collection")
            {
                editMultipleElementsFromCollection(id);
            } else
            {
                MessageBox.Show("No se puede editar los archivos de algo que no es una coleccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Funcion global para editar los archivos de una coleccion (se ocupa en ToolStripEditMultipleFlowLayoutPanel_Click y ToolStripEditMultiplePictureBox_Click)
        private void editMultipleElementsFromCollection(string id)
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

                defaultRes = int.Parse(XMLDefaultReturn(root, "CoverSonResolutionID", "0"));
                defaultWidth = int.Parse(XMLDefaultReturn(root, "CoverSonWidth", "200"));
                defaultHeight = int.Parse(XMLDefaultReturn(root, "CoverSonHeight", "200"));
                defaultImageLayout = int.Parse(XMLDefaultReturn(root, "SonImageLayout", "0"));
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
        }

        //Eliminar el picture box
        private void ToolStripDeletePictureBox_Click(object sender, EventArgs e)
        {
            //Recojer los datos del picture box
            PictureBox pic = (PictureBox)contextMenuPictureBox.SourceControl;
            string id = pic.Tag.ToString();
            string boxType = pic.AccessibleDescription;

            string message;
            if (boxType == "file")
            {
                message = $"¿Estas seguro de querer eliminar el elemento {pic.Name}?";
            } else
            {
                message = $"¿Estas seguro de querer eliminar la coleccion {pic.Name}?\n(Esto tambien eliminara su contenido)";
            }

            //PictureBox pictureBox = (PictureBox)sender;
            //var result = MessageBox.Show("Estas seguro de querer eliminar "+pic.Name.ToString(),"Eliminar", MessageBoxButtons.YesNo);
            var result = MessageBox.Show(message, "Eliminar", MessageBoxButtons.YesNo);
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

        //Abrir el programa de un elemento
        private void ToolStripOpenProgramPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)contextMenuPictureBox.SourceControl;
            int idBox = int.Parse(pic.Tag.ToString());//no se puede transformar un objeto a int, pero si a un string
            string programExe = getFileProgram(idBox);

            //bool url = true;

            //file y program se deben de formatear
            string fileExe;// = "";
            string fileDir;// = "";
            //string programDir = "";
            //string cmdLine = "";//es necesario establecerlo como "", por default es null, pero si alguien escribe algo y lo borra quedara como "" y complicara las validaciones

            //Crear el process start
            Process process = new Process();

            //Formatear la ruta del archivo
            try
            {
                fileExe = Path.GetFullPath(programExe);
                fileDir = Path.GetDirectoryName(programExe);
            }
            catch
            {
                MessageBox.Show("No se pudo encontrar el programa del elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Intentar ejecutar los archivos/URL
            try
            {
                Console.WriteLine("Abriendo el programa");
                Console.WriteLine(fileExe);

                ProcessStartInfo startInfo = new ProcessStartInfo(fileExe);//Ruta del archivo o URL

                
                //Establecer el directorio de trabajo del archivo a ejecutar
                startInfo.WorkingDirectory = fileDir;//Es necesario para que se tome cual es el directorio donde se ejecuta el archivo y pueda tomar los archivos de esa zona
                
                process.StartInfo = startInfo;
                process.Start();

            }
            //En caso de errores
            catch (Exception)
            {
                MessageBox.Show("Error abrir el programa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Error con archivos/programas/cmdLin
            }

        }

        //Mostrar el elemento en el explorador de archivos
        private void ToolStripOpenInExplorerElementPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)contextMenuPictureBox.SourceControl;
            string fileDir;
            string boxType = pic.AccessibleDescription;

            if (boxType != "automaticFile" && boxType != "automaticFolder")
            {
                int idBox = int.Parse(pic.Tag.ToString());//no se puede transformar un objeto a int, pero si a un string
                fileDir = getFileDir(idBox);
            } else
            {
                fileDir = pic.Tag.ToString();
            }
            

            //Crear el process start
            //Process process = new Process();

            if (File.Exists(fileDir) || Directory.Exists(fileDir))
            {
                Process.Start("explorer.exe", $"/select,\"{fileDir}\"");
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la ubicacion, verifica que el elemento exista en su equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //---------------------
        //PictureBox automaticas
        //---------------------
        private void ToolStripOpenInExplorerContentAutomaticPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)contextMenuPictureBox.SourceControl;
            string fileDir = pic.Tag.ToString();

            //Crear el process start
            if (Directory.Exists(fileDir))
            {
                Process.Start("explorer.exe", $"/root,\"{fileDir}\"");
            }
            else
            {
                MessageBox.Show("No se pudo encontrar el directorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region navbar ToolStrip
        #region Administrar las resoluciones
        private void administrarResolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resolution res = new Resolution();
            res.ReturnedObject += Resolution_ReturnedObject;
            res.ShowDialog();
        }

        private void administrarEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoverPadLauncher.Tags tag = new CoverPadLauncher.Tags();
            tag.ReturnedObject += Tag_ReturnedObject;
            tag.ShowDialog();
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
        #endregion

        #region Ordenar paneles
        //Ordenarlos por ID (orderPanels 0)
        private void fechaDeCreacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!fechaDeCreacionToolStripMenuItem.Checked)
            {
                fechaDeCreacionToolStripMenuItem.Checked = true;
                nombreToolStripMenuItem.Checked = false;
                //orderPanels = 0;
                settings.PanelOrder = 0;
                loadPictureBox(colSize, fileSize, false);
            }
        }

        //ordenarlos por nombre (orderPanels 1)
        private void nombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!nombreToolStripMenuItem.Checked) {
                nombreToolStripMenuItem.Checked = true;
                fechaDeCreacionToolStripMenuItem.Checked = false;
                settings.PanelOrder = 1;
                //orderPanels = 1;
                loadPictureBox(colSize, fileSize, false);
            }
            
        }
        #endregion

        #region filtro de busqueda
        private void searchFromActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //searchType = 0;
            settings.SearchFilter = 0;
            searchFromActualToolStripMenuItem.Checked = true;
            searchActualtoolStripMenuItem.Checked = false;
            searchAlltoolStripMenuItem.Checked = false;
        }

        private void searchActualtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //searchType = 1;
            settings.SearchFilter = 1;
            searchFromActualToolStripMenuItem.Checked = false;
            searchActualtoolStripMenuItem.Checked = true;
            searchAlltoolStripMenuItem.Checked = false;
        }

        private void searchAlltoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //searchType = 2;
            settings.SearchFilter = 2;
            searchFromActualToolStripMenuItem.Checked = false;
            searchActualtoolStripMenuItem.Checked = false;
            searchAlltoolStripMenuItem.Checked = true;
        }
        #endregion
        #endregion

        #region Renderer
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }

            Color defaultBG = Color.FromArgb(36, 40, 47);
            Color selectedBG = Color.FromArgb(23, 29, 37);

            //Establecer color del fondo
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                Color c = e.Item.Selected ? defaultBG : selectedBG;
                using (SolidBrush brush = new SolidBrush(c)) e.Graphics.FillRectangle(brush, rc);
            }

            //Evitar que dibuje los bordes
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }

            //Cambiar el color del texto
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = Color.White; // Establecer el nuevo color de texto
                base.OnRenderItemText(e);
            }
        }

        private class MyColors : ProfessionalColorTable
        {
            //Cambiar el fondo de los bordes
            public override Color ToolStripDropDownBackground
            {
                get
                {
                    return Color.FromArgb(23, 29, 37);
                }
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

        private void EditScanned_ReturnedObject(object sender, Scanneds e)
        {
            SaveXMLScanned(e);
            loadView(colSize, fileSize);
        }

        private void Resolution_ReturnedObject(object sender, bool e)
        {
            if (e == true)
            {
                loadView(colSize, fileSize);
            }
        }

        private void Tag_ReturnedObject(object sender, bool e)
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

        //Mostrar graficos de un picture box (nombre/iconos)
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string picName = pictureBox.Name;
            string boxType = pictureBox.AccessibleDescription;

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

            //Dibujar un rectangulo blanco encima de un picture box
            Pen borderPen = new Pen(Color.White);
            borderPen.Width = 2;
            g.DrawRectangle(borderPen, borderPen.Width - 1, borderPen.Width - 1, pictureBox.Width - (borderPen.Width), pictureBox.Height - (borderPen.Width));


            FontBrush.Dispose();
            RectBrush.Dispose();//Dejar de ocupar pincel

            //Dibujar un icono para indicar que algo es una coleccion
            if (boxType == "collection") {
                Bitmap bpm = new Bitmap(imgResourceIcons[0]);
                g.DrawImage(bpm, 5, 5);
                bpm.Dispose();
            } else if (boxType == "automaticFile") {
                Bitmap bpm = new Bitmap(imgResourceIcons[1]);
                g.DrawImage(bpm, 5, 5);
                bpm.Dispose();
            } else if (boxType == "automaticFolder") {
                Bitmap bpm = new Bitmap(imgResourceIcons[2]);
                g.DrawImage(bpm, 5, 5);
                bpm.Dispose();
            }

            g.Dispose();//Dejar de ocupar graphics
        }

        //Dejar de mostrar graficos de un picture box
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
                int idBox = -1;
                try
                {
                    idBox = int.Parse(pictureBox.Tag.ToString());//no se puede transformar un objeto a int, pero si a un string
                }
                catch (Exception)
                {
                    Console.WriteLine($"No se pudo transformar el tag {pictureBox.Tag} a int");
                }
                
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
                else if (boxType == "automaticFile")
                {
                    //Ejecutar el archivo automatico
                    startProcess(pictureBox.Tag.ToString(), "", "", false);
                }
                else if (boxType == "automaticFolder")
                {
                    string rutaEscaneo = pictureBox.Tag.ToString();

                    if (Directory.Exists(rutaEscaneo))
                    {
                        // Obtiene una lista de todos los archivos en la carpeta
                        string[] archivos = Directory.GetFiles(rutaEscaneo);
                        string[] subDir = Directory.GetDirectories(rutaEscaneo);
                        int scanStart = getColeScanStartNumber(viewDepth);

                        //Buscar dentro de esa coleccion un archivo e intentar abrirlo (si scanStart != 0)
                        if (archivos.Length > 0 && subDir.Length == 0 && scanStart != 0)
                        {
                            //Filtrar los archivos por una extension especifica
                            //archivos.Where(x => x.EndsWith(".html") || x.EndsWith(".lnk") || x.EndsWith(".url")).ToArray();
                            string[] extensions = getColeScanExtension(viewDepth);
                            //string[] filter = archivos.Where(x => x.EndsWith(".html")).ToArray();

                            string[] filter = archivos.Where(archivo =>
                                    extensions.Any(extension => archivo.EndsWith("." + extension))
                                ).ToArray();

                            if (filter.Length > 0)
                            {
                                //establecer el array de los filtros como el array para los archivos disponibles
                                archivos = filter;
                            }

                            //Ordenar el array de la misma manera que lo hace el explorador de windows
                            Array.Sort(archivos, new WindowsComparator());


                            //Invertir el orden del array para empezar a buscar desde atras
                            if (scanStart < 0)
                            {
                                Array.Reverse(archivos);
                                scanStart *= -1;//Volver al scanStart positivo
                            }

                            //Hacer que si el numero para empezar es mas largo que el array, adaptarlo
                            if (scanStart > archivos.Length) scanStart = archivos.Length;

                            scanStart -= 1; //le resta uno a scanStart por que sino abrira el segundo archivo que encuentre, no el primero

                            startProcess(archivos[scanStart], "", "", false);
                        } else
                        {
                            //viewDepth = -2;
                            scanDepth.Add(rutaEscaneo);
                            loadPictureBox(colSize, fileSize, false);
                        }
                    }
                }
            }
                
        }

        //Intervenir en el contextMenu para crearlos
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox pictureBox = (PictureBox)sender;
                int idBox = -1;

                try
                {
                    idBox = int.Parse(pictureBox.Tag.ToString());//no se puede transformar un objeto a int, pero si a un string
                }
                catch (Exception)
                {
                    Console.WriteLine($"No se pudo transformar el tag {pictureBox.Tag} a int");
                }

                string boxType = pictureBox.AccessibleDescription;//Recoje el tipo de picture box para buscar en el array especifico (col/file)
                bool fav = false;

                //Picture Box
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();//pictureBox.ContextMenuStrip;

                //MenuStrip Globales (normales y escaneados)
                ToolStripMenuItem ToolStripEdit = new ToolStripMenuItem();
                ToolStripEdit.Text = "Editar";
                ToolStripEdit.Image = Image.FromFile(imgResourceIcons[5]);
                ToolStripEdit.Click += new EventHandler(ToolStripEditPictureBox_Click);

                //Menu Strip "global" (no sirve para los picture box escaneados de un directorio)
                if (boxType != "automaticFile" && boxType != "automaticFolder")
                {
                    ToolStripMenuItem ToolStripDelete = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripFav = new ToolStripMenuItem();
                    
                    ToolStripDelete.Text = "Eliminar";
                    ToolStripDelete.Image = Image.FromFile(imgResourceIcons[3]);
                    ToolStripDelete.Click += new EventHandler(ToolStripDeletePictureBox_Click);
                    ToolStripFav.Text = "Agregar a Favoritos";
                    ToolStripFav.Image = Image.FromFile(imgResourceIcons[7]);
                    ToolStripFav.Click += new EventHandler(ToolStripFavSetPictureBox_Click);

                    //Crear un contextMenu local para modificarlo a gusto
                    
                    contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripFav, ToolStripEdit, ToolStripDelete });
                } else
                {
                    ToolStripMenuItem ToolStripAutomaticOpen = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripAutomaticOpenContent = new ToolStripMenuItem();
                    ToolStripAutomaticOpen.Text = "Mostrar ubicacion";
                    ToolStripAutomaticOpen.Image = Image.FromFile(imgResourceIcons[8]);
                    ToolStripAutomaticOpen.Click += new EventHandler(ToolStripOpenInExplorerElementPictureBox_Click);
                    ToolStripAutomaticOpenContent.Text = "Mostrar ubicacion del contenido";
                    ToolStripAutomaticOpenContent.Image = Image.FromFile(imgResourceIcons[8]);
                    ToolStripAutomaticOpenContent.Click += new EventHandler(ToolStripOpenInExplorerContentAutomaticPictureBox_Click);

                    contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripEdit, ToolStripAutomaticOpen, ToolStripAutomaticOpenContent });
                }
                

                if (boxType == "file")
                {
                    bool url = false;
                    string program = "";

                    //Dentro de la funcion se buscara los procesos asociados al archivo y llamara a start process
                    fav = getFileFav(idBox);
                    program = getFileProgram(idBox);
                    url = getFileURL(idBox);

                    //Mostrar elemento en el explorador de archivos (solo si no son URL)
                    if (url == false) {
                        ToolStripMenuItem ToolStripOpenInExplorer = new ToolStripMenuItem();
                        ToolStripOpenInExplorer.Text = "Mostrar ubicacion";
                        ToolStripOpenInExplorer.Image = Image.FromFile(imgResourceIcons[8]);
                        ToolStripOpenInExplorer.Click += new EventHandler(ToolStripOpenInExplorerElementPictureBox_Click);
                        contextMenuStrip.Items.Add(ToolStripOpenInExplorer);
                    }

                    //Abrir el programa con el que se abre el archivo (si lo tiene)
                    if (program != "")
                    {
                        string programName = Path.GetFileNameWithoutExtension(program);

                        ToolStripMenuItem ToolStripOpenProgram = new ToolStripMenuItem();
                        ToolStripOpenProgram.Text = $"Abrir {programName}";
                        ToolStripOpenProgram.Image = Image.FromFile(imgResourceIcons[9]);
                        ToolStripOpenProgram.Click += new EventHandler(ToolStripOpenProgramPictureBox_Click);

                        contextMenuStrip.Items.Add(ToolStripOpenProgram);
                    }

                }
                else if (boxType == "collection")
                {
                    ToolStripMenuItem ToolStripEditAll = new ToolStripMenuItem();
                    ToolStripEditAll.Text = "Editar todos los elementos de la coleccion";
                    ToolStripEditAll.Image = Image.FromFile(imgResourceIcons[5]);
                    ToolStripEditAll.Click += new EventHandler(ToolStripEditMultiplePictureBox_Click);

                    fav = getColeFav(idBox);
                    contextMenuStrip.Items.Add(ToolStripEditAll);
                }

                //Agregar a favoritos no sirve para archivos o directorios escaneados
                if (boxType != "automaticFile" && boxType != "automaticFolder")
                {
                    // Accede al ToolStripMenuItem dentro del ContextMenuStrip
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)contextMenuStrip.Items[0];//depende del orden establecido en la linea 75

                    // Cambia el atributo "Text" del ToolStripMenuItem según el valor del "Tag" del PictureBox
                    if (fav == false)
                    {
                        toolStripMenuItem.Text = "Agregar a favoritos";
                        toolStripMenuItem.Image = Image.FromFile(imgResourceIcons[7]);
                    }
                    else if (fav == true)
                    {
                        toolStripMenuItem.Text = "Quitar de favoritos";
                        toolStripMenuItem.Image = Image.FromFile(imgResourceIcons[6]);
                    }
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
                textBoxSearch.ForeColor = System.Drawing.Color.White;
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
                if (textBoxSearch.Text != "")
                {
                    loadPictureBox(colSize, fileSize, true);
                } else
                {
                    loadPictureBox(colSize, fileSize, false);
                }
                
            }
            
        }
        #endregion

        //Dibujar el rectangulo negro y el nombre del pictureBox
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            bool test = true;

            if (test)
            {
                PictureBox pictureBox = (PictureBox)sender;

                string picName = pictureBox.Name;
                //Graphics g = pictureBox.CreateGraphics();//Crear graphics

                // Dibujar un rectángulo negro en el PictureBox
                Color Bcolor = Color.FromArgb(180, Color.Black);
                SolidBrush RectBrush = new SolidBrush(Bcolor);
                e.Graphics.FillRectangle(RectBrush, 0, pictureBox.Height - (pictureBox.Height / 3), pictureBox.Width, pictureBox.Height);

                //Dibujar el texto
                Font font = new Font("Arial", 8);
                SolidBrush FontBrush = new SolidBrush(Color.White);
                StringFormat drawFormat = new StringFormat();
                RectangleF fontRect = new RectangleF(0, pictureBox.Height - (pictureBox.Height / 3), pictureBox.Width, pictureBox.Height / 3);
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                drawFormat.FormatFlags = StringFormatFlags.LineLimit;
                drawFormat.Trimming = StringTrimming.EllipsisCharacter;
                e.Graphics.DrawString(picName, font, FontBrush, fontRect, drawFormat);

                FontBrush.Dispose();
                RectBrush.Dispose();//Dejar de ocupar pincel
            }
        }
        
        //Para reducir el tamaño de las imagenes del picture box
        private Image loadImage(string imagePath)
        {
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
            } else
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

        private void destroyPictureBox()
        {
            //remueve todos los paneles del control
            for (int i=0; i< picBoxArr.Length; i++)
            {
                if (picBoxArr[i].BackgroundImage != null) picBoxArr[i].BackgroundImage.Dispose();//Dejar de utilizar la imagen de fondo en memoria
                flowLayoutPanelMain.Controls.Remove(picBoxArr[i]);
            }
        }

        private void loadView(int colSize, int fileSize)
        {
            loadPictureBox(colSize, fileSize, false);
            loadTreeView(colSize);
        }

        private void loadDepthName(int Father, Collections[] colls)
        {
            for (int i = 0; i < colls.Length; i++)
            {
                if (colls[i].ID == Father)
                {
                    labelDepth.Text = colls[i].Name+"/"+labelDepth.Text;

                    if (colls[i].IDFather != 0)
                    {
                        loadDepthName(colls[i].IDFather, colls);
                    }
                    break;
                }
            }
        }

        private bool returnCollectionID (Collections[] colls, int searchID) //Collections[] colls, int searchID
        {
            Collections Coll = colls.FirstOrDefault(o => o.ID == searchID);

            if (Coll != null)
            {
                if (Coll.IDFather == viewDepth)
                {
                    return true;
                }
                else if (Coll.IDFather != 0)
                {
                    return returnCollectionID(colls, Coll.IDFather);
                }
            }

            return false;
        }

        private bool returnFileID(Collections[] colls, Files[] files, int searchID)
        {
            Files file = files.FirstOrDefault(o => o.ID == searchID);

            if (file != null)
            {
                if (file.IDFather == viewDepth)
                {
                    return true;
                }
                else if (file.IDFather != 0)
                {
                    //Si el archivo no estaba dentro del viewDepth, hay que empezar a buscar dentro de las colecciones para verificar que el archivo este dentro de alguna coleccion con el viewDepth
                    return returnCollectionID(colls, file.IDFather);
                }
            }

            return false;
        }

        //Cargar todos los picture box de esa profundidad
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

            //Scanneds[] scanneds = new Scanneds[scanSize];
            //scanneds = LoadScanneds(scanSize);

            //Hacer el array tan largo como las colecciones y archivos existentes (despues se optimiza)
            Array.Resize(ref picBoxArr, colSize + fileSize);

            //Cargar las etiquetas (ID.toString(), nombre)

            int pL = 0;//largo de los pictureBox de esa profundidad

            int actualColl = 0;

            #region Cargar elementos de filtro/etiquetas
            string search = "";
            int[] tagsSearchID = { }; 
            

            if (filter)
            {
                search = textBoxSearch.Text.ToLower();

                //Cargar las etiquetas coincidentes
                XDocument xdoc = XDocument.Load(xmlTagPath);

                //Buscar dentro del fichero xml la coleccion actual
                var matchingElements = xdoc.Descendants("tag")
                    .Where(tag => tag.Element("Name")?.Value.Contains(search) == true)
                    .Select(tag => (int)tag.Attribute("id"));

                tagsSearchID = matchingElements.ToArray();
            }

            #endregion

            #region Texto "ruta" en la barra superior y cargar actualColl
            //Cambiar el texto de la "ruta"
            if (viewDepth == -1)
            {
                labelDepth.Text = "Favoritos";
            }
            else if (viewDepth == 0)
            {
                labelDepth.Text = "Inicio";
            }
            else
            {
                for(int i=0; i< colls.Length; i++)
                {
                    if (colls[i].ID == viewDepth)
                    {
                        labelDepth.Text = colls[i].Name;
                        actualColl = i;
                        Console.WriteLine($"actualColl {actualColl} | viewdepth {viewDepth}");

                        if (colls[i].IDFather != 0)
                        {
                            loadDepthName(colls[i].IDFather, colls);
                        }
                        break;
                    }
                    
                }
                
            }

            //Añadir rutas de escaneo
            if (scanDepth.Count > 0)
            {
                //foreach(string name in scanDepth)
                //{
                string name = scanDepth.Last();
                int pos = name.LastIndexOf("\\") + 1;
                labelDepth.Text = labelDepth.Text + "/" + name.Substring(pos, name.Length - pos);
                //}
            }

            //Ajustar el texto en el centro
            int centerX = (this.ClientSize.Width - labelDepth.Width) / 2;
            labelDepth.Location = new Point(centerX, labelDepth.Location.Y);
            //140+180
            #endregion

            #region Cargar etiquetas escaneables de la profundidad
            int[] tagsScan = { };
            if (viewDepth >0 && colls[actualColl].ScanTags != null)
            {
                tagsScan = colls[actualColl].ScanTags;
            }
            #endregion

            #region Cargar Elementos escaneables
            if (colls.Length>0 && (scanDepth.Count > 0 || (colls[actualColl].ScanFolder == true && colls[actualColl].ScanPath != "")))
            {
                string rutaEscaneo;

                if (scanDepth.Count > 0)
                {
                    rutaEscaneo = scanDepth.Last();//automaticPath;
                } else
                {
                    rutaEscaneo = colls[actualColl].ScanPath;
                }

                //La ruta de escaneo
                if (Directory.Exists(rutaEscaneo))
                {
                    // Obtiene una lista de todos los archivos y sub carpetas en la carpeta
                    string[] archivos = Directory.GetFiles(rutaEscaneo);
                    string[] subcarpetas = Directory.GetDirectories(rutaEscaneo);
                    Array.Resize(ref picBoxArr, colSize + fileSize + archivos.Length + subcarpetas.Length);

                    //Analizar los archivos
                    foreach (string archivo in archivos)
                    {
                        string name = Path.GetFileNameWithoutExtension(archivo);
                        string imgDir = "";
                        int layout = -1;//-1 para identificar si fue cargado desde un xml o no
                        int r = 0;
                        int g = 0;
                        int b = 0;
                        int res = 0;
                        int w = colls[actualColl].SonWidth;
                        int h = colls[actualColl].SonHeight;

                        #region Cargar desde un XML
                        XDocument doc = XDocument.Load(xmlScannedPath);

                        var matchingScans = doc.Descendants("scanned")
                                  .Where(item => item.Attribute("dir")?.Value == archivo)
                                  .Select(item => new
                                  {
                                      //Valores a rescatar
                                      Name = item.Element("Name").Value,
                                      ImageDir = item.Element("Image").Value,
                                      ImageLayout = item.Element("ImageLayout").Value,
                                      BoolBackground = item.Element("WithoutBackground").Value,
                                      CRed = item.Element("BackgroundRed").Value,
                                      CGreen = item.Element("BackgroundGreen").Value,
                                      CBlue = item.Element("BackgroundBlue").Value,
                                      ResID = item.Element("CoverResolutionID").Value,
                                      Width = item.Element("CoverWidth").Value,
                                      Height = item.Element("CoverHeight").Value,
                                  });
                        //Solo se debe recuperar 1
                        var match = matchingScans.FirstOrDefault();

                        if (match != null)
                        {
                            name = match.Name;
                            imgDir = match.ImageDir;
                            layout = int.Parse(match.ImageLayout);
                            r = int.Parse(match.CRed);
                            g = int.Parse(match.CGreen);
                            b = int.Parse(match.CBlue);
                            res = int.Parse(match.ResID);
                            w = int.Parse(match.Width);
                            h = int.Parse(match.Height);
                        }
                        #endregion

                        Console.WriteLine(archivo);

                        picBoxArr[pL] = new PictureBox
                        {
                            AccessibleDescription = "automaticFile",//Aqui se indica que tipo de picture box es (coleccion / archivo)
                            Name = name,//Aqui se guarda el nombre del elemento
                            Size = new Size(w, h),
                            BackColor = Color.FromArgb(r, g, b),
                            Tag = archivo,//Aqui se guarda en que espacio del array estamos buscando//colls[i].ID,
                        };

                        #region Caratula
                        #region Cargar la imagen
                        //Cargar la caratula del archivo si es posible y si no se encontro una ruta en el xml (dando var match = null)
                        if (match == null)
                        {
                            //Rescatar la imagen del archivo (si es posible)
                            string extension = Path.GetExtension(archivo);

                            //dependiendo del tipo de archivo, el proceso para extraer una imagen preview es totalmente diferente
                            if (extension == ".mp4" || extension == ".mkv" || extension == ".flv" || extension == ".avi" || extension == ".mov" || extension == ".wmv")//En teoria, esos son los tipos de archivos compatibles
                            {
                                //recojer la miniatura del video con MediaToolKit
                                var inputFile = new MediaFile { Filename = archivo };//ruta del archivo
                                var outputFile = new MediaFile { Filename = $"{archivo}.thumbnail.jpg" };//guardado temporal de la caratula en el disco duro (la libreria no permite guardar la imagen en un objeto, tiene que guardarse en el disco duro al parecer

                                using (var engine = new Engine())
                                {
                                    engine.GetMetadata(inputFile);


                                    var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(inputFile.Metadata.Duration.TotalSeconds / 4) };//Seek = TimeSpan.FromSeconds(15) 
                                    engine.GetThumbnail(inputFile, outputFile, options);
                                }
                                Image thumbnail;
                                //utilizar un bitmap para no mantener abierto el archivo y poder eliminarlo
                                using (var tempImage = Image.FromFile(outputFile.Filename))
                                {
                                    thumbnail = new Bitmap(tempImage);
                                }
                                File.Delete(outputFile.Filename);//eliminar el archivo

                                //Cargar la imagen a la caratula
                                picBoxArr[pL].BackgroundImage = thumbnail;
                                thumbnail = null;//porsiacaso para evitar fugas de memoria (aunque no deberia pasar si el recolector de basura cumple su funcion)
                            }
                        }


                        if (imgDir != "")
                        {
                            try
                            {
                                Image image;
                                image = loadImage(imgDir);
                                picBoxArr[pL].BackgroundImage = image;
                                image = null;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine($"No se pudo establecer una imagen al archivo automatico {archivo}");
                            }
                        }
                        #endregion

                        #region Formato de la imagen
                        try
                        {

                            if (layout != -1)
                            {
                                if (layout == 0)
                                {
                                    picBoxArr[pL].BackgroundImageLayout = ImageLayout.Zoom;
                                }
                                else
                                {
                                    picBoxArr[pL].BackgroundImageLayout = ImageLayout.Stretch;
                                }
                            }
                            else
                            {
                                if (colls[actualColl].ImageLayout == 0)
                                {
                                    picBoxArr[pL].BackgroundImageLayout = ImageLayout.Zoom;
                                }
                                else
                                {
                                    picBoxArr[pL].BackgroundImageLayout = ImageLayout.Stretch;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            picBoxArr[pL].BackgroundImageLayout = ImageLayout.Zoom;
                        }
                        #endregion
                        #endregion

                        picBoxArr[pL].MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
                        picBoxArr[pL].MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
                        picBoxArr[pL].MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Click);
                        picBoxArr[pL].MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
                        picBoxArr[pL].Paint += new PaintEventHandler(this.pictureBox_Paint);
                        pL++;//iterar en el array de paneles
                    }

                    //Analizar las carpetas
                    foreach (string subcarpeta in subcarpetas)
                    {
                        string name = Path.GetFileName(subcarpeta);
                        string imgDir = "";
                        int layout = -1;//-1 para identificar si fue cargado desde un xml o no
                        int r = 0;
                        int g = 0;
                        int b = 0;
                        int res = 0;
                        int w = colls[actualColl].SonWidth;
                        int h = colls[actualColl].SonHeight;
                        int startN = 0;
                        string[] extensions = { };

                        #region Cargar desde un XML
                        XDocument doc = XDocument.Load(xmlScannedPath); 
                        
                        var matchingScans = doc.Descendants("scanned")
                                  .Where(item => item.Attribute("dir")?.Value == subcarpeta)
                                  .Select(item => new
                                  {
                                      //Valores a rescatar
                                      Name = item.Element("Name").Value,
                                      ImageDir = item.Element("Image").Value,
                                      ImageLayout = item.Element("ImageLayout").Value,
                                      BoolBackground = item.Element("WithoutBackground").Value,
                                      CRed = item.Element("BackgroundRed").Value,
                                      CGreen = item.Element("BackgroundGreen").Value,
                                      CBlue = item.Element("BackgroundBlue").Value,
                                      ResID = item.Element("CoverResolutionID").Value,
                                      Width = item.Element("CoverWidth").Value,
                                      Height = item.Element("CoverHeight").Value,
                                      StartNumber = item.Element("StartNumber").Value,
                                      OpenExtensions = item.Element("OpenExtension").Elements().Select(x => x.Value).ToArray(),
                                  });
                        //Solo se debe recuperar 1
                        var match = matchingScans.FirstOrDefault();

                        if (match != null)
                        {
                            name = match.Name;
                            imgDir = match.ImageDir;
                            layout = int.Parse(match.ImageLayout);
                            r = int.Parse(match.CRed);
                            g = int.Parse(match.CGreen);
                            b = int.Parse(match.CBlue);
                            res = int.Parse(match.ResID);
                            w = int.Parse(match.Width);
                            h = int.Parse(match.Height);
                            startN = int.Parse(match.StartNumber);
                            extensions = match.OpenExtensions;
                        }
                        #endregion

                        picBoxArr[pL] = new PictureBox
                        {
                            AccessibleDescription = "automaticFolder",//Aqui se indica que tipo de picture box es (coleccion / archivo)
                            Name = name,//Aqui se guarda el nombre de la coleccion
                            Size = new Size(w, h),
                            BackColor = Color.FromArgb(r, g, b),
                            Tag = subcarpeta,//Aqui se guarda en que espacio del array estamos buscando//colls[i].ID,
                        };

                        #region Caratula
                        #region Cargar la imagen
                        if (imgDir != "")
                        {
                            try
                            {
                                Image image;
                                image = loadImage(imgDir);
                                picBoxArr[pL].BackgroundImage = image;
                                image = null;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine($"No se pudo establecer una imagen a la carpeta automatica {subcarpeta}");
                            }
                        }
                        else
                        {
                            //Intentar buscar dentro de la carpeta si tiene algun archivo de imagen para establecerlo como background IMAGE
                            string[] subArchivos = Directory.GetFiles(subcarpeta);
                            if (subArchivos.Length > 0)
                            {
                                string[] rutasImagenes = subArchivos.Where(ruta => checkImage(ruta)).ToArray();

                                if (rutasImagenes.Length <= 0) Console.WriteLine($"La carpeta {subcarpeta} no encontro imagenes");
                                try
                                {
                                    Image image;
                                    image = loadImage(rutasImagenes[0]);
                                    picBoxArr[pL].BackgroundImage = image;
                                    image = null;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine($"No se pudo establecer una imagen a la carpeta automatica {subcarpeta}");
                                }
                            }
                        }
                        #endregion

                        #region Formato de la imagen
                        try
                        {

                            if (layout != -1)
                            {
                                if (layout == 0)
                                {
                                    picBoxArr[pL].BackgroundImageLayout = ImageLayout.Zoom;
                                }
                                else
                                {
                                    picBoxArr[pL].BackgroundImageLayout = ImageLayout.Stretch;
                                }
                            }
                            else
                            {
                                if (colls[actualColl].ImageLayout == 0)
                                {
                                    picBoxArr[pL].BackgroundImageLayout = ImageLayout.Zoom;
                                }
                                else
                                {
                                    picBoxArr[pL].BackgroundImageLayout = ImageLayout.Stretch;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            picBoxArr[pL].BackgroundImageLayout = ImageLayout.Zoom;
                        }
                        #endregion
                        #endregion

                        picBoxArr[pL].MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
                        picBoxArr[pL].MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
                        picBoxArr[pL].MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Click);
                        picBoxArr[pL].MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
                        picBoxArr[pL].Paint += new PaintEventHandler(this.pictureBox_Paint);

                        picBoxArr[pL].ContextMenuStrip = contextMenuPictureBox;

                        pL++;//iterar en el array de paneles
                    }
                }
            }
            #endregion

            #region Cargar Colecciones
            //Recorrer todo el array de las colecciones
            for (int i = 0; i < colls.Length; i++)
            {
                bool addCollection = false;//Me permite añadir varias condicionales dentro de un mismo if

                if (filter)
                {
                    //Verifica si el nombre de la coleccion contiene alguno de los elementos del textbox
                    string nom = colls[i].Name.ToLower();

                    switch (settings.SearchFilter)//searchType
                    {
                        case 1:// buscara solo en esa coleccion (no sub colecciones)
                            if ( 
                                (nom.Contains(search) || colls[i].TagsID.Intersect(tagsSearchID).Any()) 
                                && (viewDepth == colls[i].IDFather //Busqueda coincidiendo la profundidad y el nombre/etiqueta
                                || colls[i].TagsID.Intersect(tagsScan).Any()
                                || (viewDepth == -1 && colls[i].Favorite == true))//Busqueda coincidiendo con favoritos
                               ) addCollection = true;
                            break;
                        case 2://buscara en todo el xml
                            if (nom.Contains(search) || colls[i].TagsID.Intersect(tagsSearchID).Any()) addCollection = true;
                            break;
                        default://Buscara desde esa coleccion para adentro
                            if (
                                (nom.Contains(search) || colls[i].TagsID.Intersect(tagsSearchID).Any())
                                && (colls[i].TagsID.Intersect(tagsScan).Any() || returnCollectionID(colls, colls[i].ID) || (viewDepth == -1 && colls[i].Favorite == true))
                               ) addCollection = true;
                            break;
                    }
                    

                } else {
                    if (
                        viewDepth == colls[i].IDFather 
                        || colls[i].TagsID.Intersect(tagsScan).Any() 
                        || (viewDepth == -1 && colls[i].Favorite == true)
                       ) addCollection = true;
                }

                //Solo agregar las colecciones que coincidan con la profundidad actual o que sea la profundidad de favoritos (-1) y tengan el bool
                if (addCollection)
                {
                    //Image imagen = Image.FromFile(colls[i].ImagePath);
                    //Definir el picture box
                    int red = 255;
                    int green = 255;
                    int blue = 255;

                    if (colls[i].Background == true)
                    {
                        red = flowLayoutPanelMain.BackColor.R;
                        green = flowLayoutPanelMain.BackColor.G;
                        blue = flowLayoutPanelMain.BackColor.B;
                    } else
                    {
                        red = colls[i].ColorRed;
                        green = colls[i].ColorGreen;
                        blue = colls[i].ColorBlue;
                    }


                    picBoxArr[pL] = new PictureBox
                    {
                        AccessibleDescription = "collection",//Aqui se indica que tipo de picture box es (coleccion / archivo)
                        Name = colls[i].Name,//Aqui se guarda el nombre de la coleccion
                        Size = new Size(colls[i].Width, colls[i].Height),
                        BackColor = Color.FromArgb(red, green, blue),
                        Tag = colls[i].ID,//Aqui se guarda en que espacio del array estamos buscando//colls[i].ID,
                    };

                    //Establecer formato de imagen (como tiene validaciones, no puedo meterlo en el paquete de arriba)
                    if (colls[i].ImagePath != "")
                    {
                        try
                        {
                            Image image;
                            image = loadImage(colls[i].ImagePath);
                            /*using (Stream stream = File.OpenRead(colls[i].ImagePath))
                            {
                                image = System.Drawing.Image.FromStream(stream);
                            }*/
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
                      
                        //Console.WriteLine("No se pudo cargar la imagen de la id"+i+"por que no habia string en: " + colls[i].ImagePath);
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
                    picBoxArr[pL].Paint += new PaintEventHandler(this.pictureBox_Paint);

                    picBoxArr[pL].ContextMenuStrip = contextMenuPictureBox;

                    //Se integraran despues de ordenarlos
                    //flowLayoutPanelMain.Controls.Add(picBoxArr[pL]);

                    pL++;//iterar en el array de paneles
                }
            }

            #endregion

            #region Cargar Elementos
            //Recorrer todo el array de los files
            for (int f = 0; f < files.Length; f++)
            {
                bool addFile = false;//Me permite añadir varias condicionales dentro de un mismo if

                if (filter)
                {
                    //Verifica si el nombre de la coleccion contiene alguno de los elementos del textbox
                    string nom = files[f].Name.ToLower();

                    switch (settings.SearchFilter)//searchType
                    {
                        case 1:// buscara solo en esa coleccion (no sub colecciones)
                            if ((nom.Contains(search) || files[f].TagsID.Intersect(tagsSearchID).Any()) 
                                && (viewDepth == files[f].IDFather
                                || files[f].TagsID.Intersect(tagsScan).Any()
                                || (viewDepth == -1 && files[f].Favorite == true))
                               ) addFile = true;
                            break;
                        case 2://buscara en todo el xml
                            if (nom.Contains(search) || files[f].TagsID.Intersect(tagsSearchID).Any()) addFile = true;
                            break;
                        default://Buscara desde esa coleccion para adentro
                            if (
                                (nom.Contains(search) || files[f].TagsID.Intersect(tagsSearchID).Any())
                                 && (files[f].TagsID.Intersect(tagsScan).Any() || returnFileID(colls, files, files[f].ID) || (viewDepth == -1 && files[f].Favorite == true))
                               ) addFile = true;
                            break;
                    }

                }
                else
                {
                    if (
                         (viewDepth == files[f].IDFather)
                         || files[f].TagsID.Intersect(tagsScan).Any()
                         || (viewDepth == -1 && files[f].Favorite == true)
                       ) addFile = true;
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

                            fileW = int.Parse(XMLDefaultReturn(root, "Width", "200"));
                            fileH = int.Parse(XMLDefaultReturn(root, "Height", "200"));
                        } catch (Exception ex)
                        {
                            Console.WriteLine("\n///////\nNo se pudo cargar la resolucion del archivo xml\nerror\n"+ex);
                        }
                        
                    }

                    //Definir el picture box
                    int red = 255;
                    int green = 255;
                    int blue = 255;

                    if (files[f].Background == true)
                    {
                        red = flowLayoutPanelMain.BackColor.R;
                        green = flowLayoutPanelMain.BackColor.G;
                        blue = flowLayoutPanelMain.BackColor.B;
                    }
                    else
                    {
                        red = files[f].ColorRed;
                        green = files[f].ColorGreen;
                        blue = files[f].ColorBlue;
                    }
                    picBoxArr[pL] = new PictureBox
                    {
                        AccessibleDescription = "file",//Aqui se indica que tipo de picture box es (coleccion / elemento(archivo))//,
                        Name = files[f].Name,
                        Size = new Size(fileW, fileH),
                        BackColor = Color.FromArgb(red, green, blue),
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
                            image = loadImage(files[f].ImagePath);
                            /*using (Stream stream = File.OpenRead(files[f].ImagePath))
                            {
                                image = System.Drawing.Image.FromStream(stream);
                            }*/
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
                    picBoxArr[pL].Paint += new PaintEventHandler(this.pictureBox_Paint);
                    picBoxArr[pL].ContextMenuStrip = contextMenuPictureBox;

                    //Se integraran despues de ordenarlos
                    //flowLayoutPanelMain.Controls.Add(picBoxArr[pL]);
                    pL++;//iterar en el array de paneles
                }
            }
            #endregion

            #region Ordenar el array de los paneles
            //Optimizar el tamaño del array
            Array.Resize(ref picBoxArr, pL);

            //Ordenar los paneles por orden alfabetico
            if (settings.PanelOrder == 1)
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

        #region TreeView
        private void treeViewMain_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            TreeNode node = e.Node;//Obtener el nodo que se va a dibujar

            //Determina si el nodo esta seleccionado
            bool selected = (e.State & TreeNodeStates.Selected) != 0;
            bool hover = (node == lastHoveredNode);

            //Nivel del nodo en jerarquia
            int offset = node.Level * 20; //Ajusta la posicion del texto del nodo en funcion del nivel en el que este

            //Recoger el area de dibujo del nodo
            Rectangle bounds = e.Bounds;

            // Establece el color de fondo dependiendo del estado del nodo.
            //Color backColor = selected ? SystemColors.Highlight : SystemColors.Window;
            //Personalizar el fondo del nodo segun el estado
            Color backgroundColor;
            if (selected)//Nodo seleccionado
            {
                backgroundColor = Color.FromArgb(65, 72, 85);//SystemColors.Highlight;
            }
            else if (hover)//Nodo con el mouse encima
            {
                //color hovermouse
                backgroundColor = Color.FromArgb(73, 81, 95); //Color.LightGray;
            }
            else //Default
            {
                backgroundColor = Color.FromArgb(94, 105, 123);//SystemColors.Window;
            }

            //Establece el color de primer plano dependiendo del estado del nodo
            Color foreColor = Color.White;//selected ? Color.White : Color.FromArgb(65, 72, 85);

            //Dibuja el fondo del nodo
            using (Brush backgroundBrush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, bounds);
            }

            //Ajusta el texto para que se empiece a escribir desde el punto x40 en adelante
            bounds.X += 40;//treeViewMain.Width/3 (si quiero que el nodo se vaya ajustando a 1/3 del ancho)
            //Ajusta la posicion del texto despues de que se haya dibujado el fondo del nodo
            bounds.X += offset;
            // Dibuja el texto del nodo
            TextRenderer.DrawText(e.Graphics, node.Text, treeViewMain.Font, bounds, foreColor, TextFormatFlags.VerticalCenter);

        }

        private void treeViewMain_MouseMove(object sender, MouseEventArgs e)
        {
            TreeNode node = treeViewMain.GetNodeAt(e.Location);

            if (node != lastHoveredNode)
            {
                // El mouse ha entrado o salido de un nodo
                if (lastHoveredNode != null)
                {
                    lastHoveredNode = null;
                    treeViewMain.Invalidate(); //volver a dibujar para restaurar el fondo del nodo anterior
                }

                if (node != null)
                {
                    lastHoveredNode = node;
                    treeViewMain.Invalidate(); //volver a dibujar para cambiar el fondo del nodo actual
                }
            }
        }

        private void treeViewMain_MouseLeave(object sender, EventArgs e)
        {
            if (lastHoveredNode != null)
            {
                lastHoveredNode = null;
                treeViewMain.Invalidate(); //volver a dibujar para restaurar el fondo del nodo anterior
            }
        }

        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeViewMain.Invalidate(); //volver a dibujar para actualizar la selección
        }

        private void loadTreeView(int colSize)
        {
            //Cargar todas las colecciones
            Collections[] colls = new Collections[colSize];
            colls = LoadCollections(colSize);
            treeViewMain.SelectedNode = null;
            treeViewMain.Nodes.Clear();//Limpiar todo el treeview

            //Nodo seleccionado
            TreeNode Selectednode = null;
            /*Debido a que al agregar muchos nodos el treeview cambia, el valor de los nodos tambien puede cambiar, por lo que treeViewMain.SelectedNode = node no sive siempre*/

            //Crear el nodo de favoritos
            TreeNode fvNode = new TreeNode("Favoritos");  fvNode.Tag = -1; treeViewMain.Nodes.Add(fvNode);

            Console.WriteLine($"viewdepth loadTreeview {viewDepth}");
            

            //Se carga el archivo XML de colecciones por que se haran "querys"
            //XmlDocument xmlDoc = new XmlDocument.Load(xmlColPath);
            XDocument doc = XDocument.Load(xmlColPath);

            //Cargar los nodos de las colecciones en el tree view
            for (int i = 0; i < colls.Length; i++)
            {
                //Cargar nodos de la raiz
                if (colls[i].IDFather == 0)
                {
                    //Cargar nodos de profundidad principal (idFather = 0)
                    TreeNode root = new TreeNode(colls[i].Name);

                    // Asignar una etiqueta al nodo
                    root.Tag = colls[i].ID;

                    // Utilizar LINQ to XML para contar los elementos que contengan como padre a esta coleccion
                    var matchingElements = doc.Descendants("collection")
                                  .Where(item => item.Element("IDFather")?.Value == colls[i].ID.ToString())
                                  .Select(item => new
                                  {
                                      Id = item.Attribute("id").Value,//Es el valor que rescatare para usarlo a futuro
                                  })
                                  .ToList();

                    // Contar las coincidencias
                    int count = matchingElements.Count;

                    if (count > 0)
                    {
                        //MessageBox.Show($"Se encontraron {count} elementos coincidentes en la id {colls[i].ID}");

                        foreach (var element in matchingElements)
                        {
                            Collections col = colls.FirstOrDefault(o => o.ID == int.Parse(element.Id));
                            TreeNode subNode = new TreeNode(col.Name);
                            subNode.Tag = col.ID;
                            root.Nodes.Add(subNode);

                            //Si el tag del nodo coincide con la profundidad, volverlo un nodo seleccionado
                            if (col.ID == viewDepth)
                            {
                                Selectednode = subNode;
                                //treeViewMain.SelectedNode = subNode;
                            }

                            //Buscar en ese sub nodo, si tiene sub nodos para agregarlo
                            int subCount = doc.Descendants("IDFather").Where(subElement => subElement.Value == element.Id).Count();

                            if (subCount > 0)
                            {
                                TreeNode returnSubNode;
                                returnSubNode = searchSubNode(doc, subNode, colls, element.Id, null);

                                if (returnSubNode != null) Selectednode = returnSubNode;
                            }
                        }
                    }

                    // Agregar el nodo al TreeView
                    treeViewMain.Nodes.Add(root);

                    //viewDepth == colls[i].IDFather

                    //Si el nodo padre coincide con la profundidad, volverlo seleccionado
                    if (colls[i].ID == viewDepth)
                    {
                       // treeViewMain.SelectedNode = root;
                        Selectednode = root;
                    }

                    
                }
            }

            //Si estan en favoritos, seleccionar a ese nodo
            if (viewDepth == -1)
            {
                Selectednode = fvNode;
                //treeViewMain.SelectedNode = treeViewMain.Nodes[0];
            }

            //Seleccionar el nodo
            if (Selectednode != null)
            {
                treeViewMain.SelectedNode = Selectednode;
            }
            

            //Expandir el tree view para ver todos los nodos
            treeViewMain.ExpandAll();

        }

        private TreeNode searchSubNode(XDocument doc, TreeNode fatherNode, Collections[] colls, string FatherID, TreeNode passReturnNode)
        {
            TreeNode returnNode = passReturnNode;
            //Buscar todos los elementos del sub nodo
            var matchingElements = doc.Descendants("collection")
                                  .Where(item => item.Element("IDFather")?.Value == FatherID)
                                  .Select(item => new
                                  {
                                      Id = item.Attribute("id").Value,//Es el valor que rescatare para usarlo a futuro
                                  })
                                  .ToList();

            foreach (var element in matchingElements)
            {
                Collections col = colls.FirstOrDefault(o => o.ID == int.Parse(element.Id));
                TreeNode subNode = new TreeNode(col.Name);
                subNode.Tag = col.ID;
                fatherNode.Nodes.Add(subNode);

                if (int.Parse(subNode.Tag.ToString()) == viewDepth)
                {
                    //treeViewMain.SelectedNode = subNode;
                    returnNode = subNode;
                }

                //Buscar en ese sub nodo, si tiene sub nodos para agregarlo
                int subCount = doc.Descendants("IDFather").Where(subElement => subElement.Value == element.Id).Count();

                if (subCount > 0)
                {
                    returnNode = searchSubNode(doc, subNode, colls, element.Id, returnNode);
                }
            }

            return returnNode;
        }

        //Navegar entre nodos
        private void treeViewMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewMain.SelectedNode = e.Node;
            object tag = e.Node.Tag;
            if (tag != null)
            {
                int depth = int.Parse(tag.ToString());
                viewDepth = depth;
                loadPictureBox(colSize, fileSize, false);
            }
        }
        #endregion

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

        //subir de profundidad
        private void btnBackView_Click(object sender, EventArgs e)
        {
            if (viewDepth > 0)//No volver atras si estas en el menu base
            {
                //Si estamos dentro de un escaneo, dejar ViewDepth tal cual
                if (scanDepth.Count > 0)
                {
                    //Si la lista de escaneo de directorios no es 0, eliminar un elemento
                    scanDepth.RemoveAt(scanDepth.Count - 1);
                }
                else
                {
                    //Buscar con la profundidad el idPadre de la coleccion actual
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlColPath);

                    string xpath = "//Launcher/collection[@id='" + viewDepth + "']";
                    XmlNode root = doc.SelectSingleNode(xpath);
                    int id = int.Parse(XMLDefaultReturn(root, "IDFather", "0"));
                    viewDepth = id;
                }
                
                
                
                loadPictureBox(colSize, fileSize, false);
            }
        }

        //Ir a la profundidad 0
        private void btnHomeView_Click(object sender, EventArgs e)
        {
            if (viewDepth != 0)
            {
                viewDepth = 0;
                scanDepth.Clear();
                loadPictureBox(colSize, fileSize, false);
            }
        }

        //Volver a cargar la vista
        private void btnReloadView_Click(object sender, EventArgs e)
        {
            colSize = LoadCollectionSize();
            fileSize = LoadFilesSize();
            loadView(colSize, fileSize);
        }
        #endregion

        #region Manejar datos XML
        private string XMLDefaultReturn(XmlNode node,string singleNode, string defaultValue)
        {
            XmlNode selectedNode = node.SelectSingleNode(singleNode);
            if (selectedNode != null)
            {
                return selectedNode.InnerText;
            }
            return defaultValue;
        }

        #region Directorios escaneados
        private void SaveXMLScanned(Scanneds Class)
        {
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            if (!File.Exists(xmlScannedPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlScannedPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlScannedPath);

            XmlElement scan;
           
            //Editar/crear elemento
            string xpath = "//Launcher/scanned[@dir='" + Class.Dir + "']";
            
            scan = xmlDoc.SelectSingleNode(xpath) as XmlElement;
            //Si no lo encuentra en el archivo, crearlo
            if (scan == null)
            {
                scan = xmlDoc.CreateElement("scanned");
                scan.SetAttribute("dir", Class.Dir.ToString());
                xmlDoc.DocumentElement.AppendChild(scan);//agrega la coleccion al documento
            } else
            {
                //Limpiarlo para agregarle las modificaciones
                scan.RemoveAll();
                scan.SetAttribute("dir", Class.Dir.ToString());
            }

            
            
            //Elementos de ese scan
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos de la coleccion a la coleccion
            XmlElement scanName = xmlDoc.CreateElement("Name"); scanName.InnerText = Class.Name; scan.AppendChild(scanName);
            XmlElement scanImage = xmlDoc.CreateElement("Image"); scanImage.InnerText = Class.ImagePath; scan.AppendChild(scanImage);
            XmlElement scanLayout = xmlDoc.CreateElement("ImageLayout"); scanLayout.InnerText = Class.ImageLayout.ToString(); scan.AppendChild(scanLayout);
            XmlElement scanBg = xmlDoc.CreateElement("WithoutBackground"); scanBg.InnerText = Class.Background.ToString(); scan.AppendChild(scanBg);
            XmlElement scanBgRed = xmlDoc.CreateElement("BackgroundRed"); scanBgRed.InnerText = Class.ColorRed.ToString(); scan.AppendChild(scanBgRed);
            XmlElement scanBgGreen = xmlDoc.CreateElement("BackgroundGreen"); scanBgGreen.InnerText = Class.ColorGreen.ToString(); scan.AppendChild(scanBgGreen);
            XmlElement scanBgBlue = xmlDoc.CreateElement("BackgroundBlue"); scanBgBlue.InnerText = Class.ColorBlue.ToString(); scan.AppendChild(scanBgBlue);
            XmlElement scanResolution = xmlDoc.CreateElement("CoverResolutionID"); scanResolution.InnerText = Class.ResolutionID.ToString(); scan.AppendChild(scanResolution);
            XmlElement scanWith = xmlDoc.CreateElement("CoverWidth"); scanWith.InnerText = Class.Width.ToString(); scan.AppendChild(scanWith);
            XmlElement scanHeight = xmlDoc.CreateElement("CoverHeight"); scanHeight.InnerText = Class.Height.ToString(); scan.AppendChild(scanHeight);
            XmlElement scanStartNumber = xmlDoc.CreateElement("StartNumber"); scanStartNumber.InnerText = Class.ScanStartNumber.ToString(); scan.AppendChild(scanStartNumber);
            //Guardar el array de extensiones para los escaneos
            XmlElement scanOpenExtension = xmlDoc.CreateElement("OpenExtension"); scan.AppendChild(scanOpenExtension);
            foreach (string ext in Class.ScanOpenExtension)
            {
                XmlElement extArray = xmlDoc.CreateElement("extension");
                extArray.InnerText = ext.ToString();
                scanOpenExtension.AppendChild(extArray);
            }

            xmlDoc.Save(xmlScannedPath);
        }

        private Scanneds searchScanData(string dirID)
        {
            if (File.Exists(xmlScannedPath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlScannedPath);

                string xpath = "//Launcher/scanned[@dir='" + dirID + "']";

                XmlNode root = doc.SelectSingleNode(xpath);
                XmlNode rootScanExtension = doc.SelectSingleNode(xpath + "/OpenExtension");

                //Si root es null, significa que estamos tratando de editar un scanDir por primera vez (el null se maneja en ToolStripEditPictureBox_Click)
                if (root == null) return null;

                string name = XMLDefaultReturn(root, "Name", "");
                string imgPath = XMLDefaultReturn(root, "Image", "");
                int imgLayout = int.Parse(XMLDefaultReturn(root, "ImageLayout", "0"));
                bool background = bool.Parse(XMLDefaultReturn(root, "WithoutBackground", "false"));
                int red = int.Parse(XMLDefaultReturn(root, "BackgroundRed", "255"));
                int green = int.Parse(XMLDefaultReturn(root, "BackgroundGreen", "255"));
                int blue = int.Parse(XMLDefaultReturn(root, "BackgroundBlue", "255"));
                int resolution = int.Parse(XMLDefaultReturn(root, "CoverResolutionID", "0"));
                int width = int.Parse(XMLDefaultReturn(root, "CoverWidth", "200"));
                int height = int.Parse(XMLDefaultReturn(root, "CoverHeight", "200"));


                int scanStartNumber = int.Parse(XMLDefaultReturn(root, "StartNumber", "1"));
                string[] scanExtension = { };
                if (rootScanExtension != null)
                {
                    foreach (XmlNode extension in rootScanExtension)
                    {
                        scanExtension = scanExtension.Append(extension.InnerText).ToArray();
                    }
                }

                Scanneds ScanReturn = new Scanneds(dirID, name, imgPath, imgLayout, background, red, green, blue, resolution, width, height, scanStartNumber, scanExtension);

                return ScanReturn;
            }
            return null;
        }

        #endregion

        #region Elementos
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
                //string tagpath = "//Launcher/file/TagsID";
                XmlNode root = xmlDoc.SelectSingleNode(xpath);
                //XmlNode rootTag = xmlDoc.SelectSingleNode(tagpath);

                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {
                    fileID++;
                    xpath = "//Launcher/file[@id='" + fileID + "']";
                    root = xmlDoc.SelectSingleNode(xpath);
                }

                fileData[i] = searchFileData(fileID);

                fileID++;
            }

            return fileData;
        }

        private void SaveXMLFile(Files file)
        {
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            /*if (!File.Exists(xmlFilesPath))
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

            //Guardar la imagen
            string coverDir = "";
            if (Class.ImagePath != "") coverDir = saveCover(Class.Name, Class.ImagePath, Class.ID == -1, "element_");//si Class.ID == 1, se esta creando un elemento desde 0

            //Elementos de ese file
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos de la coleccion a la coleccion
            XmlElement fileFather = xmlDoc.CreateElement("IDFather"); fileFather.InnerText = Class.IDFather.ToString(); file.AppendChild(fileFather);
            XmlElement fileName = xmlDoc.CreateElement("Name"); fileName.InnerText = Class.Name; file.AppendChild(fileName);
            XmlElement fileImage = xmlDoc.CreateElement("Image"); fileImage.InnerText = coverDir; file.AppendChild(fileImage);
            XmlElement fileLayout = xmlDoc.CreateElement("ImageLayout"); fileLayout.InnerText = Class.ImageLayout.ToString(); file.AppendChild(fileLayout);
            XmlElement filePath = xmlDoc.CreateElement("FilePath"); filePath.InnerText = Class.FilePath; file.AppendChild(filePath);
            XmlElement fileProgram = xmlDoc.CreateElement("ProgramPath"); fileProgram.InnerText = Class.ProgramPath; file.AppendChild(fileProgram);
            XmlElement filecmd = xmlDoc.CreateElement("CMDLine"); filecmd.InnerText = Class.CMDLine; file.AppendChild(filecmd);
            XmlElement fileBg = xmlDoc.CreateElement("WithoutBackground"); fileBg.InnerText = Class.Background.ToString(); file.AppendChild(fileBg);
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

            xmlDoc.Save(xmlFilesPath);*/
            Files classFile = new Files();
            classFile.SaveFiles(file);

            //Actualizar la cantidad de archivos
            fileSize = LoadFilesSize();
            //viewDepth = Class.IDFather;
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
                filePath = XMLDefaultReturn(root, "FilePath", "");
                programPath = XMLDefaultReturn(root, "ProgramPath", "");
                cmdLine = XMLDefaultReturn(root, "CMDLine", "");
                urlCheck = bool.Parse(XMLDefaultReturn(root, "URLCheck", "false"));
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

        private bool getFileURL(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            bool returnURL = false;

            if (root != null)
            {
                returnURL = bool.Parse(root.SelectSingleNode("URLCheck").InnerText);
            }

            //Llamar a la funcion para que empiece el proceso
            return returnURL;
        }

        private string getFileProgram(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            string returnProgram = "";

            if (root != null)
            {
                returnProgram = root.SelectSingleNode("ProgramPath").InnerText;
            }

            //Llamar a la funcion para que empiece el proceso
            return returnProgram;
        }

        private string getFileDir(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            string returnDir = "";

            if (root != null)
            {
                returnDir = root.SelectSingleNode("FilePath").InnerText;
            }

            //Llamar a la funcion para que empiece el proceso
            return returnDir;
        }

        private Files searchFileData(int fileID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);

            string xpath = "//Launcher/file[@id='" + fileID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);
            XmlNode rootTag = doc.SelectSingleNode(xpath + "/TagsID");

            int idFather = int.Parse(XMLDefaultReturn(root, "IDFather", "0"));
            string name = XMLDefaultReturn(root, "Name", "");
            string imgPath = XMLDefaultReturn(root, "Image", "");
            int imgLayout = int.Parse(XMLDefaultReturn(root, "ImageLayout", "0"));
            string filePath = XMLDefaultReturn(root, "FilePath", "");
            string programPath = XMLDefaultReturn(root, "ProgramPath", "");
            string cmdLine = XMLDefaultReturn(root, "CMDLine", "");
            bool background = bool.Parse(XMLDefaultReturn(root, "WithoutBackground", "false"));
            int red = int.Parse(XMLDefaultReturn(root, "BackgroundRed", "255"));
            int green = int.Parse(XMLDefaultReturn(root, "BackgroundGreen", "255"));
            int blue = int.Parse(XMLDefaultReturn(root, "BackgroundBlue", "255"));
            int resolution = int.Parse(XMLDefaultReturn(root, "CoverResolutionID", "0"));
            int width = int.Parse(XMLDefaultReturn(root, "CoverWidth", "200"));
            int height = int.Parse(XMLDefaultReturn(root, "CoverHeight", "200"));
            bool urlCheck = bool.Parse(XMLDefaultReturn(root, "URLCheck", "false"));
            int[] tagsArray = new int[] { };
            foreach (XmlNode tagid in rootTag)
            {
                //hacer un append al array
                tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
            }
            bool fav = bool.Parse(XMLDefaultReturn(root, "Favorite", "false"));

            Files FileReturn = new Files(fileID, idFather, name, imgPath, imgLayout, filePath, programPath, cmdLine, background,red, green, blue, resolution, width, height, urlCheck, tagsArray, fav);

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

            if (root != null)
            {
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

        private string[] getColeScanExtension(int colID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlColPath);

            string xpath = "//Launcher/collection[@id='" + colID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            List<string> extValues = new List<string>();
            if (root != null)
            {
                //returnExt.Append(root.SelectSingleNode("ScanOpenExtension").InnerText);

                XmlNode rootScanExtension = doc.SelectSingleNode("//Launcher/collection/ScanOpenExtension");
                if (rootScanExtension != null)
                {
                    foreach (XmlNode extension in rootScanExtension)
                    {
                        extValues.Add(extension.InnerText);
                    }
                }
            }

            string[] returnExt = extValues.ToArray();

            return returnExt;
        }

        private int getColeScanStartNumber(int colID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlColPath);

            string xpath = "//Launcher/collection[@id='" + colID + "']";
            XmlNode root = doc.SelectSingleNode(xpath);

            int returnNumber = 0;
                        
            try
            {
                returnNumber = int.Parse(root.SelectSingleNode("ScanStartNumber").InnerText);
            } catch (Exception ) { }
                
            //Llamar a la funcion para que empiece el proceso
            return returnNumber;
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

            //Guardar la imagen
            string coverDir = "";
            if (Class.ImagePath != "") coverDir = saveCover(Class.Name, Class.ImagePath, Class.ID == -1, "collection_");//si Class.ID == 1, se esta creando un elemento desde 0


            //Elementos de esa coleccion
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos de la coleccion a la coleccion
            XmlElement colFather = xmlDoc.CreateElement("IDFather"); colFather.InnerText = Class.IDFather.ToString(); coleccion.AppendChild(colFather);
            XmlElement colName = xmlDoc.CreateElement("Name"); colName.InnerText = Class.Name; coleccion.AppendChild(colName);
            XmlElement colImage = xmlDoc.CreateElement("Image"); colImage.InnerText = coverDir; coleccion.AppendChild(colImage);
            XmlElement colLayout = xmlDoc.CreateElement("ImageLayout"); colLayout.InnerText = Class.ImageLayout.ToString(); coleccion.AppendChild(colLayout);
            XmlElement colBg = xmlDoc.CreateElement("WithoutBackground"); colBg.InnerText = Class.Background.ToString(); coleccion.AppendChild(colBg);
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
            XmlElement colSonProgramPath = xmlDoc.CreateElement("SonProgramPath"); colSonProgramPath.InnerText = Class.SonProgramPath.ToString(); coleccion.AppendChild(colSonProgramPath);
            XmlElement colSonCMDLine = xmlDoc.CreateElement("SonCMDLine"); colSonCMDLine.InnerText = Class.SonCMDLine.ToString(); coleccion.AppendChild(colSonCMDLine);
            //Guardar el array de las etiquetas
            XmlElement colTags = xmlDoc.CreateElement("TagsID"); coleccion.AppendChild(colTags);
            foreach (int num in Class.TagsID)
            {
                XmlElement numArray = xmlDoc.CreateElement("id");
                numArray.InnerText = num.ToString();
                colTags.AppendChild(numArray);
            }
            //Guardar el array de las etiquetas a escanear
            XmlElement colTagsScan = xmlDoc.CreateElement("ScanTagsID"); coleccion.AppendChild(colTagsScan);
            foreach (int num in Class.ScanTags)
            {
                XmlElement numArray = xmlDoc.CreateElement("id");
                numArray.InnerText = num.ToString();
                colTagsScan.AppendChild(numArray);
            }
            XmlElement colFavorite = xmlDoc.CreateElement("Favorite"); colFavorite.InnerText = Class.Favorite.ToString(); coleccion.AppendChild(colFavorite);
            XmlElement colScanFolder = xmlDoc.CreateElement("ScanFolder"); colScanFolder.InnerText = Class.ScanFolder.ToString(); coleccion.AppendChild(colScanFolder);
            XmlElement colScanPath = xmlDoc.CreateElement("ScanPath"); colScanPath.InnerText = Class.ScanPath.ToString(); coleccion.AppendChild(colScanPath);
            XmlElement colScanStartNumber = xmlDoc.CreateElement("ScanStartNumber"); colScanStartNumber.InnerText = Class.ScanStartNumber.ToString(); coleccion.AppendChild(colScanStartNumber);
            //Guardar el array de extensiones para los escaneos
            XmlElement colScanOpenExtension = xmlDoc.CreateElement("ScanOpenExtension"); coleccion.AppendChild(colScanOpenExtension);
            foreach (string ext in Class.ScanOpenExtension)
            {
                XmlElement extArray = xmlDoc.CreateElement("extension");
                extArray.InnerText = ext.ToString();
                colScanOpenExtension.AppendChild(extArray);
            }

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


            int colID = 1;
            for (int i = 0; i < arraySize; i++)
            {
                //Buscamos el elemento a modificar
                string xpath = "//Launcher/collection[@id='" + colID + "']";
                XmlNode root = xmlDoc.SelectSingleNode(xpath);


                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {
                    colID++;
                    xpath = "//Launcher/collection[@id='" + colID + "']";

                    root = xmlDoc.SelectSingleNode(xpath);
                }

                colData[i] = searchCollectionData(colID);
                
                colID++;
            }

            return colData;
        }

        //Cargar una coleccion desde el xml (sirve para no repetir el mismo script en todas las funciones)
        private Collections searchCollectionData(int colID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlColPath);

            string xpath = "//Launcher/collection[@id='" + colID + "']";

            XmlNode root = doc.SelectSingleNode(xpath);
            XmlNode rootTag = doc.SelectSingleNode(xpath+"/TagsID");
            XmlNode rootTagScan = doc.SelectSingleNode(xpath+"/ScanTagsID");
            XmlNode rootScanExtension = doc.SelectSingleNode(xpath+"/ScanOpenExtension");

            int idFather = int.Parse(XMLDefaultReturn(root, "IDFather", "0"));
            string name = XMLDefaultReturn(root, "Name", "");
            string imgPath = XMLDefaultReturn(root, "Image", "");
            int imgLayout = int.Parse(XMLDefaultReturn(root, "ImageLayout", "0"));
            bool background = bool.Parse(XMLDefaultReturn(root, "WithoutBackground", "false"));
            int red = int.Parse(XMLDefaultReturn(root, "BackgroundRed", "255"));
            int green = int.Parse(XMLDefaultReturn(root, "BackgroundGreen", "255"));
            int blue = int.Parse(XMLDefaultReturn(root, "BackgroundBlue", "255"));
            int resolution = int.Parse(XMLDefaultReturn(root, "CoverResolutionID", "0"));
            int width = int.Parse(XMLDefaultReturn(root, "CoverWidth", "200"));
            int height = int.Parse(XMLDefaultReturn(root, "CoverHeight", "200"));
            int sonRes = int.Parse(XMLDefaultReturn(root, "CoverSonResolutionID", "0"));
            int sonWidth = int.Parse(XMLDefaultReturn(root, "CoverSonWidth", "200"));
            int sonHeight = int.Parse(XMLDefaultReturn(root, "CoverSonHeight", "200"));
            int sonLayout = int.Parse(XMLDefaultReturn(root, "SonImageLayout", "0"));
            string sonProgramPath = XMLDefaultReturn(root, "SonProgramPath", "");
            string sonCMDLine = XMLDefaultReturn(root, "SonCMDLine", "");

            int[] tagsArray = { };
            if (rootTag != null)
            {
                foreach (XmlNode tagid in rootTag)
                {
                    tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
                }
            }
            int[] tagsScan = { };
            if (rootTagScan != null)
            {
                foreach (XmlNode tagid in rootTagScan)
                {
                    tagsScan = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
                }
            }
            bool fav = bool.Parse(XMLDefaultReturn(root, "Favorite", "false"));
            bool scanFold = bool.Parse(XMLDefaultReturn(root, "ScanFolder", "false"));
            string scanPath = XMLDefaultReturn(root, "ScanPath", "");
            int scanStartNumber = int.Parse(XMLDefaultReturn(root, "ScanStartNumber", "1"));
            string[] scanExtension = { };
            if (rootScanExtension != null)
            {
                foreach (XmlNode extension in rootScanExtension)
                {
                    scanExtension = scanExtension.Append(extension.InnerText).ToArray();
                }
            }

            Collections colReturn = new Collections(colID, idFather, name, imgPath, imgLayout, background, red, green, blue, resolution, width, height, sonRes, sonWidth, sonHeight, sonLayout, sonProgramPath, sonCMDLine, tagsArray, tagsScan, fav, scanFold, scanPath, scanStartNumber, scanExtension);

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
                int idFather = int.Parse(XMLDefaultReturn(root, "IDFather", "0"));
                if (idFather != colID)
                {
                    fileID++;
                    continue;
                }
                
                string name = XMLDefaultReturn(root, "Name", "");
                string imgPath = XMLDefaultReturn(root, "Image", "");
                int imgLayout = int.Parse(XMLDefaultReturn(root, "ImageLayout", "0"));
                string filePath = XMLDefaultReturn(root, "FilePath", "");
                string programPath = XMLDefaultReturn(root, "ProgramPath", "");
                string cmdLine = XMLDefaultReturn(root, "CMDLine", "");
                bool background = bool.Parse(XMLDefaultReturn(root, "WithoutBackground", "false"));
                int red = int.Parse(XMLDefaultReturn(root, "BackgroundRed", "255"));
                int green = int.Parse(XMLDefaultReturn(root, "BackgroundGreen", "255"));
                int blue = int.Parse(XMLDefaultReturn(root, "BackgroundBlue", "255"));
                int resolution = int.Parse(XMLDefaultReturn(root, "CoverResolutionID", "0"));
                int width = int.Parse(XMLDefaultReturn(root, "CoverWidth", "200"));
                int height = int.Parse(XMLDefaultReturn(root, "CoverHeight", "200"));
                bool urlCheck = bool.Parse(XMLDefaultReturn(root, "URLCheck", "false"));
                int[] tagsArray = new int[] { };
                foreach (XmlNode tagid in rootTag)
                {
                    //hacer un append al array
                    tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
                }
                bool fav = bool.Parse(XMLDefaultReturn(root, "Favorite", "false"));

                fileData[i] = new Files(fileID, idFather, name, imgPath, imgLayout, filePath, programPath, cmdLine, background, red, green, blue, resolution, width, height, urlCheck, tagsArray, fav);

                fileID++;
            }

            Files[] arrangedFiles = fileData.Where(elemento => elemento != null).ToArray();

            return arrangedFiles;
        }

        private void deleteCollection(int colID)
        {
            //cargar xml con linq
            XDocument xmlDoc = XDocument.Load(xmlColPath);

            Console.Write($"\n/////////////////////////////////////////////\nColeccion a eliminar {colID}\n////////////////////////////////////////////////////\n");
            // Eliminar la coleccion principal
           /* var deleteColl = xmlDoc.Descendants("collection")
                .Where(e => e.Attribute("id").Value == colID.ToString()).Remove();*/

            XElement deleteColl = xmlDoc.Root.Elements("collection")
            .FirstOrDefault(e => e.Attribute("id")?.Value == colID.ToString());

            if (deleteColl != null)
            {
                //Eliminar la caratula solo si está ubicada en la carpeta "System"
                string imgDir = deleteColl.Attribute("Image")?.Value;
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

                deleteColl.Remove();
            }


            //Buscar todos los archivos que esten dentro de esa coleccion y eliminarlo
            XDocument xmlFileDoc = XDocument.Load(xmlFilesPath);

            List<XElement> filesToDelete = xmlFileDoc.Root.Elements("file")//xmlFileDoc.Root.Elements()
            .Where(e => e.Element("IDFather")?.Value == colID.ToString())
            .ToList();

            foreach (var file in filesToDelete)
            {
                //Eliminar el elemento
                deleteFile(int.Parse(file.Attribute("id").Value));
            }
            

            //Buscar todos los descendientes de esa coleccion
            List <XElement> collsToDelete = xmlDoc.Root.Elements("collection")//xmlDoc.Root.Elements()
            .Where(e => e.Element("IDFather")?.Value == colID.ToString())
            .ToList();

            
            foreach (var coll in collsToDelete)
            {
                // Llamar recursivamente a la función para eliminar los descendientes
                deleteCollection(int.Parse(coll.Attribute("id").Value));

                // Eliminar el elemento actual
                //coll.Remove();
            }


            xmlDoc.Save(xmlColPath);


            colSize = LoadCollectionSize();
            fileSize = LoadFilesSize();

            loadView(colSize, fileSize);
        }
        #endregion

        #region Settings
        //Cargar las configuraciones de settings
        private void loadSettingXML()
        {
            //cargar las configuraciones en el objeto de la clase
            settings = new Settings();

            viewDepth = settings.LastDepth;//Ultima profundidad
            treeViewMain.Width = settings.TreeViewWidth;//Ancho del treeview
            //Como se ordenan los paneles
            if (settings.PanelOrder == 1)
            {
                nombreToolStripMenuItem.Checked = true;
                fechaDeCreacionToolStripMenuItem.Checked = false;
            }
            //orderPanels = settings.PanelOrder;
            //Tipo de filtro en la barra de busqueda
            switch (settings.SearchFilter)
            {
                case 1:
                    searchFromActualToolStripMenuItem.Checked = false;
                    searchActualtoolStripMenuItem.Checked = true;
                    searchAlltoolStripMenuItem.Checked = false;
                    break;
                case 2:
                    searchFromActualToolStripMenuItem.Checked = false;
                    searchActualtoolStripMenuItem.Checked = false;
                    searchAlltoolStripMenuItem.Checked = true;
                    break;
                default:
                    searchFromActualToolStripMenuItem.Checked = true;
                    searchActualtoolStripMenuItem.Checked = false;
                    searchAlltoolStripMenuItem.Checked = false;
                    break;
            }
            //searchType = settings.SearchFilter;
            //Cargar las opciones de la ventana (estan en un sub nodo)
            //Ancho de la ventana
            //WinWidht = settings.WindowsWidth;
            //Alto de la ventana
            //WinHeight = settings.WindowsHeight;
            //Si esta o no maximizado
            //formState = settings.WindowsMaxScreen;
            if (settings.WindowsMaxScreen == 0) WindowState = FormWindowState.Normal; else WindowState = FormWindowState.Maximized;
            /*
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

            //Cargar el tipo de filtro al utilizar la barra de busqueda
            int searchT = 0;
            try { if (root.SelectSingleNode("SearchFilter") != null) searchT = int.Parse(root.SelectSingleNode("SearchFilter").InnerText); }
            finally
            {
                switch(searchT)
                {
                    case 1:
                        searchFromActualToolStripMenuItem.Checked = false;
                        searchActualtoolStripMenuItem.Checked = true;
                        searchAlltoolStripMenuItem.Checked = false;
                        break;
                    case 2:
                        searchFromActualToolStripMenuItem.Checked = false;
                        searchActualtoolStripMenuItem.Checked = false;
                        searchAlltoolStripMenuItem.Checked = true;
                        break;
                    default:
                        searchFromActualToolStripMenuItem.Checked = true;
                        searchActualtoolStripMenuItem.Checked = false;
                        searchAlltoolStripMenuItem.Checked = false;
                        break;
                }
                searchType = searchT;
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
            */
        }

        //Guardar las configuraciones de settings
        private void saveSettingsXML()
        {
            Settings classSettings = new Settings();
            classSettings.SaveSettings(settings);
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            /*if (!File.Exists(xmlSettingsPath))
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

            //Guardar como se muestran los elementos al utilizar la barra de busqueda
            XmlElement searchT = xmlDoc.CreateElement("SearchFilter"); searchT.InnerText = searchType.ToString(); set.AppendChild(searchT);

            xmlDoc.Save(xmlSettingsPath);*/
        }

        private void labelTest_Click(object sender, EventArgs e)
        {

        }

        private void labelDepth_Click(object sender, EventArgs e)
        {

        }

        private void menuStripMain_Paint(object sender, PaintEventArgs e)
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

            //Verificar la existencia del XML ScanDirs
            if (!File.Exists(xmlScannedPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlScannedPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
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

            //Verificar la existencia del XML Tags
            if (!File.Exists(xmlTagPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlTagPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Verificar la existencia del xml settings
            /*if (!File.Exists(xmlSettingsPath))
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
            }*/

            

        }

        private void configuracionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration config = new Configuration(settings);
            config.ReturnedObject += Configuration_ReturnedObject;
            config.ShowDialog();
        }

        private void Configuration_ReturnedObject(object sender, Settings e)
        {
            settings = e;
        }

        private bool checkImage(string fileDir)
        {
            string ex = Path.GetExtension(fileDir);
            if (!string.IsNullOrEmpty(ex))
            {
                string extensionLower = ex.ToLower();
                return extensionLower == ".jpg" || extensionLower == ".png" || extensionLower == ".webp";
            }
            return false;
        }

        private string returnImagePath(string outputFolder, string fileName, string extension)
        {
            string destinationFile = outputFolder + "\\" + extension + fileName + ".png";
            int i = 0;
            while (File.Exists(destinationFile))
            {
                i++;
                destinationFile = outputFolder + "\\"+ extension + fileName + "(" + i + ").png";//Se le cambia la extension a png
            }
            return destinationFile;
        }

        private string saveCover(string coverName, string originalImageDir, bool newCover, string coverType)
        {
            //Evitar que se guarde la imagen con caracteres invalidos
            string cleanName = Path.GetInvalidFileNameChars().Aggregate(coverName, (current, c) => current.Replace(c.ToString(), string.Empty));
            string imgPath = "";
            //Mover la imagen hacia la carpeta covers y transformarla a .png
            //Si estas creando un nuevo archivo, verificar si no existe un archivo con el mismo nombre, y si es asi, ponerle un iterador
            if (originalImageDir != "")
            {
                if (newCover)
                {
                    imgPath = returnImagePath(dirCoversPath, cleanName, coverType);
                }
                else
                {
                    //Si estas editando un archivo, ocupar la misma direccion que en el xml, pues el nombre se decidio al crearse
                    if (originalImageDir != null)
                    {
                        string systemCoverDir = dirCoversPath;
                        string xmlDir = Path.GetDirectoryName(originalImageDir);
                        if (xmlDir != systemCoverDir)
                        {
                            imgPath = returnImagePath(dirCoversPath, cleanName, coverType);
                        }
                        else
                        {
                            imgPath = originalImageDir;
                        }
                    }
                    else
                    {

                        imgPath = returnImagePath(dirCoversPath, cleanName, coverType);
                    }

                }
            }

            if (!Directory.Exists(dirCoversPath))
            {
                // Crea la carpeta Systems/Covers si no existe
                Directory.CreateDirectory(dirCoversPath);
            }


            //Solo reemplazar una imagen si esta existe o si la imagen de origen no es la misma que el destino
            if ((imgPath != "") && (imgPath != null) && (originalImageDir != imgPath))
            {
                //Las imagenes webp no pueden ser copiadas y pegadas a un formato png, deben ser transformadas y guardadas dentro de un objeto
                if (Path.GetExtension(originalImageDir).ToLower() == ".webp")
                {
                    Image saveImage;
                    using (MagickImage img = new MagickImage(originalImageDir))
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
                    System.IO.File.Copy(originalImageDir, imgPath, true);
                }

            }

            return imgPath;
        }
        #endregion


        //Guardar los settings
        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveSettingsXML();
        }
    }
}
