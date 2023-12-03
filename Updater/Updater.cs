using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Net;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Updater
{ 
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Actualizando CoverPadLauncher...");
            string zipPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"CoverPadLauncher-Update.zip");
            string extractPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            downloadZip(zipPath, extractPath);
            ExtractZip(zipPath, extractPath);

        }

        static void downloadZip(string zipPath, string extractPath)
        {
            string nameUser = "Jordan108";
            string nameRepo = "cSharpLauncher";
            
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"https://api.github.com/repos/{nameUser}/{nameRepo}/releases/latest");
                client.DefaultRequestHeaders.Add("User-Agent", "CoverPadLauncher");//Tengo que establecer el user agent o la api rechaza la solicitud por que webos

                //Header en formato json
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("").Result;
                if (response.IsSuccessStatusCode)
                {
                    //Analizar la respuesta
                    var apiResponse = response.Content.ReadAsStringAsync().Result;
                    JObject release = JObject.Parse(apiResponse);//Serializar el objetoJson
                   
                    //latestVersion = release["tag_name"].ToString();

                    string zipUrl = release["assets"][0]["browser_download_url"].ToString();

                    using (WebClient webClient = new WebClient())
                    {
                        Console.WriteLine($"Descargando desde: {zipUrl} - {zipPath}");
                        webClient.DownloadFile(zipUrl, zipPath);

                        // Reiniciar la aplicacion
                        //System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        //Environment.Exit(0);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al intentar descargar la actualizacion\n{e}");
            }
        }

        static void ExtractZip(string zipPath, string extractPath)
        {
            //Primero extraer el zip
            Console.WriteLine("Extrayendo el zip...");
            ZipFile.ExtractToDirectory(zipPath, extractPath, true);
            Console.WriteLine("Limpiando...");
            //Luego de extraerlo, eliminarlo
            File.Delete(zipPath);

            //Despues abrir coverpad y cerrar el updater
            Console.WriteLine("Abriendo CoverPad Launcher ...");
            string updaterPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\CoverPadLauncher.exe";
            //Process.Start(updaterPath, $"{zipUrl} {downloadPath} {extractPath}");
            Process.Start(updaterPath);

            Environment.Exit(0);
        }
    }
}