using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Infastructure.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(DataConstraints.User.MaxNameLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(DataConstraints.User.MaxNameLength)]
        public string LastName { get; set; } = null!;
    }
}
