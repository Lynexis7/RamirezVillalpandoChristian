using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PullToRefresh11.Models
{
    public class CitiesManager
    {

        #region Singleton

        static readonly Lazy<CitiesManager> lazy = new Lazy<CitiesManager>(() => new CitiesManager());
        public static CitiesManager SharedInstance { get => lazy.Value; }

        #endregion

        #region Class Variables

        HttpClient httpClient;
        Dictionary<string, List<string>> cities;

        #endregion

        #region Events

        public event EventHandler<CitiesEventArgs> CitiesFetched;
        public event EventHandler<EventArgs> FetchCitiesFailed;

        #endregion

        CitiesManager()
        {
            httpClient = new HttpClient();
        }

        #region Public Functionality

        public Dictionary<string, List<string>> GetDefaultCities() {
            var citiesJson = File.ReadAllText("citites-incomplete.json");
            return JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(citiesJson);
        }

        public void FetchCities() {

            Task.Factory.StartNew(FetchCitiesAsync);

            async Task FetchCitiesAsync() {
                try
                {
                    var citiesJson = await httpClient.GetStringAsync("https://dropbox.com/s/0adq8yw6vd5r6bj/cities.json?dl=0");
                    cities = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(citiesJson);

                    //Avisar al controller que ya estna disponibles los datos
                    //1. A traves de eventos (Events/Delegate)
                    //2. A traves de notificaciones (NSNotificationCenter)
                    //3. (Solo aplica cuando estas dentro de un ViewController) A traves de Unwind Segues

                    if(CitiesFetched == null) {
                        return;
                    }

                    var e = new CitiesEventArgs(cities);
                    CitiesFetched(this, e);

                }
                catch (Exception ex)
                {
                    //Avisar al controller que algo fallo
                    //1. A traves de eventos (Events/Delegate)
                    //2. A traves de notificaciones (NSNotificationCenter)
                    //3. (Solo aplica cuando estas dentro de un ViewController) A traves de Unwind Segues

                    if (FetchCitiesFailed == null)
                        return;

                    FetchCitiesFailed(this, new EventArgs());
                }
            }
        }

        #endregion
    }

    public class CitiesEventArgs : EventArgs {
        public Dictionary<string, List<string>> Cities { get; private set; }

        public CitiesEventArgs(Dictionary<string, List<string>> cities){
            Cities = cities;
        }
        
    }
}
