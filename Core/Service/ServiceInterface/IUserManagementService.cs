namespace ServiceInterface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Domain.User;

    public interface IUserManagementService
    {
        Task<long> RegisterUserAsync(User user);

        Task<User> GetUserDetailsByUserNameAsync(string userName);

        Task<(User, UserAuthentication)> AuthenticateUserAsync(User user);
    }
}