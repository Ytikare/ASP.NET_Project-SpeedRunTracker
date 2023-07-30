using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data;
using SpeedRunTracker.Services.Interfaces;
using SpeedRunTracker.Web.Infrastructure.Extensions;

namespace SpeedRunTracker.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SpeedRunTrackerDbContext>(opt => opt.UseSqlServer(connectionString));

            builder.Services.AddApplicationServices(typeof(ISpeedRunService));

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(setup => 
            {
                setup.AddPolicy("SpeedRunTrackerPolicy", policyBuilder => 
                {
                    policyBuilder.WithOrigins("https://localhost:7231")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("SpeedRunTrackerPolicy");

            app.Run();
        }
    }
}