using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherAPP.API
{
    class OpenWeatherMapClient
    {
        readonly string url = @"https://api.openweathermap.org/data/2.5/";
        const string WEATHER = "weather";
        readonly string appid = "ae78d7cfa88486ea307352b6595c18d6";

        private HttpClient Client;

        public OpenWeatherMapClient()
        {
            Client = new HttpClient();
        }

        public async Task<string> GetWeather(string city)
        {
            ParamCollection pars = new ParamCollection();
            pars.Add("q", city);
            pars.Add("appid", appid);

            var response = await Client.GetAsync(url + "weather" + pars.GetParams());
            string content = await response.Content.ReadAsStringAsync();

            return content;
        }

        private class ParamCollection
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            public string this[string name]
            {
                get { return dict[name]; }
                set
                {
                    if (dict.ContainsKey(name))
                        dict[name] = value;
                    else
                    {
                        Add(name, value);
                    }
                }
            }

            public void Add(string name, string val)
            {
                dict.Add(name, val);
            }

            public void Remove(string name)
            {
                dict.Remove(name);
            }

            public string GetParams()
            {
                if (dict.Count < 1) return "";
                string pars = "?";
                foreach(var item in dict)
                {
                    pars += item.Key + "=" + item.Value + "&";
                }

                return pars.Trim('&');
            }

            public override string ToString()
            {
                return this.GetParams();
            }
        }
    }
}
