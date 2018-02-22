using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autostop.Services.Identity.Configuration;
using Autostop.Services.Identity.Data;
using Autostop.Services.Identity.Models;
using Autostop.Services.Identity.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Autostop.Services.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(_configuration["DefaultConnectionString"]);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddIdentityServer()
                    .AddExtensionGrantValidator<VerifyPhoneNumberTokenGrantValidator>()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryApiResources(Config.GetApis())
                    .AddInMemoryIdentityResources(Config.GetResources())
                    .AddInMemoryClients(Config.GetClients())
                    .AddTestUsers(Config.TestUsers());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Identity API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity API");
            });

            app.UseIdentityServer();
            app.UseMvc();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
