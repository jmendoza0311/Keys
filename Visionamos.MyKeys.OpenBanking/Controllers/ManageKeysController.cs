using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Visionamos.MyKeys.Application.OpenBanking.Contracts.Interfaces;
using Visionamos.MyKeys.Application.OpenBanking.Services;


namespace Visionamos.MyKeys.OpenBanking.Controllers
{ 
    [ApiController] 
    [Route("api/[controller]")]
    public class ManageKeysController : ControllerBase
    {
        private readonly IManageKeyService _service;

        public ManageKeysController(IManageKeyService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        [SwaggerOperation(
            Summary = "Registra una nueva llave",
            Description = "Crea una llave bancaria con los datos proporcionados."
        )]
        [ProducesResponseType(typeof(KeyResponse), 200)]
        [ProducesResponseType(typeof(KeyResponse), 400)]
        public async Task<IActionResult> Register([FromBody] RegisterKeyRequest request)
        {
            try {
                if (!ModelState.IsValid)
                    return BadRequest(new KeyResponse { Success = false, Message = "Datos de entrada inválidos." });
                    var response = await _service.RegisterKeyAsync(request);
                return response.Success ? Ok(response) : BadRequest(response);
            } catch 
            {
                throw;           
            }
        }

        [HttpPost("Update")]
        [SwaggerOperation(
            Summary = "Actualiza una llave existente",
            Description = "Modifica los datos de una llave bancaria existente."
        )]
        [ProducesResponseType(typeof(KeyResponse), 200)]
        [ProducesResponseType(typeof(KeyResponse), 400)]
        [ProducesResponseType(typeof(KeyResponse), 404)]
        public async Task<IActionResult> Update([FromBody] UpdateKeyRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new KeyResponse { Success = false, Message = "Datos de entrada inválidos." });
                    var response = await _service.UpdateKeyAsync(request);
                return response.Success ? Ok(response) : BadRequest(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("Delete")]
        [SwaggerOperation(
            Summary = "Elimina una llave",
            Description = "Desactiva una llave bancaria existente."
        )]
        [ProducesResponseType(typeof(KeyResponse), 200)]
        [ProducesResponseType(typeof(KeyResponse), 400)]
        [ProducesResponseType(typeof(KeyResponse), 404)]
        public async Task<IActionResult> Delete([FromBody] DeleteKeyRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new KeyResponse { Success = false, Message = "Datos de entrada inválidos." });
                var response = await _service.DeleteKeyAsync(request);
                return response.Success ? Ok(response) : BadRequest(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("Get")]
        [SwaggerOperation(
            Summary = "Obtiene llaves por identificación",
            Description = "Recupera todas las llaves asociadas a una identificación."
        )]
        [ProducesResponseType(typeof(KeyResponse), 200)]
        [ProducesResponseType(typeof(KeyResponse), 400)]
        public async Task<IActionResult> Get([FromQuery] GetKeyRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new KeyResponse { Success = false, Message = "Datos de entrada inválidos." });
                var response = await _service.GetKeysByIdentificationAsync(request);
                return response.Success ? Ok(response) : BadRequest(response);
            }
            catch
            {
                throw;
            }
        }

        //[HttpGet("Search")]
        //[SwaggerOperation(
        //    Summary = "Busca llaves",
        //    Description = "Busca llaves por identificación o valor de llave."
        //)]
        //[ProducesResponseType(typeof(KeyResponse), 200)]
        //[ProducesResponseType(typeof(KeyResponse), 400)]
        //public async Task<IActionResult> Search([FromBody] KeySearchRequest request)
        //{
        //    try
        //    {
        //        if (request == null) return BadRequest(new KeyResponse { Success = false, Message = "Solicitud inválida." });
        //        var response = await _service.SearchKeysAsync(request);
        //        return response.Success ? Ok(response) : BadRequest(response);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}