using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using KapaMonitor.Database;

namespace KapaMonitor.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost",
                                        "http://localhost:3000",
                                        "localhost",
                                        "localhost:3000",
                                        "35.156.191.101",
                                        "35.156.191.101:80",
                                        "http://35.156.191.101",
                                        "http://35.156.191.101:80",
                                        "http://ec2-35-156-191-101.eu-central-1.compute.amazonaws.com",
                                        "http://ec2-35-156-191-101.eu-central-1.compute.amazonaws.com:80",
                                        "ec2-35-156-191-101.eu-central-1.compute.amazonaws.com",
                                        "ec2-35-156-191-101.eu-central-1.compute.amazonaws.com:80");

                    builder.AllowAnyMethod();
                });
            });


            services.AddControllers();

            services.AddSwaggerGen(x => { x.SwaggerDoc("v1", new OpenApiInfo() { Title = "KapaMonitor API", Version = "v1" } ); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            // --- Setup Swagger ---
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
