using DiyorMarket.Domain.Interfaces.Repositories;
using DiyorMarket.Extensions;
using DiyorMarket.Infrastructure.Persistence;
using DiyorMarket.Infrastructure.Persistence.Repositories;

namespace DiyorMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DiyorMarketDbContext>();

            builder.Services.AddScoped<ICommonRepository, CommonRepository>();

            builder.Services.SeedDatabase();

            var app = builder.Build();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
                "Mgo+DSMBMAY9C3t2VlhhQlVAfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn9Sd0djXn1WdXdWRmNa");

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
                pattern: "{controller=Dashboard}/{action=Index}/{id?}");

            app.Run();
        }
    }
}