using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.ClassGroup;
using System.Runtime.CompilerServices;
using KindergartenSystem.Web.ViewModels.AgeGroup;
using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Data.Models;

namespace KindergartenSystem.Web.ViewModels.ClassGroup
{
    public class ClassGroupViewModel: IMapFrom<Data.Models.ClassGroup>
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;
        [Display(Name = "Age Group")]
        public int AgeGroupId { get; set; }
        public IEnumerable<AllAgeGroupsViewModel> AgeGroups { get; set; } = new HashSet<AllAgeGroupsViewModel>();
    }
}
