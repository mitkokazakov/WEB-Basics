﻿
using SoftUniServer.FirstApp.Controllers;
using SoftUniServer.HTTP;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniServer.FirstApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            HomeController homeController = new HomeController();
            UsersController usersController = new UsersController();

            server.AddRoute("/", homeController.Home);
            server.AddRoute("/about", homeController.About);
            server.AddRoute("/users/login", usersController.Login);
            server.AddRoute("/users/register", usersController.Register);

            await server.Start(80);

        }

        
    }
}
