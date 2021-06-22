using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static CarShop.Data.ModelsConstants;

namespace CarShop.Services
{
    public class UsersService : IUsersService
    {
        private readonly CarShopDbContext db;

        public UsersService(CarShopDbContext db)
        {
            this.db = db;
        }

        public string GetUserId(LoginUserViewModel model)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == ComputeHash(model.Password));

            var userId = user.Id;

            return userId;
        }

        public bool IsUsernameFree(RegisterUserViewModel model)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == model.Username);

            if (user != null)
            {
                return false;
            }

            return true;
        }

        public void RegisterUser(RegisterUserViewModel model)
        {
            User user = new User()
            {
                Username = model.Username,
                Password = ComputeHash(model.Password),
                Email = model.Email,
                IsMechanic = model.UserType == "Mechanic" ? true : false
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public ICollection<string> ValidateRegistration(RegisterUserViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength || model.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username must be between {UsernameMinLength} and {UsernameMaxLength} characters.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("The two fields for password must me equal");
            }

            if (model.Password.Length < PasswordMinLength || model.Password.Length > PasswordMaxLength)
            {
                errors.Add($"Password must be between {PasswordMinLength} and {PasswordMaxLength} characters long.");
            }

            if (model.Password.Contains(" "))
            {
                errors.Add("Password contains whitespaces.");
            }

            if (model.UserType != "Mechanic" && model.UserType != "Client")
            {
                errors.Add("The user must be either Mechanic or Client.");
            }

            return errors;

        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}
