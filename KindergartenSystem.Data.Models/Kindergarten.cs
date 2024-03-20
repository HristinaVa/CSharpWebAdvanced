using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.Kindergarten;

namespace KindergartenSystem.Data.Models
{
    public class Kindergarten
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = string.Empty;
        [Required]
        [MaxLength(PrincipalNameMaxLength)]
        public string Principal { get; set; } =string.Empty;
        [Required]
        [MaxLength(EmailAddressMaxLength)]
        public string EmailAddress { get; set; } = string.Empty;
        public ICollection<Image>? Images { get; set; }
        public ICollection<AgeGroup> AgeGroups { get; set; } = new List<AgeGroup>();
    }
}
