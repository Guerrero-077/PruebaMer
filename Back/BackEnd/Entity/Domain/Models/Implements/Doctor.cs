using Entity.Domain.Models.Base;

namespace Entity.Domain.Models.Implements
{
    public class Doctor : BaseModelGeneric
    {
        public string name { get; set; }
        public string apellido { get; set; }
        public string especialidad { get; set; }
        public string consultorio { get; set; }
    }
}
