using BackHero_CRUD.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackHero_CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpoderesController : ControllerBase
    {
        private readonly ISuperpoderService _service;

        public SuperpoderesController(ISuperpoderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var poderes = await _service.ListarSuperpoderesAsync();
            return Ok(poderes);
        }

        [HttpGet("por-ids")]
        public async Task<IActionResult> GetPorIds([FromQuery] List<int> id)
        {
            if (id == null || !id.Any())
                return BadRequest("Informe pelo menos um ID.");

            var poderes = await _service.ObterPorIdsAsync(id);
            return Ok(poderes);
        }
    }
}
