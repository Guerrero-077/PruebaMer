using Business.Iterfaces.Base;
using Entity.DTOs.defaul;
using Entity.DTOs.Selects;

namespace Business.Iterfaces.Implements
{
    public interface ICitaBusiness : IBaseModelBusiness<CitaDto, CitaSelectDto>
    {
    }
}
