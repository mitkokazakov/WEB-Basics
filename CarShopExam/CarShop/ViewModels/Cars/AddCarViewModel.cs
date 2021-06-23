using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Cars
{
    public class AddCarViewModel
    {
        public string Model { get; set; }

        public int Year { get; set; }

        public string Url { get; set; }

        public string PlateNumber { get; set; }
    }
}
