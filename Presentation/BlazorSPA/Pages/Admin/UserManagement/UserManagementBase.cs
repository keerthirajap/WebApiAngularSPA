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
    using System.Threading;

    public class UserManagementBase : ComponentBase
    {
        [Inject] private ILogger<UserManagementBase> _logger { get; set; }
        [Inject] private IJSRuntime _jsRuntime { get; set; }
        [Inject] private AppState _appState { get; set; }
        [Inject] private UserManagementDataService _userManagementDataService { get; set; }

        public List<UserBindingModel> UsersDetails { get; set; }

        public UserBindingModel UserDetailsForAdd { get; set; } = new UserBindingModel();

        public UserBindingModel UserDetailsForDelete { get; set; } = new UserBindingModel();

        protected async Task UserManagementOnLoad()
        {
            bool isUserAuthenticated = this._appState.CheckUserAuthenticatedAsync();

            if (!isUserAuthenticated)
            {
                await this._jsRuntime.InvokeAsync<object>("homeController.RedirectToUrl", "/Login");
            }
            else
            {
                await this._jsRuntime.InvokeAsync<object>("homeController.navActiveColorChange", "nav-ItemAdmin");
                await this._jsRuntime.InvokeAsync<object>("homeController.loadScriptFile", "jsControllers/admin/userManagement.js");
            }
        }

        protected async Task UserManagementOnLoaded()
        {
            await this.GetUsersAsync();
            await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
        }

        public async Task GetUsersAsync()
        {
            UsersDetails = await this._userManagementDataService.GetUsersAsync();
        }

        protected async Task ShowDeleteUserConfirmModal(UserBindingModel userDetailsForDelete)
        {
            await this._jsRuntime.InvokeAsync<object>("homeController.ShowLoadingIndicator");

            this.UserDetailsForDelete = userDetailsForDelete;
            await this._jsRuntime.InvokeAsync<object>("homeController.showModalPopUp", "modalDeleteUser");
            Thread.Sleep(300);
            await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
        }

        protected async Task DeleteUser(UIMouseEventArgs e)
        {
            await this._jsRuntime.InvokeAsync<object>("homeController.ShowLoadingIndicator");

            var response = new SingleResponse<bool>();
            await this._jsRuntime.InvokeAsync<object>("homeController.HideModalPopUp", "modalDeleteUser");

            response = await this._userManagementDataService.DeleteUserAsync(this.UserDetailsForDelete);

            if (!response.DidError && !response.DidValidationError)
            {
                await this._jsRuntime.InvokeAsync<object>("homeController.showSweetAlertMessagePopUp", "Success", response.Message);
            }

            await this.GetUsersAsync();
            await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
        }

        protected async Task ShowAddUserModal()
        {
            await this._jsRuntime.InvokeAsync<object>("homeController.ShowLoadingIndicator");
            this.UserDetailsForAdd = new UserBindingModel();
            await this._jsRuntime.InvokeAsync<object>("homeController.showModalPopUp", "modalAddUser");
            Thread.Sleep(300);
            await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
        }

        protected async Task AddUser(UIMouseEventArgs e)
        {
        }
    }
}