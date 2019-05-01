namespace BindingModel.V1._0.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserAuthenticationBindingModel
    {
        public string UserName { get; set; }

        public string Token { get; set; }

        public DateTime ExpiresOn { get; set; }

        public DateTime LoggedOn { get; set; }
    }
}