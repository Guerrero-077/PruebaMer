using AutoMapper;
using Business.Iterfaces.Implements;
using Business.Repository;
using Data.Interfaces.Base;
using Entity.DTOs.defaul;
using Entity.DTOs.Selects;
using Entity.Models.Implements;

namespace Business.Implements
{
    public class PacienteBusiness : BaseModelBusiness<PacienteDto, PacienteSelectDto, Paciente>, IPacienteBusiness
    {
        public PacienteBusiness(IData<Paciente> data, IMapper mapper) : base(data, mapper)
        {
        }
    }
}
