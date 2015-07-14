using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using Tavisca.WebServerAssignment.RequestProcessor;

namespace Tavisca.WebServerAssignment.Dispatcher
{
    public class RequestHandler
    {
        private Socket _serverSocket;
        private string _contentPath;
        private Encoding _charEncoder = Encoding.UTF8;

        public RequestHandler(Socket serverSocket, String contentPath)
        {
            _serverSocket = serverSocket;
            _contentPath = contentPath;
        }

        public void AcceptRequest()
        {
            Socket clientSocket = null;
            try
            {
                // Create new thread to handle the request and continue to listen the socket.
                clientSocket = _serverSocket.Accept();

                var requestHandler = new Thread(() =>
                {
                    HandleTheRequest(clientSocket);
                });
                requestHandler.Start();
            }
            catch
            {
                Console.WriteLine("Error in accepting client request");
                Console.ReadLine();
                if (clientSocket != null)
                    clientSocket.Close();
            }
        }

        private void HandleTheRequest(Socket clientSocket)
        {

            if (clientSocket == null)   //remove
                return;

            var requestParser = new RequestParser();
            string requestString = DecodeRequest(clientSocket);
            requestParser.Parser(requestString);

            if (requestParser.HttpMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase))
            {
                var createResponse = new CreateResponse(clientSocket, _contentPath);
                createResponse.RequestUrl(requestParser.HttpUrl);
            }
            else
            {
                Console.WriteLine("unemplimented mothode");
                Console.ReadLine();
            }
            StopClientSocket(clientSocket);
        }

        public void StopClientSocket(Socket clientSocket)
        {
            if (clientSocket != null)
                clientSocket.Close();
        }

        private string DecodeRequest(Socket clientSocket)
        {
            var receivedBufferlen = 0;
            var buffer = new byte[10240];
            try
            {
                receivedBufferlen = clientSocket.Receive(buffer);
            }
            catch (Exception)
            {
                //Console.WriteLine("buffer full");
                Console.ReadLine();
            }
            return _charEncoder.GetString(buffer, 0, receivedBufferlen);
        }
    }

}