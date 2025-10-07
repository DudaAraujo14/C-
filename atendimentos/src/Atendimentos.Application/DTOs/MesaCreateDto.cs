namespace Atendimentos.Application.DTOs
{
    public class MesaCreateDto
    {
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public string Localizacao { get; set; } = string.Empty;
        public string QrCode { get; set; } = string.Empty;
    }
}
