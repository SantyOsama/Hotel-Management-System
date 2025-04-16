using HotelMangementSystem.Hubs;
using HotelMangementSystem.Models;
using HotelMangementSystem.Models.Database;
using HotelMangementSystem.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelMangementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DatabaseContext>(
              options =>
              {
                  options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"));
                  options.EnableSensitiveDataLogging(true);
              }


              );



            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DatabaseContext>();

            builder.Services.AddSignalR();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(url => true)
                    .AllowCredentials();

                });
            });

            builder.Services.AddScoped<IBillRepo, BillRepo>();
            builder.Services.AddScoped<ICityRepo, CityRepo>();
            builder.Services.AddScoped<IHotelRepo, HotelRepo>();
            builder.Services.AddScoped<IReservationRepo, ReservationRepo>();
            builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
            builder.Services.AddScoped<IRoomRepo, RoomRepo>();
            builder.Services.AddScoped<IRoomReservationRepo, RoomReservationRepo>();
            builder.Services.AddScoped<IUserReviewRepo, UserReviewRepo>();
            builder.Services.AddScoped<IPendingHotelRepo, PendingHotelRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IFileRepo, FileRepo>();









            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.MapHub<HAddHotelHub>("/HAddHotel");
            app.MapHub<HReviewHub>("/HReview");
            app.UseCors();

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
