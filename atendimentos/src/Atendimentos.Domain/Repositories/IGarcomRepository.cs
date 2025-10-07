using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atendimentos.Domain.Entities;

namespace Atendimentos.Domain.Repositories
{
    public interface IGarcomRepository
    {
        Task<IEnumerable<Garcom>> ObterTodosAsync();
        Task<Garcom?> ObterPorIdAsync(Guid id);
        Task CriarAsync(Garcom garcom);
        Task AtualizarAsync(Garcom garcom);
        Task DeletarAsync(Guid id);
    }
}
