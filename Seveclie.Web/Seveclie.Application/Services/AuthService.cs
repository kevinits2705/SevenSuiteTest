using Seveclie.Domain.Entities;
using Seveclie.Domain.Interfaces;

namespace Seveclie.Application.Services
{
    public class AuthService
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public AuthService(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public Usuario Login(string username, string password)
        {
            return _usuarioRepo.Login(username, password);
        }
    }
}
