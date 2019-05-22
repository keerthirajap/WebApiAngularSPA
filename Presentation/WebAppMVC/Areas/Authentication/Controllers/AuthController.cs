namespace WebAppMVC.Areas.Authentication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using BindingModel.V1._0.User;
    using BindingModel.V1._0.User.Role;
    using Domain.User;
    using Domain.User.Role;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using ServiceInterface;

    [AutoValidateAntiforgeryToken]
    [Area("Authentication")]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ServiceInterface.IAuthenticationService _authenticationService;
        private readonly IUserManagementService _userManagementService;

        public AuthController(
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

        public IActionResult Index()
        {
            return this.View();
        }

        [Route("Login")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await this.LogOut();
            return await Task.Run(() => this.View());
        }

        [Route("Login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginBindingModel userLoginBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return await Task.Run(() => this.View(userLoginBindingModel));
            }

            dynamic ajaxReturn = new JObject();
            var user = this._mapper.Map<User>(userLoginBindingModel);

            var userAuthenticationDetails = await this._authenticationService.ValidateAndAuthenticateUserAsync(user);

            User userDetails = new User();
            List<UserRole> userRoles = new List<UserRole>();
            UserAuthentication userAuthentication = new UserAuthentication();

            userDetails = userAuthenticationDetails.user;
            userRoles = userAuthenticationDetails.userRoles;
            userAuthentication = userAuthenticationDetails.authenticationDetails;

            UserAuthenticationBindingModel userAuthenticationBindingModel = new UserAuthenticationBindingModel();
            userAuthenticationBindingModel = this._mapper.Map<UserAuthenticationBindingModel>(userAuthentication);
            userAuthenticationBindingModel.UserName = userLoginBindingModel.UserName;

            if (userAuthenticationBindingModel.IsUserAuthenticated)
            {
                var identity = (ClaimsIdentity)HttpContext.User.Identity;

                List<Claim> claims = new List<Claim>
             {
                new Claim ("http://example.org/claims/UserName", userDetails.UserName),
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim("http://example.org/claims/UserId", userDetails.UserId.ToString()),
                new Claim(ClaimTypes.NameIdentifier , userDetails.UserId.ToString()),
                new Claim(ClaimTypes.Authentication , "Authenticated"),
                new Claim("http://example.org/claims/LoggedInTime", "LoggedInTime", DateTime.Now.ToString())
             };
                foreach (var item in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item.RoleName));
                }

                var identityClaims = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // create principal
                ClaimsPrincipal principal = new ClaimsPrincipal(identityClaims);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                ajaxReturn.Status = "Success";

                ajaxReturn.GetGoodJobVerb = "Congratulations";
                ajaxReturn.Message = userLoginBindingModel.UserName + " - user authenticated successfully." +
                    " ";
            }
            else
            {
                ajaxReturn.Status = "Warning";

                ajaxReturn.GetGoodJobVerb = "Opps";
                ajaxReturn.Message = "User Name or Password is incorrect. Please try again." +
                    " ";
            }

            return this.Json(ajaxReturn);
        }

        [Route("LogOut")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync();

            dynamic ajaxReturn = new JObject();
            ajaxReturn.Status = "Success";
            ajaxReturn.Message = "You have been successfully logged out. " +
                                    "Current window will be closed now";

            return this.Json(ajaxReturn);
        }

        [Route("Register")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            await this.LogOut();
            RegisterUserBindingModel registerUserBindingModel = new RegisterUserBindingModel();
            return await Task.Run(() => this.View(registerUserBindingModel));
        }

        [Route("Register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterUserBindingModel registerUserBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return await Task.Run(() => this.View(registerUserBindingModel));
            }

            dynamic ajaxReturn = new JObject();

            User user = this._mapper.Map<User>(registerUserBindingModel);

            var userCreationSuccess = await this._authenticationService.RegisterUserAsync(user);

            if (userCreationSuccess > 0)
            {
                ajaxReturn.Status = "Success";
                ajaxReturn.UserId = userCreationSuccess;
                ajaxReturn.UserName = registerUserBindingModel.UserName;
                ajaxReturn.GetGoodJobVerb = "Congratulations";
                ajaxReturn.Message = registerUserBindingModel.UserName + " - user sucessfully created." +
                    " ";

                var identity = (ClaimsIdentity)HttpContext.User.Identity;

                List<Claim> claims = new List<Claim>
             {
                new Claim ("http://example.org/claims/UserName", "UserName", user.UserName),
                new Claim(ClaimTypes.Name , user.UserName),

                new Claim(ClaimTypes.Authentication , "Authenticated"),
                new Claim("http://example.org/claims/LoggedInTime", "LoggedInTime", DateTime.Now.ToString())
             };
                var identityClaims = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // create principal
                ClaimsPrincipal principal = new ClaimsPrincipal(identityClaims);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
            else
            {
                ajaxReturn.Status = "Error";
                ajaxReturn.UserId = userCreationSuccess;
                ajaxReturn.UserName = registerUserBindingModel.UserName;
                ajaxReturn.GetGoodJobVerb = "Opps";
                ajaxReturn.Message = registerUserBindingModel.UserName + " - user sucessfully created." +
                    " ";
            }

            return this.Json(ajaxReturn);
        }

        [Authorize]
        [Route("LoadUserDetailsPartialView")]
        [HttpGet]
        public async Task<IActionResult> LoadUserDetailsPartialViewAsync(string userName)
        {
            dynamic ajaxReturn = new JObject();
            List<UserRoleBindingModel> userRolesBindingModel = new List<UserRoleBindingModel>();
            UserBindingModel userBindingModel = new UserBindingModel();
            User user = new User();
            List<UserRole> roles = new List<UserRole>();

            user = await this._authenticationService.GetUserDetailsByUserNameAsync(userName);
            List<UserRole> userRoles = await this._userManagementService.GetUserRolesAsync(user);
            userBindingModel = this._mapper.Map<UserBindingModel>(user);
            userRolesBindingModel = this._mapper.Map<List<UserRoleBindingModel>>(userRoles);
            return await Task.Run(() => this.PartialView("_getUserDetails", (userBindingModel, userRolesBindingModel)));
        }
    }
}