namespace BindingModel.V1._0.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using Microsoft.AspNetCore.Mvc;

    public class UserBindingModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Remote(action: "IsUserNameExists", controller: "Validatations",
        ErrorMessage = "User Name already exists. Please try again.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Token { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Account Active")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Account Locked")]
        public bool IsLocked { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? ModifiedBy { get; set; }
    }
}