using Business.Iterfaces.Base;

namespace Business.Repository
{
    public abstract class BaseModelBusinessA<TDto, TDtoGet, TEntityt> : IBaseModelBusiness<TDto, TDtoGet>
    {
        public abstract Task<TDto> CreateAsync(TDto dto);
        public abstract Task<bool> DeleteAsync(int id);
        public abstract Task<IEnumerable<TDtoGet>> GetAllAsync();
        public abstract Task<TDtoGet?> GetByIdAsync(int id);
        public abstract Task<bool> UpdateAsync(TDto dto);
    }
}
