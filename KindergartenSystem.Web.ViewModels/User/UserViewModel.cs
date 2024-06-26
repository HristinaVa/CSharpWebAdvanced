﻿using AutoMapper;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Mapping;

namespace KindergartenSystem.Web.ViewModels.User
{
    public class UserViewModel : IMapFrom<Data.Models.Teacher>, IMapFrom<Data.Models.Parent>, IHaveCustomMappings
    {
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Data.Models.Teacher, UserViewModel>()
                            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.User.Email))
                            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.User.FirstName + " " + s.User.LastName));
            configuration.CreateMap<Data.Models.Parent, UserViewModel>()
                            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.User.Email))
                            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.User.FirstName + " " + s.User.LastName));
            configuration.CreateMap<ApplicationUser, UserViewModel>()
                            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.FirstName + " " + s.LastName))
                            .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.Id));


        }
    }
}
