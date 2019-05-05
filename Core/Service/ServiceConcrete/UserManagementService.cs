namespace ServiceConcrete
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Domain.User;
    using RepositoryInterface;
    using ServiceInterface;

    public class UserManagementService : IUserManagementService
    {
        private readonly IUserManagementRepository _userManagementRepository;

        public UserManagementService(IUserManagementRepository userManagementRepository)
        {
            this._userManagementRepository = userManagementRepository;
        }

        public async Task<User> GetUserDetailsByUserNameAsync(string userName)
        {
            return await this._userManagementRepository.GetUserDetailsByUserNameAsync(userName);
        }

        public async Task<long> RegisterUserAsync(User user)
        {
            return await this._userManagementRepository.RegisterUserAsync(user);
        }

        public async Task<(User, UserAuthentication)> AuthenticateUserAsync(User user)
        {
            User userDetails = await this._userManagementRepository.GetUserDetailsByUserNameAsync(user.UserName);
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
    }
}