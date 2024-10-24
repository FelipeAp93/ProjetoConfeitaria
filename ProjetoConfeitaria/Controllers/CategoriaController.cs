using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoConfeitaria.DTOs;
using ProjetoConfeitaria.Models;
using ProjetoConfeitaria.Services;

namespace ProjetoConfeitaria.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly IService<Categoria, CategoriaDTO> _categoriaService;

    public CategoriaController(IService<Categoria, CategoriaDTO> categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        var categorias = await _categoriaService.BuscarTodos();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var categoria = await _categoriaService.BuscarPorId(id);
        if (categoria == null)
            return NotFound();
        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CategoriaDTO categoriaDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _categoriaService.Criar(categoriaDto);
        return CreatedAtAction(nameof(BuscarPorId), new { id = categoriaDto.CategoriaId }, categoriaDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] CategoriaDTO categoriaDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != categoriaDto.CategoriaId)
            return BadRequest();

        await _categoriaService.Atualizar(categoriaDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        await _categoriaService.Deletar(id);
        return NoContent();
    }
}
