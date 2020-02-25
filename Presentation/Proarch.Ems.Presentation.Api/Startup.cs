using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proarch.Ems.Infrastructure.Data.Common;
using Proarch.Ems.Presentation.Api.Extensions;
using AutoMapper;
using Proarch.Ems.Infrastructure.Data.Automapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace Proarch.Ems.Presentation.Api
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

            services.AddMvc(setupAction => {
                setupAction.EnableEndpointRouting = false;
            }).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
          .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            services.AddDbContext<EmsDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("EMSDbContext"));
            });



            services.AddAutoMapper(typeof(AutomapperProfile));

            services.AddControllersWithViews();

            services.AddCors();

            services.RegisterDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.EnsureSeed();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseCors(builder =>
               builder
                   .AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
