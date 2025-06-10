using Entity.Domain.Models.Base;

namespace Entity.Domain.Models.Implements
{
    public class Cita : BaseModel
    {
        public DateTime fechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }

        //Relaciones 
        public Doctor doctor { get; set; }
        public Paciente paciente { get; set; }
    }
}
