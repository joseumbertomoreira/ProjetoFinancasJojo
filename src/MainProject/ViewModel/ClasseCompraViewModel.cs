using System.ComponentModel.DataAnnotations;

namespace MainProject.ViewModel;

public class ClasseCompraViewModel
{
    public int Id { get; set; }

    [Display(Name = "Nome da Classe Compra")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; set; }

    [Display(Name = "Descrição da Classe Compra")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Descricao { get; set; }
}
