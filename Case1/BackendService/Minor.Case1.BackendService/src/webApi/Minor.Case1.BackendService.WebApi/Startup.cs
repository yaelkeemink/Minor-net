﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using Minor.Case1.BackendService.DAL.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Minor.Case1.BackendService.DAL.DAL;
using Minor.Case1.BackendService.Entities;

namespace Minor.Case1.BackendService.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddSwaggerGen();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CASDB_YK;Trusted_Connection=True;"));
            services.AddScoped<IRepository<Cursist, int>, CursistRepository>();
            services.AddScoped<IRepository<Cursus, string>, CursusRepository>();
            services.AddScoped<IRepository<CursusInstantie, int>, CursusInstantieRepository>();
            services.AddScoped<IRepository<Inschrijving, int[]>, InschrijvingenRepository>();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "A Monument service",
                    Description = "Restauration of monuments",
                    TermsOfService = "None"
                });
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "CAS_YK/CASservice");
            });

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
