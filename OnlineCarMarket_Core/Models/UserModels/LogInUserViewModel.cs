using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.UserModels
{
    public class LogInUserViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; } = null!;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
