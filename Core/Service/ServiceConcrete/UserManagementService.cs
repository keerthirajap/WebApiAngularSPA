namespace ServiceConcrete
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq;
    using Domain.User;
    using Domain.User.Role;
    using RepositoryInterface;
    using ServiceInterface;

    public class UserManagementService : IUserManagementService
    {
        private readonly IUserManagementRepository _userManagementRepository;

        public UserManagementService(IUserManagementRepository userManagementRepository)
        {
            this._userManagementRepository = userManagementRepository;
        }

        public async Task<List<User>> GetUsersAsync(bool isLocked, bool isActive)
        {
            return await this._userManagementRepository.GetUsersAsync(isLocked, isActive);
        }
    }
}