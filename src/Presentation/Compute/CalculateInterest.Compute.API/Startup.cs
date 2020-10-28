using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculateInterest.API.Extensions;
using CalculateInterest.Application.Http;
using CalculateInterest.Application.Interfaces;
using CalculateInterest.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Refit;

namespace CalculateInterest.API
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
            services.AddRefitClient<IRateService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration["UrlRateAPI"]));
            
            services.AddScoped<IComputeService, ComputeService>();
            services.AddScoped<IRunService, RunService>();
            
            services.AddSwaggerConfiguration();

            services.AddResponseCompression();
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
