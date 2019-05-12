using System;
using System.Collections.Generic;
using System.Text;

namespace BindingModel.V1._0.User.Role
{
    public class UserRoleBindingModel
    {
        public string UserName { get; set; }

        public long UserId { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
}