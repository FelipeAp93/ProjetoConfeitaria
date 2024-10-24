using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoConfeitaria.Account;
using ProjetoConfeitaria.DTOs;
using ProjetoConfeitaria.Models;
using ProjetoConfeitaria.Services;

namespace ProjetoConfeitaria.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AdminController : Controller
{
    private readonly IAuthenticate _authenticateService;
    private readonly IAdminService _adminService;

    public AdminController(IAuthenticate authenticateService, IAdminService adminService)
    {
        _authenticateService = authenticateService;
        _adminService = adminService;
    }

    [HttpPost("registro")]
    public async Task<ActionResult<UserToken>> Incluir(AdminDTO adminDTO)
    {
        if (adminDTO == null)
        {
            return BadRequest("Dados inválidos");
        }

        var emailExiste = await _authenticateService.UserExiste(adminDTO.Email);

        if (emailExiste)
        {
            return BadRequest("Este email já possui um cadastro.");
        }



        var admin = await _adminService.Incluir(adminDTO);
        if (admin == null)
        {
            return BadRequest("Ocorreu um erro ao cadastrar.");
        }

        var token = _authenticateService.GenerateToken(admin.Id, admin.Email);
        return new UserToken
        {
            Token = token
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserToken>> Selecionar(Login login)
    {
        var existe = await _authenticateService.UserExiste(login.Email);
        if (!existe)
        {
            return BadRequest("Usuário não existe.");
        }

        var result = await _authenticateService.AuthenticateAsync(login.Email, login.Password);
        if (!result)
        {
            return BadRequest("Usuário ou senha invalidos.");
        }

        var admin = await _authenticateService.GetUserByEmail(login.Email);

        var token = _authenticateService.GenerateToken(admin.Id, admin.Email);

        return new UserToken
        {
            Token = token
        };
    }
}
