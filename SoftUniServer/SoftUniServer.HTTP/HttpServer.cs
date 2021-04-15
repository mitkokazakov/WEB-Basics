using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniServer.HTTP
{
    public class HttpServer : IHttpServer
    {
        public void AddRoute(string path, Func<HttpRequest, HttpResponse> acion)
        {
            throw new NotImplementedException();
        }

        public void Start(int port)
        {
            throw new NotImplementedException();
        }
    }
}
