using AutoMapper;
using ProjetoConfeitaria.DTOs;
using ProjetoConfeitaria.Models;
using ProjetoConfeitaria.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoConfeitaria.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly IMapper _mapper;

    public AdminService(IAdminRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AdminDTO>> BuscarTodos()
    {
        var admins = await _repository.BuscarTodos();
        return _mapper.Map<IEnumerable<AdminDTO>>(admins);
    }

    public async Task<AdminDTO> BuscarPorId(int id)
    {
        var admin = await _repository.BuscarPorId(id);
        return _mapper.Map<AdminDTO>(admin);

    }

    public async Task<AdminDTO> Incluir(AdminDTO adminDTO)
    {
        var admin = _mapper.Map<Admin>(adminDTO);

        if (adminDTO.Password != null)
        {

            using var hmac = new HMACSHA256();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminDTO.Password));
            byte[] passwordSalt = hmac.Key;

            admin.AlterarSenha(passwordHash, passwordSalt);
        }
        var adminIncluido = await _repository.Incluir(admin);
        return _mapper.Map<AdminDTO>(adminIncluido);

    }

    public async Task<AdminDTO> Atualizar(AdminDTO adminDTO)
    {
        var admin = _mapper.Map<Admin>(adminDTO);
        var adminAtt = await _repository.Atualizar(admin);
        return _mapper.Map<AdminDTO>(adminAtt);
    }

    public async Task<AdminDTO> Deletar(int id)
    {
        var admin = await _repository.Deletar(id);
        return _mapper.Map<AdminDTO>(admin);
    }


}


