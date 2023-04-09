using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace C_Launcher
{
    public partial class Form1 : Form
    {
        private int currentX, currentY;
        private int resizing = 0; // 0=no se esta ajustando; 1=ajustando ancho; 2=ajustando alto; 3=ajustando ambos
        private bool isResizing;


        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);

        }

        //Crear elementos a un xml
        private void appendXML(string abc)
        {
            string xmlPath = "example.xml";
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            if (!File.Exists(xmlPath))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(xmlPath, settings))
                {
                    //Crear el elemento raiz del archivo (obligatorio)
                    writer.WriteStartElement("Launcher");
                    writer.WriteEndElement();
                }
            }

            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

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
            XmlElement coleccion = xmlDoc.CreateElement("collection");
            coleccion.SetAttribute("id", maxId+1+"");//establecer el atributo id para facilitar la busqueda por xPath
            xmlDoc.DocumentElement.AppendChild(coleccion);//agrega la coleccion al documento


            //Elementos de esa coleccion
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos de la coleccion a la coleccion
            XmlElement colFather = xmlDoc.CreateElement("IDFather"); colFather.InnerText = "-1"; coleccion.AppendChild(colFather);
            XmlElement colName = xmlDoc.CreateElement("Name"); colName.InnerText = "nombre"; coleccion.AppendChild(colName);
            XmlElement colImage = xmlDoc.CreateElement("Image"); colImage.InnerText = "/"; coleccion.AppendChild(colImage);
            XmlElement colBgRed = xmlDoc.CreateElement("BackgroundRed"); colBgRed.InnerText = "255"; coleccion.AppendChild(colBgRed);
            XmlElement colBgGreen = xmlDoc.CreateElement("BackgroundGreen"); colBgGreen.InnerText = "255"; coleccion.AppendChild(colBgGreen);
            XmlElement colBgBlue = xmlDoc.CreateElement("BackgroundBlue"); colBgBlue.InnerText = "255"; coleccion.AppendChild(colBgBlue);
            XmlElement colResolution = xmlDoc.CreateElement("CoverResolutionID"); colResolution.InnerText = "0"; coleccion.AppendChild(colResolution);
            XmlElement colWith = xmlDoc.CreateElement("CoverWidth"); colWith.InnerText = "200"; coleccion.AppendChild(colWith);
            XmlElement colHeight = xmlDoc.CreateElement("CoverHeight"); colHeight.InnerText = "200"; coleccion.AppendChild(colHeight);
            XmlElement colTags = xmlDoc.CreateElement("TagsID"); colTags.InnerText = "0"; coleccion.AppendChild(colTags);
            XmlElement colFavorite = xmlDoc.CreateElement("Favorite"); colFavorite.InnerText = "false"; coleccion.AppendChild(colFavorite);

            xmlDoc.Save(xmlPath);
        }

        //Empezar los procesos
        private void startProcess()
        {
            bool url = true;
            string fileExe = "";
            string fileDir = "";
            string programDir = "";
            string cmdLine = "";//es necesario establecerlo como "", por default es null, pero si alguien escribe algo y lo borra quedara como "" y complicara las validaciones

            //Crear el process start
            Process process = new Process();
           // ProcessStartInfo startInfo = new ProcessStartInfo();//De todas formas despues se declara con un new ProcessStart...

            //prueba para no perderme
            if (textBoxFileName.Text != "") fileExe = textBoxFileName.Text;
            if (textBoxProgramName.Text != "")  programDir = Path.GetFullPath(textBoxProgramName.Text);
            cmdLine = textBoxCMDline.Text;

            //es necesario comprobar si es una URL o un archivo del sistema, 
            if (url == false)
            {
                //Solo formatear la ruta del archivo si este no es un URL
                fileExe = Path.GetFullPath(fileExe);
                fileDir = Path.GetDirectoryName(fileExe);

                Console.WriteLine("ruta del archivo: " + fileExe);
                Console.WriteLine("ruta de la carpeta: " + fileDir);
            }
            
            //Intentar ejecutar los archivos/URL
            try{
                //Intentar abrir un archivo solo o abrir una URL
                if ((programDir == "") || (url == true)){
                    Console.WriteLine("abriendo un archivo o URL");

                    ProcessStartInfo startInfo = new ProcessStartInfo(fileExe);//Ruta del archivo o URL

                    if (url == false){
                        //Establecer el directorio de trabajo del archivo a ejecutar
                        startInfo.WorkingDirectory = fileDir;//Es necesario para que se tome cual es el directorio donde se ejecuta el archivo y pueda tomar los archivos de esa zona
                        //Utilizar los CMD arguments si es que tiene
                        startInfo.Arguments = cmdLine;
                    }

                    process.StartInfo = startInfo;
                    process.Start();
                //Intentar abrir un archivo utilizando un programa
                } else{
                    Console.WriteLine("abriendo un programa");

                    ProcessStartInfo startInfo = new ProcessStartInfo(programDir);//Ruta del programa con el que se abrira el archivo

                    //Si no tienes cmdLines
                    if (cmdLine == ""){
                       //Se utilizara como argumento del programa el archivo que se quiere abrir
                        startInfo.Arguments = "\"" + fileExe + "\"";
                    } else{
                        startInfo.Arguments = "\"" + fileExe + "\"" + " " + cmdLine;
                    }
                }
            }
            //En caso de errores
            catch (Exception){
                if (url)  MessageBox.Show("error abrir URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Error con URL
                else MessageBox.Show("error abrir archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Error con archivos/programas/cmdLine
                    
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            appendXML(textBox1.Text);
        }

        //Leer el contenido xml
        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("example.xml");

            // Obtener el elemento raíz del documento
            XmlElement root = doc.DocumentElement;

            // Iterar a través de los nodos hijos del elemento raíz
            foreach (XmlNode node in root.ChildNodes)
            {
                // Hacer algo con el nodo, por ejemplo imprimir su nombre
                Console.WriteLine(node.Name + " | " + node.InnerText);
                
            }

        }

        //Buscar un elemento  xml
        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("example.xml");

            string xpath = "//ColeccionX[@id='1']"; //Buscar un elemento que se llame "ColeccionX" que tenga en el atributo id un 1
            XmlNode root = doc.SelectSingleNode(xpath);

            if (root != null)
            {
                foreach (XmlNode rootxml in root.ChildNodes)
                {
                    // Hacer algo con el nodo, por ejemplo imprimir su nombre
                    Console.WriteLine(rootxml.Name + " | " + rootxml.InnerText);

                }
            }
        }

        //Actualizar un elemento xml
        private void button5_Click(object sender, EventArgs e)
        {
            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("example.xml");

            //Buscamos el elemento a modificar
            string xpath = "//ColeccionX[@id='1']"; //Buscar un elemento que se llame "ColeccionX" que tenga en el atributo id un 1
            XmlNode root = xmlDoc.SelectSingleNode(xpath);

            if (root != null)
            {
                foreach (XmlNode rootxml in root.ChildNodes)
                {
                    Console.WriteLine("/////////////////");

                    Console.WriteLine("Antes: " + rootxml.Name + " | " + rootxml.InnerText);
                    //Modificar ese nodo
                    rootxml.InnerText = textBox2.Text;
                    Console.WriteLine("Ahora: " + rootxml.Name + " | " + rootxml.InnerText);
                    Console.WriteLine("");
                }
            }

            xmlDoc.Save("example.xml");
        }

        //eliminar un elemento xml
        private void button4_Click(object sender, EventArgs e)
        {
            //Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("example.xml");

            //Buscamos el elemento a eliminar
            string xpath = "//ColeccionX[@id='1']"; //Buscar un elemento que se llame "ColeccionX" que tenga en el atributo id un 1
            XmlNode root = xmlDoc.SelectSingleNode(xpath);

            if (root != null)
            {
                root.ParentNode.RemoveChild(root);
            }

            xmlDoc.Save("example.xml");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            startProcess();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Aqui se ejecutaria el proccess start

        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int margin = 10;

            //Ancho (Mouse a la derecha)
            if (e.X >= pictureBox1.Width - margin && e.Y < pictureBox1.Height - margin)
            {
                //isResizing = true;
                resizing = 1;
                currentX = e.X;
                currentY = 0;
                
            }

            //Alto (Mouse en la parte inferior)
            if (e.X < pictureBox1.Width - margin && e.Y >= pictureBox1.Height - margin)
            {
                //isResizing = true;
                resizing = 2;
                currentX = 0;
                currentY = e.Y;

            }

            //Ajustando ambos (mouse en esquina inferior derecha)
            if (e.X >= pictureBox1.Width - margin && e.Y >= pictureBox1.Height - margin)
            {
                resizing = 3;
                currentX = e.X;
                currentY = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Verifique si estamos cambiando el tamaño
            if (resizing > 0)
            {
                // Calcule el nuevo ancho y alto del PictureBox
                int newWidth = pictureBox1.Width + (e.X - currentX);
                int newHeight = pictureBox1.Height + (e.Y - currentY);

                // Asegúrese de que el ancho y el alto sean mayores que cero
                if (newWidth > 0 && newHeight > 0)
                {
                    // Establecer el nuevo ancho y alto del PictureBox
                    if (resizing != 2) pictureBox1.Width = newWidth;//No ajustar el ancho si solo estamos cambiando el alto
                    if (resizing != 1)  pictureBox1.Height = newHeight;//No ajustar el alto si solo estamos cambiando el ancho

                    // Actualizar las coordenadas actuales del mouse
                    if (resizing != 2) currentX = e.X;
                    if (resizing != 1) currentY = e.Y;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // Dejar de cambiar el tamaño
            isResizing = false;
            resizing = 0;
        }

        

        //Al entrar el mouse en un picture box
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            
            
            Graphics g = pictureBox.CreateGraphics();//Crear graphics

            // Dibujar un rectángulo negro en el PictureBox
            Color Bcolor = Color.FromArgb(180, Color.Black);
            SolidBrush RectBrush = new SolidBrush(Bcolor);
            g.FillRectangle(RectBrush, 0, pictureBox.Height-(pictureBox.Height / 3), pictureBox.Width, pictureBox.Height);

            //Dibujar el texto
            Font font = new Font("Arial", 8);
            SolidBrush FontBrush = new SolidBrush(Color.White);
            StringFormat drawFormat = new StringFormat();
            RectangleF fontRect = new RectangleF(0, pictureBox.Height - (pictureBox.Height / 3), pictureBox.Width, pictureBox.Height / 3);
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            drawFormat.FormatFlags = StringFormatFlags.LineLimit;
            drawFormat.Trimming = StringTrimming.EllipsisCharacter;
            g.DrawString("The Legend of zelda: Breath of The Wild The Legend of zelda: Breath of The Wild The Legend of zelda: Breath of The Wild The Legend of zelda: Breath of The Wild", font, FontBrush, fontRect, drawFormat);

            FontBrush.Dispose();
            RectBrush.Dispose();//Dejar de ocupar pincel
            g.Dispose();//Dejar de ocupar graphics
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Al salir
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Invalidate();//Vuelve a dibujar el control otra vez, eliminando cualquier graphics
        }
    }
}
