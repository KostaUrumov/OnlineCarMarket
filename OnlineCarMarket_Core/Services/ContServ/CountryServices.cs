using Microsoft.EntityFrameworkCore;
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

        public async Task<List<EditCountryViewModel>> FindCountry(int countryId)
        {
            List<EditCountryViewModel> countryToEdit = await data
                .Countries
                .Where(c=>c.Id == countryId)
                .Select(x=>new EditCountryViewModel()
                {
                    Name = x.Name,
                    Id = x.Id
                    
                })
                .ToListAsync();

            return countryToEdit;
           
        }

        public async Task<List<ShowCountryModel>> GetAllCountries()
        {
            List<ShowCountryModel> countries = await data
                .Countries
                .Select(x => new ShowCountryModel()
                {
                    Name = x.Name,
                    Id = x.Id
                })
                .OrderBy(x => x.Name)
                .ToListAsync();

            return countries;
        }

        public async Task SaveNewCountry(EditCountryViewModel model)
        {
            List<Country> country = await data
                .Countries
                .Where(x => x.Id == model.Id)
                .ToListAsync();

            country[0].Name = model.Name;
            await data.SaveChangesAsync();

        }
    }
}
