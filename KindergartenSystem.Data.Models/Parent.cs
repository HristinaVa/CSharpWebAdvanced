using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static KindergartenSystem.Common.EntityValidationConstants.Parent;

namespace KindergartenSystem.Data.Models
{
    public class Parent
    {
        public Parent()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumberSecond { get; set; } = string.Empty;
        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = string.Empty;
        [Required]
        [MaxLength(EmailAddressMaxLength)]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public ICollection<Child> Children { get; set; } = new List<Child>();
    }
}
