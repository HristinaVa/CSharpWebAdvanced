using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Principal { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string ImageUrl { get; set; }
        public ICollection<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();


    }
}
