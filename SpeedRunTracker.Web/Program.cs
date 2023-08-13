using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data;
using SpeedRunTracker.Data.Entities;
using SpeedRunTracker.Services.Interfaces;
using SpeedRunTracker.Web.Infrastructure.Extensions;

namespace SpeedRunTracker.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<SpeedRunTrackerDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            

            builder.Services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<SpeedRunTrackerDbContext>();

            builder.Services.AddApplicationServices(typeof(ISpeedRunService));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
            }
            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute(
                    name: "SpeedRunDetials",
                    pattern: "/{controller}/{action}/{speedRunId}",
                    defaults: new { Controller = "SpeedRuns", Action = "Details" });

                cfg.MapControllerRoute(
                    name: "LeaderboardDetails",
                    pattern: "/{controller}/{action}/{gameId}/{categoryId}",
                    defaults: new { Controller = "Games", Action = "Leaderboard" }
                    );

                cfg.MapDefaultControllerRoute();

                cfg.MapRazorPages();
            });

            app.Run();
        }
    }
}