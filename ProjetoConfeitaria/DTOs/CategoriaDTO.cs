using System.ComponentModel.DataAnnotations;

namespace ProjetoConfeitaria.DTOs;

public class CategoriaDTO
{
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3)]
    [MaxLength(70)]
    public string? Nome { get; set; }
}
