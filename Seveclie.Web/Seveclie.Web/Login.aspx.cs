using System;
using System.Web.Services;
using System.Web.Security;
using Seveclie.Application.Services;
using Seveclie.Infrastructure.Repositories;
using Seveclie.Domain.Entities;

namespace Seveclie.Web
{
    public partial class Login : System.Web.UI.Page
    {
        private static AuthService _authService =
            new AuthService(new UsuarioRepository());

        protected void Page_Load(object sender, EventArgs e)
        {
            // Si ya está autenticado, redirigir
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("Clientes.aspx");
            }
        }

        [WebMethod]
        public static bool Autenticar(string usuario, string password)
        {
            Usuario user = _authService.Login(usuario, password);

            if (user != null)
            {
                // Cookie de autenticación (Forms Auth)
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return true;
            }

            return false;
        }
    }
}
