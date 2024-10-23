using System.ComponentModel.DataAnnotations;

namespace ProjetoConfeitaria.DTOs;

public class PedidoDTO
{
    public int Id { get; set; }
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3)]
    [MaxLength(70)]
    public string? NomeCliente { get; set; }
    public DateTime DataPedido { get; set; }
    public List<ItemPedidoDTO>? ItensPedido { get; set; }
    public string? Status { get; set; }
}
