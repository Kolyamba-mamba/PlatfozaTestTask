using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PlatfozaTestTask.API.Helpers;
using PlatfozaTestTask.API.Middlewares;
using PlatfozaTestTask.API.Options;
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
            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = AuthOptions.ISSUER,
 
                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = AuthOptions.AUDIENCE,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,
 
                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });
            
            
            services.AddCors(options =>
            {
                // Определение политики CORS как "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost", "http://my-platfoza-angular-client.s3-website.us-east-2.amazonaws.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .SetIsOriginAllowed(x => true);
                });
            });
            
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
            
            app.UseCors("default");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}