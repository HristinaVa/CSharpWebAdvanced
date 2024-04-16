using AutoMapper;
using KindergartenService.Services.Mapping;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Web.ViewModels.Child;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindergartenSystem.Web.ViewModels.Home
{
    public class ImageViewModel : IMapFrom<Image>
    {
        public string Id { get; set; } 
        public string Url { get; set; } 
        public int KindergardenId { get; set; }
        public string KindergartenName { get; set; }
       
    }
}
