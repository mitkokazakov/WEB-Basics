
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
            CardsController cardsController = new CardsController();

            server.AddRoute("/", homeController.Home);
            server.AddRoute("/about", homeController.About);
            server.AddRoute("/users/login", usersController.Login);
            server.AddRoute("/users/register", usersController.Register);
            server.AddRoute("/cards/all", cardsController.All);
            server.AddRoute("/cards/add", cardsController.Add);
            server.AddRoute("/cards/collection", cardsController.Collection);

            await server.Start(80);

        }

        
    }
}
