using OnlineCarMarket_Core.Models.UserModels;

namespace OnlineCarMarket_Core.Interfaces
{
    public interface IUserServices
    {
        Task AddUserAsync(RegisterUserViewModel model);

        bool UserExists(string username);

        Task LogInAsync(LogInUserViewModel model);

        Task AddToRole(RegisterUserViewModel model);

    }
}
