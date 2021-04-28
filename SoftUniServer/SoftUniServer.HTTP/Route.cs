using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniServer.HTTP
{
    public class Route
    {
        public Route(string path, MethodType method, Func<HttpRequest, HttpResponse> action)
        {
            this.Path = path;
            this.Action = action;
            this.Method = method;
        }
        public string Path { get; set; }

        public MethodType Method { get; set; }

        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
