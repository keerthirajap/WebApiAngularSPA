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

    [Intercept(typeof(ServiceClassLogInterceptor))]
    public interface IUserManagementService
    {
        Task<List<User>> GetUsersAsync(bool isLocked, bool isActive);
    }
}