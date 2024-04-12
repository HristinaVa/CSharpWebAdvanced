using System.ComponentModel.DataAnnotations;

namespace KindergartenSystem.Web.ViewModels.User
{
    public class LoginFormModel
    {
        public string? ReturnUrl { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        //public string FirstName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
       
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; } 
    }
}
