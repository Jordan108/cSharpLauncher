using C_Launcher.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
//using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_Launcher
{
    public partial class Home : Form
    {
        private PictureBox[] picBoxArr = new PictureBox[0];//Crear el array de picBox que se mantendra en memoria
        //Crea el array de las colecciones y los archivos (solo contendran las colecciones que se mostraran en en la vista)
        //private Files[] fileArr = new Files[0];
        //private Collections[] colArr = new Collections[0];


        private int viewDepth = 0;
        //Rutas de los archivos XML
        private string xmlColPath = "Collections.xml";
        private string xmlFilesPath = "Files.xml";

        //Mantener el tamaño de los archivos y colecciones
        private int colSize = 0;
        private int fileSize = 0;
        //ToolStrip
       // private ContextMenuStrip panelContexMenuStrip;

        public Home()
        {
            InitializeComponent();
            //Tool strip
            ContextMenuStrip  contextMenuLayoutPanel = new ContextMenuStrip();
            ToolStripMenuItem ToolStripAddCollection = new ToolStripMenuItem();
            ToolStripMenuItem ToolStripAddFile       = new ToolStripMenuItem();

            ToolStripAddCollection.Text = "crear coleccion";
            ToolStripAddCollection.Click += new EventHandler(ToolStripAddCollection_Click);
            ToolStripAddFile.Text = "crear archivo";
            ToolStripAddFile.Click += new EventHandler(ToolStripAddFile_Click);

            contextMenuLayoutPanel.Items.AddRange(new ToolStripItem[] { ToolStripAddCollection, ToolStripAddFile });

            //Agregar al layout panel
            flowLayoutPanelMain.ContextMenuStrip = contextMenuLayoutPanel;

            //Carga la cantidad de colecciones y archivos existentes
            colSize = LoadCollectionSize();
            fileSize = LoadFilesSize();

            
            Console.WriteLine("tamaño col: " +  colSize);
            loadPictureBox(colSize, fileSize, false);
                //saveXMLCollection();
            
        }

        //Cuando la vista cargue
        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        #region ToolStrip
        //Crear la nueva ventana para añadir las colecciones
        private void ToolStripAddCollection_Click(object sender, EventArgs e)
        {
            NewCollection newCollection = new NewCollection();
            newCollection.ReturnedObject += NewCollection_ReturnedObject;
            newCollection.ShowDialog();
        }

        //Crear la nueva ventana para crear los archivos (individual)
        private void ToolStripAddFile_Click(object sender, EventArgs e)
        {
            NewFile newFile = new NewFile();
            newFile.ReturnedObject += NewFile_ReturnedObject;
            newFile.ShowDialog();
        }



        #endregion

        #region Manejar interaccion entre ventanas
        private void NewCollection_ReturnedObject(object sender, Collections e)
        {
            SaveXMLCollection(e);
            loadPictureBox(colSize, fileSize, false);
        }

        private void NewFile_ReturnedObject(object sender, Files e)
        {
            //Guarda los archivos XML
            SaveXMLFile(e);
            //Carga de nuevo el flow layout
            loadPictureBox(colSize,fileSize,false);
        }
        #endregion

        #region Interaccion pictureBox
        //Empezar un proceso al hacer click a un archivo
        private void startProcess(string file, string program, string cmdLine, bool url)
        {
            //bool url = true;

            //file y program se deben de formatear
            string fileExe = "";
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

                    Console.WriteLine("ruta del archivo: " + fileExe);
                    Console.WriteLine("ruta de la carpeta: " + fileDir);
                    Console.WriteLine("ruta programa: " + programDir);
                    Console.WriteLine("cmd: " + cmdLine);
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
            catch (Exception)
            {
                if (url) MessageBox.Show("error abrir URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//Error con URL
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
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int idBox = int.Parse(pictureBox.Tag.ToString());//no se puede transformar un objeto a int, pero si a un string
            string boxType = pictureBox.AccessibleDescription;//Recoje el tipo de picture box para buscar en el array especifico (col/file)

            if (boxType == "file")
            {
                //Dentro de la funcion se buscara los procesos asociados al archivo y llamara a start process
                searchFileProcess(idBox);

            } else
            {
                //Buscar en el array de las colecciones
            }
        }
        #endregion

        #region Creacion/Destruccion pictureBox
        private void destroyPictureBox()
        {
            //remueve todos los paneles del control
            for (int i=0; i< picBoxArr.Length; i++)
            {
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

            //Recorrer todos el array de las colecciones
            for(int i = 0; i < colls.Length; i++)
            {
                //Solo agregar las colecciones que coincidan con la profundidad actual
                if (viewDepth == colls[i].IDFather)
                {
                    //Image imagen = Image.FromFile(colls[i].ImagePath);
                    //Definir el picture box
                    picBoxArr[pL] = new PictureBox
                    {
                        AccessibleDescription = "collection",//Aqui se indica que tipo de picture box es (coleccion / archivo)
                        Name = colls[i].Name,//Aqui se guarda el nombre de la coleccion
                        
                        Size = new Size(colls[i].Width, colls[i].Height),
                        BackColor = Color.FromArgb(colls[i].ColorRed, colls[i].ColorGreen, colls[i].ColorBlue),

                        Tag = i,//Aqui se guarda en que espacio del array estamos buscando//colls[i].ID,
                    };

                    //Establecer formato de imagen (como tiene validaciones, no puedo meterlo en el paquete de arriba)
                    try
                    {
                        Image imagen = Image.FromFile(colls[i].ImagePath);
                        picBoxArr[pL].BackgroundImage = imagen;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("no se pudo establecer una imagen en coleccion " + i + " | " + ex.ToString());
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
                    picBoxArr[pL].Click += new System.EventHandler(this.pictureBox_Click);

                    flowLayoutPanelMain.Controls.Add(picBoxArr[pL]);

                    pL++;//iterar en el array de paneles
                }
            }

            //Recorrer todo el array de los files
            for (int f = 0; f < files.Length; f++)
            {
                //Solo agregar las colecciones que coincidan con la profundidad actual
                if (viewDepth == files[f].IDFather)
                {
                    //Image imagen = Image.FromFile(colls[i].ImagePath);
                    //Definir el picture box
                    picBoxArr[pL] = new PictureBox
                    {
                        AccessibleDescription = "file",//Aqui se indica que tipo de picture box es (coleccion / archivo)//,
                        Name = files[f].Name,
                        Size = new Size(files[f].Width, files[f].Height),
                        BackColor = Color.FromArgb(files[f].ColorRed, files[f].ColorGreen, files[f].ColorBlue),
                        /*
                        BackgroundImage = imagen,
                        */
                        //Text = "file",//Aqui se indica que tipo de picture box es (coleccion / archivo)
                        Tag = files[f].ID,//Aqui indico que espacio de su array estamos buscando //Aqui se guarda la id del archivo, para que cuando se haga click, se busque en el array lo que tiene y se abra
                    };

                    //Establecer formato de imagen (como tiene validaciones, no puedo meterlo en el paquete de arriba)
                    try
                    {
                        Image imagen = Image.FromFile(files[f].ImagePath);
                        picBoxArr[pL].BackgroundImage = imagen;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("no se pudo establecer una imagen en archivo " + f + " | " + ex.ToString());
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
                    picBoxArr[pL].Click += new System.EventHandler(this.pictureBox_Click);


                    flowLayoutPanelMain.Controls.Add(picBoxArr[pL]);

                    pL++;//iterar en el array de paneles
                }
            }

            //Optimizar el tamaño del array
            Array.Resize(ref picBoxArr, pL);

            flowLayoutPanelMain.ResumeLayout();
        }
        #endregion

        #region Manejar datos XML
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
            coleccion.SetAttribute("id", maxId + 1 + "");//establecer el atributo id para facilitar la busqueda por xPath
            xmlDoc.DocumentElement.AppendChild(coleccion);//agrega la coleccion al documento


            //Elementos de esa coleccion
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos de la coleccion a la coleccion
            XmlElement colFather = xmlDoc.CreateElement("IDFather"); colFather.InnerText                            = Class.IDFather.ToString();        coleccion.AppendChild(colFather);
            XmlElement colName = xmlDoc.CreateElement("Name"); colName.InnerText                                    = Class.Name;                       coleccion.AppendChild(colName);
            XmlElement colImage = xmlDoc.CreateElement("Image"); colImage.InnerText                                 = Class.ImagePath;                  coleccion.AppendChild(colImage);
            XmlElement colLayout = xmlDoc.CreateElement("ImageLayout"); colLayout.InnerText                         = Class.ImageLayout.ToString();     coleccion.AppendChild(colLayout);
            XmlElement colBgRed = xmlDoc.CreateElement("BackgroundRed"); colBgRed.InnerText                         = Class.ColorRed.ToString();        coleccion.AppendChild(colBgRed);
            XmlElement colBgGreen = xmlDoc.CreateElement("BackgroundGreen"); colBgGreen.InnerText                   = Class.ColorGreen.ToString();      coleccion.AppendChild(colBgGreen);
            XmlElement colBgBlue = xmlDoc.CreateElement("BackgroundBlue"); colBgBlue.InnerText                      = Class.ColorBlue.ToString();       coleccion.AppendChild(colBgBlue);
            XmlElement colResolution = xmlDoc.CreateElement("CoverResolutionID"); colResolution.InnerText           = Class.ResolutionID.ToString();    coleccion.AppendChild(colResolution);
            XmlElement colWith = xmlDoc.CreateElement("CoverWidth"); colWith.InnerText                              = Class.Width.ToString();           coleccion.AppendChild(colWith);
            XmlElement colHeight = xmlDoc.CreateElement("CoverHeight"); colHeight.InnerText                         = Class.Height.ToString();          coleccion.AppendChild(colHeight);
            XmlElement colSonResolution = xmlDoc.CreateElement("CoverSonResolutionID"); colSonResolution.InnerText  = Class.SonResolution.ToString();   coleccion.AppendChild(colSonResolution);
            XmlElement colSonWidth = xmlDoc.CreateElement("CoverSonWidth"); colSonWidth.InnerText                   = Class.SonWidth.ToString();        coleccion.AppendChild(colSonWidth);
            XmlElement colSonHeight = xmlDoc.CreateElement("CoverSonHeight"); colSonHeight.InnerText                = Class.SonHeight.ToString();       coleccion.AppendChild(colSonHeight);
            XmlElement colSonLayout = xmlDoc.CreateElement("SonImageLayout"); colSonLayout.InnerText                = Class.ImageLayout.ToString();     coleccion.AppendChild(colSonLayout);
            //Guardar el array de tags
            XmlElement colTags = xmlDoc.CreateElement("TagsID"); coleccion.AppendChild(colTags);
                foreach (int num in Class.TagsID)
                {
                    XmlElement numArray = xmlDoc.CreateElement("id"); 
                    numArray.InnerText = num.ToString();
                    colTags.AppendChild(numArray);
                //Console.WriteLine(num);
                }  
            XmlElement colFavorite = xmlDoc.CreateElement("Favorite"); colFavorite.InnerText                        = "false"; coleccion.AppendChild(colFavorite);

            xmlDoc.Save(xmlColPath);

            //Actualizar cantidad de colecciones
            colSize = LoadCollectionSize();
        }

        private void SaveXMLFile(Files Class)
        {
            //Verificar que el archivo xml exista (y si no es asi, crearlo y formatearlo)
            if (!File.Exists(xmlColPath))
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
            XmlElement file = xmlDoc.CreateElement("file");
            file.SetAttribute("id", maxId + 1 + "");//establecer el atributo id para facilitar la busqueda por xPath
            xmlDoc.DocumentElement.AppendChild(file);//agrega la coleccion al documento

            //Elementos de ese file
            //Crea el nombre del elemento a agregar; agrega los datos; agrega los elementos de la coleccion a la coleccion
            XmlElement fileFather = xmlDoc.CreateElement("IDFather"); fileFather.InnerText                  = Class.IDFather.ToString();     file.AppendChild(fileFather);
            XmlElement fileName = xmlDoc.CreateElement("Name"); fileName.InnerText                          = Class.Name;                    file.AppendChild(fileName);
            XmlElement fileImage = xmlDoc.CreateElement("Image"); fileImage.InnerText                       = Class.ImagePath;               file.AppendChild(fileImage);
            XmlElement fileLayout = xmlDoc.CreateElement("ImageLayout"); fileLayout.InnerText               = Class.ImageLayout.ToString();  file.AppendChild(fileLayout);
            XmlElement filePath = xmlDoc.CreateElement("FilePath"); filePath.InnerText                      = Class.FilePath;                file.AppendChild(filePath);
            XmlElement fileProgram = xmlDoc.CreateElement("ProgramPath"); fileProgram.InnerText             = Class.ProgramPath;             file.AppendChild(fileProgram);
            XmlElement filecmd = xmlDoc.CreateElement("CMDLine"); filecmd.InnerText                         = Class.CMDLine;                 file.AppendChild(filecmd);
            XmlElement fileBgRed = xmlDoc.CreateElement("BackgroundRed"); fileBgRed.InnerText               = Class.ColorRed.ToString();     file.AppendChild(fileBgRed);
            XmlElement fileBgGreen = xmlDoc.CreateElement("BackgroundGreen"); fileBgGreen.InnerText         = Class.ColorGreen.ToString();   file.AppendChild(fileBgGreen);
            XmlElement fileBgBlue = xmlDoc.CreateElement("BackgroundBlue"); fileBgBlue.InnerText            = Class.ColorBlue.ToString();    file.AppendChild(fileBgBlue);
            XmlElement fileResolution = xmlDoc.CreateElement("CoverResolutionID"); fileResolution.InnerText = Class.ResolutionID.ToString(); file.AppendChild(fileResolution);
            XmlElement fileWith = xmlDoc.CreateElement("CoverWidth"); fileWith.InnerText                    = Class.Width.ToString();        file.AppendChild(fileWith);
            XmlElement fileHeight = xmlDoc.CreateElement("CoverHeight"); fileHeight.InnerText               = Class.Height.ToString();       file.AppendChild(fileHeight);
            XmlElement fileURL = xmlDoc.CreateElement("URLCheck"); fileURL.InnerText                        = Class.URLCheck.ToString();     file.AppendChild(fileURL);
            //Guardar el array de tags
            XmlElement fileTags = xmlDoc.CreateElement("TagsID"); file.AppendChild(fileTags);
                foreach (int num in Class.TagsID)
                {
                    XmlElement numArray = xmlDoc.CreateElement("id"); 
                    numArray.InnerText = num.ToString();
                    fileTags.AppendChild(numArray);
                //Console.WriteLine(num);
                }  
            
            XmlElement fileFavorite = xmlDoc.CreateElement("Favorite"); fileFavorite.InnerText              = Class.Favorite.ToString();     file.AppendChild(fileFavorite);

            xmlDoc.Save(xmlFilesPath);

            //Actualizar la cantidad de archivos
            fileSize = LoadFilesSize();
        }

        //cargar las colecciones del xml en un objeto collections array
        private Collections[] LoadCollections(int arraySize) {
            Collections[] colData = new Collections[arraySize];

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlColPath);


            int fileID = 1;
            for (int i=0; i<arraySize; i++)
            {
                //Buscamos el elemento a modificar
                string xpath = "//Launcher/collection[@id='"+fileID+"']";
                XmlNode root = xmlDoc.SelectSingleNode(xpath);

                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {

                    fileID++;
                    xpath = "//Launcher/collection[@id='"+fileID+"']";
                    root = xmlDoc.SelectSingleNode(xpath);
                }

                int idFather = 0;
                string name = "name";
                string imgPath = "image";
                int imgLayout = 0;
                int red = 0;
                int green = 0;
                int blue = 0;
                int resolution = 0;
                int width = 0;
                int height = 0;
                int sonRes = 0;
                int sonWidth = 0;
                int sonHeight = 0;
                int sonLayout = 0;
                int[] tagsArray = {};
                bool fav = false;

                //"1, 3, 4, 5, 6, 9, 10, 14, 23"
                //Navegar entre todos los elementos que contenga el elemento base del xml
                foreach (XmlNode rootxml in root.ChildNodes)
                {
                    Console.WriteLine(rootxml.Name + " | " + rootxml.InnerText);
                    switch (rootxml.Name)
                    {
                        case "IDFather": idFather = int.Parse(rootxml.InnerText); break;
                        case "Name": name = rootxml.InnerText; break;
                        case "Image": imgPath = rootxml.InnerText;  break;
                        case "ImageLayout": imgLayout = int.Parse(rootxml.InnerText); break;
                        case "BackgroundRed": red = int.Parse(rootxml.InnerText);  break;
                        case "BackgroundGreen": green = int.Parse(rootxml.InnerText); break;
                        case "BackgroundBlue": blue = int.Parse(rootxml.InnerText); break;
                        case "CoverResolutionID": resolution = int.Parse(rootxml.InnerText); break;
                        case "CoverWidth": width = int.Parse(rootxml.InnerText);  break;
                        case "CoverHeight": height = int.Parse(rootxml.InnerText); break;
                        case "CoverSonResolutionID": sonRes = int.Parse(rootxml.InnerText); break;
                        case "CoverSonWidth": sonWidth = int.Parse(rootxml.InnerText);  break;
                        case "CoverSonHeight": sonHeight = int.Parse(rootxml.InnerText);  break;
                        case "SonImageLayout": sonLayout = int.Parse(rootxml.InnerText); break;
                        case "TagsID":
                            string[] strArray = rootxml.InnerText.Split(' ');
                            tagsArray = strArray.Select(s => int.Parse(s)).ToArray(); 
                            break;
                        case "Favorite": fav = bool.Parse(rootxml.InnerText);  break;
                    }
                }

                colData[i] = new Collections(fileID,idFather, name, imgPath, imgLayout, red, green, blue, resolution, width, height, sonRes, sonWidth, sonHeight, sonLayout, tagsArray, fav);

                fileID++;
            }

            return colData;
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
                XmlNode root = xmlDoc.SelectSingleNode(xpath);

                //si no existe un elemento con esa id, sumar 1
                while (root == null)
                {
                    fileID++;
                    xpath = "//Launcher/file[@id='" + fileID + "']";
                    root = xmlDoc.SelectSingleNode(xpath);
                }

                int idFather = 0;
                string name = "name";
                string imgPath = "image";
                int imgLayout = 0;
                string filePath = "path";
                string programPath = "path";
                string cmdLine = "";
                int red = 0;
                int green = 0;
                int blue = 0;
                int resolution = 0;
                int width = 0;
                int height = 0;
                bool urlCheck = false;
                int[] tagsArray = new int[] { };
                bool fav = false;

                //Navegar entre todos los elementos que contenga el elemento base del xml
                foreach (XmlNode rootxml in root.ChildNodes)
                {
                    Console.WriteLine(rootxml.Name + " | " + rootxml.InnerText);
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
                            foreach(XmlNode tagid in rootxml)
                            {
                                //hacer un append al array
                                tagsArray = tagsArray.Append(int.Parse(tagid.InnerText)).ToArray();
                            }
                            break;
                        case "Favorite": fav = bool.Parse(rootxml.InnerText); break;
                    }
                }

                fileData[i] = new Files(fileID, idFather, name, imgPath, imgLayout,filePath, programPath, cmdLine, red, green, blue, resolution, width, height, urlCheck, tagsArray, fav);

                fileID++;
            }

            return fileData;
        }

        //Cargar los datos de un archivo especifico
        private void searchFileProcess(int fileID)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilesPath);
            
            string xpath = "//Launcher/file[@id='" + fileID+ "']"; //Buscar un elemento que se llame "ColeccionX" que tenga en el atributo id un 1
            XmlNode root = doc.SelectSingleNode(xpath);

            string filePath = "";
            string programPath = "";
            string cmdLine = "";
            bool urlCheck = false;

            if (root != null)
            {
                foreach (XmlNode rootxml in root.ChildNodes)
                {
                    // Hacer algo con el nodo, por ejemplo imprimir su nombre
                    Console.WriteLine(rootxml.Name + " | " + rootxml.InnerText);
                    switch (rootxml.Name)
                    {
                        case "FilePath": filePath = rootxml.InnerText; break;
                        case "ProgramPath": programPath = rootxml.InnerText; break;
                        case "CMDLine": cmdLine = rootxml.InnerText; break;
                        case "URLCheck": urlCheck = bool.Parse(rootxml.InnerText); break;
                    }
                }
            }

            //Llamar a la funcion para que empiece el proceso
            startProcess(filePath, programPath, cmdLine, urlCheck);

            //return fileData;
        }
        #endregion
    }
}
