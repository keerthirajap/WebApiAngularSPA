namespace BindingModelSPA.User
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserBindingModel
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [Compare("Password", ErrorMessage = "Password mismatch, Please try again")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}