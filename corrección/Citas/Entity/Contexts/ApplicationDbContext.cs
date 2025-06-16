using Entity.Models.Base;
using Entity.Models.Implements;
using Microsoft.EntityFrameworkCore;

namespace Entity.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<User> User { get; set; }
    }
}
