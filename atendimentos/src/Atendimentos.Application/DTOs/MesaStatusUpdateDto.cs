namespace Atendimentos.Application.DTOs
{
    public class MesaStatusUpdateDto
    {
        // 0 = Livre, 1 = Ocupada, 2 = Aguardando
        public int Status { get; set; }
    }
}
