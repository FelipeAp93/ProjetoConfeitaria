﻿using System.ComponentModel.DataAnnotations;

namespace ProjetoConfeitaria.Models;

public class Login
{
    [Required(ErrorMessage = "O email é obrigatório")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "O senha é obrigatória")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}