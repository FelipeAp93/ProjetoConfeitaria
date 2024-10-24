using ProjetoConfeitaria.DTOs;
namespace ProjetoConfeitaria.Services;

public interface IAdminService
{
    Task<IEnumerable<AdminDTO>> BuscarTodos();
    Task<AdminDTO> BuscarPorId(int id);
    Task<AdminDTO> Incluir(AdminDTO adminDto);
    Task<AdminDTO> Atualizar(AdminDTO adminDto);
    Task<AdminDTO> Deletar(int id);
}
