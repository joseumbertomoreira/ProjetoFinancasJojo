namespace MainProject.ViewModel;

public class ListaPagamentosViewModel
{
    public int CompraId { get; set; }
    public IEnumerable<PagamentoViewModel> Pagamentos { get; set; }
}
