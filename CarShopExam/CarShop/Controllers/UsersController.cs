using CarShop.Services;
using CarShop.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserViewModel model)
        {
            var userId = this.usersService.GetUserId(model);

            if (userId == null)
            {
                return this.Error("Wrong username or password.");
            }

            this.SignIn(userId);

            return this.Redirect("/Cars/All");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserViewModel model)
        {
            var errors = this.usersService.ValidateRegistration(model);

            if (!usersService.IsUsernameFree(model))
            {
                return this.Error("This username already exist.");
            }

            if (errors.Any())
            {
                return this.Error(errors);
            }

            this.usersService.RegisterUser(model);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/Users/Login");
        }
    }
}
