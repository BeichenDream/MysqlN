using MysqlN.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mysql.MysqlData
{
  public  class UserInfo
    {
        public string username { get; set; }
        public string password { get; set; }
        public string host { get; set; }
        public string info { get; set; }
        public bool LoadData { get; set; }
        public string Qpassword { get; set; }

        public string Salt { get; set; }
        public Socket client { get; set; }
        public UserInfo()
        {
            Qpassword = "NUll";
            Salt = Function.GetSalt();
        }
    }
}
