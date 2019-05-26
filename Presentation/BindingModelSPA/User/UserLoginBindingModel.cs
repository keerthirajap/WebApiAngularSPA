namespace BindingModelSPA.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class UserLoginBindingModel
    {
        [Required(ErrorMessage = "The User Name field is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; }

        public bool CanRememberMe { get; set; }
    }
}