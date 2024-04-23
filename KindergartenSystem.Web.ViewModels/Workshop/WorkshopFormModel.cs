using AutoMapper;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Web.ViewModels.Child;
using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.Workshop;

namespace KindergartenSystem.Web.ViewModels.Workshop
{
    public class WorkshopFormModel: IMapFrom<Data.Models.Workshop>, IHaveCustomMappings
    {
        public WorkshopFormModel()
        {
            CreatedOn = DateTime.UtcNow;
        }
        
        [Required(ErrorMessage = "Invalid format")]
        [DataType(DataType.Date)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(UrlMaxLength)]
        [Display(Name = "Image")]
        public string Url { get; set; } = null!;
        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }
        public string ChildId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<WorkshopFormModel, Data.Models.Workshop>().ForMember(d => d.ChildId, opt => opt.Ignore());
        }
    }
}
