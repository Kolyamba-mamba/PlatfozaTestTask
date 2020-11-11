using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlatfozaTestTask.API.Helpers;
using PlatfozaTestTask.API.Middlewares;
using PlatfozaTestTask.API.Providers;
using PlatfozaTestTask.API.Services;

namespace PlatfozaTestTask.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton();
            services.AddScoped();
            services.AddHelpers();
            services.AddRepositories();
            services.AddResolvers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<SessionMiddleware>();
            
            app.UseRouting();
            var sp = app.ApplicationServices.GetService<SessionProvider>();
            sp.OpenSession();
            app.ApplicationServices.GetService<DbInitializer>().Initialize();
            sp.CloseSession();
            
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}