using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override string ToString()
        {
            return this.Name;
        }
    }
}
