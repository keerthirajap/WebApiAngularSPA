namespace ServiceInterface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Autofac.Extras.DynamicProxy;
    using CrossCutting.Logging;
    using Domain.User;

    [Intercept(typeof(ServiceClassLogInterceptor))]
    public interface IUserManagementService
    {
        Task<long> RegisterUserAsync(User user);

        Task<User> GetUserDetailsByUserNameAsync(string userName);

        Task<(User, UserAuthentication)> AuthenticateUserAsync(User user);
    }
}