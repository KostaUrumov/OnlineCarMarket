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
                    Id = m.Id,
                    Country = m.Country.Name
                    
                })
                .OrderBy(x=>x.Name)
                .ToListAsync();

            return brands;
        }

        public async Task<List<EditManufacturerViewModel>> FindBrandToBeEdited(int Id)
        {
            List<EditManufacturerViewModel> toDo = await data
                .Manifacturers
                .Where(x=>x.Id == Id)
                .Select(m=> new EditManufacturerViewModel()
                {
                    Name = m.Name,
                    CountryId = m.CountryId,
                    Id = m.Id
                })
                .ToListAsync();
            return toDo;
        }

        public async Task SaveChanges(EditManufacturerViewModel model)
        {
            List<Manifacturer> find = await data
                .Manifacturers
                .Where(x=>x.Id == model.Id)
                .ToListAsync();

            find[0].Name = model.Name;
            find[0].CountryId = model.CountryId;

            await data.SaveChangesAsync();
        }
    }
}
