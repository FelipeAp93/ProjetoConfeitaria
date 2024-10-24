using Microsoft.EntityFrameworkCore;
using ProjetoConfeitaria.Context;
using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _context;

    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Admin>> BuscarTodos()
    {
        return await _context.Admins.ToListAsync();
    }
    public async Task<Admin> BuscarPorId(int id)
    {
        return await _context.Admins.Where(c => c.Id == id).FirstOrDefaultAsync();
    }
    public async Task<Admin> Incluir(Admin admin)
    {
        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();
        return admin;
    }
    public async Task<Admin> Atualizar(Admin admin)
    {
        _context.Entry(admin).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return  admin;
    }
    public async Task<Admin> Deletar(int id)
    {
        var admin = await BuscarPorId(id);
        _context.Admins.Remove(admin);
        await _context.SaveChangesAsync();
        return admin;
    }
}