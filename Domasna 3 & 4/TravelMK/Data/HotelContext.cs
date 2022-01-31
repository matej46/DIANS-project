using Microsoft.EntityFrameworkCore;
using TravelMK.Models;

namespace TravelMK.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }
        public HotelContext() { }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
