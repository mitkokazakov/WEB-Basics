using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniServer.HTTP
{
    public interface IHttpServer
    {

        Task Start(int port);
    }
}
