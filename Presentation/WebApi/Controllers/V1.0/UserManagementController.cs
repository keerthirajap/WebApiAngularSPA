namespace WebApi.Controllers.V1._0
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using BindingModelSPA.User;
    using BindingModelSPA.User.Role;
    using CrossCutting.ConfigCache;
    using CrossCutting.Constants;
    using Domain.User;
    using Domain.User.Role;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using ServiceInterface;
    using WebApi.Infrastructure.Filters;
    using WebApi.Models.V1._0;
    using static WebApi.Startup;

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly ILogger<UserManagementController> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserManagementService _userManagementService;

        private readonly IOptions<JwtAuthentication> _jwtAuthentication;

        public UserManagementController(ILogger<UserManagementController> logger,
                                IMapper mapper,
                                IHttpContextAccessor httpContextAccessor,
                                IOptions<JwtAuthentication> jwtAuthentication,
                                IAuthenticationService authenticationService,
                                IUserManagementService userManagementService)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._logger = logger;
            this._mapper = mapper;
            this._jwtAuthentication = jwtAuthentication ?? throw new ArgumentNullException(nameof(jwtAuthentication));

            this._authenticationService = authenticationService;
            this._userManagementService = userManagementService;
        }

        // api/UserManagement/User/Test201?api-version=1.0
        [HttpGet("User/{userName}")]
        [ProducesResponseType(200)] //If User Detail found
        [ProducesResponseType(404)] //If User Detail is not exists
        [ProducesResponseType(500)] //If there was an internal server error
        public async Task<IActionResult> GetUserDetailsByUserNameAsync(string userName)
        {
            var response = new SingleResponse<dynamic>();

            if (userName == string.Empty)
            {
                response.ErrorMessage = "Validation error occured";
                response.DidValidationError = true;
                response.Model = "User Name should not be empty";
                return response.ToHttpResponse();
            }

            UserBindingModel userDetails = new UserBindingModel()
            {
                UserName = userName,
            };

            var userDetailss = await this._authenticationService.GetUserDetailsByUserNameAsync(userName);
            response.Model = userDetails;
            return response.ToHttpResponse();
        }

        [HttpPost("User/AuthenticateUser")]
        [AllowAnonymous]
        [ValidateModelState]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] //For bad request
        [ProducesResponseType(500)] //If there was an internal server error
        public async Task<IActionResult> AuthenticateUserAsync([FromBody] UserLoginBindingModel userLoginBindingModel)
        {
            var response = new SingleResponse<dynamic>();

            var user = this._mapper.Map<User>(userLoginBindingModel);

            var userAuthenticationDetails = await this._authenticationService.AuthenticateUserAsync(user);
            var userAuthentication = userAuthenticationDetails.Item2;
            var userDetails = userAuthenticationDetails.Item1;

            UserAuthenticationBindingModel userAuthenticationBindingModel = new UserAuthenticationBindingModel();
            userAuthenticationBindingModel = this._mapper.Map<UserAuthenticationBindingModel>(userAuthentication);
            userAuthenticationBindingModel.UserName = userLoginBindingModel.UserName;
            if (userAuthenticationBindingModel.IsUserAuthenticated)
            {
                response.Message = "User " + userAuthentication.UserName
                + " authenticated successfully. Redirecting to Home screen.";
                this.CreateJWTToken(response, userAuthenticationBindingModel);
            }
            else
            {
                response.Model = userAuthenticationBindingModel;
                response.DidValidationError = true;
                response.Message = "User Name or Password is Incorrect. Please try again";
            }

            return response.ToHttpResponse();
        }

        [HttpPost("User/RegisterUser")]
        [ValidateModelState]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)] //A response as creation of user
        [ProducesResponseType(400)] //For bad request
        [ProducesResponseType(500)] //If there was an internal server error
        public async Task<IActionResult> RegisterUserAsync([FromBody]UserBindingModel userBindingModel)
        {
            var errors = new Dictionary<string, string>();
            var response = new SingleCreatedResponse<dynamic>();

            User user = await this._authenticationService.GetUserDetailsByUserNameAsync(userBindingModel.UserName);

            if (user != null)
            {
                errors.Add("UserName", "User Name " + userBindingModel.UserName + " already exists");
                response.ErrorMessage = "Validation error occured";
                response.DidValidationError = true;
                response.Model = errors;
                return response.ToHttpResponse();
            }

            user = this._mapper.Map<User>(userBindingModel);

            var userCreationSuccess = await this._authenticationService.RegisterUserAsync(user);

            if (userCreationSuccess > 0)
            {
                UserAuthenticationBindingModel userAuthentication = new UserAuthenticationBindingModel();

                userAuthentication.UserName = userBindingModel.UserName;

                response.Message = "User " + userAuthentication.UserName
                + " created successfully. Redirecting to Home screen.";
                this.CreateJWTToken(response, userAuthentication);
            }

            return response.ToHttpResponse();
        }

        [HttpGet("User/GetUserDetailsAndRoles/{userName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] //For bad request
        [ProducesResponseType(500)] //If there was an internal server error
        public async Task<IActionResult> GetUserDetailsAndRolesAsync(string userName)
        {
            var response = new SingleResponse<dynamic>();

            if (userName == null || userName == string.Empty)
            {
                response.DidValidationError = true;
                response.ErrorMessage = "User Name is incorrect";
                response.DidValidationError = true;
                return response.ToHttpResponse();
            }

            List<UserRoleBindingModel> userRolesBindingModel = new List<UserRoleBindingModel>();
            UserBindingModel userBindingModel = new UserBindingModel();
            User user = new User();
            List<UserRole> roles = new List<UserRole>();

            user = await this._authenticationService.GetUserDetailsByUserNameAsync(userName);

            if (user == null)
            {
                response.DidValidationError = true;
                response.ErrorMessage = "User Name - " + userName + "not found";
                return response.ToHttpResponse();
            }

            List<UserRole> userRoles = await this._userManagementService.GetUserRolesAsync(user);
            userBindingModel = this._mapper.Map<UserBindingModel>(user);
            userRolesBindingModel = this._mapper.Map<List<UserRoleBindingModel>>(userRoles);

            response.Model = (userDetails: userBindingModel, userRoles: userRolesBindingModel);

            return response.ToHttpResponse();
        }

        // api/UserManagement/User/Test201?api-version=1.0
        [HttpGet("User/GetUsers")]
        [ProducesResponseType(200)] //If User Detail found
        [ProducesResponseType(404)] //If User Detail is not exists
        [ProducesResponseType(500)] //If there was an internal server error
        public async Task<IActionResult> GetUsersAsync()
        {
            var response = new ListResponse<UserBindingModel>();

            List<UserBindingModel> userBindingModel = new List<UserBindingModel>();

            List<User> users =
               await this._userManagementService.GetUsersAsync(isLocked: false, isActive: true);

            response.Model = this._mapper.Map<List<UserBindingModel>>(users);

            return response.ToHttpResponse();
        }

        [HttpDelete("User/DeleteUser/{userName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)] //A response as creation of user
        [ProducesResponseType(400)] //For bad request
        [ProducesResponseType(500)] //If there was an internal server error
        public async Task<IActionResult> DeleteUserAsync(string userName)
        {
            var response = new SingleResponse<bool>();

            User user = new User();
            user.UserName = userName;
            var userCreationSuccess = await this._userManagementService.DeleteUserAsync(user);

            if (userCreationSuccess)
            {
                response.Message = userName + " - user deleted sucessfully" +
                    " ";
            }
            else
            {
                response.DidError = true;
                response.Message = "Error occured while deleting user - " + userName +
                                    "";
            }

            return response.ToHttpResponse();
        }

        [Authorize(Roles = CoreWebApiRoles.User)]
        [HttpPost("User/IsUserAdmin")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] //For bad request
        [ProducesResponseType(500)] //If there was an internal server error
        public async Task<IActionResult> IsUserAdminAsync()
        {
            return await Task.Run(() => this.Ok());
        }

        [Authorize(Roles = CoreWebApiRoles.User + "," + CoreWebApiRoles.Admin)]
        [HttpPost("User/IsUserAdminAndUser")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] //For bad request
        [ProducesResponseType(500)] //If there was an internal server error
        public async Task<IActionResult> IsUserAdminAndUserAsync()
        {
            return await Task.Run(() => this.Ok());
        }

        private void CreateJWTToken(dynamic response, UserAuthenticationBindingModel userAuthentication)
        {
            userAuthentication.ExpiresOn = DateTime.Now.AddDays(1);
            userAuthentication.LoggedOn = DateTime.Now;
            userAuthentication.IsUserAuthenticated = true;
            userAuthentication.IsUserAccountFound = true;

            var token = new JwtSecurityToken(
                issuer: GlobalAppConfigurations.Instance.GetValue("ValidIssuer").ToString(),
                audience: GlobalAppConfigurations.Instance.GetValue("ValidAudience").ToString(),
                claims: new[]
                {
                // You can add more claims if you want
                new Claim(JwtRegisteredClaimNames.Sub, userAuthentication.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(ClaimTypes.Role, CoreWebApiRoles.Admin)
                },
                expires: userAuthentication.ExpiresOn,
                notBefore: userAuthentication.LoggedOn,
                signingCredentials: this._jwtAuthentication.Value.SigningCredentials);

            userAuthentication.Token = new JwtSecurityTokenHandler().WriteToken(token);

            response.Model = userAuthentication;
        }
    }
}