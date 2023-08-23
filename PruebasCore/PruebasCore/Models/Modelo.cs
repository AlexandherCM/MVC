using Microsoft.EntityFrameworkCore;

namespace PruebasCore.Models
{
    public class Modelo : DbContext
    {
        public Modelo(DbContextOptions<Modelo> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
    }
}
