using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using CoverPadLauncher.Clases;

namespace C_Launcher
{
    public partial class Resolution : Form
    {
        private int currentX, currentY;
        private int resizing = 0; // 0=no se esta ajustando; 1=ajustando ancho; 2=ajustando alto; 3=ajustando ambos
        public event EventHandler<bool> ReturnedObject;
        private int rowSelected = -1;
        private string xmlResPath = "System\\Resolutions.xml";
        private int maxTag = 0;

        public Resolution()
        {
            InitializeComponent();
            this.pictureBoxCover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseDown);
            this.pictureBoxCover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseMove);
            this.pictureBoxCover.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseUp);
            //Cargar el tema
            loadTheme();
            //Cargar las resoluciones en el dataGrid
            loadXMLResolutions();
        }

        private void loadXMLResolutions()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlResPath);

            //Recoger la cantidad de elementos que existen
            XmlNodeList resElements = xmlDoc.SelectNodes("//*[@id]");
            int size = resElements.Count;

            int resID = 1;
            for (int i = 0; i < size; i++)
            {
                //Buscamos el elemento a recoger
                string xpath = "//Launcher/resolution[@id='" + resID + "']";
                XmlNode root = xmlDoc.SelectSingleNode(xpath);

                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {

                    resID++;
                    xpath = "//Launcher/resolution[@id='" + resID + "']";
                    root = xmlDoc.SelectSingleNode(xpath);
                }

                string name = root.SelectSingleNode("Name").InnerText;
                int width = int.Parse(root.SelectSingleNode("Width").InnerText);
                int height = int.Parse(root.SelectSingleNode("Height").InnerText);


                this.dataGridViewResolutions.Rows.Add(name, width, height);
                DataGridViewRow selectedRow = dataGridViewResolutions.Rows[i];
                selectedRow.Tag = resID;

                //Iterar al siguiente elemento
                resID++;
            }
            //Establecer el tag mas grande encontrado
            maxTag = resID-1;//le resto 1 por que al final del bucle for, para pasar al siguiente, le sumo 1

            int rowCount = dataGridViewResolutions.Rows.Count;

            if (rowCount > 0)
            {
                //Seleccionar por defecto la primera fila
                dataGridViewResolutions.CurrentCell = dataGridViewResolutions.Rows[0].Cells[0];
                dataGridViewResolutions.Rows[0].Selected = true;
                rowSelected = 0;

                DataGridViewRow selectedRow = dataGridViewResolutions.Rows[0];

                pictureBoxCover.Width = int.Parse(selectedRow.Cells[1].Value.ToString());
                pictureBoxCover.Height = int.Parse(selectedRow.Cells[2].Value.ToString());
            }
            
        }

        private void loadTheme()
        {
            Configurations config = new Configurations();
            Themes theme = new Themes($"System\\Themes\\{config.ThemeName}.css");

            BackColor = theme.WindowBackground;

            //Botones
            buttonAddRow.BackColor = theme.ButtonBackground;
            buttonAddRow.ForeColor = theme.ButtonText;
            buttonDeleteRow.BackColor = theme.ButtonBackground;
            buttonDeleteRow.ForeColor = theme.ButtonText;
            buttonSearchSonCoverTest.BackColor = theme.ButtonBackground;
            buttonSearchSonCoverTest.ForeColor = theme.ButtonText;
            buttonSaveRes.BackColor = theme.ButtonBackground;
            buttonSaveRes.ForeColor = theme.ButtonText;

            //Datagrid
            dataGridViewResolutions.BackgroundColor = theme.DataGridBackground;
            dataGridViewResolutions.GridColor = theme.DataGridBorder;
            dataGridViewResolutions.DefaultCellStyle.BackColor = theme.DataGridCellBackground;
            dataGridViewResolutions.DefaultCellStyle.ForeColor = theme.DataGridCellText;
            dataGridViewResolutions.DefaultCellStyle.SelectionBackColor = theme.DataGridSelectedBackground;
            dataGridViewResolutions.DefaultCellStyle.SelectionForeColor = theme.DataGridSelectedText;

            //CoverPanel
            panelSonImageLimit.BackColor = theme.CoverPreviewBackground;
        }

        #region Picture Box
        private void pictureBoxCover_MouseDown(object sender, MouseEventArgs e)
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

        private void pictureBoxCover_MouseMove(object sender, MouseEventArgs e)
        {
            if (rowSelected > -1)
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
                        dataGridViewResolutions.Rows[rowSelected].Cells[1].Value = pictureBoxCover.Width;
                        dataGridViewResolutions.Rows[rowSelected].Cells[2].Value = pictureBoxCover.Height;
                        //numericColWidth.Value = newWidth;
                    }
                    if (resizing != 1)
                    {
                        //No ajustar el alto si solo estamos cambiando el ancho
                        pictureBoxCover.Height = newHeight;
                        dataGridViewResolutions.Rows[rowSelected].Cells[1].Value = pictureBoxCover.Width;
                        dataGridViewResolutions.Rows[rowSelected].Cells[2].Value = pictureBoxCover.Height;
                        //numericColHeight.Value = newHeight;
                    }

                    // Actualizar las coordenadas actuales del mouse
                    if (resizing != 2) currentX = e.X;
                    if (resizing != 1) currentY = e.Y;
                }
                else
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
                        this.Cursor = Cursors.Default;
                    }
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
        #endregion

        private void dataGridViewResolutions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("\n/////////");
            Console.WriteLine("fila num: "+e.RowIndex);
            
            if (e.RowIndex > -1)
            {
                DataGridViewRow selectedRow = dataGridViewResolutions.Rows[e.RowIndex];
                Console.WriteLine("tag de la fila: " + selectedRow.Tag);
                rowSelected = e.RowIndex;

                //string resName = "name";
                int widthCover = 0;
                int heightCover = 0;
                //int coverLayout = 0;

                //if (selectedRow.Cells[0].Value != null) resName = selectedRow.Cells[0].Value.ToString();
                if (selectedRow.Cells[1].Value != null)
                {
                    widthCover = int.Parse(selectedRow.Cells[1].Value.ToString());
                    Console.WriteLine("width "+selectedRow.Cells[1].Value.ToString());
                    if (widthCover > 300) widthCover = 300;
                    if (widthCover < 100) widthCover = 100;
                }
                if (selectedRow.Cells[2].Value != null)
                {
                    heightCover = int.Parse(selectedRow.Cells[2].Value.ToString());
                    Console.WriteLine("height " + selectedRow.Cells[2].Value.ToString());
                    if (heightCover > 300) heightCover = 300;
                    if (heightCover < 100) heightCover = 100;
                }

                if (widthCover != 0 && heightCover != 0)
                {
                    pictureBoxCover.Width = widthCover;
                    pictureBoxCover.Height = heightCover;
                }
            }
        }

        private void dataGridViewResolutions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Identificar si se esta ajustando el ancho o el alto y atribuirlo a coverBox
            if (e.ColumnIndex == 1)//Ancho
            {
                int width = 200;
                try
                {
                    width = int.Parse(dataGridViewResolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    if (width < 100) { width = 100; dataGridViewResolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "100"; }
                    if (width > 300) { width = 300; dataGridViewResolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "300"; }
                    pictureBoxCover.Width = width;
                }
                catch 
                {
                    //Si da un error, es por que no se pudo transformar el contenido puesto a int, transformarlo
                    pictureBoxCover.Width = width;
                    dataGridViewResolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = width;
                }


            } else if (e.ColumnIndex == 2)//Alto
            {
                int height = 200;
                try
                {
                    height = int.Parse(dataGridViewResolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    if (height < 100) { height = 100; dataGridViewResolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "100"; }
                    if (height > 300) { height = 300; dataGridViewResolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "300"; }
                    pictureBoxCover.Height = height;
                }
                catch
                {
                    //Si da un error, es por que no se pudo transformar el contenido puesto a int, transformarlo
                    pictureBoxCover.Height = height;
                    dataGridViewResolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = height;
                }
            }

            //Console.WriteLine("Edicion terminada, \nrow: "+e.RowIndex+"\ncolumna: "+e.ColumnIndex);
            //Console.WriteLine("Contenido: " + dataGridViewResolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()+"\n");
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            this.dataGridViewResolutions.Rows.Add("", 200, 200);
            int rowCount = dataGridViewResolutions.Rows.Count;
            dataGridViewResolutions.CurrentCell = dataGridViewResolutions.Rows[rowCount - 1].Cells[0];
            dataGridViewResolutions.Rows[rowCount - 1].Selected = true;

            maxTag++;//Sumarle 1 al tag maximo
            dataGridViewResolutions.Rows[rowCount - 1].Tag = maxTag;//Asignar el id a la fila

            rowSelected = rowCount - 1;
            pictureBoxCover.Width = 200;
            pictureBoxCover.Height = 200;
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            if (rowSelected != -1)
            {
                //int rowIndex = dataGridViewResolutions.CurrentRow.Index;
                //DataGridViewRow selectedRow = dataGridViewResolutions.Rows[rowIndex];
                //rowSelected = rowIndex - 1;
                this.dataGridViewResolutions.Rows.RemoveAt(rowSelected);
                if (rowSelected > dataGridViewResolutions.Rows.Count - 1) rowSelected--;
            }
        }

        private void buttonSaveRes_Click(object sender, EventArgs e)
        {
            //Como todas las resoluciones se muestran en la tabla y se pueden modificar todas, se reseteara el xml cada vez que se vaya a ocupar
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
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

            //Despues de cargar el archivo xml, eliminar todos sus elementos
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlResPath);
            XmlNode root = xmlDoc.DocumentElement;
            root.RemoveAll();

            for (int i = 0; i < dataGridViewResolutions.Rows.Count; i++)
            {
                DataGridViewRow selectedRow = dataGridViewResolutions.Rows[i];

                int gridTag = int.Parse(selectedRow.Tag.ToString());
                XmlElement resolution;
                resolution = xmlDoc.CreateElement("resolution");
                resolution.SetAttribute("id", gridTag + "");//establecer el atributo id

                //Añadirlo a la raiz "launcher"
                root.AppendChild(resolution);

                XmlElement resName   = xmlDoc.CreateElement("Name");    resName.InnerText   = selectedRow.Cells[0].Value.ToString(); resolution.AppendChild(resName);
                XmlElement resWidht  = xmlDoc.CreateElement("Width");   resWidht.InnerText  = selectedRow.Cells[1].Value.ToString(); resolution.AppendChild(resWidht);
                XmlElement resHeight = xmlDoc.CreateElement("Height");  resHeight.InnerText = selectedRow.Cells[2].Value.ToString(); resolution.AppendChild(resHeight);

            }

            //Despues del bucle, guardar el archivo
            xmlDoc.Save(xmlResPath);

            //cerrar
            ReturnedObject?.Invoke(this, true);
            this.Close();
        }

        private void buttonSearchSonCoverTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;)|*.png;*.jpg;*.jpeg;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCover.BackgroundImage = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void dataGridViewResolutions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Resolution_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pictureBoxCover.BackgroundImage != null) pictureBoxCover.BackgroundImage.Dispose();//Dejar de utilizar la imagen de fondo en memoria
        }
    }
}
