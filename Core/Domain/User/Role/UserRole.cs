namespace Domain.User.Role
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserRole
    {
        public string UserName { get; set; }

        public long UserId { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
}