using AutoMapper;
using Business.Interface;
using Business.Repository;
using Data.Interface.DataBasic;
using Entity.Domain.Models.Implements;
using Entity.DTOs;

namespace Business.Services
{
    public class PacienteService : BusinessBasic<PacienteDto, Paciente>, IPaciente
    {
        public PacienteService(IData<Paciente> data, IMapper mapper) : base(data, mapper)
        {
        }
    }
}
