using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoverPadLauncher.Clases
{
    public class GeneralFunctions
    {
        //Ruta de las caratulas
        private string dirCoversPath = "System\\Covers";

        public string XMLDefaultReturn(XmlNode node, string singleNode, string defaultValue)
        {
            XmlNode selectedNode = node.SelectSingleNode(singleNode);
            if (selectedNode != null)
            {
                return selectedNode.InnerText;
            }
            return defaultValue;
        }
        public string ReturnImagePath(string outputFolder, string fileName, string extension)
        {
            string destinationFile = outputFolder + "\\" + extension + fileName + ".png";
            int i = 0;
            while (File.Exists(destinationFile))
            {
                i++;
                destinationFile = outputFolder + "\\" + extension + fileName + "(" + i + ").png";//Se le cambia la extension a png
            }
            return destinationFile;
        }
        public string SaveCover(string coverName, string originalImageDir, bool newCover, string coverType)
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
                    imgPath = ReturnImagePath(dirCoversPath, cleanName, coverType);
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
                            imgPath = ReturnImagePath(dirCoversPath, cleanName, coverType);
                        }
                        else
                        {
                            imgPath = originalImageDir;
                        }
                    }
                    else
                    {

                        imgPath = ReturnImagePath(dirCoversPath, cleanName, coverType);
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
                    System.Drawing.Image saveImage;
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

        public bool CheckImage(string fileDir)
        {
            string ex = Path.GetExtension(fileDir);
            if (!string.IsNullOrEmpty(ex))
            {
                string extensionLower = ex.ToLower();
                return extensionLower == ".jpg" || extensionLower == ".png" || extensionLower == ".webp";
            }
            return false;
        }
    }
}
