using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.Parent;

namespace KindergartenSystem.Web.ViewModels.Parent
{
    public class IAmParentFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Phone 2")]
        public string PhoneNumberSecond { get; set; } = null!;
        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        [Display(Name = "Address")]
        public string Address { get; set; } = null!;
        [Required]
        [StringLength(EmailAddressMaxLength, MinimumLength = EmailAddressMinLength)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; } = null!;
        [Required]
        //[DataType(DataType.Password)]
        [Display(Name = "Secret Code")]
        public string SecretCode { get; set; } = null!;

        //userid? childid?
    }
}
