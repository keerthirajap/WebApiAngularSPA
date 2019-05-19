namespace WebAppMVC.Infrastructure.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using BindingModel.V1._0.User;

    public static class UserDetailsControllerExtensions
    {
        public static UserBindingModel GetLoggedInUserDetails(this ClaimsPrincipal principal)
        {
            UserBindingModel user = new UserBindingModel();
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            user.UserId = principal.FindAll(ClaimTypes.NameIdentifier).Select(s => Convert.ToInt64(s.Value)).FirstOrDefault();
            user.UserName = principal.FindAll(ClaimTypes.Name).Select(s => s.Value).FirstOrDefault();

            var userAuthentication = principal.FindAll(ClaimTypes.Authentication).Select(s => s.Value).ToList();

            if (userAuthentication.Any(x => x == "Authenticated"))
            {
            }

            return user;
        }

        public static bool IsUserAuthenticated(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            var userRoles = principal.FindAll(ClaimTypes.Authentication).Select(s => s.Value).ToList();

            if (userRoles.Any(x => x == "Authenticated"))
            {
                return true;
            }

            return false;
        }
    }
}