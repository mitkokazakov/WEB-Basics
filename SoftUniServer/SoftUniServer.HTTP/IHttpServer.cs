using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniServer.HTTP
{
    public interface IHttpServer
    {
        void AddRoute(string path, Func<HttpRequest, HttpResponse> acion);

        Task Start(int port);
    }
}
