using Demo_Project_BLL.Interfaces;
using Demo_Project_BLL.Repositories;
using Demo_Project_DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Demo_Project_PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MVCAppDemoProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddScoped<IDepartmentReposatory, DepartmentRepository>(); // This is Dependancy Injecation
            builder.Services.AddScoped<IEmployeeReposatory, EmployeeRepository>(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
