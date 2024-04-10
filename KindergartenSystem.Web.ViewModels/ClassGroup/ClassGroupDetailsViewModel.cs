using KindergartenSystem.Web.ViewModels.ClassGroup.Interfaces;

namespace KindergartenSystem.Web.ViewModels.ClassGroup
{
    public class ClassGroupDetailsViewModel : IClassGroupModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<string>? TeachersName { get; set; } = null;
        public string Phone { get; set; }
        public int AgeGroup { get; set; }
    }
}
