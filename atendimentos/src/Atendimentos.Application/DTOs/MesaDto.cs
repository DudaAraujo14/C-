namespace Atendimentos.Application.DTOs
{
    public class MesaDto
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public int Status { get; set; }
        public int? Capacidade { get; set; }
        public string? Localizacao { get; set; }
        public string? QrCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
