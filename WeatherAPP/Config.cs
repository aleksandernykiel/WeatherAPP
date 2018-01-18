using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherAPP
{
    [Serializable]
    public class Config
    {
        private static Config _instance = null;

        public static Config Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (File.Exists(FilePath))
                        Load();
                    else if (_instance == null)
                        _instance = new Config();
                }

                return _instance;
            }
        }

        internal static readonly string Location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WeatherAPP");
        private static readonly string FileName = "config.xml";
        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(Config));
        private static string FilePath => Path.Combine(Location, FileName);

        private Config()
        {
            if (!Directory.Exists(Location))
                Directory.CreateDirectory(Location);            
        }

        private static void Load()
        {
            using(StreamReader sr = new StreamReader(FilePath, Encoding.UTF8))
            {
                _instance = (Config)Serializer.Deserialize(sr);
            }
        }

        public void Save()
        {
            using(StreamWriter sw = new StreamWriter(FilePath, false, Encoding.UTF8))
            {
                Serializer.Serialize(sw, this);
            }
        }

        public List<City> Cities { get; set; } = new List<City>();
    }
}
