using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp
{
    public class WeatherData
    {
        [JsonProperty("main")]
        public MainData Main { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("name")]
        public string CityName { get; set; }

        [JsonProperty("wind")]
        public WindData Wind { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        // Add more properties as needed
    }

    public class MainData
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }

    public class Weather
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        // You can add more properties like 'icon', 'main', etc. as needed
    }

    public class WindData
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        // You can add more properties like 'deg', 'gust', etc. as needed
    }

}
