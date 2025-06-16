using AutoMapper;
using Entity.DTOs.Base;
using Entity.DTOs.defaul;
using Entity.DTOs.Selects;
using Entity.Models.Base;
using Entity.Models.Implements;

namespace WebAPICitas.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            
            CreateMap<Paciente, PacienteDto>().ReverseMap();
            CreateMap<Paciente, PacienteSelectDto>().ReverseMap();

            CreateMap<Cita, CitaDto>().ReverseMap();
            CreateMap<Cita, CitaSelectDto>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name))
                .ForMember(dest => dest.PacienteName, opt => opt.MapFrom(src => src.Paciente.Name));

            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Doctor, DoctorSelectDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
