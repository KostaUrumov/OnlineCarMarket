using OnlineCarMarket_Core.Models.Body;

namespace OnlineCarMarket_Core.Interfaces
{
    public interface IBody
    {
        Task AddBodyAsync(AddBodyTypeViewModel model);
    }
}
