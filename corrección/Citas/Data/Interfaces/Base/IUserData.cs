using Entity.DTOs.Base;
using Entity.Models.Base;

namespace Data.Interfaces.Base
{
    public interface IUserData : IData<User>
    {
        Task<User> ValidateUserAsync(LoginDto loginDto);
        Task<User?> FindEmail(string email);
    }
}
