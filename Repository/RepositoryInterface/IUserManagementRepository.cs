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
        [Sql("[dbo].[P_GetUsers]")]
        Task<List<User>> GetUsersAsync(bool isLocked, bool isActive);
    }
}
