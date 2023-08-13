using OnlineCarMarket_Core.Models.Manufactur;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Interfaces
{
    public interface IManifacturer
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task AddBrandAsync(NewManufacturerViewModel model);

        Task<List<ShowManufacturerViewModel>> GetAllBrands();

        Task<List<EditManufacturerViewModel>> FindBrandToBeEdited(int Id);
        Task SaveChanges(EditManufacturerViewModel model);
    }
}
