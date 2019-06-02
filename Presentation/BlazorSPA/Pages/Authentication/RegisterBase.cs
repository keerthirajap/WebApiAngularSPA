﻿namespace BlazorSPA.Pages.Authentication
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

    public class RegisterBase : ComponentBase
    {
        [Inject] private ILogger<LoginBase> _logger { get; set; }
        [Inject] private IJSRuntime _jsRuntime { get; set; }
        [Inject] private AppState _appState { get; set; }
        [Inject] private AuthenticationDataService _authenticationDataService { get; set; }

        protected UserLoginBindingModel loginBindingModel = new UserLoginBindingModel();

        protected async Task LoginOnLoad()
        {
            await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
        }

        protected async Task Login()
        {
            this._logger?.LogInformation("'{0}' Method execution started", nameof(Login));
            await this._jsRuntime.InvokeAsync<object>("homeController.ShowLoadingIndicator");

            try
            {
                var response = new SingleResponse<UserAuthenticationBindingModel>();
                response = await this._authenticationDataService.Login(loginBindingModel);

                if (response.Model.IsUserAuthenticated)
                {
                    await this._appState.SaveJwtTokenAsync(response.Model);
                    await this._jsRuntime.InvokeAsync<object>("homeController.RedirectToUrl", "/");
                }

                await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
                this._logger?.LogInformation("'{0}' Method execution completed successfully", nameof(this.Login));
            }
            catch (Exception ex)
            {
                this._logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(this.Login), ex);
            }
        }

        protected async Task CheckAuthentication()
        {
            this._logger?.LogInformation("'{0}' Method execution started", nameof(this.CheckAuthentication));
            await this._jsRuntime.InvokeAsync<object>("homeController.ShowLoadingIndicator");

            try
            {
                await this._authenticationDataService.CheckAuthenticationAsync();

                await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
                this._logger?.LogInformation("'{0}' Method execution completed successfully", nameof(this.CheckAuthentication));
            }
            catch (Exception ex)
            {
                this._logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(this.CheckAuthentication), ex);
            }
        }
    }
}