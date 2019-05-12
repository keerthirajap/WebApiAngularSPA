namespace RepositoryInterface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Autofac.Extras.DynamicProxy;
    using CrossCutting.Logging;
    using Domain.User;
    using Domain.User.Role;
    using Insight.Database;

    [Intercept(typeof(RepositoryInterfaceLogInterceptor))]
    public interface IAuthenticationRepository
    {
        [Sql("[dbo].[P_RegisterUser]")]
        Task<long> RegisterUserAsync(User user);

        [Sql("[dbo].[P_GetUserDetailsByUserName]")]
        Task<User> GetUserDetailsByUserNameAsync(string userName);

        [Sql("[dbo].[P_GetUserDetailsForAuth]")]
        Task<Results<User, UserRole>> GetUserDetailsForAuthAsync(string userName);

        [Sql("SELECT [RoleId],[RoleName]  FROM [dbo].[Roles]")]
        Task<List<UserRole>> GetRolesAsync();
    }
}