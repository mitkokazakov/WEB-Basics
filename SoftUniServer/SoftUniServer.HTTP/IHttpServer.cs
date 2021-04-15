using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;

namespace SoftUniServer.HTTP
{
    public interface IHttpServer
    {
        void AddRoute(string path, Func<HttpRequest, HttpResponse> acion);

        void Start(int port);
    }
}
