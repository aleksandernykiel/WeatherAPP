﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherAPP.API;

namespace WeatherAPP
{
    public partial class WeatherForm : Form
    {
        public WeatherForm()
        {
            InitializeComponent();
            LoadCities();
        }

        private void WeatherForm_Load(object sender, EventArgs e)
        {
            
        }

        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm conf = new ConfigForm();
            conf.ShowDialog();
            LoadCities();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void informacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: messagebox z informacjami o aplikacji
        }

        private void lokalizacjaKonfiguracjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo(Config.Location)
            {
                UseShellExecute = true
            };
            Process.Start(info);
        }

        private void LoadCities()
        {
            cityComboBox.Items.Clear();
            foreach(City city in Config.Instance.Cities)
            {
                cityComboBox.Items.Add(city);
            }

            if(!String.IsNullOrEmpty(Config.Instance.SelectedCity))
            {
                City city = Config.Instance.Cities.FirstOrDefault(x => x.ID == Config.Instance.SelectedCity);
                if (city != null && cityComboBox.Items.Contains(city))
                {
                    cityComboBox.SelectedIndex = cityComboBox.Items.IndexOf(city);
                }
                else
                {
                    cityComboBox.SelectedIndex = 0;
                }
            }
        }

        private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            City city = (City)cityComboBox.SelectedItem;

            if (city.ID != Config.Instance.SelectedCity)
            {
                Config.Instance.SelectedCity = city.ID;
                Config.SaveAsync();

                RedrawWeatherPanel(sender, e);
            }

            this.ResumeLayout();
        }

        private void RedrawWeatherPanel(object sender, EventArgs e)
        {
            City city = (City)cityComboBox.SelectedItem;

            var g = weatherPanel.CreateGraphics();
            g.Clear(this.BackColor);
            

            WeatherData data = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(city.LastWeatherJSON);
            string info = city.Name;
            if (!String.IsNullOrEmpty(data.sys.country))
                info += ", " + data.sys.country;

            g.DrawString(info, 16, 5, 5);
            g.DrawString(String.Format("{0}{1}","min:  ", data.main.temp_min + " °C"), 10, 8, 36);
            g.DrawString(String.Format("{0}{1}", "max: ", data.main.temp_max + " °C"), 10, 8, 50);

            g.DrawString(data.main.temp + " °C", 
                new Font(Tools.family, 26, FontStyle.Bold), 
                Tools.brush, 
                weatherPanel.Width - 180, 
                25);

            if (city.LastImg != null)
            {
                using (MemoryStream ms = new MemoryStream(city.LastImg))
                {
                    Image img = Bitmap.FromStream(ms);
                    Rectangle rct = new Rectangle(weatherPanel.Width - 100, 5, 95, 95);
                    g.DrawImage(img, rct);
                }
            }
        }
    }
}
