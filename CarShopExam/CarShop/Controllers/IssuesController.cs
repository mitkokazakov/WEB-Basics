using CarShop.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssuesService issueService;
        private readonly ICarsService carsService;

        public IssuesController(IIssuesService issueService, ICarsService carsService)
        {
            this.issueService = issueService;
            this.carsService = carsService;
        }

        public HttpResponse CarIssues(string carId)
        {
            var currentCar = this.carsService.GetCarById(carId);

            return this.View(currentCar);
        }

        public HttpResponse Add()
        {
            return this.View();
        }
    }
}
