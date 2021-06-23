using CarShop.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public interface IUsersService
    {
        string GetUserId(LoginUserViewModel model);

        ICollection<string> ValidateRegistration(RegisterUserViewModel model);

        void RegisterUser(RegisterUserViewModel model);

        bool IsUsernameFree(RegisterUserViewModel model);

        bool IsMechanic(string userId);
    }
}
