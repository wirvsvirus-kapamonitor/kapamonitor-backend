using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using KapaMonitor.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace KapaMonitor.Api
{
    public class Startup
    {
        private readonly string CorsPolicy = "corspolicy";

        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    string firebaseProject = _env.IsDevelopment() ? "fir-49fb4" : "kapamonitor-4208b";
                    options.Authority = $"https://securetoken.google.com/{firebaseProject}";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = $"https://securetoken.google.com/{firebaseProject}",
                        ValidateAudience = true,
                        ValidAudience = firebaseProject,
                        ValidateLifetime = true
                    };

                    if (_env.IsDevelopment())
                    {
                        options.RequireHttpsMetadata = false;
                    }
                });

            string connection = _env.IsDevelopment() ? Configuration.GetConnectionString("DefaultConnection") 
                                                     : (Environment.GetEnvironmentVariable("PostgresKapaMonitorConnection") ?? "");
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connection));

            services.AddCors(options =>
            {
                if (_env.IsDevelopment())
                {
                    options.AddPolicy(CorsPolicy,
                    builder =>
                    {
                        builder.WithOrigins()
                            .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                    });
                } 
                else
                {
                    options.AddPolicy(CorsPolicy,
                    builder =>
                    {
                        builder.WithOrigins("http://ec2-3-121-86-158.eu-central-1.compute.amazonaws.com")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                    });
                }
            });


            services.AddControllers();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo() { Title = "KapaMonitor API", Version = "v1" });

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \n\n " +
                        "Enter 'Bearer' [space] and then your token in the text input below.\n\n" +
                        "Example: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme,
                            }
                        },
                        new List<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, ApplicationDbContext context)
        {
            if (_env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHttpsRedirection();

            // migrate any database changes on startup
            context.Database.Migrate();

            // --- Setup Swagger ---
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "WebApi Explorer";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "KapaMonitor API V1");
            });

            app.UseRouting();

            app.UseCors(CorsPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
