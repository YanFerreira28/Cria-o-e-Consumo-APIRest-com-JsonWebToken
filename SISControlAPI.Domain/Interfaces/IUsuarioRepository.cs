using SISControlAPI.Domain.Entities;

namespace SISControlAPI.Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        bool ValidaUsuario(string nome, string senha, string email);
    }
}
