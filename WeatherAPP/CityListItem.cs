using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAPP
{
    class CityListItem : ListViewItem
    {
        public City City { get; }

        public CityListItem(City city) : base(city.Name)
        {
            this.City = city;
        }
    }
}
