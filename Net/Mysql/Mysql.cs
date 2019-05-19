using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MysqlN.App;
using Mysql.MysqlData;
using System.Text;
using Mysql.MysqlPlugin;

namespace Mysql
{
    public class Mysql
    {
        private static Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static IPEndPoint point;
        private static Config config = Config.GetConfig();
        /// <summary>
        /// 打开Mysql服务端
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public static void open()
        {
            try
            {
                point = new IPEndPoint(IPAddress.Parse(config.Host), config.Port);
                server.Bind(point);
                server.Listen(20);
                MysqlN.App.Command.Write("Mysql服务端已经成功启动","Ok",ConsoleColor.Red);
                Thread servar_thread = new Thread(Listen);
                servar_thread.Start();

            }
            catch (Exception)
            {
                MysqlN.App.Command.Write("Mysql服务端启动失败,请检查端口是否已经被占用!","Error",ConsoleColor.Red);
                throw;
            }


        }
        public static void Stop()
        {
            server.Dispose();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        }
        private static void Listen()
        {

            while (true)
            {
                    UserInfo userInfo = new UserInfo();
                    userInfo.client = server.Accept();
                    userInfo.host = userInfo.client.RemoteEndPoint.ToString().Split(':')[0];
                MysqlN.App.Command.Write(string.Format("{0}正在连接",userInfo.host),"Connect",ConsoleColor.Red);
                    Thread thread = new Thread(Received);
                    thread.Start(userInfo);
                    userInfo.client.Send(MysqlGainData.GetHello(config.Version, thread.ManagedThreadId, userInfo.Salt));
            }

        }
        private static void Received(object l)
        {
            UserInfo userInfo = (UserInfo)l;
            byte[] data = new byte[1024 * 1024 * 1];


            while (true)
            {
       
                int len = userInfo.client.Receive(data);
                if (len == 0)
                {
                    break;
                }
                byte[] d = new byte[len];
                Array.Copy(data, 0, d, 0, len);
                MysqlGainData.TransformationLoginData(d, userInfo);
                if (Login(userInfo))
                {
                    userInfo.client.Send(MysqlGainData.GetLoginOk());
                }
                else
                {
                    userInfo.client.Send(MysqlGainData.GetLoginError((short)1045, string.Format("Access denied for user '{0}'@'{1}' (using password: YES)", userInfo.host, userInfo.username)));
                }
                userInfo.client.Dispose();
                MysqlN.App.Command.Write(Function.change(userInfo),"info",ConsoleColor.Magenta);
                return;
            }

        }
        public static bool Login(UserInfo userInfo) {
            if (!config.LoginCheck)
            {
                return false;
            }
            foreach (var item in config.MysqlUser)
            {
                if (item.Key==userInfo.username)
                {
                    if (MySqlNativePasswordPlugin.GetPassword(item.Value, userInfo.Salt) == userInfo.password)
                    {
                        userInfo.Qpassword = item.Value;
                        return true;
                    }
                    
                }
            }
            return false;
        }

    }
}
