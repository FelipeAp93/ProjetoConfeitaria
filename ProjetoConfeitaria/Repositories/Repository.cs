using Microsoft.EntityFrameworkCore;
using ProjetoConfeitaria.Context;

namespace ProjetoConfeitaria.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> BuscarTodos()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> BuscarPorId(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Criar(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(int id)
    {
        var entity = await BuscarPorId(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}