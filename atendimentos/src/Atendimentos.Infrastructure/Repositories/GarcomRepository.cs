using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atendimentos.Domain.Entities;
using Atendimentos.Domain.Repositories;
using Atendimentos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Atendimentos.Infrastructure.Repositories
{
    public class GarcomRepository : IGarcomRepository
    {
        private readonly AtendimentosDbContext _context;

        public GarcomRepository(AtendimentosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Garcom>> ObterTodosAsync()
        {
            return await _context.Garcons.ToListAsync();
        }

        public async Task<Garcom?> ObterPorIdAsync(Guid id)
        {
            return await _context.Garcons.FindAsync(id);
        }

        public async Task CriarAsync(Garcom garcom)
        {
            _context.Garcons.Add(garcom);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Garcom garcom)
        {
            _context.Garcons.Update(garcom);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var garcom = await _context.Garcons.FindAsync(id);
            if (garcom != null)
            {
                _context.Garcons.Remove(garcom);
                await _context.SaveChangesAsync();
            }
        }
    }
}
