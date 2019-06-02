namespace BlazorSPA.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using BindingModelSPA.User;
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.JSInterop;

    public class AppState
    {
        private HttpClient _httpClient;
        private IUriHelper _uriHelper;
        private IJSRuntime _jsRuntime;
        private IConfiguration _configuration;

        private ISyncLocalStorageService _localStorage;
        private ILogger<AppState> _logger;

        public AppState(HttpClient httpInstance
                       , ISyncLocalStorageService localStorage
                       , IUriHelper uriHelper
                       , IJSRuntime jsRuntime
                       , ILogger<AppState> logger
                       , IConfiguration configuration)
        {
            this._httpClient = httpInstance;
            this._localStorage = localStorage;
            this._uriHelper = uriHelper;
            this._jsRuntime = jsRuntime;
            this._logger = logger;
            this._configuration = configuration;

            this._logger?.LogInformation(this._configuration["AppSettings:SqlDbConnection"]);
        }

        public async Task SaveJwtTokenAsync(UserAuthenticationBindingModel userAuthentication)
        {
            this._localStorage
               .SetItem("AuthenticationToken", userAuthentication.Token);
            this._localStorage
              .SetItem("ExpiresOn", userAuthentication.ExpiresOn);
            this._localStorage
             .SetItem("LoggedOn", userAuthentication.LoggedOn);
        }

        public async Task LogOutUserAsync()
        {
            this._localStorage.Clear();
            await this._jsRuntime.InvokeAsync<object>("homeController.RedirectToUrl", "/Login");
        }

        public bool CheckUserAuthenticatedAsync()
        {
            string authenticationToken = _localStorage
                                            .GetItem<string>("AuthenticationToken");

            DateTime expiresOn = _localStorage
                                            .GetItem<DateTime>("ExpiresOn");

            if (authenticationToken != null && authenticationToken.Length > 0 && expiresOn >= DateTime.Now)
            {
                return true;
            }

            this._uriHelper.NavigateTo("Login");

            return false;
        }

        public async Task SetAuthorizationHeader()
        {
            if (!this._httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = this._localStorage.GetItem<string>("AuthenticationToken");
                this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}