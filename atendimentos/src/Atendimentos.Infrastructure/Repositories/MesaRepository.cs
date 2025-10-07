using Atendimentos.Domain.Entities;
using Atendimentos.Domain.Repositories;
using Atendimentos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;



namespace Atendimentos.Infrastructure.Repositories
{
    public class MesaRepository : IMesaRepository
    {
        private readonly AtendimentosDbContext _context;

        public MesaRepository(AtendimentosDbContext context)
        {
            _context = context;
        }

        public async Task<Mesa> CriarAsync(Mesa mesa)
        {
            await _context.Mesas.AddAsync(mesa);
            await _context.SaveChangesAsync();
            return mesa;
        }

        public async Task<Mesa?> ObterPorIdAsync(Guid id)
        {
            return await _context.Mesas.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Mesa>> ObterTodasAsync()
        {
            return await _context.Mesas.AsNoTracking().ToListAsync();
        }

        public async Task AtualizarAsync(Mesa mesa)
        {
            _context.Mesas.Update(mesa);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa != null)
            {
                _context.Mesas.Remove(mesa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
