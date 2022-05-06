using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingServer
{
    public class JSONPath
    {
        private static readonly JSONPath instance = new JSONPath();
        private string path;
        private string jsonFileName = System.IO.Path.Combine(@"C:\3BHIF\SYP\Projekt\remotify\WebSocket\FileSharingServer", "configPath.json");

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
            path = File.ReadAllText(jsonFileName);
        }

        private void Serialization()
        {
            File.WriteAllText(jsonFileName, path);
        }
    }
}
