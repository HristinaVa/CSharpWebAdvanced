using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.ApplicationUser;

namespace KindergartenSystem.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;
    }
}
