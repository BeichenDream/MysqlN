# MysqlN
# 404StarLink 2.0 - Galaxy
![](https://github.com/knownsec/404StarLink-Project/raw/master/logo.png)

MysqlN 是 404Team [星链计划2.0](https://github.com/knownsec/404StarLink2.0-Galaxy)中的一环，如果对MysqlN有任何疑问又或是想要找小伙伴交流，可以参考星链计划的加群方式。

- [https://github.com/knownsec/404StarLink2.0-Galaxy#community](https://github.com/knownsec/404StarLink2.0-Galaxy#community)

伪造一个Mysql服务端,使其迷惑攻击者躲避爆破攻击

支持用户验证

支持自定义Mysql版本

随机的Salt加密,加上用户验证,让攻击者毫无察觉

Net文件夹是.NET程序只能运行在Windows

NetCore文件夹是.NET CORE程序可以运行在 Windows,Linux,MAC


使用教程:https://www.bilibili.com/video/av53020564/

首次使用请在程序中输入Mysql Help,来查看帮助命令

你可以在程序中设置启动的IP,启动的端口,甚至还可以设置Mysql版本,添加可登陆的用户,当然这个可登陆的用户只是返回客户端登陆成功而已,并不会实际影响到Mysql本身

你可以在程序根目录中的User.data文件,批量添加用户,但用户名不可以重复

用户添加格式root-----toor   ,root是用户名,toor是密码,其中间是分隔符,一行一条

如果你想删除可登陆的用户,请在程序根路径删除MysqlN.bin文件与User.data文件

退出程序时,建议使用 App Exit命令,这样会保存当前的配置

本程序命令行的命令不区分大小写,你可以Mysql Help,也可以mysql help 或MYSQL HELP
### 安装教程
.NET CORE windows以及linux与mac  SDK下载地址:https://dotnet.microsoft.com/download

 Linux 64位一键安装SDK:  curl -sSL -o dotnet.tar.gz https://download.visualstudio.microsoft.com/download/pr/ece856bb-de15-4df3-9677-67cc817ffc1b/521da52132d23deae5400b8e19e23691/dotnet-sdk-2.2.204-linux-x64.tar.gz&&sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet&&sudo ln -s /opt/dotnet/dotnet /usr/local/bin

更改代码以及发布代码,请注明版权

如有BUG或者建议可以将BUG或者建议请发至我的邮箱:rroort@qq.com
