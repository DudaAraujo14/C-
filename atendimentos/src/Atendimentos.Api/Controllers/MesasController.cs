using Atendimentos.Application.DTOs;
using Atendimentos.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Atendimentos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesasController : ControllerBase
    {
        private readonly IMesaService _mesaService;

        public MesasController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mesas = await _mesaService.ObterTodasAsync();
            return Ok(mesas);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MesaCreateDto dto)
        {
            var mesa = await _mesaService.CriarMesaAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = mesa.Id }, mesa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MesaUpdateDto dto)
        {
            var resultado = await _mesaService.AtualizarMesaAsync(id, dto);
            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] MesaStatusUpdateDto dto)
        {
            var resultado = await _mesaService.AtualizarStatusAsync(id, dto.Status);
            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucesso = await _mesaService.DeletarMesaAsync(id);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}
