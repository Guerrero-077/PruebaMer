using Business.Interfaces.BusinessBasic;
using Entity.Domain.Models.Base;
using Entity.DTOs.Base;

namespace Business.Repository
{
    public abstract class ABaseModelBusiness<D, TEntity> : IBusiness<D> where TEntity : BaseModel where D : BaseDto
    {

        public abstract Task<D?> GetByIdAsync(int id);
        public abstract Task<IEnumerable<D>> GetAllAsync();
        public abstract Task<D> CreateAsync(D dto);
        public abstract Task<bool> UpdateAsync(D dto);
        public abstract Task<bool> DeleteAsync(int id);




    }
}
