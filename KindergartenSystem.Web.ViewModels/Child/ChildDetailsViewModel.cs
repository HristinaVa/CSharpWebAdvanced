using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Web.ViewModels.Child
{
    public class ChildDetailsViewModel : AllChildrenByGroupViewModel
    {
        public string DateOfBirth { get; set; } = string.Empty;
        public string ParentPhone { get; set; } = string.Empty;
        public string ParentEmail { get; set; } = string.Empty;
        public string? TeachersPhone { get; set; }
        public string? TeachersEmail { get; set; }
    }
}
