using MainProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using MainProject.Binders;

namespace MainProject.ViewModel;

public class CompraViewModel
{
    public int Id { get; set; }

    [Display(Name = "Descrição da Compra")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Descricao { get; set; }

    [Display(Name = "Classe da Compra")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int ClasseCompraId { get; set; }
    public ClasseCompra ClasseCompra { get; set; }

    [Display(Name = "Valor da Compra")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [ModelBinder(BinderType = typeof(DecimalModelBinder))]
    public decimal Valor { get; set; }

    [Display(Name = "Quantidade de Parcelas")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int QtdParcela { get; set; }

    [Display(Name = "Número de Parcelas pagas")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int ParcelasPagas { get; set; }

    [Display(Name = "Data da Compra")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Date)] // Define que é uma data
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DataCompra { get; set; }
    public List<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
