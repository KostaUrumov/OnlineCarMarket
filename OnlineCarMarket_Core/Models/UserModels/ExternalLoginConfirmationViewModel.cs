using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.UserModels
{
    public class ExternalLoginConfirmationViewModel
    {

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string HomeTown { get; set; }
        public System.DateTime? BirthDate { get; set; }

    }
}
