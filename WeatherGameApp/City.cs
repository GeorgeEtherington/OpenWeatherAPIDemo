using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
namespace WeatherGameApp
{
   public class City
    {
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class data
        {
           public coord coord { get; set; }
           public string name { get; set; }
        }

        public data CityData { get; set; }
        public void SetData(string CityName)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid=2c340e6ea06f502822c29f909a6a8052", CityName);
                var json = web.DownloadString(url);
                this.CityData = JsonConvert.DeserializeObject <data > (json);
            }
        }
    }
}
