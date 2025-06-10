using AutoMapper;
using Entity.Domain.Models.Implements;
using Entity.DTOs;

namespace Helpers.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Paciente, PacienteDto>().ReverseMap();
            //CreateMap<Doctor, DoctorDto>().ReverseMap();

            //CreateMap<Cita, CitasDto>().ReverseMap();
            //CreateMap<Rol, PacienteDto>().ReverseMap();
        }


    }
}
