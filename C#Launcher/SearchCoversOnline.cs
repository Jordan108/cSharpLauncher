using CoverPadLauncher.Clases;
using craftersmine.SteamGridDBNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace CoverPadLauncher
{
    public partial class SearchCoversOnline : Form
    {
        public SearchCoversOnline()
        {
            InitializeComponent();
        }

        private async void SearchSteamGridDB()
        {
            string apikey = new GeneralFunctions().EnvVariable("SteamGridDbApiKey");//EnvVariable("SteamGridDbApiKey");
            //GeneralFunctions gf = new GeneralFunctions();
            SteamGridDb instance = new SteamGridDb(apikey);

            //Utilizar try para errores del tipo: no se encontro, sin autorizacion etc...
            try
            {
                //Buscar el juego por palabra clave (buscara todas las coincidencias)
                var games = await instance.SearchForGamesAsync(testBox.Text);

                //SteamGridDb Game, bool nsfw, bool humorous, bool epilepsy, int page, SteamGridDbTags, SteamGridDbStyles, SteamGridDbDimensions, SteamGridDbFormats, SteamGridDbTypes
                var grids = await instance.GetGridsForGameAsync(games[0], false, false, false, 0, SteamGridDbTags.None, SteamGridDbStyles.AllGrids, SteamGridDbDimensions.W600H900, SteamGridDbFormats.All, SteamGridDbTypes.All);


                foreach (var grid in grids)
                {
                    Console.WriteLine(grid.FullImageUrl);
                }

                if (grids != null && grids.Count() > 0)
                {
                    //Tomando la primera imagen de la lista
                    string imageUrl = grids[0].FullImageUrl;

                    grids = null;

                    // Descargar la imagen desde la URL
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] imageBytes = webClient.DownloadData(imageUrl);

                        // Crear un MemoryStream desde los bytes
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            // Crear una imagen desde el MemoryStream
                            Image image = Image.FromStream(ms);

                            // Mostrar la imagen en el PictureBox u otro control
                            pictureBox1.BackgroundImage = image;

                            image.Dispose();

                            // Realizar otras operaciones según sea necesario...
                        }
                    }
                }
                //Console.WriteLine($"grids encontradas: {grids[0]}");

                //var game = await instance.GetGameByIdAsync(1226);//Tambien se pueden buscar por ID de steamGridDB
                //game = await instance.GetGameBySteamIdAsync(105600);//Tambien se pueden buscar por ID de juego de steam


                // You can get Grids, Heroes, Logos and Icons by calling needed methods
                // Here, we will get all available grids for game Terraria, with all styles, dimensions, etc by using SteamGridDB game ID
                /*var grids = await instance.GetGridsByGameIdAsync(1226);
                grids = await instance.GetGridsByPlatformGameIdAsync(SteamGridDbGamePlatform.Steam, 105600);

                // And here we will get all available Terraria logos with "Custom" style
                var logos = await instance.GetLogosByGameIdAsync(1226, styles: SteamGridDbStyles.Custom);
                // Here we will get all available animated Terraria logos
                logos = await instance.GetLogosByPlatformGameIdAsync(SteamGridDbGamePlatform.Steam, 105600, types: SteamGridDbTypes.Animated);
                */
            }
            catch (Exception er)
            {
                Console.WriteLine(er);
                throw;
            }
        }

        private async void SearchTheMovieDB()
        {
            try
            {
                //la api key la saque de: https://codepen.io/pixelnik/pen/pgWQBZ (es temporal mientras consigo la propia)
                string apikey = new GeneralFunctions().EnvVariable("TheMovieDbApiKey");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/search/movie");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync("?api_key=15d2ea6d0dc1d476efbca3eba2b9bbfb&query=scott").Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var apiResponse = response.Content.ReadAsStringAsync().Result;
                    JObject jsonResponse = JObject.Parse(apiResponse);//Serializar el objetoJson

                    //Crear un array de los posters
                    var results = jsonResponse["results"];

                    foreach (var film in results)
                    {
                        // Verificar si el objeto tiene la propiedad "poster_path"
                        if (film["poster_path"] != null && !string.IsNullOrEmpty(film["poster_path"].ToString()))
                        {
                            //string posterPath = film["poster_path"].ToString();

                            Console.WriteLine($"Poster Path: http://image.tmdb.org/t/p/w500{film["poster_path"]}");
                        }
                    }

                    //var jsonResponse = (JObject)JsonConvert.DeserializeObject(apiResponse); //JsonConvert.DeserializeObject(apiResponse);


                    //Console.WriteLine("jsonResponse: "+ jsonResponse["poster_path"].Value<string>());
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
                client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchSteamGridDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchTheMovieDB();
        }
    }
}
