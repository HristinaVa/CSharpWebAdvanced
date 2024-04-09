using KindergartenSystem.Web.ViewModels.ClassGroup;

namespace KindergartenSystem.Web.ViewModels.AgeGroup
{
    public class AgeGroupDetailsViewModel /*:AllAgeGroupsViewModel*/
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int ClassGroupsCount { get; set; }
        public ICollection<string> ClassGroupNames { get; set; }
        //public ICollection<ClassGroupDetailsViewModel> ClassGroupDetails { get; set; }
    }
}
