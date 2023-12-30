using C_Launcher.Clases;
using CoverPadLauncher;
using CoverPadLauncher.Clases;
using ImageMagick;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace C_Launcher
{
    public partial class NewMultipleFiles : Form
    {
        private int currentX, currentY;
        private int resizing = 0; // 0=no se esta ajustando; 1=ajustando ancho; 2=ajustando alto; 3=ajustando ambos
        public event EventHandler<Files[]> ReturnedObject;
        private string xmlColPath = "System\\Collections.xml";//Para cargar el comboBox de las colecciones
        private int[] combID = new int[0];//Para recoger el index
        private string xmlResPath = "System\\Resolutions.xml";//Cargar el combobox de las resoluciones
        private int[] combResID = new int[0];//Para recoger el index
        private int rowSelected = -1;
        private string coverPath = "System\\Covers";

        //private int idFile = -1;//Si es un archivo nuevo -1, si no, se actualiza con el segundo constructor
        //private string xmlImagePath;//Lo ocupare para editar la caratula

        //Datos default al crear un nuevo archivo (al editar obviamente no es necesario)
        private int defaultFather, defaultRes, defaultImageLayout = 0;
        private int defaultWidth, defaultHeight = 200;
        private string defaultProgramPath, defaultCMDLine = "";

        //Combobox de las resoluciones
        private ComboBox CmbRes = new ComboBox();
        //Combobox del formato de la imagen (zoom-estirado)
        private ComboBox CmbImageFormat = new ComboBox();

        //Crear nuevos archivos desde 0
        public NewMultipleFiles(int viewDepth, int ResId, int Width, int Height, int Layout, string ProgramPath, string CMDline)
        {
            InitializeComponent();
            this.defaultFather = viewDepth;
            this.defaultRes = ResId;
            this.defaultWidth = Width;
            this.defaultHeight = Height;
            this.defaultImageLayout = Layout;
            this.defaultProgramPath = ProgramPath;
            this.defaultCMDLine = CMDline;
            CustomComponent();
        }

        //Editar los archivos de una coleccion
        public NewMultipleFiles(Files[] files, int viewDepth, int ResId, int Width, int Height, int Layout)
        {
            InitializeComponent();
            this.defaultFather = viewDepth;
            this.defaultRes = ResId;
            this.defaultWidth = Width;
            this.defaultHeight = Height;
            this.defaultImageLayout = Layout;
            CustomComponent();

            //No permitir poder agregar archivos cuando estas editando (no deberia dar problemas, pero por si acaso)
            this.buttonAddRow.Enabled = false;
            this.buttonAddRow.Visible = false;

            //Para agregarlo en el combobox
            ((DataGridViewComboBoxColumn)dataGridViewFiles.Columns["ColumnRes"]).DataSource = CmbRes.Items;
            ((DataGridViewComboBoxColumn)dataGridViewFiles.Columns["ColumnFormat"]).DataSource = CmbImageFormat.Items;
            //Iterar sobre los archivos a editar y añadirlos a la tabla
            for (int i = 0; i < files.Length; i++)
            {
                // Crear una nueva fila para el DataGridView
                //nombre, checkbox url, ruta archivo, ruta lanzador, cmd, ancho, alto, resolucion, ruta caratula, Formato imagen, Color de fondo
                this.dataGridViewFiles.Rows.Add(files[i].Name, files[i].URLCheck, files[i].FilePath, files[i].ProgramPath, files[i].CMDLine, files[i].Width, files[i].Height, null, files[i].ImagePath, null, files[i].Background, null);

                //Optimizar el combobox para que la opcion default sea "ninguno"
                int rowCount = dataGridViewFiles.Rows.Count;
                dataGridViewFiles.CurrentCell = dataGridViewFiles.Rows[rowCount - 1].Cells[0];
                //Combobox de las resoluciones
                int resolutionIndex = Array.IndexOf(combResID, files[i].ResolutionID);
                dataGridViewFiles.Rows[rowCount - 1].Cells[7].Value = (dataGridViewFiles.Rows[rowCount - 1].Cells[7] as DataGridViewComboBoxCell).Items[resolutionIndex+1];
                //Combobox del formato de imagen
                dataGridViewFiles.Rows[rowCount - 1].Cells[9].Value = (dataGridViewFiles.Rows[rowCount - 1].Cells[9] as DataGridViewComboBoxCell).Items[files[i].ImageLayout];
                //Color del boton
                DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
                CellStyle.BackColor = Color.FromArgb(255, files[i].ColorRed, files[i].ColorGreen, files[i].ColorBlue); ;
                dataGridViewFiles.Rows[rowCount - 1].Cells[11].Style = CellStyle;

                dataGridViewFiles.Rows[rowCount - 1].Tag = files[i].ID;//Para declarar que estos archivos son nuevos
                dataGridViewFiles.Rows[rowCount - 1].Selected = true;
                rowSelected = rowCount - 1;
            }
        }

        private void CustomComponent()
        {

            loadTheme();

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

            #region resoluciones
            //Agregando item default
            CmbRes.Items.Add("Ninguno");
            CmbRes.SelectedIndex = 0;//Se selecciona despues

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

                CmbRes.Items.Add(name + " (" + width + " x" + height + ")");
                combResID[i - 1] = resID;
                resID++;
            }

            //Buscar dentro del combobox de resoluciones el index de la resolucion
            int resIndex = Array.IndexOf(combResID, defaultRes);
            comboBoxResolution.DataSource = CmbRes.Items;
            comboBoxResolution.SelectedIndex = resIndex + 1;
            #endregion

            #region formato de la imagen
            CmbImageFormat.Items.Add("Mantener escala");
            CmbImageFormat.Items.Add("Estirar");
            CmbImageFormat.SelectedIndex = defaultImageLayout;
            int defaultImage = defaultImageLayout;

            if (defaultFather > 0)
            {
                XmlDocument docF = new XmlDocument();
                docF.Load(xmlColPath);

                string xpathF = "//Launcher/collection[@id='" + defaultFather + "']";
                XmlNode rootF = docF.SelectSingleNode(xpathF);
                if (rootF.SelectSingleNode("SonImageLayout") != null)
                {
                    defaultImage = int.Parse(rootF.SelectSingleNode("SonImageLayout").InnerText);
                    if (defaultImage < 0) defaultImage = 0;
                    if (defaultImage > 1) defaultImage = 1;
                }
            }
            
            

            comboBoxImageFormat.DataSource = CmbImageFormat.Items;
            comboBoxImageFormat.SelectedIndex = defaultImage;
            #endregion

            #endregion

            //textbox
            if (defaultProgramPath != null) textBoxGlobalLauncher.Text = defaultProgramPath;
            if (defaultCMDLine != null) textBoxGlobalCMD.Text = defaultCMDLine;
        }

        private void loadTheme()
        {
            Configurations config = new Configurations();
            Themes theme = new Themes($"System\\Themes\\{config.ThemeName}.css");

            BackColor = theme.WindowBackground;

            //TextBox
            textBoxGlobalLauncher.BackColor = theme.TextBoxBackground;
            textBoxGlobalLauncher.ForeColor = theme.TextBoxText;
            textBoxGlobalCMD.BackColor = theme.TextBoxBackground;
            textBoxGlobalCMD.ForeColor = theme.TextBoxText;

            //Textos
            labelFather.ForeColor = theme.LabelText;
            labelGlobalRes.ForeColor = theme.LabelText;
            labelGlobalImageFormat.ForeColor = theme.LabelText;
            labelGlobalLauncher.ForeColor = theme.LabelText;
            labelGlobalCMD.ForeColor = theme.LabelText;

            //Combobox
            comboBoxFather.BackColor = theme.ComboboxBackground;
            comboBoxFather.ForeColor = theme.ComboboxText;
            comboBoxResolution.BackColor = theme.ComboboxBackground;
            comboBoxResolution.ForeColor = theme.ComboboxText;
            comboBoxImageFormat.BackColor = theme.ComboboxBackground;
            comboBoxImageFormat.ForeColor = theme.ComboboxText;

            //Botones
            buttonAddRow.BackColor = theme.ButtonBackground;
            buttonAddRow.ForeColor = theme.ButtonText;
            buttonDeleteRow.BackColor = theme.ButtonBackground;
            buttonDeleteRow.ForeColor = theme.ButtonText;
            addResolution.BackColor = theme.ButtonBackground;
            addResolution.ForeColor = theme.ButtonText;
            buttonGlobalResolution.BackColor = theme.ButtonBackground;
            buttonGlobalResolution.ForeColor = theme.ButtonText;
            buttonGlobalImageFormat.BackColor = theme.ButtonBackground;
            buttonGlobalImageFormat.ForeColor = theme.ButtonText;
            buttonGlobalLauncher.BackColor = theme.ButtonBackground;
            buttonGlobalLauncher.ForeColor = theme.ButtonText;
            buttonDeleteGlobalLauncher.BackColor = theme.ButtonBackground;
            buttonDeleteGlobalLauncher.ForeColor = theme.ButtonText;
            buttonGlobalCMD.BackColor = theme.ButtonBackground;
            buttonGlobalCMD.ForeColor = theme.ButtonText;
            buttonSearchCoversOnline.BackColor = theme.ButtonBackground;
            buttonSearchCoversOnline.ForeColor = theme.ButtonText;
            buttonSearchCoverOnlineRow.BackColor = theme.ButtonBackground;
            buttonSearchCoverOnlineRow.ForeColor = theme.ButtonText;
            buttonSelectCover.BackColor = theme.ButtonBackground;
            buttonSelectCover.ForeColor = theme.ButtonText;
            buttonDeleteCoverRow.BackColor = theme.ButtonBackground;
            buttonDeleteCoverRow.ForeColor = theme.ButtonText;
            buttonSave.BackColor = theme.ButtonBackground;
            buttonSave.ForeColor = theme.ButtonText;

            //Datagridview
            dataGridViewFiles.BackgroundColor = theme.DataGridBackground;
            dataGridViewFiles.GridColor = theme.DataGridBorder;
            dataGridViewFiles.DefaultCellStyle.BackColor = theme.DataGridCellBackground;
            dataGridViewFiles.DefaultCellStyle.ForeColor = theme.DataGridCellText;
            dataGridViewFiles.DefaultCellStyle.SelectionBackColor = theme.DataGridSelectedBackground;
            dataGridViewFiles.DefaultCellStyle.SelectionForeColor = theme.DataGridSelectedText;

            //Panel de las caratulas
            panelImageLimit.BackColor = theme.CoverPreviewBackground;
        }

        #region Manejar dataGridView
        //Añadir archivo/archivos
        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFiles = new OpenFileDialog();
            openFiles.Multiselect = true;

            if (openFiles.ShowDialog() == DialogResult.OK)
            {
                // Obtener la lista de archivos seleccionados
                string[] archivosSeleccionados = openFiles.FileNames;
                //Establecer el combobox de las resoluciones
                ((DataGridViewComboBoxColumn)dataGridViewFiles.Columns["ColumnRes"]).DataSource = CmbRes.Items;
                ((DataGridViewComboBoxColumn)dataGridViewFiles.Columns["ColumnFormat"]).DataSource = CmbImageFormat.Items;

                //Agregar los archivos
                for (int i = 0; i < archivosSeleccionados.Length; i++)
                {
                    string texto = archivosSeleccionados[i];

                    //Extraer el nombre del open file dialog (nombre archivo)
                    string fileName = Path.GetFileNameWithoutExtension(texto);

                    // Crear una nueva fila para el DataGridView
                    //nombre, checkbox url, ruta archivo, ruta lanzador, cmd, ancho, alto, resolucion, ruta caratula, Formato imagen, Color de fondo
                    this.dataGridViewFiles.Rows.Add(fileName, false, texto, textBoxGlobalLauncher.Text, textBoxGlobalCMD.Text, defaultWidth, defaultHeight, null, "", null, null);

                    //Optimizar el combobox para que la opcion default sea "ninguno"
                    int rowCount = dataGridViewFiles.Rows.Count;
                    dataGridViewFiles.CurrentCell = dataGridViewFiles.Rows[rowCount - 1].Cells[0];

                    //Combobox de las resoluciones
                    //dataGridViewFiles.Rows[rowCount - 1].Cells[7].Value = (dataGridViewFiles.Rows[rowCount - 1].Cells[7] as DataGridViewComboBoxCell).Items[0];
                    dataGridViewFiles.Rows[rowCount - 1].Cells[7].Value = (dataGridViewFiles.Rows[rowCount - 1].Cells[7] as DataGridViewComboBoxCell).Items[comboBoxResolution.SelectedIndex];
                    //Combobox del formato de imagen
                    dataGridViewFiles.Rows[rowCount - 1].Cells[9].Value = (dataGridViewFiles.Rows[rowCount - 1].Cells[9] as DataGridViewComboBoxCell).Items[comboBoxImageFormat.SelectedIndex];
                    //Color del boton
                    DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
                    CellStyle.BackColor = Color.FromArgb(255, 0, 0, 0); ;
                    dataGridViewFiles.Rows[rowCount - 1].Cells[11].Style = CellStyle;

                    dataGridViewFiles.Rows[rowCount - 1].Tag = -1;//Para declarar que estos archivos son nuevos
                    dataGridViewFiles.Rows[rowCount - 1].Selected = true;
                    rowSelected = rowCount - 1;
                }
            }
            openFiles.Dispose();
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            if (rowSelected != -1)
            {
                this.dataGridViewFiles.Rows.RemoveAt(rowSelected);
                if (rowSelected > dataGridViewFiles.Rows.Count - 1) rowSelected--;
            }
        }

        private void dataGridViewFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("\n/////////");
            Console.WriteLine("fila num: " + e.RowIndex);

            if (e.RowIndex > -1)
            {
                DataGridViewRow selectedRow = dataGridViewFiles.Rows[e.RowIndex];

                Console.WriteLine("tag de la fila: " + selectedRow.Tag);
                rowSelected = e.RowIndex;

                #region PictureBox
                //Tomar la ruta de la caratula de la columna 8 y establecerlo en el picture Box junto al ancho y alto
                string coverDir = dataGridViewFiles.Rows[rowSelected].Cells[8].Value?.ToString();
                if (coverDir != "" || coverDir != null)
                {
                    if (coverDir.StartsWith("https://") || coverDir.StartsWith("http://"))
                    {
                        try
                        {
                            // Descargar la imagen desde la URL
                            using (WebClient webClient = new WebClient())
                            {
                                byte[] imageBytes = webClient.DownloadData(coverDir);

                                // Crear un MemoryStream desde los bytes
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    // Crear una imagen desde el MemoryStream
                                    Image image = Image.FromStream(ms);

                                    // Mostrar la imagen en el PictureBox u otro control
                                    pictureBoxCover.BackgroundImage = image;

                                    // Realizar otras operaciones según sea necesario...
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"No se pudo descargar la caratula de la url: \n{coverDir}\n debido a: {ex}");
                        }
                    } else {
                        try
                        {
                            //Establecer la caratula en el picture Box
                            Image image;
                            image = loadImage(coverDir);
                            pictureBoxCover.BackgroundImage = image;
                            pictureBoxCover.Tag = coverDir;
                            image = null;
                        }
                        catch (Exception ex)
                        {
                            pictureBoxCover.BackgroundImage = null;
                            pictureBoxCover.Tag = null;
                            Console.WriteLine($"No se pudo establecer una caratula en dataGridViewFiles_CellClick debido a el error: {ex}");
                        }
                    }
                       
                }
                //Verificar si tiene una resolucion para establecer el tamaño, si no, establecer el tamaño de ancho y alto
                int resID = 0;
                int selectedIndex = comboBoxResolution.Items.IndexOf(dataGridViewFiles.Rows[rowSelected].Cells[7].Value);
                if (selectedIndex > 0)
                {
                    resID = combResID[selectedIndex - 1];
                }

                if (resID != 0)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlResPath);

                    string xpath = "//Launcher/resolution[@id='" + resID + "']";
                    XmlNode root = doc.SelectSingleNode(xpath);

                    int width = int.Parse(root.SelectSingleNode("Width").InnerText);
                    int height = int.Parse(root.SelectSingleNode("Height").InnerText);

                    //Cambiar el tamaño con respecto a la resolucion escogida
                    pictureBoxCover.Width = width; pictureBoxCover.Height = height;
                } else
                {
                    int width = int.Parse(dataGridViewFiles.Rows[rowSelected].Cells[5].Value.ToString());
                    int height = int.Parse(dataGridViewFiles.Rows[rowSelected].Cells[6].Value.ToString());
                    pictureBoxCover.Width = width; pictureBoxCover.Height = height;
                }
                //Formato de la imagen
                int selectedLayoutIndex = comboBoxImageFormat.Items.IndexOf(dataGridViewFiles.Rows[rowSelected].Cells[9].Value);
                if (selectedLayoutIndex == 1)
                {
                    pictureBoxCover.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    pictureBoxCover.BackgroundImageLayout = ImageLayout.Zoom;
                }
                #endregion

                switch (e.ColumnIndex)
                {
                    case 2:
                        //Buscar un archivo
                        //No tiene filtro
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            dataGridViewFiles.Rows[e.RowIndex].Cells[2].Value = openFileDialog.FileName;
                        }
                        openFileDialog.Dispose();
                        break;
                    case 3:
                        //Buscar el programa
                        OpenFileDialog openProgramDialog = new OpenFileDialog();
                        if (openProgramDialog.ShowDialog() == DialogResult.OK)
                        {
                            dataGridViewFiles.Rows[e.RowIndex].Cells[3].Value = openProgramDialog.FileName;
                        }
                        openProgramDialog.Dispose();
                        break;
                    case 8:
                        //Busca la caratula
                        OpenFileDialog openDialog = new OpenFileDialog();
                        openDialog.Filter = "Archivos de imagen(*.png; *.jpg; *.jpeg; *.webp;)| *.png; *.jpg; *.jpeg; *.webp;";
                        if (openDialog.ShowDialog() == DialogResult.OK)
                        {
                            dataGridViewFiles.Rows[e.RowIndex].Cells[8].Value = openDialog.FileName;
                            //Establecer la caratula en el picture Box
                            Image image;
                            image = loadImage(openDialog.FileName);
                            pictureBoxCover.BackgroundImage = image;
                            pictureBoxCover.Tag = openDialog.FileName;
                            image = null;
                        }
                        openDialog.Dispose();
                        break;
                    case 11:
                        //Cambiar el color de fondo
                        ColorDialog colorDialog = new ColorDialog();

                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Aquí obtienes el color seleccionado
                            Color selectedColor = colorDialog.Color;

                            dataGridViewFiles.Rows[e.RowIndex].Cells[10].Style.BackColor = selectedColor;
                            //Para poder ver el color
                            this.dataGridViewFiles.CurrentCell.Selected = false;
                        }
                        break;
                }
            }
        }

        private void dataGridViewFiles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int width = 200;
            int height = 200;
            //Identificar si se esta ajustando el ancho o el alto
            switch (e.ColumnIndex)
            {
                case 5://Ancho
                    
                    try
                    {
                        width = int.Parse(dataGridViewFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        if (width < 100) { width = 100; dataGridViewFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "100"; }
                        if (width > 300) { width = 300; dataGridViewFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "300"; }
                    }
                    catch
                    {
                        //Si da un error, es por que no se pudo transformar el contenido puesto a int, transformarlo
                        dataGridViewFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = width;
                    }

                    pictureBoxCover.Width = width;
                break;

                case 6://Alto
                    
                    try
                    {
                        height = int.Parse(dataGridViewFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        if (height < 100) { height = 100; dataGridViewFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "100"; }
                        if (height > 300) { height = 300; dataGridViewFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "300"; }
                    }
                    catch
                    {
                        //Si da un error, es por que no se pudo transformar el contenido puesto a int, transformarlo
                        dataGridViewFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = height;
                    }
                    pictureBoxCover.Height = height;
                    break;

                case 7://Resolucion
                    int resID = 0;
                    int selectedIndex = comboBoxResolution.Items.IndexOf(dataGridViewFiles.Rows[e.RowIndex].Cells[7].Value);
                    if (selectedIndex > 0)
                    {
                        resID = combResID[selectedIndex - 1];
                    }

                    if (resID != 0)
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(xmlResPath);

                        string xpath = "//Launcher/resolution[@id='" + resID + "']";
                        XmlNode root = doc.SelectSingleNode(xpath);

                        width = int.Parse(root.SelectSingleNode("Width").InnerText);
                        height = int.Parse(root.SelectSingleNode("Height").InnerText);

                        //Cambiar el tamaño con respecto a la resolucion escogida
                        pictureBoxCover.Width = width; pictureBoxCover.Height = height;
                    }
                    break;

                case 9://Formato de la imagen
                    int selectedLayoutIndex = comboBoxImageFormat.Items.IndexOf(dataGridViewFiles.Rows[e.RowIndex].Cells[9].Value);
                    if (selectedLayoutIndex == 1)
                    {
                        pictureBoxCover.BackgroundImageLayout = ImageLayout.Stretch;
                    } else
                    {
                        pictureBoxCover.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    break;
            }

        }
        #endregion

        #region Opciones globales
        private void buttonGlobalResolution_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewFiles.RowCount; i++)
            {
                dataGridViewFiles.Rows[i].Cells[7].Value = (dataGridViewFiles.Rows[i].Cells[7] as DataGridViewComboBoxCell).Items[comboBoxResolution.SelectedIndex];
            }
        }

        private void buttonGlobalImageFormat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewFiles.RowCount; i++)
            {
                dataGridViewFiles.Rows[i].Cells[9].Value = (dataGridViewFiles.Rows[i].Cells[9] as DataGridViewComboBoxCell).Items[comboBoxImageFormat.SelectedIndex];
            }
        }

        //Establecer el lanzador global
        private void textBoxGlobalLauncher_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog openProgramDialog = new OpenFileDialog();
            if (openProgramDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxGlobalLauncher.Text = openProgramDialog.FileName;
            }
            openProgramDialog.Dispose();
        }

        //Establecer el lanzador global en todas las filas
        private void buttonGlobalLauncher_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewFiles.RowCount; i++)
            {
                dataGridViewFiles.Rows[i].Cells[3].Value = textBoxGlobalLauncher.Text;
            }
        }

        //Eliminar el lanzador global
        private void buttonDeleteGlobalLauncher_Click(object sender, EventArgs e)
        {
            textBoxGlobalLauncher.Text = "";
        }

        //Establecer el argumento de inicio en todas las filas
        private void buttonGlobalCMD_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewFiles.RowCount; i++)
            {
                dataGridViewFiles.Rows[i].Cells[4].Value = textBoxGlobalCMD.Text;
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
                comboBoxResolution.DataSource = null;
                comboBoxResolution.Items.Clear();
                CmbRes.Items.Clear();
                //Agregando item default
                CmbRes.Items.Add("Ninguno");
                CmbRes.SelectedIndex = 0;//Se selecciona despues

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

                    CmbRes.Items.Add(name + " (" + width + " x" + height + ")");
                    combResID[i - 1] = resID;
                    resID++;
                }

                //Buscar dentro del combobox de resoluciones el index de la resolucion
                int resIndex = Array.IndexOf(combResID, defaultRes);
                comboBoxResolution.DataSource = CmbRes.Items;
                comboBoxResolution.SelectedIndex = resIndex + 1;
                #endregion
            }
        }

        //Buscar las caratulas online
        private void buttonSearchCoversOnline_Click(object sender, EventArgs e)
        {
            //Crear un array de los elementos y pasarselos al windowsForm
            string[,] passElement = new string[dataGridViewFiles.RowCount, 2];

            for (int i = 0; i < dataGridViewFiles.RowCount; i++)
            {
                passElement[i, 0] = dataGridViewFiles.Rows[i].Cells[0].Value.ToString();//Nombre elemento
                passElement[i, 1] = dataGridViewFiles.Rows[i].Cells[2].Value.ToString();//Direccion
            }

            SearchCoversOnline sco = new SearchCoversOnline(passElement);
            sco.ReturnedObject += SearchCoverOnline_ReturnedObject;
            sco.ShowDialog();
        }

        private void SearchCoverOnline_ReturnedObject(object sender, string[,] e)
        {
            for (int i=0; i < dataGridViewFiles.RowCount; i++)
            {
                //Nombre elemento
                dataGridViewFiles.Rows[i].Cells[0].Value = e[i, 0];
                //Ruta caratula
                string coverValue = "";
                if (e[i, 1] != null) coverValue = e[i, 1];

                dataGridViewFiles.Rows[i].Cells[8].Value = coverValue;
            }

            //Actualizar la caratula
            try
            {
                //Actualizar la caratula con la fila seleccionada
                int sR = dataGridViewFiles.CurrentCell.RowIndex;//Fila seleccionada
                string downloadImage = dataGridViewFiles.Rows[sR].Cells[8].Value.ToString();
                // Descargar la imagen desde la URL
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(downloadImage);

                    // Crear un MemoryStream desde los bytes
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        // Crear una imagen desde el MemoryStream
                        Image image = Image.FromStream(ms);

                        // Mostrar la imagen en el PictureBox u otro control
                        pictureBoxCover.BackgroundImage = image;

                        // Realizar otras operaciones según sea necesario...
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo establecer la caratula de la url: \n{e[0, 1]}\n debido a: {ex}");
            }
        }

        private void buttonSearchCoverOnlineRow_Click(object sender, EventArgs e)
        {
            int sR = dataGridViewFiles.CurrentCell.RowIndex;//Fila seleccionada

            //Crear un array de los elementos y pasarselos al windowsForm
            string[,] passElement = new string[1, 2];

            passElement[0, 0] = dataGridViewFiles.Rows[sR].Cells[0].Value.ToString();//Nombre elemento
            passElement[0, 1] = dataGridViewFiles.Rows[sR].Cells[2].Value.ToString();//Direccion



            SearchCoversOnline sco = new SearchCoversOnline(passElement);
            sco.ReturnedObject += SearchCoverOnlineRow_ReturnedObject;
            sco.ShowDialog();
        }

        private void SearchCoverOnlineRow_ReturnedObject(object sender, string[,] e)
        {
            int sR = dataGridViewFiles.CurrentCell.RowIndex;//Fila seleccionada
            //Nombre elemento
            dataGridViewFiles.Rows[sR].Cells[0].Value = e[0, 0];
            //Ruta caratula
            dataGridViewFiles.Rows[sR].Cells[8].Value = e[0, 1];

            //Actualizar la caratula
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
                        pictureBoxCover.BackgroundImage = image;

                        // Realizar otras operaciones según sea necesario...
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo establecer la caratula de la url: \n{e[0, 1]}\n debido a: {ex}");
            }
        }

        private void buttonSelectCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;*.webp;*.gif)|*.png;*.jpg;*.jpeg;*.webp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int sR = dataGridViewFiles.CurrentCell.RowIndex;
                dataGridViewFiles.Rows[sR].Cells[8].Value = openFileDialog.FileName;
                Image image;
                image = loadImage(openFileDialog.FileName);
                pictureBoxCover.BackgroundImage = image;
                pictureBoxCover.Tag = openFileDialog.FileName;
                image = null;
            }
            openFileDialog.Dispose();
        }

        //Para reducir el tamaño de las imagenes del picture box
        private Image loadImage(string imagePath)
        {
            Console.WriteLine($"Image path: {imagePath}");
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

        private void buttonDeleteCoverRow_Click(object sender, EventArgs e)
        {
            int sR = dataGridViewFiles.CurrentCell.RowIndex;
            dataGridViewFiles.Rows[sR].Cells[8].Value = "";
            pictureBoxCover.BackgroundImage = null;
            pictureBoxCover.Tag = null;
        }

        #endregion

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

            //Referencia al datagridview

            int idFather = 0;
            int rowCount = dataGridViewFiles.RowCount;

            if ((comboBoxFather.SelectedIndex - 1) >= 0)
            {
                idFather = combID[comboBoxFather.SelectedIndex - 1];
            }

            Files[] passFile = new Files[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                int fileID = int.Parse(dataGridViewFiles.Rows[i].Tag.ToString());

                //Id de la resolucion
                int resID = 0;
                int selectedIndex = comboBoxResolution.Items.IndexOf(dataGridViewFiles.Rows[i].Cells[7].Value);
                if (selectedIndex > 0)
                {
                    resID = combResID[selectedIndex - 1];
                }
                

                string nameFile = dataGridViewFiles.Rows[i].Cells[0].Value?.ToString();
                string imgPath = dataGridViewFiles.Rows[i].Cells[8].Value?.ToString();
                //Evitar que se guarde la imagen con caracteres invalidos
                //string cleanName = Path.GetInvalidFileNameChars().Aggregate(nameFile, (current, c) => current.Replace(c.ToString(), string.Empty));
                //string imgPath = "";

                //Guardar la imagen
                /*if (cellImgPath != "")
                {
                    /*if (checkBoxImageLocation.Checked == true)
                    {
                        imgPath = pictureBoxCover.Tag.ToString();
                    }
                    else
                    {*//*
                        //string outputFolder = System.Environment.CurrentDirectory + "\\System\\Covers";
                        string outputFolder = coverPath;

                        imgPath = returnImagePath(outputFolder, cleanName);

                        if (!Directory.Exists(outputFolder))
                        {
                            // Crea la carpeta si no existe
                            Directory.CreateDirectory(outputFolder);
                        }

                        string source = cellImgPath;
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
                   // }
                }*/

                //Image layout
                int imgLayout = 0;
                int selectedLayoutIndex = comboBoxImageFormat.Items.IndexOf(dataGridViewFiles.Rows[i].Cells[9].Value);
                if (selectedLayoutIndex > 0)
                {
                    imgLayout = selectedLayoutIndex;
                }
                //if (radioButtonEstreched.Checked == true) imgLayout = 1;

                string filePath = dataGridViewFiles.Rows[i].Cells[2].Value?.ToString();
                string programPath = dataGridViewFiles.Rows[i].Cells[3].Value?.ToString();
                string cmdLine = dataGridViewFiles.Rows[i].Cells[4].Value?.ToString();
                bool background = Convert.ToBoolean(dataGridViewFiles.Rows[i].Cells[10].Value?.ToString());//Convert.ToBoolean transforma los null en false
                int R = dataGridViewFiles.Rows[i].Cells[11].Style.BackColor.R;
                int G = dataGridViewFiles.Rows[i].Cells[11].Style.BackColor.G;
                int B = dataGridViewFiles.Rows[i].Cells[11].Style.BackColor.B;
                int width = int.Parse(dataGridViewFiles.Rows[i].Cells[5].Value?.ToString());
                int height = int.Parse(dataGridViewFiles.Rows[i].Cells[6].Value?.ToString());
                bool url = Convert.ToBoolean(dataGridViewFiles.Rows[i].Cells[1].Value?.ToString());
                int[] tagsArray = new int[] { };
                bool favorite = false;


                Files tempFile = new Files(fileID, idFather, nameFile, imgPath, imgLayout, filePath, programPath, cmdLine, background, R, G, B, resID, width, height, url, tagsArray, favorite);
                passFile[i] = tempFile;

                //Files passFile = new Files(idFile, idFather, nameFile, imgPath, imgLayout, filePath, programPath, cmdLine, R, G, B, resID, width, height, url, tagsArray, favorite);
            }
            ReturnedObject?.Invoke(this, passFile);
            this.Close();
        }
    }
}
