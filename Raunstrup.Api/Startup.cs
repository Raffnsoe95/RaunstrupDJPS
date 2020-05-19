using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Raunstrup.Api.Extensions;
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.BusinessLogic.Services;
using Raunstrup.DataAccess.Context;

namespace Raunstrup.Api
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
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //Try'n Erro
            //services.AddDbContext<RaunstrupContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("ModelDatabaseConnection"), b => b.MigrationsAssembly("Raunstrup.Api")));

            services.AddDbContext<RaunstrupContext>(options =>
              options.UseInMemoryDatabase(databaseName: "RaunstrupDBAPIInMemory"));

            //options.UseSqlite(Configuration.GetConnectionString("MvcMovieContext")));

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IWorkingHoursService, WorkingHoursService>();
            services.AddApiVersioningAndExplorer();
            services.AddSwaggerGeneration();
            //--------------------------------------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUIAndAddApiVersionEndPointBuilder(provider);
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
