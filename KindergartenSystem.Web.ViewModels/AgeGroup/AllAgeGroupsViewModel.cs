using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Data.Models;

namespace KindergartenSystem.Web.ViewModels.AgeGroup
{
    public class AllAgeGroupsViewModel : IMapFrom<Data.Models.AgeGroup>
    {
        public int Id { get; set; }
        public string Number { get; set; }
    }
}
