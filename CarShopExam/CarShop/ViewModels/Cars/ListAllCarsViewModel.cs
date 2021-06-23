using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Cars
{
    public class ListAllCarsViewModel
    {
        public string Id { get; set; }
        public string Year { get; set; }
        public string Model { get; set; }

        public string Image { get; set; }
        public string PlateNumber { get; set; }
        public string RemainingIssues { get; set; }
        public string FixedIssues { get; set; }
    }
}
