
using Seveclie.Domain.Entities;

namespace Seveclie.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string username, string password);
    }
}
