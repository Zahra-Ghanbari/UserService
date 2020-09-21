using AutoMapper;
using DataContext;
using Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Okta.AspNetCore;
using Repository;
using System;
using UnitOfWork;

namespace UserAPI
{
    public class Startup
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddMvcOptions(o =>
            {
                o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                o.EnableEndpointRouting = false;

                //var policy = new AuthorizationPolicyBuilder()
                //.RequireAuthenticatedUser()
                //.Build();
                //o.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var connectionString = _configuration["connectionStrings:UserDBConnectionString"];
            services.AddDbContext<UserContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IUserService, Service.UserService>();
            services.AddScoped<IUnitOfWork<Entity.User>, UnitOfWork<Entity.User>>();
            services.AddScoped<IRepository<Entity.User>, Repository<Entity.User>>();
            services.AddScoped<DbContext, UserContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
            })
   .AddOktaWebApi(new OktaWebApiOptions()
   {
       OktaDomain = _configuration["Okta:OktaDomain"],
       //AuthorizationServerId = Configuration["Okta:AuthorizationServerId"]
   });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            //app.UseRouting();
            app.UseStatusCodePages();
            app.UseAuthentication();
            app.UseMvc();


        }
    }
}
