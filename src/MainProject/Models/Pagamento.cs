namespace MainProject.Models;

public class Pagamento
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public int TipoPagamentoId { get; set; }
    public TipoPagamento TipoPagamento { get; set; }
    public int NumeroParcela { get; set; }
    public DateTime DataPagamento { get; set; }
    public int CompraId { get; set; }
    public Compra Compra { get; set; }
}
