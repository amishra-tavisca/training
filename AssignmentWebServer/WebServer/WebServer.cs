using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using Tavisca.WebServerAssignment.Dispatcher;


namespace Tavisca.WebServerAssignment.WebServerHandler
{
    public class WebServer
    {
        // check for already running
        private bool _running = false;
        private Encoding _charEncoder = Encoding.UTF8;
        private Socket _serverSocket;

        // Directory to host our contents
        private string _contentPath;

        //create socket and initialization
        private void InitializeSocket(IPAddress ipAddress, int port, string contentPath) //create socket
        {
          
             _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(ipAddress, port));
            _serverSocket.Listen(10);    //no of request in queue
            Console.WriteLine("new socket created");

            _running = true; //socket created
            if (string.IsNullOrEmpty(contentPath))
                throw new ArgumentNullException();
            _contentPath = contentPath;


         
        }
        public void Start(IPAddress ipAddress, int port, string contentPath)
        {
            try
            {
                InitializeSocket(ipAddress, port, contentPath);
            }
            catch
            {
                Console.WriteLine("Error in creating server socker");
                Console.ReadLine();
            }
            while (_running)
            {
                var requestHandler = new RequestHandler(_serverSocket, contentPath);
                Console.WriteLine("request handler called");    //remove
                requestHandler.AcceptRequest();
     
            }
        }
        public void Stop()
        {
            _running = false;
            try
            {
                _serverSocket.Close();
            }
            catch
            {
                Console.WriteLine("Error in closing server or server already closed");
                Console.ReadLine();

            }
            _serverSocket = null;
        }

    }
}
