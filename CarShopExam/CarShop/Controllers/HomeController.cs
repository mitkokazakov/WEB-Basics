using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
