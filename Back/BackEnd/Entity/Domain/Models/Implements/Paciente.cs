using Entity.Domain.Models.Base;

namespace Entity.Domain.Models.Implements
{
    public class Paciente : BaseModelGeneric
    {
        public string documento { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
    }
}
