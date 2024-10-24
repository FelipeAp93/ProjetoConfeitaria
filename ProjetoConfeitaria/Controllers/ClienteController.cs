using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoConfeitaria.DTOs;
using ProjetoConfeitaria.Models;
using ProjetoConfeitaria.Services;

namespace ProjetoConfeitaria.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IService<Cliente, ClienteDTO> _clienteService;

    public ClienteController(IService<Cliente, ClienteDTO> clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodosClientes()
    {
        var clientes = await _clienteService.BuscarTodos();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var cliente = await _clienteService.BuscarPorId(id);
        if (cliente == null)
            return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> AddCliente([FromBody] ClienteDTO clienteDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _clienteService.Criar(clienteDto);
        return CreatedAtAction(nameof(BuscarPorId), new { id = clienteDto.Id }, clienteDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarCliente(int id, [FromBody] ClienteDTO clienteDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != clienteDto.Id)
            return BadRequest();

        await _clienteService.Atualizar(clienteDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarCliente(int id)
    {
        await _clienteService.Deletar(id);
        return NoContent();
    }
}

