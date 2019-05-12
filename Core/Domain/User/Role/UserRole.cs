namespace Domain.User.Role
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserRole
    {
        public long UserRoleId { get; set; }

        public string UserName { get; set; }

        public long UserId { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? ModifiedBy { get; set; }
    }
}