using Business.Iterfaces.Implements;
using Entity.DTOs.defaul;
using Entity.DTOs.Selects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICitas.Controllers.Base;

namespace WebAPICitas.Controllers.Implements
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CitaController : BaseController<CitaDto, CitaSelectDto, ICitaBusiness>
    {
        private readonly ILogger<CitaController> _logger;

        public CitaController(ICitaBusiness service, ILogger<CitaController> logger) : base(service, logger)
        {
            _logger = logger;
        }

        protected override Task<IEnumerable<CitaSelectDto>> GetAllAsync()
        {
            return _service.GetAllAsync();
        }
        protected override Task<CitaSelectDto?> GetByIdAsync(int id)
        {
            return _service.GetByIdAsync(id);
        }
        protected override Task AddAsync(CitaDto dto)
        {
            return _service.CreateAsync(dto);
        }

        protected override Task<bool> UpdateAsync(int id, CitaDto dto)
        {
            return _service.UpdateAsync(dto);
        }

        protected override async Task<bool> DeleteAsync(int id)
        {
            var form = await _service.GetByIdAsync(id);
            if (form is null) return false;

            await _service.DeleteAsync(id);
            return true;
        }
    }
}
