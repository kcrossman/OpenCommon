using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenCommon.DependencyInjection.Extensions;

namespace OpenCommon.ServiceHost
{
    public class Startup
    {
        private IServiceCollection Services;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Services = services;

            AutoRegisterDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/reload", async context =>
                {
                    await HotReloadServices(context);
                });
            });
        }

        private async Task HotReloadServices(HttpContext context)
        {
            await OutputText("Reloading services...");

            var serviceHostDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
            var servicesDirectory = Path.Combine(serviceHostDirectory, @"Services");
            if (!Directory.Exists(servicesDirectory))
            {
                Directory.CreateDirectory(servicesDirectory);
            }
            
            var servicesPaths = Directory.GetFiles(servicesDirectory, "*.dll", SearchOption.TopDirectoryOnly);
            if (servicesPaths.Length == 0)
            {
                await OutputText("No services found.");
            }
            else
            {
                foreach (var servicePath in servicesPaths)
                {
                    try
                    {
                        var serviceAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(servicePath);

                        await OutputText($"Loaded service '{servicePath}'.");
                    }
                    catch
                    {
                        await OutputText($"Failed to load service '{servicePath}'.");
                    }
                }

                await AutoRegisterDependencies();
            }
            
            await OutputText("Finished reloading services.");
        }

        private async Task AutoRegisterDependencies(HttpContext context = null)
        {
            await OutputText("Registering dependencies...");

            var dependencies = Services.AutoRegisterDependencies();
            if (dependencies.Count == 0)
            {
                await OutputText("No dependencies found.");
            }
            else
            {
                foreach (var dependency in dependencies)
                {
                    await OutputText(dependency.ImplementationType == dependency.ServiceType
                        ? $" - {dependency.ServiceType.Name} as {dependency.AttributeType.Name}"
                        : $" - {dependency.ImplementationType.Name} ({dependency.ServiceType.Name}) as {dependency.AttributeType.Name}");
                }
            }
            
        }

        private async Task OutputText(string text, HttpContext context = null)
        {
            if (context != null)
            {
                await context.Response.WriteAsync($"{text}\n");
            }
            Console.WriteLine(text);
        }
    }
}
