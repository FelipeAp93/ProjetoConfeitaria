using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoConfeitaria.DTOs;
using ProjetoConfeitaria.Services;

namespace ProjetoConfeitaria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        var produtos = await _produtoService.BuscarTodos();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var produto = await _produtoService.BuscarPorId(id);
        if (produto == null)
            return NotFound();
        return Ok(produto);
    }

    [HttpGet("disponiveis")]
    public async Task<IActionResult> GetProdutosDisponiveis()
    {
        var produtos = await _produtoService.GetProdutosDisponiveisAsync();
        return Ok(produtos);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddProduto([FromBody] ProdutoDTO produtoDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _produtoService.Criar(produtoDto);
        return CreatedAtAction(nameof(BuscarPorId), new { id = produtoDto.Id }, produtoDto);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> AtualizarProduto(int id, [FromBody] ProdutoDTO produtoDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != produtoDto.Id)
            return BadRequest();

        await _produtoService.Atualizar(produtoDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeletarProduto(int id)
    {
        await _produtoService.Deletar(id);
        return NoContent();
    }
}
