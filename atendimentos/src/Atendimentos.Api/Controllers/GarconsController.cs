using Microsoft.AspNetCore.Mvc;
using Atendimentos.Application.Services;
using Atendimentos.Application.DTOs;

namespace Atendimentos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GarconsController : ControllerBase
    {
        private readonly IGarcomService _garcomService;

        public GarconsController(IGarcomService garcomService)
        {
            _garcomService = garcomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var garcons = await _garcomService.ObterTodosAsync();
            return Ok(garcons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var garcom = await _garcomService.ObterPorIdAsync(id);
            if (garcom == null) return NotFound();
            return Ok(garcom);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GarcomCreateUpdateDto dto)
        {
            var garcom = await _garcomService.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = garcom.Id }, garcom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, GarcomCreateUpdateDto dto)
        {
            var atualizado = await _garcomService.AtualizarAsync(id, dto);
            if (atualizado == null) return NotFound();
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucesso = await _garcomService.DeletarAsync(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
