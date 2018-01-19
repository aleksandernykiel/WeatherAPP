using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public void RefreshData()
        {
            try
            {
                lock (this)
                {
                    OpenWeatherMapClient client = new OpenWeatherMapClient();
                    string result = client.GetWeather(this.Name).Result;

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
            }
            catch (AggregateException aEx)
            {
                Exception tmp = aEx;
                while (tmp is AggregateException)
                {
                    tmp = tmp.InnerException;
                }

                if (tmp is HttpRequestException)
                {
                    MessageBox.Show("Problem komunikacji z API. \n" + tmp.Message);
                }
                else
                {
                    throw tmp;
                }
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
