using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;

using Zapper.Payment.Api.Entities;
using Zapper.Payment.Api.Repositories;
using Zapper.Payment.Api.Repositories.Interfaces;
using Zapper.Payment.Api.Services;
using Zapper.Payment.Api.Services.Interfaces;

namespace Zapper.Payment.Api {

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.     
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<TransactionContext>(opt =>
               opt.UseInMemoryDatabase("Transactions"), ServiceLifetime.Singleton);

            services.AddControllers();

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
                    Title = "Payments API",
                    Version = "v1",
                    Description = "Sample service for Payments API",
                });
            });

            services.AddScoped<IPaymentsService, PaymentsService>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.    
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "documentation";
            });
        }
    }
}