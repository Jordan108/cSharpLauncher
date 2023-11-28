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
            loadTheme();
        }

        private void loadTheme()
        {
            Configurations config = new Configurations();
            Themes theme = new Themes($"System\\Themes\\{config.ThemeName}.css");

            //Fondos
            BackColor = theme.WindowBackground;
            tabPage1.BackColor = theme.WindowBackground;
            tabPage2.BackColor = theme.WindowBackground;
            tabPage3.BackColor = theme.WindowBackground;

            //Textos
            groupBox1.ForeColor = theme.LabelText;
            radioButtonGames.ForeColor = theme.LabelText;
            radioButtonFilms.ForeColor = theme.LabelText;
            radioButtonSeries.ForeColor = theme.LabelText;
            radioButtonMangas.ForeColor = theme.LabelText;
            radioButtonComics.ForeColor = theme.LabelText;
            radioButtonBooks.ForeColor = theme.LabelText;
            labelChangeNameWarning.ForeColor = theme.LabelText;
            labelCoverArraySelected.ForeColor = theme.LabelText;

            //Botones
            buttonContinueType.BackColor = theme.ButtonBackground;
            buttonContinueType.ForeColor = theme.ButtonText;
            buttonContinueName.BackColor = theme.ButtonBackground;
            buttonContinueName.ForeColor = theme.ButtonText;
            buttonCoverBack.BackColor = theme.ButtonBackground;
            buttonCoverBack.ForeColor = theme.ButtonText;
            buttonCoverNext.BackColor = theme.ButtonBackground;
            buttonCoverNext.ForeColor = theme.ButtonText;
            buttonFinish.BackColor = theme.ButtonBackground;
            buttonFinish.ForeColor = theme.ButtonText;
            //Datagridview
            dataGridViewNames.BackgroundColor = theme.DataGridBackground;
            dataGridViewNames.GridColor = theme.DataGridBorder;
            dataGridViewNames.DefaultCellStyle.BackColor = theme.DataGridCellBackground;
            dataGridViewNames.DefaultCellStyle.ForeColor = theme.DataGridCellText;
            dataGridViewNames.DefaultCellStyle.SelectionBackColor = theme.DataGridSelectedBackground;
            dataGridViewNames.DefaultCellStyle.SelectionForeColor = theme.DataGridSelectedText;

            dataGridViewCovers.BackgroundColor = theme.DataGridBackground;
            dataGridViewCovers.GridColor = theme.DataGridBorder;
            dataGridViewCovers.DefaultCellStyle.BackColor = theme.DataGridCellBackground;
            dataGridViewCovers.DefaultCellStyle.ForeColor = theme.DataGridCellText;
            dataGridViewCovers.DefaultCellStyle.SelectionBackColor = theme.DataGridSelectedBackground;
            dataGridViewCovers.DefaultCellStyle.SelectionForeColor = theme.DataGridSelectedText;
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


                /*foreach (var grid in grids)
                {
                    Console.WriteLine(grid.FullImageUrl);
                }*/

                string[] returnstring = new string[grids.Count()];
                //Array.Resize(ref coversUrl, grids.Count());

                for (int i = 0; i< returnstring.Length; i++)
                {
                    returnstring[i] = grids[i].FullImageUrl;
                    updateProgressBar(i, returnstring.Length);
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
            try
            {
                //la api key la saque de: https://codepen.io/pixelnik/pen/pgWQBZ (es temporal mientras consigo la propia)
                string apikey = new GeneralFunctions().EnvVariable("TheMovieDbApiKey");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/search/movie");

                //Header en formato json
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync($"?api_key={apikey}&query={movieName}").Result;
                if (response.IsSuccessStatusCode)
                {
                    //Analizar la respuesta
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

                        updateProgressBar(i, results.Count());
                    }

                    string[] returnString = posterPaths.ToArray();

                    return returnString;

                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

                //client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SearchTheMovieDB: {ex.Message}");
            }

            return null;
        }

        private string[] SearchComicsVine(string comicName)
        {
            try
            {
                string apikey = new GeneralFunctions().EnvVariable("ComicVineApiKey");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://comicvine.gamespot.com/api/volumes");
                client.DefaultRequestHeaders.Add("User-Agent", "CoverPadLauncher");//Tengo que establecer el user agent o la api rechaza la solicitud por que webos

                //Header en formato json
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync($"?api_key={apikey}&filter=name:{comicName}&sort=name&format=json").Result;
                if (response.IsSuccessStatusCode)
                {
                    //Analizar la respuesta
                    var apiResponse = response.Content.ReadAsStringAsync().Result;
                    JObject jsonResponse = JObject.Parse(apiResponse);//Serializar el objetoJson

                    //Crear un array de la data de las caratulas
                    var results = jsonResponse["results"];

                    Console.WriteLine($"Results json: \n{results}\n\n\n");
                    List<string> coversPaths = new List<string>();

                    //Adaptar el objeto a un arrayString
                    for (int i = 0; i < results.Count(); i++)
                    {
                        //var film = results[i]["image"]["original_url"];

                        if (results[i]["image"]["original_url"] != null && !string.IsNullOrEmpty(results[i]["image"]["original_url"].ToString()))
                        {
                            Console.WriteLine($"Film Poster: \n{results[i]["image"]["original_url"]}\n\n\n");
                            coversPaths.Add($"{results[i]["image"]["original_url"]}");
                        }

                        updateProgressBar(i, results.Count());
                    }

                    string[] returnString = coversPaths.ToArray();

                    return returnString;

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

        private string[] SearchOpenLibrary(string bookName)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://openlibrary.org/search.json");
                client.DefaultRequestHeaders.Add("User-Agent", "CoverPadLauncher");//Por si acaso
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//Header en formato json

                HttpResponseMessage response = client.GetAsync($"?q={bookName}").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("OpenLibrary Response success");

                    //Analizar la respuesta
                    var apiResponse = response.Content.ReadAsStringAsync().Result;
                    JObject jsonResponse = JObject.Parse(apiResponse);//Serializar el objetoJson

                    //Crear un array de la data de las caratulas
                    var results = jsonResponse["docs"];//Cada objeto sera un libro diferente

                    List<string> coversPaths = new List<string>();

                    //Adaptar el objeto a un arrayString
                    int bookLimit = 10;//Cantidad maxima de libros a rescatar
                    for (int b = 0; b < results.Count(); b++)
                    {
                        int limitType = 1;//Solo uno por tipo (o si no tendrias como 5 caratulas iguales)
                        //Las caratulas estan dentro de diferentes objetos que podrian o no existir, por lo que se intentara iterar dentro de cada uno verificando que exista y tenga contenido
                        //Caratulas tipo oclc
                        if (results[b]["oclc"] != null && results[b]["oclc"].Count() > 0)
                        {
                            for(int c=0; c < results[b]["oclc"].Count(); c++)
                            {
                                if (!URLImageExists($"https://covers.openlibrary.org/b/oclc/{results[b]["oclc"][c]}-L.jpg?default=false"))
                                {
                                    Console.WriteLine($"https://covers.openlibrary.org/b/oclc/{results[b]["oclc"][c]}-L.jpg devolvio 404");
                                    limitType++;//si no se encuentran caratulas, no se cuenta para el limite
                                    continue;//Algunas imagenes no existen xd
                                }
                                Console.WriteLine($"Se añadio https://covers.openlibrary.org/b/oclc/{results[b]["oclc"][c]}-L.jpg");
                                coversPaths.Add($"https://covers.openlibrary.org/b/oclc/{results[b]["oclc"][c]}-L.jpg");
                                if (c > limitType) break;
                            }
                        }
                        //Caratulas de tipo isbn
                        if (results[b]["isbn"] != null && results[b]["isbn"].Count() > 0)
                        {
                            for (int c = 0; c < results[b]["isbn"].Count(); c++)
                            {
                                if (!URLImageExists($"https://covers.openlibrary.org/b/isbn/{results[b]["isbn"][c]}-L.jpg?default=false"))
                                {
                                    Console.WriteLine($"https://covers.openlibrary.org/b/isbn/{results[b]["isbn"][c]}-L.jpg devolvio 404");
                                    limitType++;//si no se encuentran caratulas, no se cuenta para el limite
                                    continue;//Algunas imagenes no existen xd
                                }
                                Console.WriteLine($"Se añadio https://covers.openlibrary.org/b/isbn/{results[b]["isbn"][c]}-L.jpg");
                                coversPaths.Add($"https://covers.openlibrary.org/b/isbn/{results[b]["isbn"][c]}-L.jpg");
                                if (c > limitType) break;
                            }
                        }
                        //Caratulas de tipo isbn
                        if (results[b]["lccn"] != null && results[b]["lccn"].Count() > 0)
                        {
                            for (int c = 0; c < results[b]["lccn"].Count(); c++)
                            {
                                if (!URLImageExists($"https://covers.openlibrary.org/b/lccn/{results[b]["lccn"][c]}-L.jpg?default=false"))
                                {
                                    Console.WriteLine($"https://covers.openlibrary.org/b/lccn/{results[b]["lccn"][c]}-L.jpg devolvio 404");
                                    limitType++;//si no se encuentran caratulas, no se cuenta para el limite
                                    continue;//Algunas imagenes no existen xd
                                }
                                Console.WriteLine($"Se añadio https://covers.openlibrary.org/b/lccn/{results[b]["lccn"][c]}-L.jpg");
                                coversPaths.Add($"https://covers.openlibrary.org/b/lccn/{results[b]["lccn"][c]}-L.jpg");
                                if (c > limitType) break;
                            }
                        }
                        
                        if (b > bookLimit) break;
                        updateProgressBar(b, bookLimit);
                    }


                    string[] returnString = coversPaths.ToArray();

                    return returnString;

                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

                //client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SearchOpenLibrary: {ex.Message}");
            }

            return null;
        }

        private static bool URLImageExists(string imageUrl)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imageUrl);
                request.Method = "HEAD"; // Utiliza el método HEAD en lugar de GET

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Verifica si la respuesta es satisfactoria (código 200-299)
                    return (int)response.StatusCode >= 200 && (int)response.StatusCode < 300;
                }
            }
            catch (WebException ex)
            {
                //Cualquier error con la imagen devolvera un false
                return false;
            }
        }

        private async Task<string[]> SearchMangaDex(string mangaName)
        {
            try
            {
                //Primero, se tiene que identificar la id del manga al buscar un nombre
                HttpClient clientID = new HttpClient();
                clientID.BaseAddress = new Uri("https://api.mangadex.org/manga");
                clientID.DefaultRequestHeaders.Add("User-Agent", "CoverPadLauncher");//Tengo que establecer el user agent o la api rechaza la solicitud por que webos
                HttpResponseMessage responseID = clientID.GetAsync($"?title={mangaName}").Result;//Parametros de la api

                if (responseID.IsSuccessStatusCode)
                {

                    //Analizar la respuesta
                    var apiIDResponse = responseID.Content.ReadAsStringAsync().Result;
                    JObject jsonIDResponse = JObject.Parse(apiIDResponse);//Serializar el objetoJson

                    Console.WriteLine(jsonIDResponse);
                    
                    //Navegar  dentro de la respuesta de la api y rescatar la primera id
                    string mangaId = jsonIDResponse["data"][0]["id"].ToString();//Si queremos revisar todas las id, podemos navegar en jsonIDResponse["data"][i] y revisar los nombres en jsonIDResponse["data"][i]["attributes"]["title"]["en"]

                    //Ahora teniendo el id del manga, volvemos a hacer un request de la api pero esta vez, para rescatar las caratulas asociadas a esa id
                    HttpClient clientCover = new HttpClient();
                    clientCover.BaseAddress = new Uri("https://api.mangadex.org/cover");
                    clientCover.DefaultRequestHeaders.Add("User-Agent", "CoverPadLauncher");//Tengo que establecer el user agent o la api rechaza la solicitud por que webos
                    HttpResponseMessage responseCover = clientCover.GetAsync($"?limit={10}&manga%5B%5D={mangaId}&order%5BcreatedAt%5D=asc&order%5BupdatedAt%5D=asc&order%5Bvolume%5D=asc").Result;//limit=Cantidad max de covers

                    Console.WriteLine("Response: ", await responseCover.Content.ReadAsStringAsync());

                    if (responseCover.IsSuccessStatusCode)
                    {
                        //Analizar la respuesta
                        var apiCoverResponse = responseCover.Content.ReadAsStringAsync().Result;
                        JObject jsonCoverResponse = JObject.Parse(apiCoverResponse);//Serializar el objetoJson

                        //Las caratulas estan separadas
                        var resultsData = jsonCoverResponse["data"];

                        List<string> coversPaths = new List<string>();

                        for (int i = 0; i < resultsData.Count(); i++)
                        {
                            var manga = resultsData[i];

                            if (manga["attributes"]["fileName"] != null && !string.IsNullOrEmpty(manga["attributes"]["fileName"].ToString()))
                            {
                                Console.WriteLine($"Manga Cover: \n{manga["attributes"]["fileName"]}\n\n\n");

                                coversPaths.Add($"https://uploads.mangadex.org/covers/{mangaId}/{manga["attributes"]["fileName"]}");
                            }
                        }
                        
                        string[] returnString = coversPaths.ToArray();

                        return returnString;
                    }
                    
                } else
                {
                    Console.WriteLine($"No hubo respuesta de api id: {responseID}");
                    return null;
                }
            } catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                //Agregar mas detalles
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
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
                //Buscar Peliculas
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
                //Buscar Series
                case 2:
                    for (int j = 0; j < names.Length; j++)
                    {
                        //Buscar las url de las caratulas
                        string[] covers = SearchTheMovieDB(names[j], "tv");

                        //Establecerlo en el dataGridView
                        dataGridViewCovers.Rows.Add(names[j], covers.Length, covers.Length > 0 ? 1 : 0);
                        dataGridViewCovers.Rows[j].Tag = covers;
                    }
                    break;
                //Buscar mangas
                case 3:
                    for (int j = 0; j < names.Length; j++)
                    {
                        //Buscar las url de las caratulas
                        string[] covers = await SearchMangaDex(names[j]);

                        //Establecerlo en el dataGridView
                        dataGridViewCovers.Rows.Add(names[j], covers.Length, covers.Length > 0 ? 1 : 0);
                        dataGridViewCovers.Rows[j].Tag = covers;
                    }
                    break;
                //Buscar comics
                case 4:
                    for (int j = 0; j < names.Length; j++)
                    {
                        //Buscar las url de las caratulas
                        string[] covers = SearchComicsVine(names[j]);

                        //Establecerlo en el dataGridView
                        dataGridViewCovers.Rows.Add(names[j], covers.Length, covers.Length > 0 ? 1 : 0);
                        dataGridViewCovers.Rows[j].Tag = covers;
                    }
                    break;

                //Buscar libros
                case 5:
                    for (int j = 0; j < names.Length; j++)
                    {
                        //Buscar las url de las caratulas
                        string[] covers = SearchOpenLibrary(names[j]);

                        //Establecerlo en el dataGridView
                        dataGridViewCovers.Rows.Add(names[j], covers.Length, covers.Length > 0 ? 1 : 0);
                        dataGridViewCovers.Rows[j].Tag = covers;
                    }
                    break;
            }

            //Mostrar la barra de progreso
            progressBarDownload.Visible = true;

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
                //Algunas url pueden contener redirecciones, asi que verifico
                string finalImageUrl = GetFinalImageUrl(imageURL);

                // Descargar la imagen desde la URL
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(finalImageUrl);

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

        private static string GetFinalImageUrl(string imageUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imageUrl);
            request.AllowAutoRedirect = true; // Habilita el seguimiento de redirecciones

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // La propiedad ResponseUri contiene la URL final después de seguir las redirecciones
                return response.ResponseUri.ToString();
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

        private void radioButtonGames_CheckedChanged(object sender, EventArgs e)
        {
            type = 0;
        }

        private void radioButtonFilms_CheckedChanged(object sender, EventArgs e)
        {
            type = 1;
        }

        private void radioButtonSeries_CheckedChanged(object sender, EventArgs e)
        {
            type = 2;
        }

        private void radioButtonMangas_CheckedChanged(object sender, EventArgs e)
        {
            type = 3;
        }

        private void radioButtonComics_CheckedChanged(object sender, EventArgs e)
        {
            type = 4;
        }

        private void radioButtonBooks_CheckedChanged(object sender, EventArgs e)
        {
            type = 5;
        }

        private void updateProgressBar(int actualProgress, int maxProgress)
        {
            int progress = actualProgress / maxProgress;
            if (progress > 100) progress = 100;
            progressBarDownload.Value = progress;
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
