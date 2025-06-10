

using Business.Interface;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.ControllersBase.Web.Controllers.BaseController;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : BaseController<PacienteDto, IPaciente>
    {
        public PacienteController(IPaciente service, ILogger<PacienteController> logger)
            : base(service, logger) { }

        protected override Task<IEnumerable<PacienteDto>> GetAllAsync() => _service.GetAllAsync();

        protected override Task<PacienteDto?> GetByIdAsync(int id) => _service.GetByIdAsync(id);

        protected override Task AddAsync(PacienteDto dto) => _service.CreateAsync(dto);

        protected override async Task<bool> DeleteAsync(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user is null) return false;

            await _service.DeleteAsync(id);
            return true;
        }
        protected override Task<bool> UpdateAsync(int id, PacienteDto dto) => _service.UpdateAsync(dto);
    }
}
