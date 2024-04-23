using KindergartenSystem.Web.ViewModels.AgeGroup;
using KindergartenSystem.Web.ViewModels.Child;
using static KindergartenSystem.Common.GeneralApplicationConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Web.ViewModels.Teacher
{
    public class AllTeachersQueryModel
    {
        public int? AgeGroup { get; set; }
        public string? SearchText { get; set; }
        public int CurrentPage { get; set; } = DefaultPage;
        public int TeachersPerPage { get; set; } = DefaultTeachersPerPage;
        public int AllTeachers { get; set; }
        public IEnumerable<AgeGroupViewModel> AgeGroups { get; set; } = new HashSet<AgeGroupViewModel>();
        public IEnumerable<AllTeachersViewModel> Teachers { get; set; } = new HashSet<AllTeachersViewModel>();
    }
}
