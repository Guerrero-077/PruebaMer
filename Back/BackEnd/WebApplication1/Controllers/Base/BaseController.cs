namespace Web.Controllers.ControllersBase
{
    using Entity.DTOs.Base;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    namespace Web.Controllers.BaseController
    {
        [ApiController]
        [Route("api/[controller]")]
        public abstract class BaseController<D, TService> : ControllerBase
        where D : BaseDto
        where TService : class
        {
            protected readonly TService _service;
            protected readonly ILogger _logger;

            protected BaseController(TService service, ILogger logger)
            {
                _service = service;
                _logger = logger;
            }

            [HttpGet]
            //[ProducesResponseType(typeof(IEnumerable<TDto>), 200)]
            [ProducesResponseType(200)]
            [ProducesResponseType(500)]
            public virtual async Task<IActionResult> Get()
            {
                try
                {
                    var result = await GetAllAsync();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error obteniendo datos");
                    return StatusCode(500, new { message = "Error interno del servidor." });
                }

                //var result = await DeleteAsync(id, deleteType);

                //if (!result)
                //    return NotFound(new { message = "No se pudo eliminar el recurso." });

                //return Ok(new { message = $"Eliminación {deleteType} realizada correctamente." });
            }

            [HttpGet("{id}")]
            //[ProducesResponseType(typeof(TDto), 200)]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]
            [ProducesResponseType(404)]
            [ProducesResponseType(500)]
            public virtual async Task<IActionResult> GetById(int id)
            {
                try
                {
                    var result = await GetByIdAsync(id);
                    if (result == null)
                        return NotFound(new { message = $"No se encontró el elemento con ID {id}" });

                    return Ok(result);
                }
                catch (ValidationException ex)
                {
                    _logger.LogWarning(ex, "Validación fallida con ID: {Id}", id);
                    return BadRequest(new { message = ex.Message });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al obtener el ID {Id}", id);
                    return StatusCode(500, new { message = "Error interno del servidor." });
                }
            }


            [HttpPost]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]
            [ProducesResponseType(500)]
            public virtual async Task<IActionResult> Post([FromBody] D dto)
            {
                try
                {
                    await AddAsync(dto);
                    return Ok(new { message = "Elemento agregado exitosamente" });
                }
                catch (ValidationException ex)
                {
                    _logger.LogWarning(ex, "Validación fallida al agregar");
                    return BadRequest(new { message = ex.Message });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al agregar elemento");
                    return StatusCode(500, new { message = "Error interno del servidor." });
                }
            }


            [HttpPut("{id}")]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]
            [ProducesResponseType(404)]
            [ProducesResponseType(500)]
            public virtual async Task<IActionResult> Put(int id, [FromBody] D dto)
            {
                try
                {
                    if (dto is not BaseDto identifiableDto)
                        return BadRequest(new { message = "El DTO no implementa IHasId." });

                    identifiableDto.id = id;

                    var updated = await UpdateAsync(id, dto);
                    if (updated == null)
                        return NotFound(new { message = $"No se encontró el recurso con ID {id} para actualizar." });

                    return Ok(new { message = "Elemento actualizado exitosamente." });
                }
                catch (ValidationException ex)
                {
                    _logger.LogWarning(ex, "Validación fallida al actualizar ID: {Id}", id);
                    return BadRequest(new { message = ex.Message });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al actualizar ID: {Id}", id);
                    return StatusCode(500, new { message = "Error interno del servidor." });
                }
            }




            [HttpDelete("{id}")]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]
            [ProducesResponseType(404)]
            [ProducesResponseType(500)]
            public async Task<IActionResult> Delete(int id)
            {
                try
                {
                    var result = await DeleteAsync(id);

                    if (!result)
                        return NotFound(new { message = "No se pudo eliminar el recurso." });

                    return Ok(new { message = $"Eliminación {result} realizada correctamente." });
                }
                catch (ValidationException ex)
                {
                    _logger.LogWarning(ex, "Validación fallida al eliminar recurso con id: {ResourceId}", id);
                    return BadRequest(new { message = ex.Message });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error inesperado al eliminar recurso con id: {ResourceId}", id);
                    return StatusCode(500, new { message = "Error interno del servidor." });
                }
            }

            // Métodos que las subclases deben implementar
            protected abstract Task<IEnumerable<D>> GetAllAsync();
            //protected virtual Task<IEnumerable<TSelect>> GetAllDynamicAsync();
            protected abstract Task<D?> GetByIdAsync(int id);
            protected abstract Task AddAsync(D dto);
            protected abstract Task<bool> UpdateAsync(int id, D dto);

            protected abstract Task<bool> DeleteAsync(int id);
        }


    }

}
