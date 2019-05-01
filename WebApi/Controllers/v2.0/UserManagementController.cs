using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BindingModel.User;
using BindingModel.v1._0;
using BindingModel.v1._0.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Service;

namespace WebApi.Controllers.v2._0
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        [ProducesResponseType(200)] //
        [ProducesResponseType(201)] //A response as creation of user
        [ProducesResponseType(400)] //For bad request
        [ProducesResponseType(500)] //If there was an internal server error
        public IActionResult CreateUser([FromBody]UserBindingModel userLogin)
        {
            if (ModelState.IsValid)
            {
                var userCreationSuccess = this._userService.CreateUser(userLogin);

                return Ok(userCreationSuccess);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}