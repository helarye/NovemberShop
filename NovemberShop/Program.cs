using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using NovemberShop.Data;
using System.Globalization;

namespace NovemberShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //מוסיפים שירות גישה לבסיס נתונים
            //ויוצרים ספרייה המכילה קישור לבסיס הנתונים
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();
            //הכנסת תצוגה (תרבות) עברית שתגרום למחירים להופיע בשקלים
            // Set culture to Hebrew (Israel)
            var supportedCultures = new[] { new CultureInfo("he-IL") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("he-IL"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            //סוף תרבות

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
