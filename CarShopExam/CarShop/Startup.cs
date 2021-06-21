﻿namespace CarShop
{
    using System.Threading.Tasks;
    using CarShop.Data;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>())
                .WithConfiguration<CarShopDbContext>(context => context.Database.Migrate())
                .Start();
    }
}
