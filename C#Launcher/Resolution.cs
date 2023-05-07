using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO
using System.Xml.Linq;

namespace C_Launcher
{
    public partial class Resolution : Form
    {
        private int currentX, currentY;
        private int resizing = 0; // 0=no se esta ajustando; 1=ajustando ancho; 2=ajustando alto; 3=ajustando ambos
        private int rowSelected = -1;
        private string xmlFilesPath = "System\\Resolutions.xml";

        public Resolution()
        {
            InitializeComponent();
            this.pictureBoxCover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseDown);
            this.pictureBoxCover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseMove);
            this.pictureBoxCover.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCover_MouseUp);
            //Seleccionar por defecto la primera fila
            //dataGridViewResolutions.Rows[0].Selected = true;
        }

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
            // Verifique si estamos cambiando el tamaño
            if ((resizing > 0) && (rowSelected > -1))
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
        }

        private void pictureBoxCover_MouseUp(object sender, MouseEventArgs e)
        {
            // Dejar de cambiar el tamaño
            resizing = 0;
            this.Cursor = Cursors.Arrow;
        }

        private void dataGridViewResolutions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("/////////");
            Console.WriteLine(e.RowIndex);
            if (e.RowIndex > -1)
            {
                DataGridViewRow selectedRow = dataGridViewResolutions.Rows[e.RowIndex];
                rowSelected = e.RowIndex;

                //string resName = "name";
                int widthCover = 0;
                int heightCover = 0;
                int coverLayout = 0;

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
                int width = 100;
                try
                {
                    width = int.Parse(dataGridViewResolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
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
                int height = 100;
                try
                {
                    height = int.Parse(dataGridViewResolutions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
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
            this.dataGridViewResolutions.Rows.Add("", 100, 100);
            int rowCount = dataGridViewResolutions.Rows.Count;
            dataGridViewResolutions.CurrentCell = dataGridViewResolutions.Rows[rowCount - 1].Cells[0];
            dataGridViewResolutions.Rows[rowCount - 1].Selected = true;
            rowSelected = rowCount - 1;
            pictureBoxCover.Width = 100;
            pictureBoxCover.Height = 100;
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

            /*
            for (int i = 0; i < dataGridViewResolutions.Rows.Count; i++)
            {
                XmlElement rowElement = xmlDocument.CreateElement("Row");
                rootElement.AppendChild(rowElement);

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    string columnName = dataGridView1.Columns[j].Name;
                    string cellValue = dataGridView1.Rows[i].Cells[j].Value.ToString();

                    XmlElement cellElement = xmlDocument.CreateElement(columnName);
                    cellElement.InnerText = cellValue;
                    rowElement.AppendChild(cellElement);
                }
            }
            */

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
    }
}
