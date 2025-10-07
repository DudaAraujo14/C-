using Atendimentos.Domain.Entities;

namespace Atendimentos.Domain.Repositories
{
    public interface IMesaRepository
    {
        Task<Mesa> CriarAsync(Mesa mesa);
        Task<Mesa?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Mesa>> ObterTodasAsync();
        Task AtualizarAsync(Mesa mesa);
        Task DeletarAsync(Guid id);
    }
}
