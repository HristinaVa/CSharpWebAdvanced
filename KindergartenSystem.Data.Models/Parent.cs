using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.Parent;

namespace KindergartenSystem.Data.Models
{
    public class Parent
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumberSecond { get; set; } = string.Empty;
        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        public ICollection<Child> Children { get; set; } = new List<Child>();
    }
}
