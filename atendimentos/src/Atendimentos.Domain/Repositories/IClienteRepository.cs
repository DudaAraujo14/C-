using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atendimentos.Domain.Entities;

namespace Atendimentos.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> CriarAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> ObterTodosAsync();
        Task<Cliente?> ObterPorIdAsync(Guid id);
        Task DeletarAsync(Guid id);
    }
}
