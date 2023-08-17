using OnlineCarMarket.Areas.Administrator.Models.Body;

namespace OnlineCarMarket.Areas.Administrator.Interfaces
{
    public interface IBody
    {
        Task AddBodyAsync(AddBodyTypeViewModel model);
        Task<List<ShowBodyTypes>> GetAllBodyTypes();
    }
}
