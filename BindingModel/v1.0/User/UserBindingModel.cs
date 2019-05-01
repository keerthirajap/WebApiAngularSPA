using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BindingModel.v1._0.User
{
    [Table("User", Schema = "dbo")]
    public class UserBindingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The First Name field is required.")]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name field is required.")]
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The User Name field is required.")]
        [Column(TypeName = "varchar(100)")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}