using Entity.Models.Base;

namespace Entity.Models.Implements
{
    public class Cita : BaseModel
    {
        public int Consultorio { get; set; }
        public DateTime FechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }

        // Relaciones con claves foráneas
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}