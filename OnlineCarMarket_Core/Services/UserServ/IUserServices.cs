using OnlineCarMarket_Core.Models.UserModels;

namespace OnlineCarMarket_Core.Services.UserServ
{
    public interface IUserServices
    {
        Task AddUserAsync (RegisterUserViewModel model);
        
        bool UserExists(string username);

        Task LogInAsync(LogInUserViewModel model);

    }
}
