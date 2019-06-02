namespace BlazorSPA.Pages.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BlazorSPA.Infrastructure;
    using Microsoft.AspNetCore.Components;
    using Microsoft.Extensions.Logging;
    using Microsoft.JSInterop;

    public class DashboardBase : ComponentBase
    {
        [Inject] private ILogger<DashboardBase> _logger { get; set; }
        [Inject] private IJSRuntime _jsRuntime { get; set; }
        [Inject] private AppState _appState { get; set; }

        protected async Task DashboardOnLoad()
        {
            await this._jsRuntime.InvokeAsync<object>("homeController.HideLoadingIndicator");
            bool isUserAuthenticated = this._appState.CheckUserAuthenticatedAsync();

            if (!isUserAuthenticated)
            {
                await this._jsRuntime.InvokeAsync<object>("homeController.RedirectToUrl", "/Login");
            }
        }
    }
}