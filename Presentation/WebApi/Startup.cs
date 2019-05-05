namespace WebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using AutoMapper;
    using CrossCutting.ConfigCache;
    using CrossCutting.Logging;
    using ElmahCore.Mvc;
    using ElmahCore.Sql;
    using IOC;
    using Microsoft.AspNetCore.Antiforgery;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json.Serialization;
    using Swashbuckle.AspNetCore.Swagger;
    using WebApi.Infrastructure.Filters;
    using WebApi.Infrastructure.Helpers;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public static Dictionary<string, object> ApplicationConfigurations { get; private set; }

        public IConfiguration Configuration { get; }

        private readonly NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public Autofac.IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

                //  options.SuppressInferBindingSourcesForParameters = true;
            });

            ApplicationConfigurations = this.Configuration.GetSection("AppSettings")
                                    .GetChildren()
                                    .Select(item => new KeyValuePair<string, object>(item.Key, item.Value))
                                    .ToDictionary(x => x.Key, x => x.Value);
            GlobalAppConfigurations.Instance.AddKeysAndValues(ApplicationConfigurations);
            ApplicationConfigurations = this.Configuration.GetSection("JwtAuthentication")
                                    .GetChildren()
                                    .Select(item => new KeyValuePair<string, object>(item.Key, item.Value))
                                    .ToDictionary(x => x.Key, x => x.Value);

            GlobalAppConfigurations.Instance.AddKeysAndValues(ApplicationConfigurations);

            services.AddAutoMapper();

            services.AddCors();

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
                            options.Filters.Add(typeof(ValidateModelStateAttribute));
                            options.Filters.Add<LoggingActionFilter>();
                            //  options.Filters.Add(typeof(JsonExceptionFilter));
                        })
                 .AddJsonOptions(options =>
                 {
                     options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                     options.SerializerSettings.DateFormatString = "MM/dd/yyyy HH:mm:ss";
                 })

                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "ASP.NET Core Web API"
                });
            });

            services.AddApiVersioning();

            services.Configure<JwtAuthentication>(this.Configuration.GetSection("JwtAuthentication"));

            // I use PostConfigureOptions to be able to use dependency injection for the configuration
            // For simple needs, you can set the configuration directly in AddJwtBearer()
            services.AddSingleton<IPostConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
            services.AddSingleton<LoggingActionFilter>();
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
            // Add a sample response header
            app.Use(async (context, nextMiddleware) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("RequestId", context.TraceIdentifier);
                    return Task.FromResult(0);
                });
                await nextMiddleware();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpStatusCodeExceptionMiddleware();
            app.UseElmah();

            app.UseHttpsRedirection();

            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //https://localhost:44388/swagger/index.html
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });
            app.UseApiVersioning();
        }

        private class ConfigureJwtBearerOptions : IPostConfigureOptions<JwtBearerOptions>
        {
            private readonly IOptions<JwtAuthentication> _jwtAuthentication;

            public ConfigureJwtBearerOptions(IOptions<JwtAuthentication> jwtAuthentication)
            {
                this._jwtAuthentication = jwtAuthentication ?? throw new System.ArgumentNullException(nameof(jwtAuthentication));
            }

            public void PostConfigure(string name, JwtBearerOptions options)
            {
                var jwtAuthentication = this._jwtAuthentication.Value;

                options.ClaimsIssuer = jwtAuthentication.ValidIssuer;
                options.IncludeErrorDetails = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateActor = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtAuthentication.ValidIssuer,
                    ValidAudience = jwtAuthentication.ValidAudience,
                    IssuerSigningKey = jwtAuthentication.SymmetricSecurityKey,
                    NameClaimType = ClaimTypes.NameIdentifier,
                    ClockSkew = TimeSpan.Zero
                };
            }
        }

        public class JwtAuthentication
        {
            public string SecurityKey { get; set; }

            public string ValidIssuer { get; set; }

            public string ValidAudience { get; set; }

            public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Convert.FromBase64String(this.SecurityKey));

            public SigningCredentials SigningCredentials => new SigningCredentials(this.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        }
    }
}