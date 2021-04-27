using SoftUniServer.HTTP;
using SoftUniServer.MVC;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniServer.FirstApp.Controllers
{
    class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View("Login");
        }

        public HttpResponse Register(HttpRequest request)
        {
            return this.View("Register");
        }
    }
}
