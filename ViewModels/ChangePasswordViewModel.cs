using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore_Identity_Auth.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }



        [Required(ErrorMessage = "NewPassword is required")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "The {0} must be at {2} and at max {1} characters")]
        [DataType(DataType.Password)]
        [Compare("ConfirmNewPassword", ErrorMessage = "NewPassword does not match.")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }



        [Required(ErrorMessage = "Confirm NewPassword is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
