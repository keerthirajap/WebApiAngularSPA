namespace BlazorSPA.Pages.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using BindingModelSPA.User;
    using Microsoft.Extensions.Logging;

    public class LoginBase : ComponentBase
    {
        [Inject]
        protected ILogger<LoginBase> logger { get; set; }

        protected async Task Login(UserLoginBindingModel userLoginBindingModel)
        {
            logger.LogDebug(userLoginBindingModel.UserName);
        }
    }
}