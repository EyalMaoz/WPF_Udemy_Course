using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        private const string API_KEY = "6d6pY1s4Nu6gXloLNBSTsiFzYOXaf6h7";
        private const string BASE_URL = "http://dataservice.accuweather.com/";
        private const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        private const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        public static async Task<List<City>> GetCities(string name)
        {
            List<City> cities = new List<City>();
            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, name);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }
            return cities;
        }
        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();
            string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json).FirstOrDefault();
            }
            return currentConditions;
        }

    }
}
