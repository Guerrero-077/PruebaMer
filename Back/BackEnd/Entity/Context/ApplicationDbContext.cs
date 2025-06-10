using Entity.Domain.Models.Implements;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        DbSet<Paciente> paciente { get; set; }
        DbSet<Doctor> doctor { get; set; }
        DbSet<Cita> cita { get; set; }          
    }
}
