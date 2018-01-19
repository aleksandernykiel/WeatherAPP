using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.API;

namespace WeatherAPP
{
    [Serializable]
    public class City
    {
        public City() { }
        public City(string name) { this.Name = name; }

        public string ID { get; set; }
        public string Name { get; set; }
        public string LastWeatherJSON { get; set; }
        public byte[] LastImg { get; set; }
        public DateTime LastCheck { get; set; }

        public void Update(string contentJson)
        {
            LastWeatherJSON = contentJson;
            LastCheck = DateTime.Now;
        }

        public async void RefreshData()
        {
            OpenWeatherMapClient client = new OpenWeatherMapClient();
            string result = await client.GetWeather(this.Name);

            WeatherData json = JsonConvert.DeserializeObject<WeatherData>(result);

            if (json.cod == "200")
            {
                Task<byte[]> iconData = Task.Run<byte[]>(() =>
                {
                    return client.GetIcon(json.weather[0].icon).Result;
                });

                this.Update(result);
                this.LastImg = iconData.Result;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
