using Business.Iterfaces.Base;
using Business.Iterfaces.IJWT;
using Entity.Contexts;
using Entity.DTOs.Base;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPICitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class LoginController : ControllerBase
    {


        private readonly IToken _token;
        private readonly IUserBusiness _userService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IToken token, ILogger<LoginController> logger, IUserBusiness userService, ApplicationDbContext context)
        {
            _token = token;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Registrarse")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Registrarse(UserDto objeto)
        {
            try
            {
                var userCreated = await _userService.CreateAsyncUser(objeto);

                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { isSuccess = false, message = ex.Message });
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            try
            {
                var token = await _token.GenerateToken(login);

                //await _serviceEmail.EnviarEmailBienvenida(login.email);
                //await _notifyManager.NotifyAsync();

                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token });

                //return Ok(token);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida para el inicio de sesión");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el token");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("ValidarToken")]
        public IActionResult ValidarToken([FromQuery] string token)

        {

            bool respuesta = _token.validarToken(token);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });

        }


    }
}
