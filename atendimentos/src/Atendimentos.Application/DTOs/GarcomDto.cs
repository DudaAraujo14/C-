using System;

namespace Atendimentos.Application.DTOs
{
    public class GarcomDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Telefone { get; set; }
        public DateTime DataContratacao { get; set; }
        public bool Ativo { get; set; }
    }
}
