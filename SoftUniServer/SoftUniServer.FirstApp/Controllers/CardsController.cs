using SoftUniServer.HTTP;
using SoftUniServer.MVC;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniServer.FirstApp.Controllers
{
    class CardsController : Controller
    {
        public HttpResponse Add(HttpRequest httpRequest)
        {
            return this.View("Add");
        }

        public HttpResponse All(HttpRequest httpRequest)
        {
            return this.View("All");
        }

        public HttpResponse Collection(HttpRequest httpRequest)
        {
            return this.View("Collection");
        }
    }
}
