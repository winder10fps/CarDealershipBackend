using CarDealershipBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipBackend.Data
{
    /// <summary>
    /// Контекст базы данных. Мост между классами и таблицами бд
    /// </summary>
    /// <param name="options">Конфигурация подключения к базе</param>
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
