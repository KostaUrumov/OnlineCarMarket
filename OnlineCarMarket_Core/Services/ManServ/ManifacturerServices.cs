using Microsoft.EntityFrameworkCore;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Manufactur;
using OnlineCarMarket_Infastructure.Data;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Services.ManServ
{
    public class ManifacturerServices : IManifacturer
    {
        private readonly ApplicationDbContext data;

        public ManifacturerServices(ApplicationDbContext _data)
        {
            data = _data;
        }

        public async Task AddBrandAsync(NewManufacturerViewModel model)
        {
            Manifacturer brand = new Manifacturer()
            {
                Name = model.Name,
                CountryId = model.CountryId
            };

            data.Manifacturers.Add(brand);
            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await data.Countries.OrderBy(x=>x.Name).ToListAsync();
        }

        public async Task<List<ShowManufacturerViewModel>> GetAllBrands()
        {
            List<ShowManufacturerViewModel> brands = await data
                .Manifacturers
                .Select(m=> new ShowManufacturerViewModel
                {
                    Name = m.Name,
                    Id = m.Id
                })
                .OrderBy(x=>x.Name)
                .ToListAsync();

            return brands;
        }
    }
}
