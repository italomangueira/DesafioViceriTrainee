using BackHero_CRUD.Application.DTOs;
using BackHero_CRUD.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackHero_CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly IHeroiService _service;

        public HeroisController(IHeroiService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarHeroiRequest request)
        {
            var result = await _service.CriarAsync(request);
            return CreatedAtAction(nameof(ObterPorId), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var herois = await _service.ListarAsync();
            if (!herois.Any())
                return NotFound("Nenhum herói encontrado.");
            return Ok(herois);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var heroi = await _service.ObterPorIdAsync(id);
            if (heroi == null)
                return NotFound($"Herói com ID {id} não encontrado.");
            return Ok(heroi);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] CriarHeroiRequest request)
        {
            var atualizado = await _service.AtualizarAsync(id, request);
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var sucesso = await _service.RemoverAsync(id);
            if (!sucesso)
                return NotFound($"Herói com ID {id} não encontrado.");
            return NoContent();
        }
    }
}
