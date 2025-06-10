using Entity.DTOs.Base;

namespace Entity.DTOs
{
    public class PacienteDto : BaseGenericDto
    {
        public string name { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
    }
}
