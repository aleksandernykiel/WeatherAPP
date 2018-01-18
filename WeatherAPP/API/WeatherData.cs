using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPP.API
{
    public class WeatherData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string cod { get; set; }
        public Sys sys { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Main main { get; set; }
        public Weather[] weather { get; set; }
        public Coord coord { get; set; }
    }
}
