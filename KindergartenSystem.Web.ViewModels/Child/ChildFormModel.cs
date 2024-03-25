
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.Child;
using KindergartenSystem.Web.ViewModels.ClassGroup;


namespace KindergartenSystem.Web.ViewModels.Child
{
    public class ChildFormModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = "Име")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(MiddleNameMaxLength, MinimumLength = MiddleNameMinLength)]
        [Display(Name = "Презиме")]

        public string MiddleName { get; set; } = string.Empty;
        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Дата на раждане")]
        public string DateOfBirth { get; set; }= null!;
        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Снимка")]
        public string ImageUrl { get; set; } = string.Empty;
        [Display(Name = "Група")]
        public int ClassGroupId { get; set; }
        public IEnumerable<ClassGroupSelectModel> ClassGroups { get; set; } = new HashSet<ClassGroupSelectModel>();


    }
}
