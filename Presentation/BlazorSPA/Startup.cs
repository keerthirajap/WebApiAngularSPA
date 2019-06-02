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
    using System.Reflection;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Linq;
    using System.Web;
    using Microsoft.Extensions.FileProviders;
    using System.IO;
    using System.Text;
    using Microsoft.Extensions.Primitives;

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

            services.AddEnvironmentConfiguration<Startup>(() =>
              new EnvironmentChooser("Development")
                  .Add("localhost", "Development")
                  .Add("tossproject.com", "Production", false));

            services.AddSingleton<AppState>();
            services.AddSingleton<AuthenticationDataService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            //force config initialisation with current uri
            IConfiguration config = app.Services.GetService<IConfiguration>();

            app.AddComponent<App>("app");
        }
    }
}