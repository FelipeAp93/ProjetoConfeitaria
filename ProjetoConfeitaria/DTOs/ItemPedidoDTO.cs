using System.ComponentModel.DataAnnotations;

namespace ProjetoConfeitaria.DTOs;

public class ItemPedidoDTO
{
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3)]
    [MaxLength(70)]
    public string? NomeProduto { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
}
