namespace BlazorSPA.Pages.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using BindingModelSPA.User;
    using Microsoft.Extensions.Logging;
    using BlazorSPA.Services;
    using BindingModelSPA.Infrastructure;
    using Microsoft.JSInterop;
    using BlazorSPA.Infrastructure;
    using System.Net.Http;
    using Microsoft.Extensions.Configuration;

    public class UserManagementBase : ComponentBase
    {
        [Inject] private ILogger<UserManagementBase> _logger { get; set; }
        [Inject] private IJSRuntime _jsRuntime { get; set; }
        [Inject] private AppState _appState { get; set; }
        [Inject] private UserManagementDataService _userManagementDataService { get; set; }

        public List<UserBindingModel> UsersDetails { get; set; }

        protected async Task UserManagementOnLoad()
        {
            await this._jsRuntime.InvokeAsync<object>("homeController.navActiveColorChange", "nav-ItemAdmin");
            await this._jsRuntime.InvokeAsync<object>("homeController.loadScriptFile", "jsControllers/admin/userManagement.js");

            this.UsersDetails = await this._userManagementDataService.GetUsersAsync();

            await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
        }
    }
}