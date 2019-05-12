namespace WebAppMVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.User;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ServiceInterface;

    public class ValidatationsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthenticationService _authenticationService;

        public ValidatationsController(
                               IMapper mapper,
                               IHttpContextAccessor httpContextAccessor,
                               IAuthenticationService authenticationService)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
            this._authenticationService = authenticationService;
        }

        public async Task<IActionResult> IsUserNameExists(string userName)
        {
            User user = new User();
            bool isUserNameExists = true;
            user = await this._authenticationService.GetUserDetailsByUserNameAsync(userName);

            if (user != null && user.UserId > 0)
            {
                isUserNameExists = false;
            }

            return this.Json(isUserNameExists);
        }
    }
}