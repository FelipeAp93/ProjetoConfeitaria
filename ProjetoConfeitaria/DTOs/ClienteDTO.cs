using System.ComponentModel.DataAnnotations;

namespace ProjetoConfeitaria.DTOs;

public class ClienteDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3)]
    [MaxLength(70)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    public string? Telefone { get; set; }
}

