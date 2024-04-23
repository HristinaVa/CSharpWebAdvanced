using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.Teacher;

namespace KindergartenSystem.Web.ViewModels.Teacher
{
    public class TeacherFormModel : IMapFrom<Data.Models.Teacher>
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; } = null!;
        [Display(Name = "Class Group")]
        public int ClassGroupId { get; set; }
        public IEnumerable<ClassGroupSelectModel> ClassGroups { get; set; } = new HashSet<ClassGroupSelectModel>();
    }
}
