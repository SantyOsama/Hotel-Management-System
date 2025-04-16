using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelMangementSystem.Models.Database

{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<PendingHotel> PendingHotels { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}
