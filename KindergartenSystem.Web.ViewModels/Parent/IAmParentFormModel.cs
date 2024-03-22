using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using static KindergartenSystem.Common.EntityValidationConstants.Parent;

namespace KindergartenSystem.Web.ViewModels.Parent
{
    public class IAmParentFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Име")]

        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Телефон 2")]
        public string PhoneNumberSecond { get; set; } = string.Empty;
        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        [Display(Name = "Адрес")]
        public string Address { get; set; } = string.Empty;
        [Required]
        [StringLength(EmailAddressMaxLength, MinimumLength = EmailAddressMinLength)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; } = string.Empty;
    }
}
