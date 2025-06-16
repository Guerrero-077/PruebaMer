using Entity.DTOs.Base;

namespace Business.Iterfaces.IJWT
{
    public interface IToken
    {
        Task<string> GenerateToken(LoginDto dto);
        bool validarToken(string token);
    }
}
