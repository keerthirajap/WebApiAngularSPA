namespace BindingModel.V1._0.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class UserBindingModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The User Name field is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}