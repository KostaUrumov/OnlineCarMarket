using Microsoft.EntityFrameworkCore;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Body;
using OnlineCarMarket_Infastructure.Data;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Services.BodyServ
{
    public class BodyTypeServices : IBody
    {
        private readonly ApplicationDbContext data;

        public BodyTypeServices(ApplicationDbContext _data)
        {
            data = _data;
        }

        public async Task AddBodyAsync(AddBodyTypeViewModel model)
        {
            BodyType body = new BodyType()
            {
                Name = model.Name
            };

            data.BoduTypes.Add(body);
            await data.SaveChangesAsync();
        }

        public async Task<List<ShowBodyTypes>> GetAllBodyTypes()
        {
            List<ShowBodyTypes> bodyTypes = await data
                .BoduTypes
                .Select(x => new ShowBodyTypes()
                { 
                    Name = x.Name
                })
                .OrderBy(x => x.Name)
                .ToListAsync();

            return bodyTypes;
        }
    }
}
