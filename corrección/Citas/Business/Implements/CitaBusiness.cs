using AutoMapper;
using Business.Iterfaces.Implements;
using Business.Repository;
using Data.Interfaces.Base;
using Data.Interfaces.Implements;
using Entity.DTOs.defaul;
using Entity.DTOs.Selects;
using Entity.Models.Implements;

namespace Business.Implements
{
    public class CitaBusiness : BaseModelBusiness<CitaDto, CitaSelectDto, Cita>, ICitaBusiness
    {
        public CitaBusiness(ICitasData data, IMapper mapper) : base(data, mapper)
        {
        }
    }
}
