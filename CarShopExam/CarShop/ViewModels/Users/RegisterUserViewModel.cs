using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Data.ModelsConstants;

namespace CarShop.ViewModels.Users
{
    public class RegisterUserViewModel
    {
        [Required]
        [MinLength(UsernameMinLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(PasswordMinLength)]
        public string Password { get; set; }

        [Required]
        [MinLength(PasswordMinLength)]
        public string ConfirmPassword { get; set; }

        public string UserType { get; set; }
    }
}
