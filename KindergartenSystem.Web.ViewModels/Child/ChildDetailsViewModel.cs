using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Data.Models;

namespace KindergartenSystem.Web.ViewModels.Child
{
    public class ChildDetailsViewModel : AllChildrenByGroupViewModel//, IMapFrom<Data.Models.Child>
    {
        public string DateOfBirth { get; set; } = string.Empty;
        public string ParentPhone { get; set; } = string.Empty;
        public string ParentEmail { get; set; } = string.Empty;
        public string? TeachersPhone { get; set; }
        public string? TeachersEmail { get; set; }
        //public bool IsAttending { get; set; } = true;
    }
}
