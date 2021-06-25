using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Issues
{
    public class ListAllCarsIssues
    {
        public string CarId { get; set; }
        public string Year { get; set; }

        public string Model { get; set; }

        public ICollection<SingleIssueViewModel> Issues { get; set; }
    }
}
