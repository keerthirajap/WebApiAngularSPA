namespace WebAppMVC
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using AutoMapper;
    using CrossCutting.ConfigCache;
    using CrossCutting.Logging;
    using ElmahCore.Mvc;
    using ElmahCore.Sql;
    using IOC;
    using JSNLog;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using StackExchange.Profiling.Storage;
    using WebAppMVC.Infrastructure.CustomFilters;
    using WebAppMVC.Infrastructure.SignalRHubs;

    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed.")]
    public class Startup
    {
        private readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public static Dictionary<string, object> ApplicationConfigurations { get; private set; }

        public Autofac.IContainer ApplicationContainer { get; private set; }

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

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Login";
                        options.AccessDeniedPath = "/AccessDenied";
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperUser-Admin-Manager-User", policy =>
                   policy.RequireRole("SuperUser", "Admin", "Manager", "User"));

                options.AddPolicy("SuperUser-Admin-Manager", policy =>
                  policy.RequireRole("SuperUser", "Admin", "Manager"));
            });

            ApplicationConfigurations = this.Configuration.GetSection("AppSettings")
                        .GetChildren()
                        .Select(item => new KeyValuePair<string, object>(item.Key, item.Value))
                        .ToDictionary(x => x.Key, x => x.Value);
            GlobalAppConfigurations.Instance.AddKeysAndValues(ApplicationConfigurations);

            services.AddAutoMapper();

            services.AddMiniProfiler();

            services.AddElmah(options =>
            {
                //options.CheckPermissionAction = context => context.User.Identity.IsAuthenticated;
                options.Path = @"elmah";
            });
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.ConnectionString = GlobalAppConfigurations.Instance.GetValue("SqlDbConnection").ToString(); // DB structure see here: https://bitbucket.org/project-elmah/main/downloads/ELMAH-1.2-db-SQLServer.sql
            });
            services.AddMvc(options =>
            {
                options.Filters.Add<LoggingActionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSignalR();

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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

            app.UseAuthentication();
            app.Use(
                 next =>
                 {
                     return async context =>
                     {
                         var stopWatch = new Stopwatch();
                         stopWatch.Start();
                         context.Response.OnStarting(
                             () =>
                             {
                                 context.Response.Headers.Add("RequestId", context.TraceIdentifier);
                                 stopWatch.Stop();

                                 context.Response.Headers.Add("X-ResponseTime-Ms", stopWatch.ElapsedMilliseconds.ToString());
                                 return Task.CompletedTask;
                             });

                         await next(context);
                     };
                 });

            app.UseElmah();
            app.UseMiniProfiler();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            var jsnlogConfiguration = new JsnlogConfiguration
            {
                serverSideMessageFormat = "Url : %url %newline* RequestId : %requestId  %entryId %newline*" +
                                    "Message : %message %newline* %jsonmessage %newline*" +
                                    "Sent: %date, Browser: %userAgent %newline*",
                serverSideLogger = "WebApp.Jslogger"
            };

            app.UseJSNLog(new LoggingAdapter(loggerFactory), jsnlogConfiguration);

            app.UseSignalR(routes =>
            {
                routes.MapHub<AnonymousHub>("/anonymousHub");
            });

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