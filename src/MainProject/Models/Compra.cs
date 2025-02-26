namespace MainProject.Models;

public class Compra
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public int ClasseCompraId { get; set; }
    public ClasseCompra ClasseCompra { get; set; }
    public decimal Valor { get; set; }
    public int QtdParcela { get; set; }
    public int ParcelasPagas { get; set; }
    public DateTime DataCompra { get; set; }
    public List<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
