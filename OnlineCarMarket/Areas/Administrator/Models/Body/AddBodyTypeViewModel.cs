using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket.Areas.Administrator.Models.Body
{
    public class AddBodyTypeViewModel
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
