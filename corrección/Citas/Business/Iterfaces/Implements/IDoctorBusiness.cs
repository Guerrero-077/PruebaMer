using Business.Iterfaces.Base;
using Business.Repository;
using Entity.DTOs.defaul;
using Entity.DTOs.Selects;
using Entity.Models.Implements;

namespace Business.Iterfaces.Implements
{
    public interface IDoctorBusiness : IBaseModelBusiness<DoctorDto, DoctorSelectDto>
    {
    }
}
