namespace BlazorSPA.Infrastructure
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
    using Microsoft.AspNetCore.Components;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.JSInterop;

    public class AppState
    {
        private HttpClient _httpClient;
        private IUriHelper _uriHelper;
        private IJSRuntime _jsRuntime;

        private ISyncLocalStorageService _localStorage;
        private ILogger<AppState> _logger;

        public Dictionary<string, string> GlobalAppSettings = new Dictionary<string, string>();

        public AppState(HttpClient httpInstance
                       , ISyncLocalStorageService localStorage
                       , IUriHelper uriHelper
                       , IJSRuntime jsRuntime
                       , ILogger<AppState> logger
                       )
        {
            this._httpClient = httpInstance;
            this._localStorage = localStorage;
            this._uriHelper = uriHelper;
            this._jsRuntime = jsRuntime;
            this._logger = logger;
        }

        public async Task SaveJwtTokenAsync(UserAuthenticationBindingModel userAuthentication)
        {
            this._localStorage
               .SetItem("AuthenticationToken", userAuthentication.Token);
            this._localStorage
              .SetItem("ExpiresOn", userAuthentication.ExpiresOn);
            this._localStorage
             .SetItem("LoggedOn", userAuthentication.LoggedOn);
            this._localStorage
            .SetItem("UserName", userAuthentication.UserName);
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

        public async Task<bool> SetAppSettings()
        {
            List<AppSetting> appsettings = new List<AppSetting>();

            appsettings = await this._httpClient.GetJsonAsync<List<AppSetting>>("appsettings.json");

            foreach (var item in appsettings)
            {
                this.GlobalAppSettings.Add(item.Key, item.Value);
            }

            return true;
        }
    }
}