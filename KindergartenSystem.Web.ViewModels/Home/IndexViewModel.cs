using AutoMapper;
using KindergartenService.Services.Mapping;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Web.ViewModels.Child;

namespace KindergartenSystem.Web.ViewModels.Home
{
    public class IndexViewModel : IMapFrom<Kindergarten>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Principal { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<IndexViewModel, Image>().ForMember(d => d.Url, opt => opt.Ignore());
        }
    }
}
