using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Atendimentos.Domain.Entities;
using Atendimentos.Domain.Repositories;
using Atendimentos.Infrastructure.Context;

namespace Atendimentos.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AtendimentosDbContext _context;

        public ClienteRepository(AtendimentosDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CriarAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente?> ObterPorIdAsync(Guid id)
        {
            return await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task DeletarAsync(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
