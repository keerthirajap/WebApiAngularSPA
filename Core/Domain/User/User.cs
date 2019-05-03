namespace Domain.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class User
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsLocked { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? ModifiedBy { get; set; }
    }
}