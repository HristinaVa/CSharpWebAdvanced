using AutoMapper;
using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Data.Models;

namespace KindergartenSystem.Web.ViewModels.Child
{
    public class AllChildrenByGroupViewModel : IMapFrom<Data.Models.Child>
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ClassGroupName { get; set; } = string.Empty;
        public string Teacher { get; set; } = string.Empty;
        public string ParentName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsAttending { get; set; } = true;

       
    }
}
