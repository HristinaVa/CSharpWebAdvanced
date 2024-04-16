
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.ChildConst;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using KindergartenSystem.Web.ViewModels.Parent;
using KindergartenService.Services.Mapping;
using KindergartenSystem.Data.Models;
using AutoMapper;


namespace KindergartenSystem.Web.ViewModels.Child
{
    public class ChildFormModel : IMapFrom<Data.Models.Child>, IHaveCustomMappings
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

        [Required]
        [Phone]       
        [Display(Name = "Телефон на родител")]
        public string ParentPhone { get; set; } = null!;

        [Display(Name = "Група")]
        public int ClassGroupId { get; set; }
        public IEnumerable<ClassGroupSelectModel> ClassGroups { get; set; } = new HashSet<ClassGroupSelectModel>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ChildFormModel, Data.Models.Child>().ForMember(d => d.ParentId, opt => opt.Ignore()); 
            configuration.CreateMap<ChildFormModel, Data.Models.Parent>().ForMember(x => x.PhoneNumber, opt => opt.Ignore());
        }
    }
}
