using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace SampleExam
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Planet> Planets { get; set; }
        public DbSet<SpaceShip> SpaceShip { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}