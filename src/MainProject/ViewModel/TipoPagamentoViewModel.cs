using System.ComponentModel.DataAnnotations;

namespace MainProject.ViewModel;

public class TipoPagamentoViewModel
{
    public int Id { get; set; }

    [Display(Name = "Nome do Tipo de Pagamento")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; set; }

    [Display(Name = "Descrição do Tipo de Pagamento")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Descricao { get; set; }
}
