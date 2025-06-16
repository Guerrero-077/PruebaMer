using Data.Base;
using Data.Interfaces.Base;
using Entity.Contexts;
using Entity.DTOs.Base;
using Entity.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Implements
{
    public class UserData  : BaseModelData<User>, IUserData
    {
        public UserData(ApplicationDbContext context) : base(context){}



        public async Task<User?> FindEmail(string email)
        {
            var user = await _context.Set<User>().Where(u => u.email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> ValidateUserAsync(LoginDto loginDto)
        {
            bool suceeded = false;

            var user = await _context.Set<User>()
                .FirstOrDefaultAsync(u =>
                            u.email == loginDto.email &&
                            u.password == (loginDto.password));

            suceeded = (user != null) ? true : throw new UnauthorizedAccessException("Credenciales inválidas");

            return user;
        }
    }
}
