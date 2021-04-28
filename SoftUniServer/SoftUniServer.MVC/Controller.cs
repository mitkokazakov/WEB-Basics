using SoftUniServer.HTTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace SoftUniServer.MVC
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName]string path = null)
        {
            var layout = File.ReadAllText("Views/Shared/_Layout.html");

            var controllerName = this.GetType().Name.Replace("Controller", String.Empty);

            string currentView = File.ReadAllText("Views/" + controllerName + "/" + path + ".html");

            var html = layout.Replace("@RenderBody()",currentView);

            byte[] bodyResponseBytes = Encoding.UTF8.GetBytes(html);

            HttpResponse httpResponse = new HttpResponse("text/html", bodyResponseBytes);

            return httpResponse;
        }

        public HttpResponse FileRead(string path, string contentType)
        {
            var fileBytes = File.ReadAllBytes(path);

            var response = new HttpResponse(contentType,fileBytes);

            return response;
        }
    }
}
