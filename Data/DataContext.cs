using Microsoft.EntityFrameworkCore;
using SearchEngine.API.Models;

namespace SearchEngine.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Place> Place { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}