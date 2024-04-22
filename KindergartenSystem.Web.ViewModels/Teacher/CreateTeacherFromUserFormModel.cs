using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static KindergartenSystem.Common.EntityValidationConstants.Teacher;
using KindergartenSystem.Web.ViewModels.ClassGroup;
using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Data.Models;
using AutoMapper;
using KindergartenSystem.Web.ViewModels.Child;

namespace KindergartenSystem.Web.ViewModels.Teacher
{
    public class CreateTeacherFromUserFormModel 
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        public string ImageUrl { get; set; } = null!;
        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [Display(Name = "User Id")]
        public string UserId { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;
        [Required]
        [Display(Name = "Class Group")]
        public int ClassGroupId { get; set; }
        
    }
}
