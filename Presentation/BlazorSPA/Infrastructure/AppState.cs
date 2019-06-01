namespace BlazorSPA.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Blazored.LocalStorage;

    public class AppState
    {
        private ILocalStorageService _localStorage;
        private HttpClient _httpClient;

        public AppState(HttpClient httpInstance, ILocalStorageService localStorage)
        {
            this._httpClient = httpInstance;
            this._localStorage = localStorage;
        }

        public bool IsLoggedIn { get; private set; }

        public async Task SaveJwtTokenAsync(string jsonWebToken)
        {
            this.IsLoggedIn = true;
            await this._localStorage.SetItemAsync("AuthenticationToken", jsonWebToken);
        }

        public async Task SetAuthorizationHeader()
        {
            if (!this._httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = await this._localStorage.GetItemAsync<string>("AuthenticationToken");
                this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}