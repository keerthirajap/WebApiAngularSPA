namespace BlazorSPA.Pages.Authentication
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
    using Newtonsoft.Json;
    using System.Dynamic;
    using System.Threading;

    public class RegisterBase : ComponentBase
    {
        [Inject] private ILogger<LoginBase> _logger { get; set; }
        [Inject] private IJSRuntime _jsRuntime { get; set; }
        [Inject] private AppState _appState { get; set; }
        [Inject] private AuthenticationDataService _authenticationDataService { get; set; }

        protected RegisterUserBindingModel RegisterUserBindingModel = new RegisterUserBindingModel();

        protected static string UserNameValidatationMessage { get; set; }

        protected async Task RegisterOnLoad()
        {
            await this._jsRuntime.InvokeAsync<object>("homeController.navActiveColorChange", "nav-ItemRegister");
            await this._jsRuntime.InvokeAsync<object>("homeController.loadScriptFile", "jsControllers/authentication/registerController.js");
            await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
        }

        protected async Task RegisterAsync()
        {
            this._logger?.LogInformation("'{0}' Method execution started", nameof(this.RegisterAsync));
            await this._jsRuntime.InvokeAsync<object>("homeController.ShowLoadingIndicator");

            try
            {
                var response = new SingleResponse<dynamic>();
                string jsonModel = string.Empty;
                try
                {
                    response = await this._authenticationDataService.RegisterAsync(this.RegisterUserBindingModel);
                    jsonModel = JsonConvert.SerializeObject(response.Model);
                }
                catch (HttpRequestException ex)
                {
                    this._logger?.LogInformation(response.Message);

                    await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
                    await this._jsRuntime.InvokeAsync<object>("homeController.showWarningMessagePopUp", response.ErrorMessage);
                }

                if (response.DidValidationError)
                {
                    Dictionary<string, string> validationErrors =
                        JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonModel);

                    foreach (var item in validationErrors)
                    {
                        if (item.Key == "UserName")
                        {
                            UserNameValidatationMessage = item.Value;
                        }
                    }
                }
                else if (response.DidError)
                {
                }
                else
                {
                    UserAuthenticationBindingModel userAuthentication = new UserAuthenticationBindingModel();
                    userAuthentication = JsonConvert.DeserializeObject<UserAuthenticationBindingModel>(jsonModel);
                    await this._appState.SaveJwtTokenAsync(userAuthentication);
                    await this._jsRuntime
                        .InvokeAsync<object>
                            ("registerController.onUserRegistrationSuccess", userAuthentication.UserName, "/");
                }

                await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
                this._logger?.LogInformation("'{0}' Method execution completed successfully", nameof(this.RegisterAsync));
            }
            catch (Exception ex)
            {
                this._logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(this.RegisterAsync), ex);
            }
        }
    }
}