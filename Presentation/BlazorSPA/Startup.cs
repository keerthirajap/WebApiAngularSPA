namespace BlazorSPA
{
    using Blazor.Extensions.Logging;
    using Blazored.LocalStorage;
    using BlazorSPA.Infrastructure;
    using BlazorSPA.Services;
    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder => builder
                    .AddBrowserConsole()
                    .SetMinimumLevel(LogLevel.Trace)
                    );

            services.AddBlazoredLocalStorage();

            services.AddSingleton<AppState>();
            services.AddSingleton<AuthenticationDataService>();
            services.AddSingleton<UserManagementDataService>();
        }

        public void Configure(IComponentsApplicationBuilder app, AppState appState)
        {
            appState.SetAppSettings();
            app.AddComponent<App>("app");
        }
    }
}