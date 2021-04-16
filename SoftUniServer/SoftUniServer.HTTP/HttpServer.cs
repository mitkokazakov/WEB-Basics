using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniServer.HTTP
{
    public class HttpServer : IHttpServer
    {
        private const int BufferSize = 4096;

        IDictionary<string, Func<HttpRequest, HttpResponse>> routingTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routingTable.ContainsKey(path))
            {
                routingTable[path] = action;
            }
            else 
            {
                routingTable.Add(path,action);
            }
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

                Console.WriteLine(request);
                
            }

                
        }
    }
}
