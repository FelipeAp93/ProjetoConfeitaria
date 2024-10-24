namespace ProjetoConfeitaria.Models;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public DateTime DataPedido { get; set; }
    public List<ItemPedido>? ItensPedido { get; set; }
    public string? Status { get; set; }  // Ex: "Em preparo", "Pronto", "Entregue"
}





