using AutoMapper;
using ProjetoConfeitaria.DTOs;
using ProjetoConfeitaria.Models;
using ProjetoConfeitaria.Repositories;

namespace ProjetoConfeitaria.Services;

public class ProdutoService : Service<Produto, ProdutoDTO>, IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        : base(produtoRepository, mapper)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProdutoDTO>> GetProdutosDisponiveisAsync()
    {
        var produtos = await _produtoRepository.GetProdutosDisponiveisAsync();
        return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
    }
}


