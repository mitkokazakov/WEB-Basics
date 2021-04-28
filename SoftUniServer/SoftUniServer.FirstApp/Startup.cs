using SoftUniServer.FirstApp.Controllers;
using SoftUniServer.HTTP;
using SoftUniServer.MVC;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniServer.FirstApp
{
    public class Startup : IMvcApp
    {
        public void Configuration(List<Route> routeTable)
        {
            HomeController homeController = new HomeController();
            UsersController usersController = new UsersController();
            CardsController cardsController = new CardsController();
            FileController fileController = new FileController();

            routeTable.Add(new Route("/", MethodType.GET, homeController.Home));
            routeTable.Add(new Route("/about", MethodType.GET, homeController.About));
            routeTable.Add(new Route("/users/login", MethodType.GET, usersController.Login));
            routeTable.Add(new Route("/users/register", MethodType.GET, usersController.Register));
            routeTable.Add(new Route("/cards/all", MethodType.GET, cardsController.All));
            routeTable.Add(new Route("/cards/add", MethodType.GET, cardsController.Add));
            routeTable.Add(new Route("/cards/collection", MethodType.GET, cardsController.Collection));

            routeTable.Add(new Route("/css/bootstrap.min.css", MethodType.GET, fileController.BootstrapCSS));
            routeTable.Add(new Route("/css/custom.css", MethodType.GET, fileController.CustomCSS));
            routeTable.Add(new Route("/js/bootstrap.bundle.min.js", MethodType.GET, fileController.BootstrapJS));
            routeTable.Add(new Route("/js/custom.js", MethodType.GET, fileController.CustomJS));
        }

        public void ConfigureServices()
        {
            
        }
    }
}
