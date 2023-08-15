using OnlineCarMarket_Infastructure;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.UserModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [MinLength(DataConstraints.User.MinNameLength)]
        [MaxLength(DataConstraints.User.MaxNameLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(DataConstraints.User.MinNameLength)]
        [MaxLength(DataConstraints.User.MaxNameLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; } = null!;

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; } = null!;


        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; } = null!;

        [Required]
        [Display(Name = "Repeat Password")]
        [DataType(DataType.Password)]
        public string RepeatPassWord { get; set; } = null!;

    }
}
