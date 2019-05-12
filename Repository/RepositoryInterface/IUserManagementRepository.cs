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
    public interface IUserManagementRepository
    {
        [Sql("[dbo].[P_GetUserRoles]")]
        Task<List<UserRole>> GetUserRolesAsync(User user);

        [Sql("[dbo].[P_GetUsers]")]
        Task<List<User>> GetUsersAsync(bool isLocked, bool isActive);

        [Sql("[dbo].[P_UpdateUser]")]
        Task<bool> UpdateUserAsync(User user);

        [Sql("[dbo].[P_DeleteUser]")]
        Task<bool> DeleteUserAsync(User user);

        [Sql("[dbo].[P_ModifyUserRoles]")]
        Task<bool> ModifyUserRolesAsync(User user, List<UserRole> userRoles);
    }
}