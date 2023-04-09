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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_Launcher
{
    public partial class Home : Form
    {
        private PictureBox[] picBoxArr = new PictureBox[0];//Crear el array de picBox que se mantendra en memoria
        private int viewDepth = 0;
        //Rutas de los archivos XML
        private string xmlColPath = "example.xml";


        /*
         como hacer un get y un set de una clase

        Clase a = new clase()

        a.name = "value"; Set
        string name = a.name; Get
         */
        public Home()
        {
            InitializeComponent();
            int colSize = loadCollectionSize();
            int fileSize = loadFilesSize();

            flowLayoutPanelMain.SuspendLayout();
                Console.WriteLine("tamaño col: " +  colSize);
                loadPictureBox(colSize, fileSize, false);
                //saveXMLCollection();
            flowLayoutPanelMain.ResumeLayout();
        }

        //Cuando la vista cargue
        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        #region controlar vista de usuario 
        private void loadPictureBox(int colSize, int fileSize, bool filter)
        {
            Collections[] colls = new Collections[colSize];
            colls = loadCollections(colSize);

            Files[] files = new Files[fileSize];
          //  files = loadFiles(fileSize);

            //Hacer el array tan largo como las colecciones y archivos existentes (despues se optimiza)
            Array.Resize(ref picBoxArr, colSize + fileSize);


            int pL = 0;//largo de los pictureBox de esa profundidad

           //Recorrer todos el array de las colecciones colecciones
           for(int i = 0; i < colls.Length; i++)
            {
                //Solo agregar las colecciones que coincidan con la profundidad actual

                if (viewDepth == colls[i].IDFather)
                {
                    //Image imagen = Image.FromFile(colls[i].ImagePath);
                    //Definir el picture box
                    picBoxArr[pL] = new PictureBox
                    {
                        Name = colls[i].Name,
                        Size = new Size(colls[i].Width, colls[i].Height),
                        BackColor = Color.FromArgb(colls[i].ColorRed, colls[i].ColorGreen, colls[i].ColorBlue),
                        /*
                        BackgroundImage = imagen,
                        */

                        Text = "collection",//Aqui se indica que tipo de picture box es (coleccion / archivo)
                        Tag = colls[i].ID,
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


                    flowLayoutPanelMain.Controls.Add(picBoxArr[pL]);

                    pL++;//iterar en el array de paneles
                }

                
            }

           //Optimizar el tamaño del array
            Array.Resize(ref picBoxArr, pL);
        }
        #endregion

        #region Manejar datos XML
        private void saveXMLCollection()
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
            XmlElement colFather = xmlDoc.CreateElement("IDFather"); colFather.InnerText = "-1"; coleccion.AppendChild(colFather);
            XmlElement colName = xmlDoc.CreateElement("Name"); colName.InnerText = "nombre"; coleccion.AppendChild(colName);
            XmlElement colImage = xmlDoc.CreateElement("Image"); colImage.InnerText = "/"; coleccion.AppendChild(colImage);
            XmlElement colLayout = xmlDoc.CreateElement("ImageLayout"); colLayout.InnerText = "/"; coleccion.AppendChild(colLayout);
            XmlElement colBgRed = xmlDoc.CreateElement("BackgroundRed"); colBgRed.InnerText = "255"; coleccion.AppendChild(colBgRed);
            XmlElement colBgGreen = xmlDoc.CreateElement("BackgroundGreen"); colBgGreen.InnerText = "255"; coleccion.AppendChild(colBgGreen);
            XmlElement colBgBlue = xmlDoc.CreateElement("BackgroundBlue"); colBgBlue.InnerText = "255"; coleccion.AppendChild(colBgBlue);
            XmlElement colResolution = xmlDoc.CreateElement("CoverResolutionID"); colResolution.InnerText = "0"; coleccion.AppendChild(colResolution);
            XmlElement colWith = xmlDoc.CreateElement("CoverWidth"); colWith.InnerText = "200"; coleccion.AppendChild(colWith);
            XmlElement colHeight = xmlDoc.CreateElement("CoverHeight"); colHeight.InnerText = "200"; coleccion.AppendChild(colHeight);
            XmlElement colTags = xmlDoc.CreateElement("TagsID"); colTags.InnerText = "0"; coleccion.AppendChild(colTags);
            XmlElement colFavorite = xmlDoc.CreateElement("Favorite"); colFavorite.InnerText = "false"; coleccion.AppendChild(colFavorite);

            xmlDoc.Save(xmlColPath);
        }

        //Cargar el tamaño de elementos con id que existen en el xml de archivos
        private int loadFilesSize()
        {
            int size = 0;
            return size;
        }

        //Cargar el tamaño de elementos con id que existen en el xml de colecciones
        private int loadCollectionSize()
        {
            int size = 0;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlColPath);

            XmlNodeList colElements = xmlDoc.SelectNodes("//*[@id]");

            size = colElements.Count;

            return size;
        }
        //cargar las colecciones del xml en un objeto collections array
        private Collections[] loadCollections(int arraySize) {
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
                        case "BackgroundRed": red = int.Parse(rootxml.InnerText);  break;
                        case "BackgroundGreen": green = int.Parse(rootxml.InnerText); break;
                        case "BackgroundBlue": blue = int.Parse(rootxml.InnerText); break;
                        case "CoverResolutionID": resolution = int.Parse(rootxml.InnerText); break;
                        case "CoverWidth": width = int.Parse(rootxml.InnerText);  break;
                        case "CoverHeight": height = int.Parse(rootxml.InnerText); break;
                        case "TagsID":
                            string[] strArray = rootxml.InnerText.Split(' ');
                            tagsArray = strArray.Select(s => int.Parse(s)).ToArray(); 
                            break;
                        case "Favorite": fav = bool.Parse(rootxml.InnerText);  break;
                    }
                }

                colData[i] = new Collections(fileID,idFather, name, imgPath, imgLayout, red, green, blue, resolution, width, height, tagsArray, fav);

                fileID++;
            }

            return colData;
        }
        #endregion
    }
}
