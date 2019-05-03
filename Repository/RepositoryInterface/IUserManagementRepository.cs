namespace RepositoryInterface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Domain.User;
    using Insight.Database;

    public interface IUserManagementRepository
    {
        [Sql("[dbo].[P_RegisterUser]")]
        Task<long> RegisterUserAsync(User user);

        [Sql("[dbo].[P_GetUserDetailsByUserName]")]
        Task<User> GetUserDetailsByUserNameAsync(string userName);
    }
}