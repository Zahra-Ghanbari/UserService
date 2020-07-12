using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using DataContext;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UnitOfWork;

namespace User.API
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
            services.AddMvc().AddMvcOptions(o=>o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter())
                );
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var connectionString =_configuration["connectionStrings:UserDBConnectionString"];           
            services.AddDbContext<UserContext>(o=>o.UseSqlServer(connectionString));

            services.AddScoped<IUserService, Service.UserService>();
            services.AddScoped<IUnitOfWork<Model.User>, UnitOfWork<Model.User>>();
            services.AddScoped<IRepository<Model.User>,Repository.Repository<Model.User>>();
            
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
            app.UseMvc();

            
        }
    }
}
