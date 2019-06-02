namespace BlazorSPA.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using BindingModelSPA.Infrastructure;
    using BindingModelSPA.User;
    using Blazored.LocalStorage;
    using BlazorSPA.Infrastructure;
    using Microsoft.AspNetCore.Components;
    using Microsoft.Extensions.Logging;
    using Microsoft.JSInterop;

    public class AuthenticationDataService
    {
        private HttpClient _httpClient;
        private AppState _appState;
        private ILogger<AuthenticationDataService> _logger;

        public AuthenticationDataService(HttpClient httpInstance, AppState appState
                                        , ILogger<AuthenticationDataService> logger)
        {
            this._httpClient = httpInstance;
            this._appState = appState;
            this._logger = logger;
        }

        public async Task<SingleResponse<UserAuthenticationBindingModel>> Login(UserLoginBindingModel userLoginBindingModel)
        {
            var response = new SingleResponse<UserAuthenticationBindingModel>();

            try
            {
                response = await this._httpClient
                            .SendJsonAsync<SingleResponse<UserAuthenticationBindingModel>>
                            (HttpMethod.Post, "https://localhost:44388/api/v1.0/Authentication/User/AuthenticateUser", userLoginBindingModel);
            }
            catch (Exception ex)
            {
                this._logger?.LogError(ex.Message + " " + ex.StackTrace);
            }

            return response;
        }

        public async Task CheckAuthenticationAsync()
        {
            await this._appState.SetAuthorizationHeader();

            await this._httpClient
                        .GetAsync
                        ("https://localhost:44388/api/v1.0/Authentication/User/CheckAuthentication");
        }
    }
}