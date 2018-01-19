using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            if(!String.IsNullOrEmpty(NewCity) && Config.Instance.Cities.Where(x => x.Name.ToLower() == NewCity.ToLower()).Count() > 0)
            {
                MessageBox.Show("To miasto jest już na liście.");
                return;
            }

            if (!String.IsNullOrEmpty(NewCity))
            {
                try
                {
                    Task<string> weatherData = Task.Run<string>(async () =>
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
                    Config.Instance.Save();

                }
                catch (AggregateException aEx)
                {
                    Exception tmp = aEx;
                    while(tmp is AggregateException)
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
                catch(HttpRequestException reqEx)
                {
                    MessageBox.Show("Problem komunikacji z API. \n" + reqEx.Message);
                }
            }
        }

        private void deleteCityBtn_Click(object sender, EventArgs e)
        {
            var item = (CityListItem)cityList.FocusedItem;
            cityList.Items.Remove(item);

            Config.Instance.Cities.Remove(item.City);
            Config.Instance.Save();
        }

        private void deleteCityBtn_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(deleteCityBtn, deleteCityBtn.Tag.ToString());
        }
    }
}
