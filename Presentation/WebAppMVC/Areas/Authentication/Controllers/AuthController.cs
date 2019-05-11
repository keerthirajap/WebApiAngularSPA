namespace WebAppMVC.Areas.Authentication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BindingModel.V1._0.User;
    using Domain.User;
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
        private readonly IUserManagementService _userManagementService;

        public AuthController(
                               IMapper mapper,
                               IHttpContextAccessor httpContextAccessor,
                               IUserManagementService userManagementService)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
            this._userManagementService = userManagementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Login")]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return await Task.Run(() => this.View());
        }

        [Route("Register")]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            RegisterUserBindingModel registerUserBindingModel = new RegisterUserBindingModel();
            return await Task.Run(() => this.View(registerUserBindingModel));
        }

        [Route("RegisterUser")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromForm] RegisterUserBindingModel registerUserBindingModel)
        {
            if (ModelState.IsValid)
            {
                return await Task.Run(() => this.View("Register", registerUserBindingModel));
            }

            dynamic ajaxReturn = new JObject();

            User user = this._mapper.Map<User>(registerUserBindingModel);

            var userCreationSuccess = await this._userManagementService.RegisterUserAsync(user);

            if (userCreationSuccess > 0)
            {
                ajaxReturn.Status = "Success";
                ajaxReturn.UserId = userCreationSuccess;
                ajaxReturn.UserName = registerUserBindingModel.UserName;
                ajaxReturn.GetGoodJobVerb = "Congratulations";
                ajaxReturn.Message = registerUserBindingModel.UserName + " - user sucessfully created." +
                    " ";
                return this.Json(ajaxReturn);
            }

            return await Task.Run(() => this.View("Register", registerUserBindingModel));
        }
    }
}