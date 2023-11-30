using C_Launcher.Clases;

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
using System.Threading.Tasks;

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
        private Configurations config;
        Themes theme;
        private Color pictureBoxHover = Color.White;

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
            "System\\Resources\\OpenIcon.png", //9
            "System\\Resources\\BackIcon.png",//10
            "System\\Resources\\HomeIcon.png",//11
            "System\\Resources\\ReloadIcon.png"//12
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
            loadConfigurationsXML();
            loadTheme();

            //Establecerle iconos a los botones
            try
            {
                // Cargar la imagen desde la ruta especificada
                Image imagen = Image.FromFile(imgResourceIcons[10]);
                btnBackView.Image = imagen;// Establecer la imagen como icono del botón
                btnBackView.BackColor = Color.Transparent;
                btnBackView.FlatAppearance.BorderSize = 0;
                btnBackView.Text = "";//El texto lo ocupo de referencia en el editor solamente
                btnBackView.Size = imagen.Size;// Ajustar el tamaño del botón para que se ajuste a la imagen
                //Declarar efecto hover
                btnBackView.FlatAppearance.MouseOverBackColor = theme.PanelTopButtonHover;
                btnBackView.FlatAppearance.MouseDownBackColor = theme.PanelTopButtonHover;

                imagen = Image.FromFile(imgResourceIcons[11]);
                btnHomeView.Image = imagen;// Establecer la imagen como icono del botón
                btnHomeView.BackColor = Color.Transparent;
                btnHomeView.FlatAppearance.BorderSize = 0;
                btnHomeView.Text = "";//El texto lo ocupo de referencia en el editor solamente
                btnHomeView.Size = imagen.Size;// Ajustar el tamaño del botón para que se ajuste a la imagen
                //Declarar efecto hover
                btnHomeView.FlatAppearance.MouseOverBackColor = theme.PanelTopButtonHover;
                btnHomeView.FlatAppearance.MouseDownBackColor = theme.PanelTopButtonHover;

                imagen = Image.FromFile(imgResourceIcons[12]);
                btnReloadView.Image = imagen;// Establecer la imagen como icono del botón
                btnReloadView.BackColor = Color.Transparent;
                btnReloadView.FlatAppearance.BorderSize = 0;
                btnReloadView.Text = "";//El texto lo ocupo de referencia en el editor solamente
                btnReloadView.Size = imagen.Size;// Ajustar el tamaño del botón para que se ajuste a la imagen
                //Declarar efecto hover
                btnReloadView.FlatAppearance.MouseOverBackColor = theme.PanelTopButtonHover;
                btnReloadView.FlatAppearance.MouseDownBackColor = theme.PanelTopButtonHover;
            }
            catch (Exception)
            {
                // Manejar cualquier error al cargar la imagen
                MessageBox.Show($"Error al cargar imagenes a los botones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //Tool strip (click derecho)
            //flow Layout Panel Tool Strip
            ContextMenuStrip contextMenuLayoutPanel   = new ContextMenuStrip();
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
            textBoxSearch.KeyDown += new KeyEventHandler(SearchBarEnter);
            textBoxSearch.GotFocus += new EventHandler(SearchBarRemoveText);
            textBoxSearch.LostFocus += new EventHandler(SearchBarAddText);

            //Carga la cantidad de colecciones y archivos existentes
            colSize = new Collections().GetCollectionsSize();
            fileSize = new Files().GetFilesSize();//LoadFilesSize();

            loadTreeView(colSize);
            loadPictureBox(colSize, fileSize, false);
            
            

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

                GeneralFunctions gf = new GeneralFunctions();

                defaultRes = int.Parse(gf.XMLDefaultReturn(root, "CoverSonResolutionID", "0"));
                defaultWidth = int.Parse(gf.XMLDefaultReturn(root, "CoverSonWidth", "200"));
                defaultHeight = int.Parse(gf.XMLDefaultReturn(root, "CoverSonHeight", "200"));
                defaultImageLayout = int.Parse(gf.XMLDefaultReturn(root, "SonImageLayout", "0"));
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

                GeneralFunctions gf = new GeneralFunctions();

                defaultRes = int.Parse(gf.XMLDefaultReturn(root, "CoverSonResolutionID", "0"));
                defaultWidth = int.Parse(gf.XMLDefaultReturn(root, "CoverSonWidth", "200"));
                defaultHeight = int.Parse(gf.XMLDefaultReturn(root, "CoverSonHeight", "200"));
                defaultImageLayout = int.Parse(gf.XMLDefaultReturn(root, "SonImageLayout", "0"));
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

                GeneralFunctions gf = new GeneralFunctions();

                defaultRes = int.Parse(gf.XMLDefaultReturn(root, "CoverSonResolutionID", "0"));
                defaultWidth = int.Parse(gf.XMLDefaultReturn(root, "CoverSonWidth", "200"));
                defaultHeight = int.Parse(gf.XMLDefaultReturn(root, "CoverSonHeight", "200"));
                defaultImageLayout = int.Parse(gf.XMLDefaultReturn(root, "SonImageLayout", "0"));
                defaultProgramPath = gf.XMLDefaultReturn(root, "SonProgramPath", "");
                defaultCMDLine = gf.XMLDefaultReturn(root, "SonCMDLine", "");
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
                Files file = new Files().LoadFileData(int.Parse(id));//searchFileData(int.Parse(id));

                NewFile editFile = new NewFile(file);
                editFile.ReturnedObject += NewFile_ReturnedObject;
                editFile.ShowDialog();
            } else if (boxType == "collection") {
                Collections col = new Collections().LoadCollectionData(int.Parse(id));//searchCollectionData(int.Parse(id));

                NewCollection editCollection = new NewCollection(col);
                editCollection.ReturnedObject += NewCollection_ReturnedObject;
                editCollection.ShowDialog();
            } else if (boxType == "automaticFile" || boxType == "automaticFolder") {
                Scanneds scanned = new Scanneds().GetScannedData(id);

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
                            GeneralFunctions gf = new GeneralFunctions();
                            //string rutasImagen = subArchivos.Where(ruta => checkImage(ruta));
                            imgPath = subArchivos.FirstOrDefault(ruta => gf.CheckImage(ruta));
                        }
                    }
                    

                        scanned = new Scanneds(id, pic.Name, imgPath, 0, false, 0, 0, 0, 0, pic.Width, pic.Height, 0, def);
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

                GeneralFunctions gf = new GeneralFunctions();

                defaultRes = int.Parse(gf.XMLDefaultReturn(root, "CoverSonResolutionID", "0"));
                defaultWidth = int.Parse(gf.XMLDefaultReturn(root, "CoverSonWidth", "200"));
                defaultHeight = int.Parse(gf.XMLDefaultReturn(root, "CoverSonHeight", "200"));
                defaultImageLayout = int.Parse(gf.XMLDefaultReturn(root, "SonImageLayout", "0"));
            }

            Files[] files = new Files().LoadFilesInCollection(int.Parse(id), fileSize);//searchFilesInCollection(int.Parse(id));

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
                message = $"¿Estas seguro de querer eliminar el elemento '{pic.Name}'?\n\n(Esto tambien eliminara la imagen almacenada en 'System/Covers')";
            } else
            {
                message = $"¿Estas seguro de querer eliminar la coleccion '{pic.Name}'?\n\n(Esto tambien eliminara su contenido y las imagenes almacenadas en 'System/Covers')";
            }

            //PictureBox pictureBox = (PictureBox)sender;
            //var result = MessageBox.Show("Estas seguro de querer eliminar "+pic.Name.ToString(),"Eliminar", MessageBoxButtons.YesNo);
            var result = MessageBox.Show(message, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (boxType == "file") 
                {
                    Files classFile = new Files();
                    classFile.DeleteFile(int.Parse(id));//Eliminar el archivo

                    colSize = new Collections().GetCollectionsSize();//LoadCollectionSize();
                    fileSize = new Files().GetFilesSize(); //LoadFilesSize();
                    loadPictureBox(colSize, fileSize, false);
                }
                else if (boxType == "collection")
                {
                    Collections classCollections = new Collections();
                    classCollections.DeleteCollection(int.Parse(id));

                    colSize = new Collections().GetCollectionsSize(); //LoadCollectionSize();
                    fileSize = new Files().GetFilesSize(); //LoadFilesSize();

                    loadView(colSize, fileSize);
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
                //setFileFav(idBox);
                Files classFiles = new Files();
                classFiles.SetFileFav(idBox);

                Console.WriteLine("set fav " + boxType + " | " + idBox);
                if (viewDepth == -1) loadView(colSize, fileSize);
            }
            else if (boxType == "collection")
            {
                //setColeFav(idBox);
                Collections classCollection = new Collections();
                classCollection.SetColeFav(idBox);

                Console.WriteLine("set fav " + boxType + " | " + idBox);
                if (viewDepth == -1) loadView(colSize, fileSize);
            }
        }

        //Abrir el programa de un elemento
        private void ToolStripOpenProgramPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)contextMenuPictureBox.SourceControl;
            int idBox = int.Parse(pic.Tag.ToString());//no se puede transformar un objeto a int, pero si a un string
            string programExe = new Files().GetFileProgram(idBox);//getFileProgram(idBox);

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
                fileDir = new Files().getFileDir(idBox);//getFileDir(idBox);
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
                config.PanelOrder = 0;
                loadPictureBox(colSize, fileSize, false);
            }
        }

        //ordenarlos por nombre (orderPanels 1)
        private void nombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!nombreToolStripMenuItem.Checked) {
                nombreToolStripMenuItem.Checked = true;
                fechaDeCreacionToolStripMenuItem.Checked = false;
                config.PanelOrder = 1;
                //orderPanels = 1;
                loadPictureBox(colSize, fileSize, false);
            }
            
        }
        #endregion

        #region filtro de busqueda
        private void searchFromActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //searchType = 0;
            config.SearchFilter = 0;
            searchFromActualToolStripMenuItem.Checked = true;
            searchActualtoolStripMenuItem.Checked = false;
            searchAlltoolStripMenuItem.Checked = false;
        }

        private void searchActualtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //searchType = 1;
            config.SearchFilter = 1;
            searchFromActualToolStripMenuItem.Checked = false;
            searchActualtoolStripMenuItem.Checked = true;
            searchAlltoolStripMenuItem.Checked = false;
        }

        private void searchAlltoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //searchType = 2;
            config.SearchFilter = 2;
            searchFromActualToolStripMenuItem.Checked = false;
            searchActualtoolStripMenuItem.Checked = false;
            searchAlltoolStripMenuItem.Checked = true;
        }
        #endregion
        #endregion

        #region Renderer
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            Color defaultBG = Color.FromArgb(36, 40, 47);
            Color selectedBG = Color.FromArgb(23, 29, 37);
            Color text = Color.White;
            public MyRenderer(Color _background, Color _selectedBackground, Color _text) : base(new MyColors()) { 
                this.defaultBG = _background;
                this.selectedBG = _selectedBackground;
                this.text = _text;

                Console.WriteLine($"renderer defaultBG {this.defaultBG}");
                Console.WriteLine($"renderer selectedBG {this.selectedBG}");
                Console.WriteLine($"renderer text {this.text}");
            }

            readonly static Themes theme = new Themes("System\\Themes\\cyan.css");


            //Establecer color del fondo
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                Color c = e.Item.Selected ? selectedBG : defaultBG ;
                using (SolidBrush brush = new SolidBrush(c)) e.Graphics.FillRectangle(brush, rc);
            }

            //Evitar que dibuje los bordes
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }

            //Cambiar el color del texto
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = text;//Color.White; // Establecer el nuevo color de texto
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
            //SaveXMLCollection(e);
            Collections classCollection = new Collections();
            classCollection.SaveCollection(e);
            //Actualizar cantidad de colecciones
            colSize = new Collections().GetCollectionsSize(); //LoadCollectionSize();
            loadView(colSize, fileSize);
        }

        private void EditScanned_ReturnedObject(object sender, Scanneds e)
        {
            //SaveXMLScanned(e);
            Scanneds classScanned = new Scanneds();
            classScanned.SaveScanned(e);
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
            //SaveXMLFile(e);
            Files classFile = new Files();
            classFile.SaveFile(e);

            //Actualizar la cantidad de archivos
            fileSize = new Files().GetFilesSize(); //LoadFilesSize();
            //Carga de nuevo el flow layout
            loadView(colSize, fileSize);
        }

        private void NewMultFiles_ReturnedObject(object sender, Files[] e)
        {
            for (int i = 0; i < e.Length; i++)
            {
                //Guarda 1x1 los archivos
                //SaveXMLFile(e[i]);
                Files classFile = new Files();
                classFile.SaveFile(e[i]);
            }
            //Actualizar la cantidad de archivos
            fileSize = new Files().GetFilesSize(); //LoadFilesSize();
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
            Pen borderPen = new Pen(pictureBoxHover);
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
                    Files classFile = new Files();
                    classFile = classFile.LoadFileData(idBox);

                    startProcess(classFile.FilePath, classFile.ProgramPath, classFile.CMDLine, classFile.URLCheck);
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
                        int scanStart = new Collections().GetColeScanStartNumber(viewDepth);

                        //Si el proceso de buscarlo por la coleccion fallo, buscarlo por scanned
                        if (scanStart == 0 && scanDepth.Count > 0)
                        {
                            scanStart = new Scanneds().GetScannedScanStartNumber(rutaEscaneo);
                        }

                        //Buscar dentro de esa coleccion un archivo e intentar abrirlo (si scanStart != 0)
                        if (archivos.Length > 0 && subDir.Length == 0 && scanStart != 0)
                        {
                            //Filtrar los archivos por una extension especifica
                            //archivos.Where(x => x.EndsWith(".html") || x.EndsWith(".lnk") || x.EndsWith(".url")).ToArray();
                            string[] extensions = new Collections().GetColeScanExtension(viewDepth);
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
                            
                            foreach(var file in archivos)
                            {
                                Console.WriteLine($"archivo: {file}");
                            }

                            startProcess(archivos[scanStart], "", "", false);
                        } 
                        else
                        {
                            Console.WriteLine($"archivos lenght: {archivos.Length}\nSubdir lenght: {subDir}\nScan start: {scanStart}");
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
                    ToolStripDelete.Image = Image.FromFile(imgResourceIcons[4]);
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

                    if (boxType == "automaticFile")
                    {
                        //Si es automatic file, no deberia aparecer "mostrar ubicacion del contenido"
                        contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripEdit, ToolStripAutomaticOpen });
                    } else
                    {
                        contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripEdit, ToolStripAutomaticOpen, ToolStripAutomaticOpenContent });
                    }

                    
                }
                

                if (boxType == "file")
                {
                    bool url = false;
                    string program = "";

                    //Dentro de la funcion se buscara los procesos asociados al archivo y llamara a start process
                    fav = new Files().GetFileFav(idBox);//getFileFav(idBox);
                    program = new Files().GetFileProgram(idBox);
                    url = new Files().GetFileURL(idBox);// getFileURL(idBox);

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

                    fav = new Collections().GetColeFav(idBox);
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
                Color text = new Themes("System\\Themes\\cyan.css").TextBoxSearchText;
                textBoxSearch.ForeColor = text;
            }
        }

        //Colocar el placeholder si es que no hay nada escrito y se pierde el foco
        public void SearchBarAddText(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Length  == 0)
            {
                textBoxSearch.Text = "Buscar...";
                Color text = new Themes("System\\Themes\\cyan.css").TextBoxSearchTextEmpty;
                textBoxSearch.ForeColor = text;
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

        //Controlar los temas
        private void loadTheme()
        {
            theme = new Themes($"System\\Themes\\{config.ThemeName}.css");

            viewDepth = config.LastDepth;//Ultima profundidad

            flowLayoutPanelMain.BackColor = theme.PanelBackground;

            //searchBox
            textBoxSearch.BackColor = theme.TextBoxSearchBackground;
            textBoxSearch.ForeColor = theme.TextBoxSearchTextEmpty;//Empieza con texto default (buscar...); el color cambia con sus funciones SearchBarAddText SearchBarRemoveText

            panelTop.BackColor = theme.PanelTopBackground;
            labelDepth.ForeColor = theme.PanelTopText;

            menuStripMain.BackColor = theme.NavbarBackground;

            //TreeView
            treeViewMain.BackColor = theme.TreeViewBackground;

            splitter1.BackColor = theme.TreeViewBorderBackground;

            //establecer el renderer de la barra de herramientas
            menuStripMain.Renderer = new MyRenderer(theme.NavbarBackground, theme.NavbarSelectedBackground, theme.NavbarText);

            //PictureBox
            pictureBoxHover = theme.CoverSelected;
        }

        //Dibujar el rectangulo negro y el nombre del pictureBox
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {

            if (config.PictureBoxName)
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
            //loadTheme();//Se recarga el tema solo al abrir el programa o al guardar las configuraciones (pide muchos recursos recargarlo constantemente)
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
            labelDepth.Visible = false;
            flowLayoutPanelMain.SuspendLayout();

            //Primero remueve todos los paneles del control
            destroyPictureBox();
            

            //Luego carga todos los archivos en los arrays
            Collections[] colls = new Collections[colSize];
            colls = new Collections().LoadCollections(colSize);

            Files[] files = new Files[fileSize];
            //Files classFile = new Files();
            files = new Files().LoadFiles(fileSize); //LoadFiles(fileSize);

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
                for (int i = 0; i < colls.Length; i++)
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
                string rootName = labelDepth.Text;
                foreach (string name in scanDepth)
                {
                    //string name = scanDepth.Last();
                    int pos = name.LastIndexOf("\\") + 1;
                    labelDepth.Text = rootName + "/" + name.Substring(pos, name.Length - pos);
                }
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
                        bool transparent = false;
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
                            transparent = bool.Parse(match.BoolBackground);
                            res = int.Parse(match.ResID);
                            w = int.Parse(match.Width);
                            h = int.Parse(match.Height);
                        }
                        #endregion

                        picBoxArr[pL] = new PictureBox
                        {
                            AccessibleDescription = "automaticFile",//Aqui se indica que tipo de picture box es (coleccion / archivo)
                            Name = name,//Aqui se guarda el nombre del elemento
                            Size = new Size(w, h),
                            BackColor = Color.FromArgb(r, g, b),
                            Tag = archivo,//Aqui se guarda en que espacio del array estamos buscando//colls[i].ID,
                        };

                        if (transparent)
                        {
                            picBoxArr[pL].BackColor = Color.Transparent;
                        }

                        #region Caratula
                        #region Cargar la imagen
                        //Cargar la caratula del archivo si es posible y si no se encontro una ruta en el xml (dando var match = null)
                        if (match == null)
                        {
                            //Rescatar la imagen del archivo (si es posible)
                            string extension = Path.GetExtension(archivo);

                            //dependiendo del tipo de archivo, el proceso para extraer una imagen preview es totalmente diferente
                            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".webp" || extension == ".gif")
                            {
                                Image thumbnail;
                                thumbnail = loadImage(archivo);
                                picBoxArr[pL].BackgroundImage = thumbnail;
                                thumbnail = null;
                            }
                            else if (extension == ".mp4" || extension == ".mkv" || extension == ".flv" || extension == ".avi" || extension == ".mov" || extension == ".wmv")//En teoria, esos son los tipos de archivos compatibles
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
                        picBoxArr[pL].ContextMenuStrip = contextMenuPictureBox;

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
                        bool transparent = false;
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
                            transparent = bool.Parse(match.BoolBackground);
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

                        if (transparent)
                        {
                            picBoxArr[pL].BackColor = Color.Transparent;
                        }

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
                                GeneralFunctions gf = new GeneralFunctions();

                                string[] rutasImagenes = subArchivos.Where(ruta => gf.CheckImage(ruta)).ToArray();

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

                    switch (config.SearchFilter)//searchType
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
                    picBoxArr[pL] = new PictureBox
                    {
                        AccessibleDescription = "collection",//Aqui se indica que tipo de picture box es (coleccion / archivo)
                        Name = colls[i].Name,//Aqui se guarda el nombre de la coleccion
                        Size = new Size(colls[i].Width, colls[i].Height),
                        BackColor = Color.FromArgb(colls[i].ColorRed, colls[i].ColorGreen, colls[i].ColorBlue),
                        Tag = colls[i].ID,//Aqui se guarda en que espacio del array estamos buscando//colls[i].ID,
                    };

                    if (colls[i].Background == true)
                    {
                        picBoxArr[pL].BackColor = Color.Transparent;
                    }

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

                    switch (config.SearchFilter)//searchType
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

                            GeneralFunctions gf = new GeneralFunctions();

                            fileW = int.Parse(gf.XMLDefaultReturn(root, "Width", "200"));
                            fileH = int.Parse(gf.XMLDefaultReturn(root, "Height", "200"));
                        } catch (Exception ex)
                        {
                            Console.WriteLine("\n///////\nNo se pudo cargar la resolucion del archivo xml\nerror\n"+ex);
                        }
                        
                    }

                    //Definir el picture box
                    picBoxArr[pL] = new PictureBox
                    {
                        AccessibleDescription = "file",//Aqui se indica que tipo de picture box es (coleccion / elemento(archivo))//,
                        Name = files[f].Name,
                        Size = new Size(fileW, fileH),
                        BackColor = Color.FromArgb(files[f].ColorRed, files[f].ColorGreen, files[f].ColorBlue),
                        /*
                        BackgroundImage = imagen,
                        */
                        //Text = "file",//Aqui se indica que tipo de picture box es (coleccion / archivo)
                        Tag = files[f].ID,//Aqui indico que espacio de su array estamos buscando //Aqui se guarda la id del archivo, para que cuando se haga click, se busque en el array lo que tiene y se abra
                    };

                    //Establecer un color translucido
                    if (files[f].Background == true)
                    {
                        picBoxArr[pL].BackColor = Color.Transparent;
                    }

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
            if (config.PanelOrder == 1)
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
            labelDepth.Visible = true;
        }

        #region TreeView
        private void treeViewMain_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            TreeNode node = e.Node;//Obtener el nodo que se va a dibujar

            //Establecer los colores
            Color defaultColor = theme.TreeViewBackground;
            Color hoverColor = theme.TreeViewHoverBackground;
            Color selectedColor = theme.TreeViewSelectedBackground;
            Color foreColor = theme.TreeViewText;

            //Determina si el nodo esta seleccionado
            bool selected = (e.State & TreeNodeStates.Selected) != 0;
            bool hover = (node == lastHoveredNode);

            //Nivel del nodo en jerarquia
            int offset = node.Level * 20; //Ajusta la posicion del texto del nodo en funcion del nivel en el que este

            //Recoger el area de dibujo del nodo
            //Rectangle bounds = e.Bounds;
            // Obtener el área de dibujo del nodo con el ancho total del control
            Rectangle bounds = new Rectangle(treeViewMain.Bounds.X, e.Bounds.Y, treeViewMain.Width, e.Bounds.Height);

            // Establece el color de fondo dependiendo del estado del nodo.
            //Color backColor = selected ? SystemColors.Highlight : SystemColors.Window;
            //Personalizar el fondo del nodo segun el estado
            Color backgroundColor;
            if (selected)//Nodo seleccionado
            {
                backgroundColor = selectedColor;
            }
            else if (hover)//Nodo con el mouse encima
            {
                //color hovermouse
                backgroundColor = hoverColor;
            }
            else //Default
            {
                backgroundColor = defaultColor;//Color.FromArgb(94, 105, 123);//SystemColors.Window;
            }

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
                    Rectangle lastNodeBounds = new Rectangle(treeViewMain.Bounds.X, lastHoveredNode.Bounds.Y, treeViewMain.Width, lastHoveredNode.Bounds.Height);
                    //Rectangle lastNodeBounds = lastHoveredNode.Bounds;
                    treeViewMain.Invalidate(lastNodeBounds); //volver a dibujar para restaurar el fondo del nodo anterior; // con lastNodeBound solo invalido la area especifica a redibujar
                    lastHoveredNode = null;
                }

                if (node != null)
                {
                    lastHoveredNode = node;
                    //Rectangle currentNodeBounds = node.Bounds;
                    Rectangle nodeBounds = new Rectangle(treeViewMain.Bounds.X, node.Bounds.Y, treeViewMain.Width, node.Bounds.Height);
                    treeViewMain.Invalidate(nodeBounds); //volver a dibujar para cambiar el fondo del nodo actual; // con currentNodeBounds solo invalido la area especifica a redibujar
                }
            }
        }

        private void treeViewMain_MouseLeave(object sender, EventArgs e)
        {
            if (lastHoveredNode != null)
            {
                treeViewMain.Invalidate();//(lastHoveredNode.Bounds); //volver a dibujar para restaurar el fondo del nodo anterior
                lastHoveredNode = null;
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
            colls = new Collections().LoadCollections(colSize);
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

                    GeneralFunctions gf = new GeneralFunctions();

                    int id = int.Parse(gf.XMLDefaultReturn(root, "IDFather", "0"));
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
            colSize = new Collections().GetCollectionsSize();//LoadCollectionSize();
            fileSize = new Files().GetFilesSize(); //LoadFilesSize();
            loadView(colSize, fileSize);
        }
        #endregion

        #region Manejar datos XML

        #region Configuraciones
        //Cargar las configuraciones de settings ( se tienen que ajustar algunos elementos del formulario)
        private void loadConfigurationsXML()
        {
            //cargar las configuraciones en el objeto de la clase
            config = new Configurations();

            viewDepth = config.LastDepth;//Ultima profundidad
            treeViewMain.Width = config.TreeViewWidth;//Ancho del treeview
            //Como se ordenan los paneles
            if (config.PanelOrder == 1)
            {
                nombreToolStripMenuItem.Checked = true;
                fechaDeCreacionToolStripMenuItem.Checked = false;
            }
            //orderPanels = settings.PanelOrder;
            //Tipo de filtro en la barra de busqueda
            switch (config.SearchFilter)
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

            if (config.WindowsMaxScreen == 0) WindowState = FormWindowState.Normal; else WindowState = FormWindowState.Maximized;
        }

        //Guardar las configuraciones (se tienen que ajustar algunas cosas)
        private void SaveConfigurationsXML()
        {
            //Guardar tamaño de treenode
            config.TreeViewWidth = treeViewMain.Width;

            //Guardar el tamaño actual de la venana
            config.WindowsWidth = Width;
            config.WindowsHeight = Height;
            if (WindowState == FormWindowState.Maximized) config.WindowsMaxScreen = 1;

            Configurations classConfig = new Configurations();

            classConfig.SaveConfigurations(config);
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
        }

        private void configuracionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            config.LastDepth = viewDepth;
            Configuration conf = new Configuration(config);
            conf.ReturnedObject += Configuration_ReturnedObject;
            conf.ShowDialog();
        }

        private void Configuration_ReturnedObject(object sender, Configurations e)
        {
            config = e;
            loadTheme();//Recargar el tema
            loadPictureBox(colSize, fileSize, false); //Recargar la vista
        }

        private void importaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion


        //Guardar los settings
        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveConfigurationsXML();
        }
    }
}
