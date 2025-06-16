namespace Business.Iterfaces.Base
{
    public interface IBaseModelBusiness<TDto, TDtoGet>
    {
        Task<IEnumerable<TDtoGet>> GetAllAsync();
        Task<TDtoGet?> GetByIdAsync(int id);
        Task<TDto> CreateAsync(TDto dto);
        Task<bool> UpdateAsync(TDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
