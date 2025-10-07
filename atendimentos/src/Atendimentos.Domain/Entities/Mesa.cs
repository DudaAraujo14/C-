using Atendimentos.Domain.Enums;

namespace Atendimentos.Domain.Entities
{
    public class Mesa
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public int Numero { get; private set; }
        public MesaStatus Status { get; private set; } = MesaStatus.Livre;
        public int? Capacidade { get; private set; }
        public string? Localizacao { get; private set; }
        public string? QrCode { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
        public byte[] RowVersion { get; private set; } = new byte[8];

        // ✅ Construtor padrão exigido pelo EF
        private Mesa() { }

        // ✅ Construtor de criação
        public Mesa(int numero, int capacidade, string localizacao, string qrCode)
        {
            Numero = numero;
            Capacidade = capacidade;
            Localizacao = localizacao;
            QrCode = qrCode;
            Status = MesaStatus.Livre;
        }

        // ✅ Métodos de negócio (mutators)
        public void AtualizarDados(int? capacidade, string? localizacao, string? qrCode)
        {
            if (capacidade.HasValue)
                Capacidade = capacidade;

            if (!string.IsNullOrEmpty(localizacao))
                Localizacao = localizacao;

            if (!string.IsNullOrEmpty(qrCode))
                QrCode = qrCode;

            UpdatedAt = DateTime.UtcNow;
        }

        public void AlterarStatus(MesaStatus novoStatus)
        {
            Status = novoStatus;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
