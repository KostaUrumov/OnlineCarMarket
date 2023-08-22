using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(model.PassWord, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            



            User user = new User()
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = savedPasswordHash

            };


            data.Add(user);
            await data.SaveChangesAsync();

            await signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<bool> LogInAsync(LogInUserViewModel model)
        {
            var findUser = data.Users.FirstOrDefault(x => x.UserName == model.Username);
            string savedPasswordHash = findUser.PasswordHash;
           
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(model.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }

            }

            await signInManager.SignInAsync(findUser, isPersistent: false);
            return true;


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
