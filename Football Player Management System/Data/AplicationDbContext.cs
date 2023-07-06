using Football_Player_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Football_Player_Management_System.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) 
            : base(options) 
        {
        }

        public DbSet<Player> FootballDB { get; set; }
    }
}
