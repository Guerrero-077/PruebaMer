using Data.Interfaces.Base;

namespace Data.Base
{
    public abstract class BaseModelDataA<T> : IData<T>
    {
        public abstract Task<T> Create(T Entity);
        public abstract Task<bool> DeleteAsync(int id);
        public abstract Task<IEnumerable<T>> GetAll();
        public abstract Task<T> GetAllById(int id);
        public abstract Task<bool> UpdateAsync(T Entity);
    }
}
