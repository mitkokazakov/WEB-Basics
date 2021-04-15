using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HTTPServer
{
    class Program
    {
        static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();

        static async Task Main(string[] args)
        {


            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 2233);

            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();

                ProccessClient(client);

            }
        }

        public static async Task ProccessClient(TcpClient client)
        {
            string newLine = "\n\r";

            using var clientStream = client.GetStream();


            byte[] buffer = new byte[10000000];

            int length = await clientStream.ReadAsync(buffer, 0, buffer.Length);

            string clientRequest = Encoding.UTF8.GetString(buffer, 0, length);

            Console.WriteLine(clientRequest);

            string date = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            

            string expireDate = DateTime.UtcNow.AddHours(3).ToString("R");

            string sid = Guid.NewGuid().ToString();

            string pattern = @"sid=[^\n]*\r\n";
            var match = Regex.Match(clientRequest,pattern);

            if (match.Success)
            {
                sid = match.Value.Substring(4);
            }

            if (!SessionStorage.ContainsKey(sid))
            {
                SessionStorage[sid] = 0;
            }

            SessionStorage[sid]++;

            string html = $"<h1> Thermal Power Plant 2 Server {date} and you've visited it {SessionStorage[sid]} times</h1>" + newLine +
                            "<form method=post>" +
                            "<input name=firstName /><br><br>" +
                            "<input name=pass type=password /><br><br>" +
                            "<input type=submit />" +
                            "</form>";

            string response = "HTTP/1.1 200 OK" + newLine +
                              "Date: " + DateTime.Now + newLine +
                              //"Location: https://google.com" + newLine +
                              $"Server: Hello, this is Mitko's server" + newLine +
                              "Content-Length: " + html.Length + newLine +
                              "Content-Type: text/html" + newLine +
                              $"Set-Cookie: sid={sid}; Expires={expireDate}"
                              + newLine + newLine +
                              html + newLine;

            byte[] responseBuffer = Encoding.UTF8.GetBytes(response);

            await clientStream.WriteAsync(responseBuffer);
        }
    }
}
