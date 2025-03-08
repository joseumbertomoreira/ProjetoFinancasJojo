using System.ComponentModel.DataAnnotations;

namespace MainProject.Models;

public class TipoPagamento
{
    public int Id { get; set; }

    [Display(Name = "Nome do Tipo de Pagamento")]
    public string Nome { get; set; }
    public string Descricao { get; set; }
}
