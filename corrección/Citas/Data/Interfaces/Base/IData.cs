namespace Data.Interfaces.Base
{
    public interface IData<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetAllById(int id);
        Task<T> Create(T Entity);
        Task<bool> UpdateAsync(T Entity);
        Task<bool>  DeleteAsync(int id);
    }
}
