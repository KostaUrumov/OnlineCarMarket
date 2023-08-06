using Microsoft.AspNetCore.Identity;
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

        public async Task AddUserAsync(RegisterUserViewModel model)
        {
            SHA256 hash = SHA256.Create();
            var pass = Encoding.Default.GetBytes(model.PassWord);
            var hashedPass = hash.ComputeHash(pass);

            var finalPass = Convert.ToHexString(hashedPass);

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

        public  async Task LogInAsync(LogInUserViewModel model)
        {
            var findUser = data.Users.FirstOrDefault(x => x.UserName == model.Username);
            if (findUser != null && findUser.PasswordHash == model.Password)
            {
                await signInManager.SignInAsync(findUser, isPersistent:false);
            }


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
