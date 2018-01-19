using System;
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
            foreach(City city in Config.Instance.Cities)
            {
                object loc = new object();
                int tasks = 0;
                if(city.LastCheck.AddMinutes(10) <= DateTime.Now)
                {
                    lock (loc)
                    {
                        tasks++;
                    }
                    Task.Run(() => {
                        city.RefreshData();
                        lock (loc)
                        {
                            tasks--;
                        }
                    });
                }
            }

            Config.Instance.Save();
            //timer pracuje w osobnym wątku, więc odwołania do UI należy odpowiednio wywołać
            this.Invoke((MethodInvoker)delegate { this.RedrawWeatherPanel(null, EventArgs.Empty); this.OnPaint(null); }); 
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
            if (!String.IsNullOrEmpty(data.sys.country))
                info += ", " + data.sys.country;
            info += $" ({city.LastCheck.ToString()})";

            g.DrawString(info, 14, 5, 5);
            g.DrawString(String.Format("{0}{1}","min:  ", data.main.temp_min + " °C"), 10, 8, 41);
            g.DrawString(String.Format("{0}{1}", "max: ", data.main.temp_max + " °C"), 10, 8, 55);

            g.DrawString(data.main.temp + " °C", 
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
    }
}
