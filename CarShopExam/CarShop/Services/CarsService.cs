using CarShop.Data;
using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly CarShopDbContext db;

        public CarsService(CarShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ListAllCarsViewModel> ListAllCars(string userId)
        {
            var allCars = this.db.Cars.Where(c => c.OwnerId == userId)
                                      .Select(c => new ListAllCarsViewModel()
                                      {
                                          Id = c.Id,
                                          Year = c.Year.ToString(),
                                          Model = c.Model,
                                          RemainingIssues = c.Issues.Count().ToString(),
                                          FixedIssues = c.Issues.Where(i => i.IsFixed).Count().ToString(),
                                          PlateNumber = c.PlateNumber,
                                          Image = c.PictureUrl
                                      }).ToList();

            return allCars;
        }
    }
}
