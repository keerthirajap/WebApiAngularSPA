namespace Domain.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserAuthentication
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public bool IsUserAuthenticated { get; set; }

        public bool IsUserAccountLocked { get; set; }

        public bool IsUserAccountDisabled { get; set; }

        public bool IsUserAccountFound { get; set; }
    }
}