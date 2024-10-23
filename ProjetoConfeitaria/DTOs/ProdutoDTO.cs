using System.ComponentModel.DataAnnotations;

namespace ProjetoConfeitaria.DTOs;

public class ProdutoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3)]
    [MaxLength(70)]
    public string? Nome { get; set; }
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "O preço é obrigatório.")]
    public decimal Preco { get; set; }
    public bool Disponivel { get; set; }
    public string? CategoriaNome { get; set; }
}

