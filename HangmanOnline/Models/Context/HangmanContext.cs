using Microsoft.EntityFrameworkCore;

namespace HangmanOnline.Models.Context
{
    public class HangmanContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder() 
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
