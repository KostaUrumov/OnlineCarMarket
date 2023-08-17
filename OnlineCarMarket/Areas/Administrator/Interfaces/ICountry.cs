using OnlineCarMarket.Areas.Administrator.Models.Countres;

namespace OnlineCarMarket.Areas.Administrator.Interfaces
{
    public interface ICountry
    {
        Task AddCountryAsync(AddCountryViewModel model);
        Task <List<ShowCountryModel>> GetAllCountries();
        Task<List<EditCountryViewModel>> FindCountry(int countryId);
        Task SaveNewCountry(EditCountryViewModel model);
    }
}
