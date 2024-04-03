
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.ChildConst;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using KindergartenSystem.Web.ViewModels.Parent;


namespace KindergartenSystem.Web.ViewModels.Child
{
    public class ChildFormModel
    {
        public ChildFormModel()
        {
            DateOfBirth = DateTime.UtcNow;
        }
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
        [Required(ErrorMessage = "Invalid format")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на раждане")]
        public DateTime DateOfBirth { get; set; }// = DateTime.Parse(DateOfBirthFormat);
        
        [Required(AllowEmptyStrings = false)]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Снимка")]
        public string ImageUrl { get; set; } = string.Empty;

       // public string ParentPhone { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Телефон на родител")]
        public string ParentPhone { get; set; } = null!;

        [Display(Name = "Група")]
        public int ClassGroupId { get; set; }
        public IEnumerable<ClassGroupSelectModel> ClassGroups { get; set; } = new HashSet<ClassGroupSelectModel>();


    }
}
