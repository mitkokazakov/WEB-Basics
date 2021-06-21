using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Data.ModelsConstants;

namespace CarShop.Data.Models
{
    public class Car
    {
        public Car()
        {
            this.Issues = new HashSet<Issue>();
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }
        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(PlateNumberMaxLength)]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
