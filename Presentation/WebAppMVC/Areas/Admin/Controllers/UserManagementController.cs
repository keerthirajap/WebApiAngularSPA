namespace WebAppMVC.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BindingModel.V1._0.User;
    using BindingModel.V1._0.User.Role;
    using Domain.User;
    using Domain.User.Role;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using ServiceInterface;

    [AutoValidateAntiforgeryToken]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserManagementService _userManagementService;
        private readonly ServiceInterface.IAuthenticationService _authenticationService;

        public UserManagementController(
                               IMapper mapper,
                               IHttpContextAccessor httpContextAccessor,
                               IUserManagementService userManagementService,
                               ServiceInterface.IAuthenticationService authenticationService)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
            this._userManagementService = userManagementService;
            this._authenticationService = authenticationService;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => this.View());
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            List<UserBindingModel> userBindingModel = new List<UserBindingModel>();

            List<User> users =
               await this._userManagementService.GetUsersAsync(isLocked: false, isActive: true);

            userBindingModel = this._mapper.Map<List<UserBindingModel>>(users);

            return await Task.Run(() => this.PartialView("_GetUsers", userBindingModel));
        }

        [Route("EditUserRolesAsync")]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditUserRolesAsync(List<UserRoleBindingModel> userRolesBindingModel, string userName)
        {
            dynamic ajaxReturn = new JObject();
            User user = new User();
            List<UserRole> roles = new List<UserRole>();

            user = await this._authenticationService.GetUserDetailsByUserNameAsync(userName);

            if (user == null)
            {
                ajaxReturn.Status = "Warning";
                ajaxReturn.UserName = userName;
                ajaxReturn.Message = userName +
                                    " - user name not found";
            }

            roles = this._mapper.Map<List<UserRole>>(userRolesBindingModel);

            var isModifyUserSuccess = await this._userManagementService.ModifyUserRolesAsync(user, roles);
            if (isModifyUserSuccess)
            {
                ajaxReturn.Status = "Success";
                ajaxReturn.UserName = userName;
                ajaxReturn.GetGoodJobVerb = "Congratulations";
                ajaxReturn.Message = userName + " - user roles modified successfully." +
                    " ";
            }
            else
            {
                ajaxReturn.Status = "Error";
                ajaxReturn.UserName = userName;
                ajaxReturn.Message = "Error occured while modifying roles for - " + userName +
                                    "";
            }

            return this.Json(ajaxReturn);
        }

        [HttpGet]
        public async Task<IActionResult> LoadAddUserPartialView()
        {
            UserBindingModel userBindingModel = new UserBindingModel();

            return await Task.Run(() => this.PartialView("_AddUser", userBindingModel));
        }

        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUserAsync(UserBindingModel userBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return await Task.Run(() => this.PartialView("_AddUser", userBindingModel));
            }

            dynamic ajaxReturn = new JObject();

            User user = this._mapper.Map<User>(userBindingModel);

            var userCreationSuccess = await this._authenticationService.RegisterUserAsync(user);

            if (userCreationSuccess > 0)
            {
                ajaxReturn.Status = "Success";
                ajaxReturn.UserId = userCreationSuccess;
                ajaxReturn.UserName = userBindingModel.UserName;
                ajaxReturn.GetGoodJobVerb = "Congratulations";
                ajaxReturn.Message = userBindingModel.UserName + " - user sucessfully created." +
                    " ";
            }
            else
            {
                ajaxReturn.Status = "Error";
                ajaxReturn.UserId = userCreationSuccess;
                ajaxReturn.UserName = userBindingModel.UserName;
                ajaxReturn.Message = "Error occured while creating user - " + userBindingModel.UserName +
                                    "";
            }

            return this.Json(ajaxReturn);
        }

        [HttpGet]
        public async Task<IActionResult> LoadEditUserPartialView(string userName)
        {
            dynamic ajaxReturn = new JObject();
            List<UserRoleBindingModel> userRolesBindingModel = new List<UserRoleBindingModel>();
            UserBindingModel userBindingModel = new UserBindingModel();
            User user = new User();
            List<UserRole> roles = new List<UserRole>();

            roles = await this._authenticationService.GetRolesAsync();
            user = await this._authenticationService.GetUserDetailsByUserNameAsync(userName);
            List<UserRole> userRoles = await this._userManagementService.GetUserRolesAsync(user);

            var rolesNotMapped = (from r in roles
                                  join ur in userRoles on r.RoleName equals ur.RoleName
                                  into result
                                  where result.Count() == 0
                                  select r).ToList();

            if (rolesNotMapped != null && rolesNotMapped.Count > 0)
            {
                userRoles.AddRange(rolesNotMapped);
            }

            userBindingModel = this._mapper.Map<UserBindingModel>(user);
            userRolesBindingModel = this._mapper.Map<List<UserRoleBindingModel>>(userRoles);
            return await Task.Run(() => this.PartialView("_EditUser", (userBindingModel, userRolesBindingModel)));
        }

        [Route("EditUser")]
        [HttpPost]
        public async Task<IActionResult> EditUserAsync([Bind(Prefix = "Item1")] UserBindingModel userBindingModel)
        {
            dynamic ajaxReturn = new JObject();

            User user = this._mapper.Map<User>(userBindingModel);

            var userCreationSuccess = await this._userManagementService.UpdateUserAsync(user);

            if (userCreationSuccess)
            {
                ajaxReturn.Status = "Success";
                ajaxReturn.UserName = userBindingModel.UserName;
                ajaxReturn.GetGoodJobVerb = "Good Work";
                ajaxReturn.Message = userBindingModel.UserName + " - user details saved sucessfully" +
                    " ";
            }
            else
            {
                ajaxReturn.Status = "Error";
                ajaxReturn.UserId = userCreationSuccess;
                ajaxReturn.UserName = userBindingModel.UserName;
                ajaxReturn.Message = "Error occured while updating user - " + userBindingModel.UserName +
                                    "";
            }

            return this.Json(ajaxReturn);
        }

        [HttpGet]
        public async Task<IActionResult> LoadDeleteUserPartialView(string userName)
        {
            UserBindingModel userBindingModel = new UserBindingModel();

            dynamic ajaxReturn = new JObject();

            User user = new User();

            user = await this._authenticationService.GetUserDetailsByUserNameAsync(userName);

            userBindingModel = this._mapper.Map<UserBindingModel>(user);

            return await Task.Run(() => this.PartialView("_DeleteUser", userBindingModel));
        }

        [Route("DeleteUser")]
        [HttpPost]
        public async Task<IActionResult> DeleteUserAsync(UserBindingModel userBindingModel)
        {
            dynamic ajaxReturn = new JObject();

            User user = this._mapper.Map<User>(userBindingModel);

            var userCreationSuccess = await this._userManagementService.DeleteUserAsync(user);

            if (userCreationSuccess)
            {
                ajaxReturn.Status = "Success";
                ajaxReturn.UserName = userBindingModel.UserName;
                ajaxReturn.GetGoodJobVerb = "Good Work";
                ajaxReturn.Message = userBindingModel.UserName + " - user deleted sucessfully" +
                    " ";
            }
            else
            {
                ajaxReturn.Status = "Error";
                ajaxReturn.UserId = userCreationSuccess;
                ajaxReturn.UserName = userBindingModel.UserName;
                ajaxReturn.Message = "Error occured while deleting user - " + userBindingModel.UserName +
                                    "";
            }

            return this.Json(ajaxReturn);
        }
    }
}