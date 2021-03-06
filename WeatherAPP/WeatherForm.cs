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
        int updateMinutes = 10;

        public WeatherForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += FirstPaint;
            LoadCities();

            Tools.StartTimer(TimerElapsed);
            this.FormClosing += WeatherForm_FormClosing;

            Task.Run(() =>
            {
                while (!this.IsHandleCreated) { }
                TimerElapsed(null, null);
            });
        }

        private void WeatherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tools.StopTimer();
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Task.Run(() =>
            {
                this.Invoke((MethodInvoker)delegate { this.waitPanel.Visible = true; });

                foreach (City city in Config.Instance.Cities)
                {
                    object loc = new object();
                    if (city.LastCheck.AddMinutes(updateMinutes) <= DateTime.Now)
                    {
                        city.RefreshData();
                    }
                }

                lock (Config.Instance)
                {
                    Config.Instance.Save();
                }

                updateMinutes = 10;

                //timer pracuje w osobnym wątku, więc odwołania do UI należy odpowiednio wywołać
                this.Invoke((MethodInvoker)delegate
                {
                    LoadCities();
                    this.RedrawWeatherPanel(null, EventArgs.Empty);
                    this.waitPanel.Visible = false;
                    this.OnPaint(null);
                });
            });
        }

        private void FirstPaint(object sender, PaintEventArgs e)
        {
            RedrawWeatherPanel(sender, e);
            this.Paint -= FirstPaint;
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
            string text = "Weather APP\n" +
                "Autor: Aleksander Nykiel\n" +
                "Kontakt: nykiel.aleksander@gmail.com\n\n" +
                "Opis aplikacji:\n" +
                "Niniejsza aplikacja służy do pobierania aktualnych danych pogodowych z serwisu \"OpenWeatherMap\".\n" +
                "Dodaj swoje miasta w ustawieniach, aby móc śledzić dla nich pogodę.\n\n" +
                "W konfiguracji podajemy nazwę miasta. \n" +
                "Jeśli znalezione miasto nie jest tym, którego szukasz - inny kraj, podaj kod kraju po przecinku\n\n" +
                "np. \"Bali, CN\"";

            MessageBox.Show(text);
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
            if (city == null) return;

            WeatherData data = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(city.LastWeatherJSON);

            label1.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label8.Visible = true;

            wspolrzedneLabel.Text = data.coord.lat + ", " + data.coord.lon;
            cisnienieLabel.Text = data.main.pressure + " hPa";
            wilgotnoscLabel.Text = data.main.humidity + " %";
            wiatrLabel.Text = data.wind.speed + " m/s";
            wschodLabel.Text = double.Parse(data.sys.sunrise).UnixTSToDateTime().ToString("HH:mm");
            zachodLabel.Text = double.Parse(data.sys.sunset).UnixTSToDateTime().ToString("HH:mm");

            var g = weatherPanel.CreateGraphics();
            g.Clear(this.BackColor);

            string info = city.Name;
            if (!String.IsNullOrEmpty(data.sys.country) && !info.Contains(data.sys.country))
                info += ", " + data.sys.country;
            info += $" ({city.LastCheck.ToString()})";

            g.DrawString(info, 14, 5, 5);
            g.DrawString(String.Format("{0}{1}","min:  ", data.main.temp_min + " °C"), 10, 8, 41);
            g.DrawString(String.Format("{0}{1}", "max: ", data.main.temp_max + " °C"), 10, 8, 55);

            g.DrawString((int)double.Parse(data.main.temp, System.Globalization.CultureInfo.InvariantCulture) + " °C", 
                new Font(Tools.family, 26, FontStyle.Bold), 
                Tools.brush, 
                weatherPanel.Width - 180, 
                40);

            if (city.LastImg != null)
            {
                using (MemoryStream ms = new MemoryStream(city.LastImg))
                {
                    Image img = Bitmap.FromStream(ms);
                    Rectangle rct = new Rectangle(weatherPanel.Width - 100, 13, 95, 95);
                    g.DrawImage(img, rct);
                }
            }
        }

        private void weatherPanel_Resize(object sender, EventArgs e)
        {
            RedrawWeatherPanel(sender, e);
        }

        private void odświeżToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.StopTimer();
            updateMinutes = 0;
            TimerElapsed(sender, null);
            Tools.StartTimer();
        }
    }
}
