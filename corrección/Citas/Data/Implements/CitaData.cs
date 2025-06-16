using Data.Base;
using Data.Interfaces.Implements;
using Entity.Contexts;
using Entity.Models.Implements;
using Microsoft.EntityFrameworkCore;

namespace Data.Implements
{
    public class CitaData : BaseModelData<Cita>, ICitasData
    {
        public CitaData(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Cita>> GetAll()
        {
            return await _context.Set<Cita>()
                         .Include(u => u.Doctor)
                         .Include(u => u.Paciente)
                         .ToListAsync();
        }
    }
}
