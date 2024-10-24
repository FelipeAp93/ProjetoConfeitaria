using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoConfeitaria.DTOs;
using ProjetoConfeitaria.Services;

namespace ProjetoConfeitaria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidoController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodosPedidos()
    {
        var pedidos = await _pedidoService.BuscarTodos();
        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPedidoPorId(int id)
    {
        var pedido = await _pedidoService.BuscarPorId(id);
        if (pedido == null)
            return NotFound();
        return Ok(pedido);
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetPedidosPorStatus(string status)
    {
        var pedidos = await _pedidoService.GetPedidosPorStatusAsync(status);
        return Ok(pedidos);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddPedido([FromBody] PedidoDTO pedidoDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _pedidoService.Criar(pedidoDto);
        return CreatedAtAction(nameof(BuscarPedidoPorId), new { id = pedidoDto.Id }, pedidoDto);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> AtualizarPedido(int id, [FromBody] PedidoDTO pedidoDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != pedidoDto.Id)
            return BadRequest();

        await _pedidoService.Atualizar(pedidoDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeletarPedido(int id)
    {
        await _pedidoService.Deletar(id);
        return NoContent();
    }
}
