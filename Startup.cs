using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using back.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace back
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContext<ProductContext>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("TestDatabase")));

            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zeux API", Version = "v1" });
                //c.CustomSchemaIds(x => x.FullName);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            //services.AddDistributedRedisCache(option =>
            //{
            //    option.Configuration = "127.0.0.1";
            //    option.InstanceName = "master";
            //});

            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "http://localhost:61885",
                        ValidAudience = "http://localhost:61885",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                    };
                });
            //services.AddMemoryCache();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var origins = Configuration.GetValue<string>("Cors:AllowedOrigins")?.Split(',') ?? new string[0];

            if (env.IsDevelopment())    
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment() && !origins.Any())
            {
                app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            }
            else
            {
                app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(origins));
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }


    }
}
