
using SoftUniServer.FirstApp.Controllers;
using SoftUniServer.HTTP;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoftUniServer.MVC;

namespace SoftUniServer.FirstApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            HomeController homeController = new HomeController();
            UsersController usersController = new UsersController();
            CardsController cardsController = new CardsController();
            FileController fileController = new FileController();

            List<Route> routeTable = new List<Route>();

           routeTable.Add(new Route("/", homeController.Home));
           routeTable.Add(new Route("/about", homeController.About));
           routeTable.Add(new Route("/users/login", usersController.Login));
           routeTable.Add(new Route("/users/register", usersController.Register));
           routeTable.Add(new Route("/cards/all", cardsController.All));
           routeTable.Add(new Route("/cards/add", cardsController.Add));
           routeTable.Add(new Route("/cards/collection", cardsController.Collection));

           routeTable.Add(new Route("/css/bootstrap.min.css", fileController.BootstrapCSS));
           routeTable.Add(new Route("/css/custom.css", fileController.CustomCSS));
           routeTable.Add(new Route("/js/bootstrap.bundle.min.js", fileController.BootstrapJS));
           routeTable.Add(new Route("/js/custom.js", fileController.CustomJS));


            await Host.RunAsync(routeTable);

        }

        
    }
}
