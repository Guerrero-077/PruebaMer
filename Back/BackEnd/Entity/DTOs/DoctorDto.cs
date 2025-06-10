using Entity.DTOs.Base;

namespace Entity.DTOs
{
    public class DoctorDto : BaseGenericDto
    {
        public string name { get; set; }
        public string apellido { get; set; }
        public string especialidad { get; set; }
        public string consultorio { get; set; }
    }
}
