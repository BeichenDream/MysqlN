﻿using MysqlN.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mysql
{
    class Command
    {
      private static  Config config = Config.GetConfig();
        public static string GetUser() {

            return Function.change(config.MysqlUser);

        }

        public static string GetLogincheck() {
            string data = string.Format("LoginChek : {0}",config.LoginCheck.ToString());
            return data;
        }
        public static string GetHost() {
            string data= string.Format("Host : {0}", config.Host);
            return data;
        }
        public static string GetPort() {
            string data = string.Format("Port : {0}", config.Port.ToString());
            return data;
        }
        public static string GetVersion() {
            return config.Version;
        }
        public static string SetVersion(string v) {
            config.Version = v;
            return "Ok MysqlVersion:"+config.Version;
        }
        public static string SetLogincheck(bool b) {
            config.LoginCheck = b;
            string data = string.Format("Ok, LoginCheck : {0}", config.LoginCheck.ToString());
            return data;
        }
        public static string SetHost(string Host) {
            try
            {
                IPAddress.Parse(Host);
                config.Host = Host;
                string data = string.Format("Ok, Host : {0}", config.Host);
                return data;
            }
            catch (Exception e)
            {

                return "Error:"+e.Message;
            }
            

        }
        public static string SetPort(int Port) {
            string data = string.Empty;
            if (Port>=0&&Port<=65535)
            {
                config.Port = Port;
              data=string.Format("Ok, Port : {0}", config.Port.ToString());
            }
            else
            {
                data = "No,端口范围0~65535";
            }
            
            
            return data;
        }

        public static string AddUser(string username, string password) {
            lock (config.MysqlUser)
            {
                string data = "";
                if (config.MysqlUser.ContainsKey(username))
                {
                    data = string.Format("添加失败,用户名或用户已存在");
                }
                else
                {
                    config.MysqlUser.Add(username,password);
                    data = string.Format("添加成功");
                }
                return data;
            }
        }
        public static string MysqlRun() {
            Mysql.open();
            return "已通知进程开启";
        }
        public static string MysqlStop() {
            Mysql.Stop();
            return "已通知线程停止";
        }
        public static string ConfigSave() {
            Config.SaveConfig();
            return "已保存配置到本地文件";
        }
        public static string AppExit() {
            Config.SaveConfig();
            Environment.Exit(0);
            return "";
        }
        public static string AppClear() {
            Console.Clear();
            return "";
        }
        public static string MysqlHelp() {
            string data="\n";
            data += "变量\n";
            data += "\tHost:Mysql启动的ip\n\tPort:Mysql启动的端口\n\tUser:可以登录成功的Mysql用户键值集合\n\tVersion:Mysql的版本\n\tLogincheck:是否开启Mysql用户登录验证\n";
            data += "支持的方法\n";
            data += " Get:\n\tHost,Port,User,Version,Logincheck\n";
            data += " Set:\n\tHost,Port,Version,Logincheck\n";
            data += " Add:\n\tUser\n";
            data += " Config:\n\tSave\n";
            data += " App:\n\tExit\n\tClear\n";
            data += "例子:\tGet Host\n\tSet Host 127.0.0.1\n\tConfig Save\n\tAdd User root root";
            return data;

        }
    }
}
