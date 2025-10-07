using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atendimentos.Application.DTOs;

namespace Atendimentos.Application.Services
{
    public interface IGarcomService
    {
        Task<IEnumerable<GarcomDto>> ObterTodosAsync();
        Task<GarcomDto?> ObterPorIdAsync(Guid id);
        Task<GarcomDto> CriarAsync(GarcomCreateUpdateDto dto);
        Task<GarcomDto?> AtualizarAsync(Guid id, GarcomCreateUpdateDto dto);
        Task<bool> DeletarAsync(Guid id);
    }
}
