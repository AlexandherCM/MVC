using Microsoft.EntityFrameworkCore;

namespace EscuelaBD.Models
{
    public class Modelo : DbContext
    {
        public Modelo(DbContextOptions<Modelo> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<clsAlumno> Alumnos { get; set; }
        public virtual DbSet<clsSalon> Salones { get; set; }
    }
}
