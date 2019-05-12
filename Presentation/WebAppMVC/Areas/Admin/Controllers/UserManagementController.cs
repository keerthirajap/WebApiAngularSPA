namespace WebAppMVC.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BindingModel.V1._0.User;
    using Domain.User;
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
            UserBindingModel userBindingModel = new UserBindingModel();

            dynamic ajaxReturn = new JObject();

            User user = new User();
            user.UserName = userName;

            //var userAuthenticationDetails =
            //    await this._userManagementService.GetUsersAsync(user);

            return await Task.Run(() => this.PartialView("_EditUser", userBindingModel));
        }
    }
}