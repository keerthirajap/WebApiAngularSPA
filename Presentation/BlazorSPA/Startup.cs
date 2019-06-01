namespace BlazorSPA
{
    using Blazor.Extensions.Logging;
    using Blazored.LocalStorage;
    using BlazorSPA.Infrastructure;
    using BlazorSPA.Service;
    using Microsoft.AspNetCore.Components.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();

            services.AddSingleton<AppState>();

            services.AddSingleton<AuthenticationDataService>();

            services.AddLogging(builder => builder
                                .AddBrowserConsole()
                                .SetMinimumLevel(LogLevel.Trace)
                                );
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}