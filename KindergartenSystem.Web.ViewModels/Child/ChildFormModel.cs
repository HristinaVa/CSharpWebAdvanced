
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.ChildConst;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using KindergartenSystem.Web.ViewModels.Parent;
using KindergartenSystem.Services.Mapping;
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
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(MiddleNameMaxLength, MinimumLength = MiddleNameMinLength)]
        [Display(Name = "Middle Name")]

        public string MiddleName { get; set; } = string.Empty;
        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Invalid format")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }// = DateTime.Parse(DateOfBirthFormat);
        
        [Required(AllowEmptyStrings = false)]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Picture")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Phone]       
        [Display(Name = "Phone of the Parent")]
        public string ParentPhone { get; set; } = null!;

        [Display(Name = "Class Group")]
        public int ClassGroupId { get; set; }
        public IEnumerable<ClassGroupSelectModel> ClassGroups { get; set; } = new HashSet<ClassGroupSelectModel>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ChildFormModel, Data.Models.Child>().ForMember(d => d.ParentId, opt => opt.Ignore()); 
            configuration.CreateMap<ChildFormModel, Data.Models.Parent>().ForMember(x => x.PhoneNumber, opt => opt.Ignore());
        }
    }
}
