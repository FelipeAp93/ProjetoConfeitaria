using AutoMapper;
using ProjetoConfeitaria.Repositories;

namespace ProjetoConfeitaria.Services;

public class Service<T, TDTO> : IService<T, TDTO> where T : class where TDTO : class
{
    private readonly IRepository<T> _repository;
    private readonly IMapper _mapper;

    public Service(IRepository<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TDTO>> BuscarTodos()
    {
        var entities = await _repository.BuscarTodos();
        return _mapper.Map<IEnumerable<TDTO>>(entities);
    }

    public async Task<TDTO?> BuscarPorId(int id)
    {
        var entity = await _repository.BuscarPorId(id);
        return _mapper.Map<TDTO>(entity);
    }

    public async Task Criar(TDTO dto)
    {
        var entity = _mapper.Map<T>(dto);
        await _repository.Criar(entity);
    }

    public async Task Atualizar(TDTO dto)
    {
        var entity = _mapper.Map<T>(dto);
        await _repository.Atualizar(entity);
    }

    public async Task Deletar(int id)
    {
        await _repository.Deletar(id);
    }
}
