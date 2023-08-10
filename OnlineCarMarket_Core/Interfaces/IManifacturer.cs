using OnlineCarMarket_Core.Models.Manufactur;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Interfaces
{
    public interface IManifacturer
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task AddBrandAsync(NewManufacturerViewModel model);
    }
}
