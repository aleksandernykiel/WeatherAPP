using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherAPP.API;

namespace WeatherAPP
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();

            foreach(City city in Config.Instance.Cities)
            {
                cityList.Items.Add(new CityListItem(city));
            }
        }

        public string NewCity { get { return cityBox.Text; } set { cityBox.Text = value; } }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(NewCity))
            {
                Task<string> weatherData = Task.Run<string>(async() =>
                {
                    OpenWeatherMapClient client = new OpenWeatherMapClient();
                    return await client.GetWeather(NewCity);
                });

                City city = new City(NewCity);
                CityListItem item = new CityListItem(city);

                string result = weatherData.Result;
                WeatherData json = JsonConvert.DeserializeObject<WeatherData>(result);

                if (json.cod == "200")
                {
                    Task<byte[]> iconData = Task.Run<byte[]>(() =>
                    {
                        OpenWeatherMapClient client = new OpenWeatherMapClient();
                        return client.GetIcon(json.weather[0].icon).Result;
                    });

                    city.ID = json.id;
                    city.Update(result);
                    Config.Instance.Cities.Add(city);
                    cityList.Items.Add(item);

                    city.LastImg = iconData.Result;
                }
                else
                {
                    MessageBox.Show("Nie znaleziono miasta.");
                }

                NewCity = "";
            }
        }

        private void deleteCityBtn_Click(object sender, EventArgs e)
        {
            var item = (CityListItem)cityList.FocusedItem;
            cityList.Items.Remove(item);

            Config.Instance.Cities.Remove(item.City);
        }
    }
}
