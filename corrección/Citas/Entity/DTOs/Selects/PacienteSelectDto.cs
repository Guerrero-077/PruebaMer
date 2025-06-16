using Entity.DTOs.Base;

namespace Entity.DTOs.Selects
{
    public class PacienteSelectDto : BaseGenericDto
    {
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
