namespace ServiceInterface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Autofac.Extras.DynamicProxy;
    using CrossCutting.Logging;
    using Domain.User;
    using Domain.User.Role;

    [Intercept(typeof(ServiceInterfaceLogInterceptor))]
    public interface IUserManagementService
    {
        Task<List<User>> GetUsersAsync(bool isLocked, bool isActive);

        Task<bool> UpdateUserAsync(User user);

        Task<bool> DeleteUserAsync(User user);

        Task<List<UserRole>> GetUserRolesAsync(User user);

        Task<bool> ModifyUserRolesAsync(User user, List<UserRole> userRoles);
    }
}