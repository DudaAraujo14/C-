using System;

namespace Atendimentos.Domain.Entities
{
    public class Garcom
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public string Matricula { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataContratacao { get; private set; } = DateTime.UtcNow;
        public bool Ativo { get; private set; } = true;

        // Construtor
        public Garcom(string nome, string matricula, string telefone)
        {
            Nome = nome;
            Matricula = matricula;
            Telefone = telefone;
        }

        // Métodos de negócio
        public void Atualizar(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }

        public void Desativar()
        {
            Ativo = false;
        }
    }
}
