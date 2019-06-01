namespace BlazorSPA.Service
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

    public class AuthenticationDataService
    {
        private HttpClient _httpClient;
        private AppState _appState;

        public AuthenticationDataService(HttpClient httpInstance, AppState appState)
        {
            this._httpClient = httpInstance;
            this._appState = appState;
        }

        public async Task<SingleResponse<UserAuthenticationBindingModel>> Login(UserLoginBindingModel userLoginBindingModel)
        {
            return await this._httpClient
                        .SendJsonAsync<SingleResponse<UserAuthenticationBindingModel>>
                        (HttpMethod.Post, "https://localhost:44388/api/v1.0/Authentication/User/AuthenticateUser", userLoginBindingModel);
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