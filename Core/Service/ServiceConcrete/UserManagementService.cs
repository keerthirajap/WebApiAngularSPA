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
    }
}