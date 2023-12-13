﻿using ImageMagick;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace CoverPadLauncher.Clases
{
    public class GeneralFunctions
    {
        //Ruta de las caratulas
        private string dirCoversPath = "System\\Covers";

        public string XMLDefaultReturn(XmlNode node, string singleNode, string defaultValue)
        {
            
            try
            {
                XmlNode selectedNode = node.SelectSingleNode(singleNode);
                if (selectedNode != null)
                {
                    return selectedNode.InnerText;
                }
            } catch (Exception)
            {
                Console.WriteLine("Devolviendo valor por default");
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
            //Para descargar caratulas online
            string tempOnlineImagePath = "System\\Covers\\http_temp_Cover.png";


            //Primero, verificar si la caratula es online (si es asi, descargarla temporalmente en System//Covers)
            if (originalImageDir.StartsWith("https://") || originalImageDir.StartsWith("http://"))
            {
                try
                {
                    //Algunas url pueden contener redirecciones, asi que verifico
                    string finalImageUrl = GetFinalImageUrl(originalImageDir);

                    // Descargar la imagen desde la URL
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] imageBytes = webClient.DownloadData(finalImageUrl);
                        Console.WriteLine($"Descargando imagen desde: {finalImageUrl}");

                        // Crear un MemoryStream desde los bytes
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            using (var onlineCover = Image.FromStream(ms)){
                                //Guardarlo como png
                                onlineCover.Save(tempOnlineImagePath, ImageFormat.Png);
                                //Establecer originalImageDir como la caratula descargada
                                originalImageDir = tempOnlineImagePath;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"No se pudo descargar la caratula de la url: \n{originalImageDir}\n debido a: {ex}");
                }
            }

            //Mover la imagen hacia la carpeta covers y transformarla a .png
            //Si estas creando un nuevo archivo, verificar si no existe un archivo con el mismo nombre, y si es asi, ponerle un iterador
            if (originalImageDir != "")
            {
                if (newCover)
                {
                    //Creando una nueva caratula
                    imgPath = ReturnImagePath(dirCoversPath, cleanName, coverType);
                }
                else
                {
                    //Si estas editando un archivo, ocupar la misma direccion que en el xml, pues el nombre se decidio al crearse
                    if (originalImageDir != null)
                    {
                        string systemCoverDir = dirCoversPath;
                        string xmlDir = Path.GetDirectoryName(originalImageDir);

                        imgPath = ReturnImagePath(dirCoversPath, cleanName, coverType);
                        if (xmlDir != systemCoverDir)
                        {
                            //Si la ubicacion de la caratula al editar no esta en system/Covers moverla alli
                            imgPath = ReturnImagePath(dirCoversPath, cleanName, coverType);
                            Console.WriteLine($"save A imagePath: {imgPath}");
                        }
                        else
                        {
                            //Caso contrario dejarlo como estaba, Excepto si el nombre del archivo es http_temp_Cover (en caso de que alguien quiera editar la ruta desde el xml)
                            if (originalImageDir != "System\\Covers\\http_temp_Cover.png") imgPath = originalImageDir;
                            else imgPath = ReturnImagePath(dirCoversPath, cleanName, coverType);
                            Console.WriteLine($"save B imagePath: {imgPath}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("save C");
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

            //Antes de devolver, si existe la imagen temporal de descarga online, eliminarlo
            if (File.Exists(tempOnlineImagePath))
            {
                File.Delete(tempOnlineImagePath);
            }

            return imgPath;
        }

        //Para descargar Imagenes online
        public string GetFinalImageUrl(string imageUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imageUrl);
            request.AllowAutoRedirect = true; // Habilita el seguimiento de redirecciones

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // La propiedad ResponseUri contiene la URL final después de seguir las redirecciones
                return response.ResponseUri.ToString();
            }
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

        //rescata un valor desde el json env.json
        /*public string EnvVariable(string key)
        {
            // Verifica si el archivo existe
            if (!File.Exists("env.txt"))
            {
                Console.WriteLine($"El archivo env.txt no existe.");
                return null;
            }

            // Lee todas las líneas del archivo
            string[] lineas = File.ReadAllLines("env.txt");

            // Itera sobre cada línea para buscar la clave
            foreach (string linea in lineas)
            {
                // Divide la línea en clave y valor usando el carácter '=' como separador
                string[] partes = linea.Split('=');

                // Verifica si la clave actual coincide con la clave buscada (ignorando mayúsculas y minúsculas)
                if (partes.Length == 2 && partes[0].Trim().Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    // Devuelve el valor asociado a la clave
                    return partes[1].Trim();
                }
            }

            // Si la clave no se encontró, devuelve null
            return null;
        }*/
    }
}
