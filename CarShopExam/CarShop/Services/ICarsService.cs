using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public interface ICarsService
    {
        IEnumerable<ListAllCarsViewModel> ListAllCars(string userId);
    }
}
