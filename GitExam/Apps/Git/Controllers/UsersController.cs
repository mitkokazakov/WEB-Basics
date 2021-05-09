using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.Controllers
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

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel loginModel)
        {
            string userId = this.usersService.GetUserId(loginModel.Username, loginModel.Password);

            if (userId == null)
            {
                return this.Error("Username or Password are incorect!");
            }

            this.SignIn(userId);

            return this.Redirect("/Repositories/All");
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel register)
        {
            if (register.Username.Length < 5 || register.Username.Length > 20 || String.IsNullOrEmpty(register.Username))
            {
                return this.Error("Username must be minimum 5 characers and maximum 20 characters long!");
            }

            if (register.Password.Length < 6 || register.Password.Length > 20 || String.IsNullOrEmpty(register.Password))
            {
                return this.Error("Password must be minimum 6 characers and maximum 20 characters long!");
            }

            if (String.IsNullOrEmpty(register.Email) || !new EmailAddressAttribute().IsValid(register.Email))
            {
                return this.Error("Invalid Email Address");
            }

            if (String.IsNullOrEmpty(register.ConfirmPassword) || register.Password != register.ConfirmPassword)
            {
                return this.Error("Confirm Password field must match Password field!");
            }

            if (this.usersService.IsEmailAvailable(register.Email))
            {
                return this.Error("The Email is already taken");
            }

            if (this.usersService.IsUsernameAvailable(register.Username))
            {
                return this.Error("The Username is already taken");
            }

            this.usersService.CreateUser(register.Username, register.Email, register.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse LogOut()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
