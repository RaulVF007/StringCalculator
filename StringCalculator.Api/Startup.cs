using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using StringCalculator.Application.Actions;
using StringCalculator.Infrastructure;
using ILogger = StringCalculator.Application.Model.ILogger;
using Microsoft.OpenApi.Models;
using StringCalculator.Api.HealthChecks;

namespace StringCalculator.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigureHealthChecks(services);
            ConfigureScopes(services);
            AddSwagger(services);
        }

        private static void ConfigureHealthChecks(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddHealthChecks().AddCheck<LoggerHealthCheck>("logger_health_check", failureStatus: HealthStatus.Degraded,
                tags: new[] {"logger"});
            services.AddHealthChecks().AddCheck<ErrorHealthCheck>("error_health_check", failureStatus: HealthStatus.Degraded,
                tags: new[] {"error"});
        }

        private static void ConfigureScopes(IServiceCollection services)
        {
            services.AddScoped<GetStringCalculator>();
            services.AddScoped<ILogger, StringCalculatorLogger>();
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Foo {groupName}",
                    Version = groupName,
                    Description = "Foo API",
                    Contact = new OpenApiContact
                    {
                        Name = "Foo Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
