using Business.Iterfaces.IJWT;
using Data.Interfaces.Base;
using Entity.DTOs.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Custom
{
    public class TokenBusiness : IToken
    {
        private readonly IConfiguration _configuration;
        private readonly IUserData _dataUser;

        public TokenBusiness(IConfiguration configuration, IUserData dataUser)
        {
            _configuration = configuration;
            _dataUser = dataUser;
        }
        public async Task<string> GenerateToken(LoginDto dto)
        {
            // Crear la información del usuario para el token
            var user = await _dataUser.ValidateUserAsync(dto);

            var userClaims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Email, dto.email!)
            };


            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //  Crear detalles del Token
            var jwtConfig = new JwtSecurityToken
            (
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:exp"])),
                signingCredentials: credentials

            );
            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }




        public bool validarToken(string token)
        {
            var ClaimsPrincipal = new ClaimsPrincipal();
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!))
            };

            try
            {
                ClaimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (SecurityTokenExpiredException)
            {
                //Manejar token Expirado
                return false;
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                // Manejar firma Invalida
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


    }
}
