using AutoMapper;
using Data.Interfaces.Base;
using Entity.Models.Base;

namespace Business.Repository
{
    public class BaseModelBusiness<TDto, TDtoGet, TEntity> : BaseModelBusinessA<TDto, TDtoGet, TEntity> where TEntity : BaseModel
    {
        protected readonly IMapper _mapper;
        protected readonly IData<TEntity> Data;

        public BaseModelBusiness(IData<TEntity> data, IMapper mapper)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public override async Task<IEnumerable<TDtoGet>> GetAllAsync()
        {
            try
            {
                var entities = await Data.GetAll();
                return _mapper.Map<IEnumerable<TDtoGet>>(entities);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los registros.", ex);
            }
        }


     
        public override async Task<TDtoGet?> GetByIdAsync(int id)
        {
            try
            {
                //BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");

                var entity = await Data.GetAllById(id);
                return entity == null ? default : _mapper.Map<TDtoGet>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el registro con ID {id}.", ex);
            }
        }

        public override async Task<TDto> CreateAsync(TDto dto)
        {
            try
            {
                //BusinessValidationHelper.ThrowIfNull(dto, "El DTO no puede ser nulo.");

                var entity = _mapper.Map<TEntity>(dto);

                var created = await Data.Create(entity);
                return _mapper.Map<TDto>(created);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el registro.", ex);
            }
        }

        public override async Task<bool> UpdateAsync(TDto dto)
        {
            try
            {
                //BusinessValidationHelper.ThrowIfNull(dto, "El DTO no puede ser nulo.");

                var entity = _mapper.Map<TEntity>(dto);
                return await Data.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el registro: {ex.Message}", ex);
            }
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("El ID debe ser mayor que cero.");
                }


                return await Data.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el registro con ID {id}.", ex);
            }
        }

    }
}
