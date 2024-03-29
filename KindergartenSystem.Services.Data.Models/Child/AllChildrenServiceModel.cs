using KindergartenSystem.Web.ViewModels.Child;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Services.Data.Models.Child
{
    public class AllChildrenServiceModel
    {
        public int AllChilderenCount { get; set; }
        public IEnumerable<AllChildrenByGroupViewModel> Children { get; set; } = new HashSet<AllChildrenByGroupViewModel>();
    }
}
