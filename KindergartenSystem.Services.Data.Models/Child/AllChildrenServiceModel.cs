using KindergartenSystem.Web.ViewModels.Child;

namespace KindergartenSystem.Services.Data.Models.Child
{
    public class AllChildrenServiceModel
    {
        public int AllChilderenCount { get; set; }
        public IEnumerable<AllChildrenByGroupViewModel> Children { get; set; } = new HashSet<AllChildrenByGroupViewModel>();
    }
}
