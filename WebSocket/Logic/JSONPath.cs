using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class JSONPath
    {
        private static readonly JSONPath instance = new JSONPath();
        private string path;
        private string jsonFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            , "configPath.json");
        static JSONPath()
        {

        }

        private JSONPath()
        {

        }

        public static JSONPath GetInstance
        {
            get
            {
                return instance;
            }
        }

        public string Path
        {
            get
            {
                Deserialization();
                return path;
            }

            set
            {
                path = value;
                Serialization();
            }
        }

        private void Deserialization()
        {
            if (!File.Exists(jsonFileName))
            {
                File.Create(jsonFileName).Close();
            }
            path = File.ReadAllText(jsonFileName);
        }

        private void Serialization()
        {
            File.WriteAllText(jsonFileName, path);
        }
    }
}