using System.Dynamic;

namespace Business.Interfaces.BusinessBasic
{
    public interface IBusiness<D>
    {
        Task<IEnumerable<D>> GetAllAsync();
        Task<D?> GetByIdAsync(int id);
        Task<D> CreateAsync(D dto);
        Task<bool> UpdateAsync(D dto);
        Task<bool> DeleteAsync(int id);


    }
}
