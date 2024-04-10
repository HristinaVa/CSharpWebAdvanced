using KindergartenSystem.Web.ViewModels.ClassGroup.Interfaces;



namespace KindergartenSystem.Web.ViewModels.ClassGroup
{
    public class ClassGroupSelectModel : IClassGroupModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
