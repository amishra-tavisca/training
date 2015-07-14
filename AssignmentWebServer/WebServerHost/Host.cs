using System;
using System.Net;
using Microsoft.Win32;
using Tavisca.WebServerAssignment.WebServerHandler;

namespace Tavisca.WebServerAssignment.WebServerHost
{
    class Host
    {
        static void Main(string[] args)
        {

            WebServer webServer = new WebServer();
            webServer.Start(IPAddress.Any, 2050, "D:/startbootstrap-sb-admin-1.0.3");
            if (Console.ReadLine() == "x")
            webServer.Stop();
            Console.ReadLine();
        }
    }
}
