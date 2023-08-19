using Microsoft.AspNetCore.Identity;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.UserModels;
using OnlineCarMarket_Infastructure.Data;
using OnlineCarMarket_Infastructure.Entities;
using System.Security.Cryptography;
using System.Text;

namespace OnlineCarMarket_Core.Services.UserServ
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext data;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public UserServices(
            ApplicationDbContext _data,
            SignInManager<User> _signInManager,
            UserManager<User> _userManager,
            RoleManager<IdentityRole> _roleManager

            )
        {
            data = _data;
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        public async Task AddToRole(RegisterUserViewModel model)
        {
            var findUser = data.Users.First(x => x.UserName == model.Username);
            if (findUser.UserName == "kostadin")
            {
                await userManager.AddToRoleAsync(findUser, "Admin");
            }

            else
            {
                await userManager.AddToRoleAsync(findUser, "User");
            }

            await data.SaveChangesAsync();
        }

        public async Task AddUserAsync(RegisterUserViewModel model)
        {

            User user = new User()
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = model.PassWord
            };


            data.Add(user);
            await data.SaveChangesAsync();

            await signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<bool> LogInAsync(LogInUserViewModel model)
        {
            var findUser = data.Users.FirstOrDefault(x => x.UserName == model.Username);
            if (findUser != null && findUser.PasswordHash == model.Password)
            {
                await signInManager.SignInAsync(findUser, isPersistent:false);
                return true;
            }

            return false;


        }

        public bool UserExists(string username)
        {
            var FindUser = data.Users.FirstOrDefault(x => x.UserName == username);
            if (FindUser == null)
            {
                return false;
            }

            return true;

        }
    }
}
