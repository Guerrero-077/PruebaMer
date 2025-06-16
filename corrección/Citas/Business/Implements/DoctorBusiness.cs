using AutoMapper;
using Business.Iterfaces.Implements;
using Business.Repository;
using Data.Interfaces.Base;
using Entity.DTOs.defaul;
using Entity.DTOs.Selects;
using Entity.Models.Implements;

namespace Business.Implements
{
    public class DoctorBusiness : BaseModelBusiness<DoctorDto, DoctorSelectDto, Doctor>, IDoctorBusiness
    {
        public DoctorBusiness(IData<Doctor> data, IMapper mapper) : base(data, mapper)
        {
        }
    }
}
