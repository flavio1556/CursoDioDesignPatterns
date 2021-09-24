using CursoDioDesignPatterns.Domain.Veiculo;
using CursoDioDesignPatterns.Infra.Facade;
using CursoDioDesignPatterns.Infra.Repository;
using CursoDioDesignPatterns.Infra.Repository.EF;
using CursoDioDesignPatterns.Infra.Singleton;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CursoDioDesignPatterns
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Design Patterns",
                    Description= "Api curso", 
                    Version ="v1"
                });
                var apiPath = Path.Combine(AppContext.BaseDirectory, "CursoDioDesignPatterns.xml");
                c.IncludeXmlComments(apiPath);
            });
            services.AddDbContext<Context>(opt =>
                                           opt.UseInMemoryDatabase("frota"));
            services.AddSingleton<SingletonContainer>();
            services.AddTransient<IVeiculoRepository, FrotaRepository>();
            services.AddTransient<IVeiculoDetran, VeiculoDetranFacade>();
            services.Configure<DetranOptions>(Configuration.GetSection("DetranOptions"));
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api CursoDioDesignPatterns");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
