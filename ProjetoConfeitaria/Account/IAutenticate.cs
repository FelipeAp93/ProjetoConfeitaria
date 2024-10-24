using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Account;

public interface IAuthenticate
{
    Task<bool> AuthenticateAsync(string email, string senha);
    Task<bool> UserExiste(string email);
    public string GenerateToken(int id, string email);
    public Task<Admin> GetUserByEmail(string email);

}