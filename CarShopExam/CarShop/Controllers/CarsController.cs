using CarShop.Services;
using CarShop.ViewModels.Cars;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;

        public CarsController(ICarsService carsService, IUsersService usersService)
        {
            this.carsService = carsService;
            this.usersService = usersService;
        }

        public HttpResponse All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var cars = new List<ListAllCarsViewModel>();

            var userId = this.User.Id;

            if (this.usersService.IsMechanic(userId))
            {
                cars = this.carsService.ListAllCarsForMechanics().ToList();
            }
            else 
            {
                cars = this.carsService.ListAllCars(userId).ToList();
            }

            

            return this.View(cars);

        }

        
        public HttpResponse Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User.Id;

            if (this.usersService.IsMechanic(userId)) 
            {
                return this.Redirect("/Cars/All");
            } 

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCarViewModel model)
        {
            var userId = this.User.Id;

            var errors = this.carsService.ValidateCar(model);

            if (errors.Any())
            {
                return this.Error(errors);
            }

            this.carsService.AddCar(model,userId);

            return this.Redirect("/Cars/All");
        }
    }
}
