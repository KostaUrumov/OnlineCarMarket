using Microsoft.AspNetCore.Identity;
using OnlineCarMarket_Core.Models.UserModels;
using OnlineCarMarket_Infastructure.Data;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Services.UserServ
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext data;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;


        public UserServices( 
            ApplicationDbContext _data,
            SignInManager<User> _signInManager,
            UserManager<User> _userManager
            )
        {
            data = _data;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task AddUserAsync (RegisterUserViewModel model)
        {
            string pass = model.PassWord;
            string passhash = BCrypt.Net.BCrypt.EnhancedHashPassword(pass);

            User user = new User()
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = passhash
            };

            data.Add(user);
            await data.SaveChangesAsync();

            await signInManager.SignInAsync(user, isPersistent: false);            
        }

        public bool UserExists(string username)
        {
            var FindUser = data.Users.FirstOrDefault(x=>x.UserName == username);
            if (FindUser == null)
            {
                return false;
            }

            return true;
            
        }
    }
}
