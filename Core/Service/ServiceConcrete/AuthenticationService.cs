namespace ServiceConcrete
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq;
    using Domain.User;
    using Domain.User.Role;
    using RepositoryInterface;
    using ServiceInterface;

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            this._authenticationRepository = authenticationRepository;
        }

        public async Task<User> GetUserDetailsByUserNameAsync(string userName)
        {
            return await this._authenticationRepository.GetUserDetailsByUserNameAsync(userName);
        }

        public async Task<long> RegisterUserAsync(User user)
        {
            return await this._authenticationRepository.RegisterUserAsync(user);
        }

        public async Task<(User, UserAuthentication)> AuthenticateUserAsync(User user)
        {
            User userDetails = await this._authenticationRepository.GetUserDetailsByUserNameAsync(user.UserName);
            UserAuthentication userAuthentication = new UserAuthentication();

            if (userDetails == null || userDetails.UserId <= 0)
            {
                userAuthentication.IsUserAccountFound = false;
            }
            else
            {
                userAuthentication.UserName = user.UserName;
                userAuthentication.IsUserAccountFound = true;

                if (userDetails.IsLocked.Value)
                {
                    userAuthentication.IsUserAccountLocked = true;
                }
                else if (user.Password == userDetails.Password)
                {
                    if (userDetails.Password == user.Password)
                    {
                        userAuthentication.IsUserAuthenticated = true;
                    }
                }
                else
                {
                    userAuthentication.IsUserAuthenticated = false;
                    //// Lock Acount
                }
            }

            return (userDetails, userAuthentication);
        }

        public async Task<(User user, List<UserRole> userRoles, UserAuthentication authenticationDetails)> ValidateAndAuthenticateUserAsync(User user)
        {
            var userAuthenticationDetails = await this._authenticationRepository.GetUserDetailsForAuthAsync(user.UserName);

            User userDetails = new User();
            List<UserRole> userRoles = new List<UserRole>();
            UserAuthentication userAuthentication = new UserAuthentication();

            userDetails = userAuthenticationDetails.Set1.FirstOrDefault();

            if (userDetails == null || userDetails.UserId <= 0)
            {
                userAuthentication.IsUserAccountFound = false;
            }
            else
            {
                userAuthentication.UserName = user.UserName;
                userAuthentication.IsUserAccountFound = true;

                if (userDetails.IsLocked.Value)
                {
                    userAuthentication.IsUserAccountLocked = true;
                }
                else if (user.Password == userDetails.Password)
                {
                    if (userDetails.Password == user.Password)
                    {
                        userAuthentication.IsUserAuthenticated = true;
                        userRoles = userAuthenticationDetails.Set2.ToList();
                    }
                }
                else
                {
                    userAuthentication.IsUserAuthenticated = false;
                    //// Lock Acount
                }
            }

            return (userDetails, userRoles, userAuthentication);
        }
    }
}