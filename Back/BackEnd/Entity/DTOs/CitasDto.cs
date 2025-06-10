using Entity.Domain.Models.Implements;
using Entity.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class CitasDto : BaseDto
    {
        public DateTime fechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }

        //Relaciones 
        public int doctorId { get; set; }
        public int pacienteId { get; set; }
    }
}
