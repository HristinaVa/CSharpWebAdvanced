using KindergartenService.Services.Mapping;
using KindergartenSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Web.ViewModels.Home
{
    public class ImageViewModel //: IMapFrom<Image>
    {
        public string Id { get; set; } 
        public string Url { get; set; } 
        public int KindergardenId { get; set; }
        public string Title { get; set; }
        public IndexViewModel Kindergarten { get; set; } = new IndexViewModel();

    }
}
