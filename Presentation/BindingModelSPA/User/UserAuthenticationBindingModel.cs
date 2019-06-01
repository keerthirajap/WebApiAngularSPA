namespace BindingModelSPA.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserAuthenticationBindingModel
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }

        public DateTime ExpiresOn { get; set; }

        public DateTime LoggedOn { get; set; }

        public bool IsUserAuthenticated { get; set; }

        public bool IsUserAccountLocked { get; set; }

        public bool IsUserAccountDisabled { get; set; }

        public bool IsUserAccountFound { get; set; }
    }
}