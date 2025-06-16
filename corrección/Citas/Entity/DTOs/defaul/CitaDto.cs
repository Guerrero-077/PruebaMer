using Entity.DTOs.Base;

namespace Entity.DTOs.defaul
{
    public class CitaDto : BaseModelDto
    {
        public int Consultorio { get; set; }
        public DateTime FechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }

        // Relación con claves foráneas
        public int DoctorId { get; set; }
        public int PacienteId { get; set; }
    }
}