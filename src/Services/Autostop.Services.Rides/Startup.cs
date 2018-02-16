using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Autostop.Services.Rides
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

	        services.AddSwaggerGen(c =>
	        {
		        c.SwaggerDoc("v1", new Info { Title = "Rides API", Version = "v1" });
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
		        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rides API");
	        });

	        app.UseMvc();
	        app.UseMvcWithDefaultRoute();
		}
    }
}
