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
    public partial class NewMultipleFiles : Form
    {
        private int currentX, currentY;
        private int resizing = 0; // 0=no se esta ajustando; 1=ajustando ancho; 2=ajustando alto; 3=ajustando ambos
        public event EventHandler<Files> ReturnedObject;
        private string xmlColPath = "System\\Collections.xml";//Para cargar el comboBox de las colecciones
        private int[] combID = new int[0];//Para recoger el index
        private string xmlResPath = "System\\Resolutions.xml";//Cargar el combobox de las resoluciones
        private int[] combResID = new int[0];//Para recoger el index
        private int rowSelected = -1;
        private string coverPath = "System\\Covers";

        private int idFile = -1;//Si es un archivo nuevo -1, si no, se actualiza con el segundo constructor
        private string xmlImagePath;//Lo ocupare para editar la caratula

        //Datos default al crear un nuevo archivo (al editar obviamente no es necesario)
        private int defaultFather, defaultRes, defaultImageLayout = 0;
        private int defaultWidth, defaultHeight = 200;

        //Combobox de las resoluciones
        private ComboBox CmbRes = new ComboBox();
        public NewMultipleFiles(int viewDepth, int ResId, int Width, int Height, int Layout)
        {
            InitializeComponent();
            this.defaultFather = viewDepth;
            this.defaultRes = ResId;
            this.defaultWidth = Width;
            this.defaultHeight = Height;
            this.defaultImageLayout = Layout;
            CustomComponent();
        }

        private void CustomComponent()
        {

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

            /*if (resIndex + 1 > 0)
            {
                groupBoxSize.Enabled = false;
            }*/
            #endregion
            #endregion
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            //76

            ((DataGridViewComboBoxColumn)dataGridViewFiles.Columns["ColumnRes"]).DataSource = CmbRes.Items;

            this.dataGridViewFiles.Rows.Add("", false, "","","",200,200, null, "");
            int rowCount = dataGridViewFiles.Rows.Count;
            dataGridViewFiles.CurrentCell = dataGridViewFiles.Rows[rowCount - 1].Cells[0];
            dataGridViewFiles.Rows[rowCount - 1].Cells[7].Value = "Ninguno";
            dataGridViewFiles.Rows[rowCount - 1].Selected = true;

            //maxTag++;//Sumarle 1 al tag maximo
            //dataGridViewFiles.Rows[rowCount - 1].Tag = maxTag;//Asignar el id a la fila

            //rowSelected = rowCount - 1;
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            if (rowSelected != -1)
            {
                //int rowIndex = dataGridViewResolutions.CurrentRow.Index;
                //DataGridViewRow selectedRow = dataGridViewResolutions.Rows[rowIndex];
                //rowSelected = rowIndex - 1;
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
            }
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

        }
    }
}
