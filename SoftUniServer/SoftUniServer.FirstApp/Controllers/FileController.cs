using SoftUniServer.HTTP;
using SoftUniServer.MVC;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniServer.FirstApp.Controllers
{
    public class FileController : Controller
    {
        public HttpResponse BootstrapCSS(HttpRequest arg)
        {
            return this.FileRead("wwwroot/css/bootstrap.min.css","text/css");
        }

        public HttpResponse CustomCSS(HttpRequest arg)
        {
            return this.FileRead("wwwroot/css/custom.css", "text/css");
        }

        public HttpResponse BootstrapJS(HttpRequest arg)
        {
            return this.FileRead("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
        }

        public HttpResponse CustomJS(HttpRequest arg)
        {
            return this.FileRead("wwwroot/js/custom.js", "text/javascript");
        }
    }
}
