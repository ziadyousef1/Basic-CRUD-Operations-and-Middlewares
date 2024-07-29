using Basic_CRUD_Operations_and_Middlewares.Middlewares;
using Basic_CRUD_Operations_and_Middlewares.Models;
using Basic_CRUD_Operations_and_Middlewares.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Basic_CRUD_Operations_and_Middlewares
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("conStr"));
            });
            builder.Services.AddScoped<IProductRepository, ProductRepository>();



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

            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<ExceptionHandlingMiddleware>();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Products}/{action=index}/{id?}");

            app.Run();
        }
    }
}