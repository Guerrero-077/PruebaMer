using Entity.DTOs.Base;

namespace Business.Iterfaces.Base
{
    public interface IUserBusiness : IBaseModelBusiness<UserDto, UserSelectDto>
    {
        Task<UserDto> CreateAsyncUser(UserDto dto);

    }
}
