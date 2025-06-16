using Entity.Models.Base;
using System.Collections.Generic;

namespace Entity.Models.Implements
{
    public class Doctor : BaseGeneric
    {
        public string Especializacion { get; set; }

        // Relaciones
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}