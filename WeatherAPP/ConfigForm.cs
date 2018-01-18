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
                JObject json = JObject.Parse(result);

                if (json["cod"].ToString() == "200")
                {
                    city.ID = json["id"].ToString();
                    city.Update(result);
                    Config.Instance.Cities.Add(city);
                    cityList.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("Nie znaleziono miasta.");
                }

                NewCity = "";
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Config.SaveAsync();
            this.Close();
        }

        private void deleteCityBtn_Click(object sender, EventArgs e)
        {
            var item = (CityListItem)cityList.FocusedItem;
            cityList.Items.Remove(item);

            Config.Instance.Cities.Remove(item.City);
        }
    }
}
