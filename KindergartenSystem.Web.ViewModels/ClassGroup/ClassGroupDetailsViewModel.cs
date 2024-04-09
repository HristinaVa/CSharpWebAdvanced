using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Web.ViewModels.ClassGroup
{
    public class ClassGroupDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<string> TeachersName { get; set; }
        public string Phone { get; set; }
    }
}
