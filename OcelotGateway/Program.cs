using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OcelotGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHostBuilder builder = new WebHostBuilder();  
            builder.ConfigureServices(s =>  
            {  
                s.AddSingleton(builder);  
            });  
            builder.UseKestrel()  
                .UseContentRoot(Directory.GetCurrentDirectory())  
                .UseStartup<Startup>()  
                .UseUrls("https://localhost:5001");  
  
            var host = builder.Build();  
            host.Run();  
        }
    }
}