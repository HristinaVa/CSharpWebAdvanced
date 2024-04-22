using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Web.ViewModels.Parent
{
    public class PendingParentsViewModel
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Id { get; set; } = null!;

    }
}
