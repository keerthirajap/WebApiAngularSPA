namespace RepositoryInterface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Autofac.Extras.DynamicProxy;
    using CrossCutting.Logging;
    using Domain.User;
    using Insight.Database;

    [Intercept(typeof(RepositoryInterfaceLogInterceptor))]
    public interface IUserManagementRepository
    {
        [Sql("[dbo].[P_RegisterUser]")]
        Task<long> RegisterUserAsync(User user);

        [Sql("[dbo].[P_GetUserDetailsByUserName]")]
        Task<User> GetUserDetailsByUserNameAsync(string userName);
    }
}