using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BindingModel.v1._0.User
{
    public class UserLoginBindingModel
    {
        [Required(ErrorMessage = "The User Name field is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; }
    }
}