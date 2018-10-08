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

namespace back
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
            services.AddDbContext<ProductContext>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("TestDatabase")));

            services.AddMvc();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var origins = Configuration.GetValue<string>("Cors:AllowedOrigins")?.Split(',') ?? new string[0];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment() && !origins.Any())
            {
                app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().AllowAnyOrigin());
            }
            else
            {
                app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(origins));
            }

            app.UseMvc();
        }
    }
}
