using C_Launcher.Clases;
using CoverPadLauncher.Clases;
using craftersmine.SteamGridDBNet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace CoverPadLauncher
{
    public partial class SearchCoversOnline : Form
    {
        public event EventHandler<string[,]> ReturnedObject;

        private int type = 0;//El tipo de multimedia a buscar (juegos, peliculas/series)

        private string[] names;
        private string[] routes;

        //private string[] coversUrl = new string[0];

        public SearchCoversOnline()
        {
            InitializeComponent();
            CustomComponent();
        }

        //Constructor al crear un solo elemento
        public SearchCoversOnline(string nameFile, string dirFile)
        {
            InitializeComponent();
            CustomComponent();
            
            Array.Resize(ref names, 1);
            Array.Resize(ref routes, 1);

            names[0] = nameFile;
            routes[0] = dirFile;
        }

        //Constructor de multiples elementos
        public SearchCoversOnline(string[,] arrayPass)
        {
            InitializeComponent();
            CustomComponent();

            Array.Resize(ref names, arrayPass.GetLength(0));
            Array.Resize(ref routes, arrayPass.GetLength(0));

            for(int i = 0; i < arrayPass.GetLength(0); i++) 
            {
                names[i] = arrayPass[i,0];
                routes[i] = arrayPass[i,1];
            }
        }

        private void CustomComponent()
        {
            tabControl.TabPages[1].Enabled = false;
            tabControl.TabPages[2].Enabled = false;
        }

        private async Task<string[]> SearchSteamGridDB(string gameName)
        {
            string apikey = new GeneralFunctions().EnvVariable("SteamGridDbApiKey");//EnvVariable("SteamGridDbApiKey");
            //GeneralFunctions gf = new GeneralFunctions();
            SteamGridDb instance = new SteamGridDb(apikey);

            //Utilizar try para errores del tipo: no se encontro, sin autorizacion etc...
            try
            {
                //Buscar el juego por palabra clave (buscara todas las coincidencias)
                var games = await instance.SearchForGamesAsync(gameName);


                //SteamGridDb Game, bool nsfw, bool humorous, bool epilepsy, int page, SteamGridDbTags, SteamGridDbStyles, SteamGridDbDimensions, SteamGridDbFormats, SteamGridDbTypes
                var grids = await instance.GetGridsForGameAsync(games[0], false, false, false, 0, SteamGridDbTags.None, SteamGridDbStyles.AllGrids, SteamGridDbDimensions.W600H900, SteamGridDbFormats.All, SteamGridDbTypes.Static);


                foreach (var grid in grids)
                {
                    Console.WriteLine(grid.FullImageUrl);
                }

                string[] returnstring = new string[grids.Count()];
                //Array.Resize(ref coversUrl, grids.Count());

                for (int i = 0; i< returnstring.Length; i++)
                {
                    returnstring[i] = grids[i].FullImageUrl;
                }

                return returnstring;


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

        private string[] SearchTheMovieDB(string movieName, string type)
        {
            //type = tv ; movie
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
                HttpResponseMessage response = client.GetAsync($"?api_key={apikey}&query={movieName}").Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var apiResponse = response.Content.ReadAsStringAsync().Result;
                    JObject jsonResponse = JObject.Parse(apiResponse);//Serializar el objetoJson

                    //Crear un array de los posters
                    
                    var results = jsonResponse["results"];

                    Console.WriteLine($"Results json: \n{results}\n\n\n");
                    List<string> posterPaths = new List<string>();

                    //Adaptar el objeto a un arrayString
                    for (int i = 0; i < results.Count(); i++)
                    {
                        var film = results[i];

                        if (film["poster_path"] != null && !string.IsNullOrEmpty(film["poster_path"].ToString()))
                        {
                            Console.WriteLine($"Film Poster: \n{film["poster_path"]}\n\n\n");
                            posterPaths.Add($"http://image.tmdb.org/t/p/w500{film["poster_path"]}");
                        }
                    }

                    string[] returnString = posterPaths.ToArray();

                    return returnString;

                    /*foreach (var film in results)
                    {
                        // Verificar si el objeto tiene la propiedad "poster_path"
                        if (film["poster_path"] != null && !string.IsNullOrEmpty(film["poster_path"].ToString()))
                        {
                            //string posterPath = film["poster_path"].ToString();

                            Console.WriteLine($"Poster Path: http://image.tmdb.org/t/p/w500{film["poster_path"]}");
                        }
                    }*/

                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

                //client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        

        //Al cambiar de pestaña, cargar el datagrid de nombres (para poder cargarlo ahora
        private void buttonContinueType_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < names.Length; i++)
            {
                dataGridViewNames.Rows.Add(names[i], routes[i]);
            }

            //Cambiar de pestaña
            tabControl.TabPages[0].Enabled = false;
            tabControl.TabPages[1].Enabled = true;
            tabControl.SelectedTab = tabControl.TabPages[1];
        }

        //Al cambiar de pestaña, utilizar los valores del datagrid para actualizar el array que se utilizara para buscar las caratulas
        private async void buttonContinueName_Click(object sender, EventArgs e)
        {
            //Actualizar el array
            for (int i = 0; i < dataGridViewNames.RowCount; i++)
            {
                names[i] = dataGridViewNames.Rows[i].Cells[0].Value.ToString();
            }

            //Buscar las caratulas
            switch (type)
            {
                //Buscar juegos (SteamGridDB)
                case 0:
                    for (int j = 0; j < names.Length; j++)
                    {
                        //Buscar las url de las caratulas
                        string[] covers = await SearchSteamGridDB(names[j]);


                        //Establecerlo en el dataGridView
                        dataGridViewCovers.Rows.Add(names[j], covers.Length, covers.Length > 0 ? 1 : 0);
                        dataGridViewCovers.Rows[j].Tag = covers;
                    }
                    break;
                case 1:
                    for (int j = 0; j < names.Length; j++)
                    {
                        //Buscar las url de las caratulas
                        string[] covers = SearchTheMovieDB(names[j], "movie");


                        //Establecerlo en el dataGridView
                        dataGridViewCovers.Rows.Add(names[j], covers.Length, covers.Length > 0 ? 1 : 0);
                        dataGridViewCovers.Rows[j].Tag = covers;
                    }
                    break;
            }
            

            //Se selecciona por defecto la primera fila y muestro el contenido de esta
            labelCoverArraySelected.Text = $"{dataGridViewCovers.Rows[0].Cells[2].Value}/{dataGridViewCovers.Rows[0].Cells[1].Value}";


            //Establecer la caratula por url
            if (dataGridViewCovers.Rows[0].Tag is string[] coverArray)
            {
                //Si no se encuentran caratulas estara vacio
                if (coverArray.Length > 0) SetPictureBoxCover(coverArray[0]);
            }

            //Cambiar de pestaña
            tabControl.TabPages[1].Enabled = false;
            tabControl.TabPages[2].Enabled = true; 
            tabControl.SelectedTab = tabControl.TabPages[2];
        }

        private void SetPictureBoxCover(string imageURL)
        {
            try
            {
                // Descargar la imagen desde la URL
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(imageURL);

                    // Crear un MemoryStream desde los bytes
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        // Crear una imagen desde el MemoryStream
                        Image image = Image.FromStream(ms);

                        // Mostrar la imagen en el PictureBox u otro control
                        pictureBoxCover.BackgroundImage = image;

                        //image.Dispose();

                        // Realizar otras operaciones según sea necesario...
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo establecer la caratula de la url: \n{imageURL}\n debido a: {ex}");
            }
            
        }

        

        private void buttonCoverNext_Click(object sender, EventArgs e)
        {
            int sR = dataGridViewCovers.CurrentCell.RowIndex;//Fila seleccionada

            int arrayLength = int.Parse(dataGridViewCovers.Rows[sR].Cells[1].Value.ToString());
            int actualCover = int.Parse(dataGridViewCovers.Rows[sR].Cells[2].Value.ToString());

            if (actualCover < arrayLength)
            {
                actualCover++;
                dataGridViewCovers.Rows[sR].Cells[2].Value = actualCover.ToString();


                if (dataGridViewCovers.Rows[sR].Tag is string[] coverArray)
                {
                    //Si no se encuentran caratulas estara vacio
                    if (coverArray.Length > 0) SetPictureBoxCover(coverArray[actualCover-1]);
                    labelCoverArraySelected.Text = $"{actualCover}/{arrayLength}";
                }
            }
        }

        private void buttonCoverBack_Click(object sender, EventArgs e)
        {
            int sR = dataGridViewCovers.CurrentCell.RowIndex;//Fila seleccionada

            int actualCover = int.Parse(dataGridViewCovers.Rows[sR].Cells[2].Value.ToString());

            if (actualCover > 1)
            {
                actualCover--;
                dataGridViewCovers.Rows[sR].Cells[2].Value = actualCover.ToString();

                if (dataGridViewCovers.Rows[sR].Tag is string[] coverArray)
                {
                    //Si no se encuentran caratulas estara vacio
                    if (coverArray.Length > 0) SetPictureBoxCover(coverArray[actualCover-1]);
                    labelCoverArraySelected.Text = $"{actualCover}/{dataGridViewCovers.Rows[sR].Cells[1].Value}";
                }
            }
        }

        //Cuando se cambie de fila en el dataGrid de caratulas, actualizar todo
        private void dataGridViewCovers_SelectionChanged(object sender, EventArgs e)
        {
            int sR = dataGridViewCovers.CurrentCell.RowIndex;//Fila actual
            int actualCover = int.Parse(dataGridViewCovers.Rows[sR].Cells[2].Value.ToString());

            //Actualizar la cantidad de caratulas encontradas
            labelCoverArraySelected.Text = $"{actualCover}/{dataGridViewCovers.Rows[sR].Cells[1].Value}";


            //Establecer la caratula por url
            if (dataGridViewCovers.Rows[sR].Tag is string[] coverArray)
            {
                //Si no se encuentran caratulas estara vacio
                if (coverArray.Length > 0) SetPictureBoxCover(coverArray[actualCover-1]);
            }
        }

        private void radioButtonFilms_CheckedChanged(object sender, EventArgs e)
        {
            type = 1;
        }

        private void radioButtonGames_CheckedChanged(object sender, EventArgs e)
        {
            type = 0;
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            int rowCount = dataGridViewCovers.RowCount;
            string[,] passFile = new string[rowCount, 2];
            for (int i=0; i < rowCount; i++)
            {
                //Extraer el nuevo nombre del elemento (por que se puede cambiar en la pestaña de confirmacion de nombre
                passFile[i,0] = dataGridViewCovers.Rows[i].Cells[0].Value.ToString();

                //Extraer la url elegida
                if (dataGridViewCovers.Rows[i].Tag is string[] coverArray)
                {
                    //Si no se encuentran caratulas estara vacio
                    if (coverArray.Length > 0)
                    {
                        int actualCover = int.Parse(dataGridViewCovers.Rows[i].Cells[2].Value.ToString());
                        passFile[i, 1] = coverArray[actualCover - 1];
                    }
                } 
            }

            ReturnedObject?.Invoke(this, passFile);
            this.Close();
        }
    }
}
