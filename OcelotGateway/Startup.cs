using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotGateway
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder();  
            builder.SetBasePath(env.ContentRootPath)      
                //add configuration.json  
                .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)  
                .AddEnvironmentVariables();  
  
            Configuration = builder.Build();  
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Action<ConfigurationBuilderCachePart> settings = (x) =>  
            // {  
            //     x.WithMicrosoftLogging(log =>  
            //     {  
            //         log.AddConsole(LogLevel.Debug);  
            //
            //     }).WithDictionaryHandle();  
            // };  
            // services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();
            services.AddOcelot(Configuration); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseOcelot().Wait();
        }
    }
}