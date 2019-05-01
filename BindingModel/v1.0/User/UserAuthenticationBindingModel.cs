using System;
using System.Collections.Generic;
using System.Text;

namespace BindingModel.v1._0.User
{
    public class UserAuthenticationBindingModel
    {
        public string UserName { get; set; }

        public string Token { get; set; }

        public DateTime ExpiresOn { get; set; }

        public DateTime LoggedOn { get; set; }
    }
}