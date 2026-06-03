using CarDealershipBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipBackend.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
