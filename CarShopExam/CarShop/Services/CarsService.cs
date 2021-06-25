using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CarShop.Data.ModelsConstants;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly CarShopDbContext db;

        public CarsService(CarShopDbContext db)
        {
            this.db = db;
        }

        public void AddCar(AddCarViewModel model, string userId)
        {
            Car car = new Car()
            {
                Model = model.Model,
                Year = model.Year,
                PlateNumber = model.PlateNumber,
                PictureUrl = model.Url,
                OwnerId = userId
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public ListAllCarsIssues GetCarById(string carId)
        {
            var car = this.db.Cars.FirstOrDefault(c => c.Id == carId);

            var currentCar = new ListAllCarsIssues()
            {
                Model = car.Model,
                Year = car.Year.ToString(),
                CarId = carId,
                Issues = car.Issues.Select(i => new SingleIssueViewModel()
                {
                    IsFixed = i.IsFixed,
                    Id = i.Id,
                    Description = i.Description
                }).ToList()
            };

            return currentCar;
        }

        public IEnumerable<ListAllCarsViewModel> ListAllCars(string userId)
        {
            var allCars = this.db.Cars.Where(c => c.OwnerId == userId)
                                      .Select(c => new ListAllCarsViewModel()
                                      {
                                          Id = c.Id,
                                          Year = c.Year.ToString(),
                                          Model = c.Model,
                                          RemainingIssues = c.Issues.Count(i => !i.IsFixed).ToString(),
                                          FixedIssues = c.Issues.Where(i => i.IsFixed).Count().ToString(),
                                          PlateNumber = c.PlateNumber,
                                          Image = c.PictureUrl
                                      }).ToList();

            return allCars;
        }

        public IEnumerable<ListAllCarsViewModel> ListAllCarsForMechanics()
        {
            var allCars = this.db.Cars.Where(c => c.Issues.Any(i => !i.IsFixed))
                                      .Select(c => new ListAllCarsViewModel()
                                      {
                                          Id = c.Id,
                                          Year = c.Year.ToString(),
                                          Model = c.Model,
                                          RemainingIssues = c.Issues.Count(i => !i.IsFixed).ToString(),
                                          FixedIssues = c.Issues.Where(i => i.IsFixed).Count().ToString(),
                                          PlateNumber = c.PlateNumber,
                                          Image = c.PictureUrl
                                      }).ToList();

            return allCars;
        }

        public ICollection<string> ValidateCar(AddCarViewModel model)
        {
            var errors = new List<string>();

            if (model.Model.Length < ModelMinLength || model.Model.Length > ModelMaxLength)
            {
                errors.Add($"Car's model name must be between {ModelMinLength} and {ModelMaxLength} characters.");
            }

            if (model.Year < 1900 || model.Year > 2021)
            {
                errors.Add("Car's year must be in range 1900 - 2021.");
            }

            if (String.IsNullOrWhiteSpace(model.Url))
            {
                errors.Add("The Url must be a valid url.");
            }

            if (!Regex.IsMatch(model.PlateNumber, @"[A-Z]{2}[0-9]{4}[A-Z]{2}"))
            {
                errors.Add("The Plate Number must be in format 'AA0000AA'");
            }

            return errors;
        }
    }
}
