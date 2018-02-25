using JetBrains.Annotations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Autostop.Services.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
		
		[UsedImplicitly]
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
	            .ConfigureAppConfiguration((builderContext, config) =>
	            {
		            config.AddEnvironmentVariables();
	            })
				.UseStartup<Startup>()
                .Build();
    }
}
