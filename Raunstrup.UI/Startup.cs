using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Raunstrup.UI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raunstrup.UI.Services;
using Raunstrup.Contract.Services;
using Raunstrup.BusinessLogic.Services;
using Raunstrup.UI.UserManagement;
using Raunstrup.Contakt.Service;
using Raunstrup.Contakt.Service.Interface;

namespace Raunstrup.UI
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
            services.AddHttpClient<IItemService, ItemServiceProxy>(client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
            services.AddHttpClient<IProjectService, ProjectServiceProxy>(client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
            services.AddHttpClient<IEmployeeservice, EmployeeServiceProxy>(client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
            services.AddHttpClient<ICustomerService, CustomerServiceProxy>(client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
            services.AddHttpClient<IWorkingHoursService, WorkingHoursServiceProxy>(client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
            
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName: "RaunstrupDBVieModelInMemory"));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            
            services.AddDbContext<UserManagementContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("UserDatabaseConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<UserManagementContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
            });


            services.AddRazorPages();

            //SqlDb
            services.AddDbContext<ViewModelContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //SqlDb

            ////InMemDB
            //services.AddDbContext<ViewModelContext>(options => options.UseInMemoryDatabase(databaseName: "RaunstrupInMeme"));
            ////InMemDB

            services.AddScoped<IContactService, ContactService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
