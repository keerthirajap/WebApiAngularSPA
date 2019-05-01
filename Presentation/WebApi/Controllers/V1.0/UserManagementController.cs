namespace WebApi.Controllers.V1._0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BindingModel.User;
    using BindingModel.V1._0;
    using BindingModel.V1._0.User;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Infrastructure.Filters;
    using WebApi.Models.V1._0;
    using WebApi.Service;

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            this._userService = userService;
        }

        // api/UserManagement/User?api-version=1.0
        [AllowAnonymous]
        [HttpPost("User")]
        [ValidateModelState]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)] //A response as creation of user
        [ProducesResponseType(400)] //For bad request
        [ProducesResponseType(500)] //If there was an internal server error
        public IActionResult CreateUser([FromBody]UserBindingModel userLogin)
        {
            var errors = new Dictionary<string, string>();
            var response = new SingleCreatedResponse<dynamic>();

            UserBindingModel checkUserExists =
                                        this._userService.GetUserByName(userLogin);
            if (checkUserExists != null)
            {
                errors.Add("UserName", "User Name " + userLogin.UserName + " already exists");
                response.ErrorMessage = "Validation error occured";
                response.DidValidationError = true;
                response.Model = errors;
                return response.ToHttpResponse();
            }

            var userCreationSuccess = this._userService.CreateUser(userLogin);

            if (userCreationSuccess)
            {
                var userAuthenticationToken = this._userService.Authenticate(userLogin.UserName, userLogin.Password);
                response.Model = userAuthenticationToken;
                response.Message = "User " + userLogin.UserName
                                + " created successfully. Redirecting to Home screen.";
            }

            return response.ToHttpResponse();
        }

        // api/UserManagement/User/Test201?api-version=1.0
        [HttpGet("User/{userName}")]
        [ProducesResponseType(200)] //If User Detail found
        [ProducesResponseType(404)] //If User Detail is not exists
        [ProducesResponseType(500)] //If there was an internal server error
        public IActionResult GetUserByName(string userName)
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

            userDetails = this._userService.GetUserByName(userDetails);

            response.Model = userDetails;
            return response.ToHttpResponse();
        }

        [AllowAnonymous]
        [HttpPut("User")]
        [ValidateModelState]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] //For bad request
        [ProducesResponseType(500)] //If there was an internal server error
        public IActionResult UpdateUser([FromBody]UserBindingModel userBindingModel)
        {
            var errors = new Dictionary<string, string>();
            var response = new SingleResponse<dynamic>();

            UserBindingModel userDetails =
                                        this._userService.GetUserByName(userBindingModel);
            if (userDetails == null)
            {
                errors.Add("UserName", "User Name " + userBindingModel.UserName + " not found");
                response.ErrorMessage = "Validation error occured";
                response.DidValidationError = true;
                response.Model = errors;
                return response.ToHttpResponse();
            }

            ModelState.Remove("UserId");
            var userUpdateSuccess = this._userService.UpdateUser(userBindingModel);

            if (userUpdateSuccess)
            {
                userDetails = this._userService.GetUserByName(userBindingModel);
                response.Model = userDetails;
                response.Message = "User " + userBindingModel.UserName
                                + " updated successfully.";
            }

            return response.ToHttpResponse();
        }

        [AllowAnonymous]
        [HttpDelete("User")]
        [ValidateModelState]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] //For bad request
        [ProducesResponseType(500)] //If there was an internal server error
        public IActionResult DeleteUser([FromBody]UserBindingModel userBindingModel)
        {
            var errors = new Dictionary<string, string>();
            var response = new SingleResponse<dynamic>();

            UserBindingModel userDetails =
                                        this._userService.GetUserByName(userBindingModel);
            if (userDetails == null)
            {
                errors.Add("UserName", "User Name " + userBindingModel.UserName + " not found");
                response.ErrorMessage = "Validation error occured";
                response.DidValidationError = true;
                response.Model = errors;
                return response.ToHttpResponse();
            }

            ModelState.Remove("UserId");
            var userUpdateSuccess = this._userService.DeleteUser(userBindingModel);

            if (userUpdateSuccess)
            {
                response.Model = string.Empty;
                response.Message = "User " + userBindingModel.UserName
                                + " deleted successfully.";
            }

            return response.ToHttpResponse();
        }

        [AllowAnonymous]
        [HttpPost("AuthenticateUser")]
        [ValidateModelState]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] //For bad request
        [ProducesResponseType(500)] //If there was an internal server error
        public IActionResult AuthenticateUser([FromBody]UserLoginBindingModel userLoginBindingModel)
        {
            var response = new SingleResponse<dynamic>();

            var user = this._userService.Authenticate(userLoginBindingModel.UserName, userLoginBindingModel.Password);

            if (user == null)
            {
                response.Model = null;
                response.Message = "Username or password is incorrect";

                return this.BadRequest(response);
            }

            response.Model = user;
            return response.ToHttpResponse();
        }
    }
}