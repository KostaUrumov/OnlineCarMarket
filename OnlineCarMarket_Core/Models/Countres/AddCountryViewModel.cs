using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.Countres
{
    public class AddCountryViewModel
    {
        public int Id { get; set; }
        

        public string Name { get; set; } = null!;
    }
}
