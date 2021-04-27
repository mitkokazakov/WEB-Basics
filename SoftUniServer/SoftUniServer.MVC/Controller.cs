using SoftUniServer.HTTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SoftUniServer.MVC
{
    public abstract class Controller
    {
        public HttpResponse View(string path)
        {
            string html = File.ReadAllText(path);

            byte[] bodyResponseBytes = Encoding.UTF8.GetBytes(html);

            HttpResponse httpResponse = new HttpResponse("text/html", bodyResponseBytes);

            return httpResponse;
        }
    }
}
