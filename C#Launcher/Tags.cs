using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace CoverPadLauncher
{
    public partial class Tags : Form
    {
        private int rowSelected = -1;
        private string xmlTagPath = "System\\Tags.xml";
        private int maxID = 0;
        public event EventHandler<bool> ReturnedObject;

        public Tags()
        {
            InitializeComponent();
            loadXMLTags();

            dataGridViewTags.BackgroundColor = Color.BlueViolet;//Fondo
            dataGridViewTags.GridColor = Color.Blue;//Borde
            dataGridViewTags.DefaultCellStyle.BackColor = Color.Red;//Fondo celda default
            dataGridViewTags.DefaultCellStyle.ForeColor = Color.White;//texto celda default
            dataGridViewTags.DefaultCellStyle.SelectionBackColor = Color.Yellow;//Fondo celda seleccionada
            dataGridViewTags.DefaultCellStyle.SelectionForeColor = Color.Black;//texto celda seleccionada

        }

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


                this.dataGridViewTags.Rows.Add(name);
                DataGridViewRow selectedRow = dataGridViewTags.Rows[i];
                selectedRow.Tag = tagID;

                //Iterar al siguiente elemento
                tagID++;
            }
            //Establecer el tag mas grande encontrado
            maxID = tagID - 1;//le resto 1 por que al final del bucle for, para pasar al siguiente, le sumo 1

            int rowCount = dataGridViewTags.Rows.Count;

            if (rowCount > 0)
            {
                //Seleccionar por defecto la primera fila
                dataGridViewTags.CurrentCell = dataGridViewTags.Rows[0].Cells[0];
                dataGridViewTags.Rows[0].Selected = true;
                rowSelected = 0;

                DataGridViewRow selectedRow = dataGridViewTags.Rows[0];
            }
        }

        private void addTag_Click(object sender, EventArgs e)
        {
            if (textBoxTagName.Text != "")
            {
                this.dataGridViewTags.Rows.Add(textBoxTagName.Text);
                int rowCount = dataGridViewTags.Rows.Count;
                dataGridViewTags.CurrentCell = dataGridViewTags.Rows[rowCount - 1].Cells[0];
                dataGridViewTags.Rows[rowCount - 1].Selected = true;
                maxID++;//Sumarle 1 al id maximo
                dataGridViewTags.Rows[rowCount - 1].Tag = maxID;//Asignar el id a la fila

                textBoxTagName.Clear();

            }
        }

        private void deleteTag_Click(object sender, EventArgs e)
        {
            if (rowSelected != -1)
            {
                this.dataGridViewTags.Rows.RemoveAt(rowSelected);
                if (rowSelected > dataGridViewTags.Rows.Count - 1) rowSelected--;
            }
        }

        private void dataGridViewTags_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow selectedRow = dataGridViewTags.Rows[e.RowIndex];

                rowSelected = e.RowIndex;
            }
        }

        private void saveForm_Click(object sender, EventArgs e)
        {
            //Como todas las etiquetas se muestran en la tabla y se pueden modificar todas, se reseteara el xml cada vez que se vaya a ocupar
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
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

            //Despues de cargar el archivo xml, eliminar todos sus elementos
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlTagPath);
            XmlNode root = xmlDoc.DocumentElement;
            root.RemoveAll();

            //Recorrer la tabla e introducir los elementos desde alli
            for (int i = 0; i < dataGridViewTags.Rows.Count; i++)
            {
                DataGridViewRow selectedRow = dataGridViewTags.Rows[i];

                int gridTag = int.Parse(selectedRow.Tag.ToString());
                XmlElement tag;
                tag = xmlDoc.CreateElement("tag");
                tag.SetAttribute("id", gridTag + "");//establecer el atributo id

                //Añadirlo a la raiz "launcher"
                root.AppendChild(tag);

                XmlElement tagName = xmlDoc.CreateElement("Name"); tagName.InnerText = selectedRow.Cells[0].Value.ToString(); tag.AppendChild(tagName);

            }

            //Despues del bucle, guardar el archivo
            xmlDoc.Save(xmlTagPath);

            //cerrar
            ReturnedObject?.Invoke(this, true);
            this.Close();
        }
    }
}
