using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniServer.HTTP
{
    public class HttpServer : IHttpServer
    {
        private const int BufferSize = 4096;
        private const string NewLine = "\r\n";

        //IDictionary<string, Func<HttpRequest, HttpResponse>> routingTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();

        List<Route> routeTable;
        public HttpServer(List<Route> routeTable)
        {
            this.routeTable = routeTable;
        }

        
        public async Task Start(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback,port);
            tcpListener.Start();

            while (true)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(client);
                
            }
        }

        private async Task ProcessClientAsync(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[BufferSize];
                
                int position = 0;

                List<byte> data = new List<byte>();

                while (true)
                {
                    int count = await stream.ReadAsync(buffer,position,buffer.Length);
                    position += count;

                    if (count < buffer.Length)
                    {
                        byte[] partialData = new byte[count];

                        Array.Copy(buffer, partialData, count);

                        data.AddRange(partialData);
                        break;
                    }
                    else 
                    {
                        data.AddRange(buffer);
                    }

                }

                string request = Encoding.UTF8.GetString(data.ToArray());

                HttpRequest httpRequest = new HttpRequest(request);

                HttpResponse currentResponse = null;

                Route route = this.routeTable.FirstOrDefault(r => r.Path == httpRequest.Path && r.Method == httpRequest.Method);

                if (route == null)
                {
                    // NotFound 404
                }
                else 
                {
                    var page = route.Action;

                    currentResponse = page(httpRequest);
                }

                //Console.WriteLine(request);
                Console.WriteLine(httpRequest);


                //string html = "<h1>Welcome in our SoftUni Server</h1>";

                //byte[] bodyResponseBytes = Encoding.UTF8.GetBytes(html);

                //HttpResponse httpResponse = new HttpResponse("text/html",bodyResponseBytes);

                //byte[] headersResponseBytes = Encoding.UTF8.GetBytes(httpResponse.ToString());


                byte[] headersResponseBytes = Encoding.UTF8.GetBytes(currentResponse.ToString());

                await stream.WriteAsync(headersResponseBytes,0,headersResponseBytes.Length);
                await stream.WriteAsync(currentResponse.Body,0,currentResponse.Body.Length);

            }

                
        }
    }
}
