# MysqlN
伪造一个Mysql服务端,使其迷惑攻击者躲避爆破攻击

使用教程:https://www.bilibili.com/video/av53020564/

.NET CORE windows以及linux与mac  SDK下载地址:https://dotnet.microsoft.com/download

首次使用请在程序中输入Mysql Help,来查看帮助命令

你可以在程序中设置启动的IP,启动的端口,甚至还可以设置Mysql版本,添加可登陆的用户,当然这个可登陆的用户只是返回客户端登陆成功而已,并不会实际影响到Mysql本身

你可以在程序根目录中的User.data文件,批量添加用户,但用户名不可以重复

用户添加格式root-----toor   ,root是用户名,toor是密码,其中间是分隔符,一行一条

如果你想删除可登陆的用户,请在程序根路径删除MysqlN.bin文件与User.data文件


更改代码以及发布代码,请注明版权

如有BUG或者建议可以将BUG或者建议请发至我的邮箱:rroort@qq.com
