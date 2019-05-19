using Mysql.MysqlData;
using MysqlN.App;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Mysql
{
    [Serializable]
    public  class Config
    {
        public  Dictionary<string, string> MysqlUser = new Dictionary<string, string>();
        public  bool LoginCheck = true;
        public string Host = "0.0.0.0";
        public int Port = 3306;
        public string Version = "5.5.54-log";
        private static Config config;
        private static object o = new object();
        public static Config GetConfig() {
            if (config==null)
            {
                lock (o)
                {
                    if (config==null)
                    {
                        config = new Config();
                    }
                }
            };
            return config;

        }
        private Config() {

        }

        private static void LoadMysqlUser() {
         string[]  data=  log.FileRead("User.data");
            foreach (var item in data)
            {
              string[] _t= Regex.Split(item, "-----", RegexOptions.IgnoreCase);
                if (_t.Length == 2) {
                    if (!config.MysqlUser.ContainsKey(_t[0]))
                    {
                        config.MysqlUser.Add(_t[0], _t[1]);
                    }
                    
                }
            }
        }

        public static void init() {
            using (FileStream stream = new FileStream("MysqlN.bin", FileMode.OpenOrCreate))
            {
                if (stream.Length > 0)
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    config = (Config)binary.Deserialize(stream);
                }
            }
            GetConfig();
            LoadMysqlUser();
   
        }
        public static void SaveConfig() {
           
            using (FileStream stream = new FileStream("MysqlN.bin", FileMode.Create))
            {
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(stream, config);
                stream.Flush();
            }
            
        }
    }
}
