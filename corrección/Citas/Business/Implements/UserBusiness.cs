using AutoMapper;
using Business.Iterfaces.Base;
using Business.Repository;
using Data.Interfaces.Base;
using Entity.DTOs.Base;
using Entity.Models.Base;
using Microsoft.Extensions.Logging;

namespace Business.Implements
{
    public class UserBusiness  : BaseModelBusiness<UserDto, UserSelectDto, User> , IUserBusiness
    {
        private readonly IUserData _dataUser;
        private readonly ILogger<UserBusiness> _logger;

        public UserBusiness(IUserData data, ILogger<UserBusiness> logger, IMapper mapper) : base(data, mapper)
        {
            _dataUser = data;
            _logger = logger;
        }

     
        //Nuevo metodo 

        public async Task<UserDto> CreateAsyncUser(UserDto dto)
        {
            //BusinessValidationHelper.ThrowIfNull(dto, "El DTO no puede ser nulo.");

            // Mapeamos primero
            var userEntity = _mapper.Map<User>(dto);
            //InitializeLogical.InitializeLogicalState(userEntity); // Inicializa estado lógico (is_deleted = false)
                                                                  // Inicializa estado lógico (is_deleted = false)
            var createdEntity = await _dataUser.Create(userEntity);

            return _mapper.Map<UserDto>(createdEntity);

          

        }

    }
}
