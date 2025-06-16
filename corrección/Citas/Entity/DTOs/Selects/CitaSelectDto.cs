using Entity.DTOs.Base;

namespace Entity.DTOs.Selects
{
    public class CitaSelectDto : BaseModelDto
    {
        public int Consultorio { get; set; }
        public DateTime FechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }  
        public int PacienteId { get; set; }
        public string PacienteName { get; set; }
    }
}
