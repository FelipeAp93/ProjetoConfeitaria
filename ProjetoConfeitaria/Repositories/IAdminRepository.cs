using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public interface IAdminRepository
{
        Task<IEnumerable<Admin>> BuscarTodos();
        Task<Admin> BuscarPorId(int id);
        Task<Admin> Incluir(Admin admin);
        Task<Admin> Atualizar(Admin admin);
        Task<Admin> Deletar(int id);

    }

