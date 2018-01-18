using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAPP
{
    public partial class WeatherForm : Form
    {
        public WeatherForm()
        {
            InitializeComponent();
        }

        private void WeatherForm_Load(object sender, EventArgs e)
        {
            LoadCities();
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
        }
    }
}
