using MainProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using MainProject.Binders;

namespace MainProject.ViewModel;

public class PagamentoViewModel
{
    public int Id { get; set; }

    [Display(Name = "Valor do Pagamento")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [ModelBinder(BinderType = typeof(DecimalModelBinder))]
    public decimal Valor { get; set; }

    [Display(Name = "Tipo de Pagamento")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int TipoPagamentoId { get; set; }
    public TipoPagamento TipoPagamento { get; set; }

    [Display(Name = "Número de Parcela")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int NumeroParcela { get; set; }

    [Display(Name = "Data do Pagamento")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Date)] // Define que é uma data
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DataPagamento { get; set; }
    public int CompraId { get; set; }
    public Compra Compra { get; set; }
}
