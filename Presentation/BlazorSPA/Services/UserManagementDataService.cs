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
    using BindingModelSPA.User.Role;
    using Blazored.LocalStorage;
    using BlazorSPA.Infrastructure;
    using Microsoft.AspNetCore.Components;
    using Microsoft.Extensions.Logging;
    using Microsoft.JSInterop;

    public class UserManagementDataService
    {
        private HttpClient _httpClient;
        private AppState _appState;
        private ILogger<UserManagementDataService> _logger;

        public UserManagementDataService(HttpClient httpInstance, AppState appState
                                        , ILogger<UserManagementDataService> logger)
        {
            this._httpClient = httpInstance;
            this._appState = appState;
            this._logger = logger;
        }

        public async Task<(UserBindingModel userDetails, List<UserRoleBindingModel> userRoles)> GetLoggedInUserDetailsAsync(String userName)
        {
            var response = new SingleResponse<(UserBindingModel userDetails, List<UserRoleBindingModel> userRoles)>();
            var baseUrl = this._appState.GlobalAppSettings["UserManagementApiURL"];
            await this._appState.SetAuthorizationHeader();

            try
            {
                response = await this._httpClient
                                     .GetJsonAsync<SingleResponse<(UserBindingModel userDetails, List<UserRoleBindingModel> userRoles)>>
                                     (baseUrl + "User/GetUserDetailsAndRoles/" + userName);
            }
            catch (Exception ex)
            {
                this._logger?.LogError(ex.Message + " " + ex.StackTrace);
            }

            return response.Model;
        }

        public async Task<List<UserBindingModel>> GetUsersAsync()
        {
            var response = new ListResponse<UserBindingModel>();
            var baseUrl = this._appState.GlobalAppSettings["UserManagementApiURL"];
            await this._appState.SetAuthorizationHeader();

            try
            {
                response = await this._httpClient
                                     .GetJsonAsync<ListResponse<UserBindingModel>>
                                     (baseUrl + "User/GetUsers");
            }
            catch (Exception ex)
            {
                this._logger?.LogError(ex.Message + " " + ex.StackTrace);
            }

            return response.Model.ToList();
        }

        public async Task<SingleResponse<bool>> DeleteUserAsync(UserBindingModel userBindingModel)
        {
            this._logger?.LogInformation("'{0}' Method execution started", nameof(this.DeleteUserAsync));

            var response = new SingleResponse<bool>();
            var baseUrl = this._appState.GlobalAppSettings["UserManagementApiURL"];
            await this._appState.SetAuthorizationHeader();

            try
            {
                response = await this._httpClient
                                     .SendJsonAsync<SingleResponse<bool>>
                                     (HttpMethod.Delete, baseUrl + "User/DeleteUser/" + userBindingModel.UserName, null);
            }
            catch (Exception ex)
            {
                this._logger?.LogError(ex.Message + " " + ex.StackTrace);
            }

            this._logger?.LogInformation("'{0}' Method execution completed successfully", nameof(this.DeleteUserAsync));

            return response;
        }
    }
}