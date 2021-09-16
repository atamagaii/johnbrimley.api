using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

namespace johnbrimley.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            new HostBuilder()
                .ConfigureWebHost(webHostBuilder =>
                    webHostBuilder
                        .Configure((webHostBuilderContext, applicationBuilder) =>
                            applicationBuilder
                                .UseRouting()
                                .UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute())
                        )
                        .ConfigureServices(serviceCollection =>
                            serviceCollection
                                .AddRouting()
                                .AddControllers()
                        )
                        .UseKestrel()
                );
    }
}
