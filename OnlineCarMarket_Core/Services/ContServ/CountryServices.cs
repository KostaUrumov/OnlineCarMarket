using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Countres;
using OnlineCarMarket_Infastructure.Data;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Services.ContServ
{
    public class CountryServices : ICountry
    {
        private readonly ApplicationDbContext data;

        public CountryServices(ApplicationDbContext _data)
        {
            data = _data;
        }
        public async Task AddCountryAsync(AddCountryViewModel model)
        {
            Country country = new Country()
            {
                Name = model.Name
            };

            data.Countries.Add(country);
            await data.SaveChangesAsync();
        }
    }
}
