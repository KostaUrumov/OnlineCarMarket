using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.Body
{
    public class AddBodyTypeViewModel
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
