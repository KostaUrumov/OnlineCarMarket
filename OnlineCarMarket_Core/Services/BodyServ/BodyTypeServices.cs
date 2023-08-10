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
    }
}
