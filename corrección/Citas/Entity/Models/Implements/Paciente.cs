using Entity.Models.Base;
using System.Collections.Generic;

namespace Entity.Models.Implements
{
    public class Paciente : BaseGeneric
    {
        public string Telefono { get; set; }
        public string Email { get; set; }

        // Relaciones
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}