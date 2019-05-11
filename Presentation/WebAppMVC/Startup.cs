namespace WebAppMVC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using AutoMapper;
    using CrossCutting.ConfigCache;
    using CrossCutting.Logging;
    using IOC;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using WebAppMVC.Infrastructure.CustomFilters;

    public class Startup
    {
        public static Dictionary<string, object> ApplicationConfigurations { get; private set; }

        public Autofac.IContainer ApplicationContainer { get; private set; }

        private readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            ApplicationConfigurations = this.Configuration.GetSection("AppSettings")
                        .GetChildren()
                        .Select(item => new KeyValuePair<string, object>(item.Key, item.Value))
                        .ToDictionary(x => x.Key, x => x.Value);
            GlobalAppConfigurations.Instance.AddKeysAndValues(ApplicationConfigurations);

            services.AddAutoMapper();

            services.AddMvc(options =>
            {
                //options.Filters.Add(typeof(ValidateModelStateAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IConfiguration>(this.Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.Register(c => new RepositoryInterfaceLogInterceptor(this.logger)).InstancePerLifetimeScope();
            builder.Register(c => new ServiceClassLogInterceptor(this.logger)).InstancePerLifetimeScope();

            builder.RegisterModule(new DatabaseIOC(GlobalAppConfigurations.Instance.GetValue("SqlDbConnection").ToString(), "InstancePerLifetimeScope"));
            builder.RegisterModule(new ServiceIOC("InstancePerLifetimeScope"));
            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                 );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}