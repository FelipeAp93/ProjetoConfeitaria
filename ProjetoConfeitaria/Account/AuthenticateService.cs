using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoConfeitaria.Context;
using ProjetoConfeitaria.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoConfeitaria.Account;

public class AuthenticateService : IAuthenticate
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthenticateService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<bool> AuthenticateAsync(string email, string senha)
    {
        var admin = await _context.Admins.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        if (admin == null)
        {
            return false;
        }

        using var hmac = new HMACSHA256(admin.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
        for (int x = 0; x < computedHash.Length; x++)
        {
            if (computedHash[x] != admin.PasswordHash[x]) return false;
        }
        return true;

    }

    public string GenerateToken(int id, string email)
    {
        var claims = new[]
        {
        new Claim("id", id.ToString()),
        new Claim("email", email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        // Obtém a chave secreta do appsettings.json
        var secretKey = _configuration["jwt:secretKey"];

        // Valida o tamanho da chave
        if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
        {
            throw new ArgumentException("A chave secreta precisa ter pelo menos 32 caracteres.");
        }

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(15);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["jwt:issuer"],
            audience: _configuration["jwt:audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<Admin> GetUserByEmail(string email)
    {
        return await _context.Admins.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
    }

    public async Task<bool> UserExiste(string email)
    {
        var admin = await _context.Admins
            .Where(x => x.Email.ToLower() == email.ToLower())
            .FirstOrDefaultAsync();

        // Verifique se o usuário é nulo antes de acessar suas propriedades
        if (admin == null)
        {
            return false; // Nenhum usuário foi encontrado com o email especificado
        }

        return true; // O usuário existe
    }

}