using System;

namespace Atendimentos.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Cliente(string nome, string cpf, string telefone)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            DataCadastro = DateTime.UtcNow;
        }

        // EF Core
        protected Cliente() { }
    }
}
