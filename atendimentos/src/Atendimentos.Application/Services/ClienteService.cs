using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atendimentos.Domain.Entities;
using Atendimentos.Domain.Repositories;

namespace Atendimentos.Application.Services
{
    public interface IClienteService
    {
        Task<Cliente> CriarAsync(string nome, string cpf, string telefone);
        Task<IEnumerable<Cliente>> ObterTodosAsync();
        Task<Cliente?> ObterPorIdAsync(Guid id);
        Task DeletarAsync(Guid id);
    }

    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> CriarAsync(string nome, string cpf, string telefone)
        {
            var cliente = new Cliente(nome, cpf, telefone);
            return await _repository.CriarAsync(cliente);
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<Cliente?> ObterPorIdAsync(Guid id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task DeletarAsync(Guid id)
        {
            await _repository.DeletarAsync(id);
        }
    }
}
