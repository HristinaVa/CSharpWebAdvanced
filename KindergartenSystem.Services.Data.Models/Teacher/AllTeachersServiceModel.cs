using KindergartenSystem.Web.ViewModels.Child;
using KindergartenSystem.Web.ViewModels.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Services.Data.Models.Teacher
{
    public class AllTeachersServiceModel
    {
        public int AllTeachersCount { get; set; }
        public IEnumerable<AllTeachersViewModel> Teachers { get; set; } = new HashSet<AllTeachersViewModel>();
    }
}
