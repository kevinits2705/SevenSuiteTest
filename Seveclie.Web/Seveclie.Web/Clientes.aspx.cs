using System;
using System.Collections.Generic;
using System.Web.Services;
using Seveclie.Application.Services;
using Seveclie.Infrastructure.Repositories;
using System.Web.Security;

namespace Seveclie.Web
{
    public partial class Clientes : System.Web.UI.Page
    {
        private static ClienteService _clienteService =
            new ClienteService(new ClienteRepository());

        private static EstadoCivilService _estadoCivilService =
            new EstadoCivilService(new EstadoCivilRepository());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static List<EstadoCivilDto> EstadosCivil()
        {
            var estados = _estadoCivilService.ObtenerTodos();
            var lista = new List<EstadoCivilDto>();

            foreach (var e in estados)
            {
                lista.Add(new EstadoCivilDto
                {
                    IdEstadoCivil = e.IdEstadoCivil,
                    Descripcion = e.Descripcion
                });
            }

            return lista;
        }

        [WebMethod]
        public static List<ClienteDto> Consultar(string filtro)
        {
            var clientes = _clienteService.Consultar(filtro);
            var lista = new List<ClienteDto>();

            foreach (var c in clientes)
            {
                lista.Add(new ClienteDto
                {
                    IdCliente = c.IdCliente,
                    Cedula = c.Cedula,
                    Nombre = c.Nombre,
                    Genero = c.Genero,
                    FechaNacimiento = c.FechaNacimiento.ToString("yyyy-MM-dd"),
                    EstadoCivil = c.EstadoCivil
                });
            }

            return lista;
        }

        [WebMethod]
        public static bool Guardar(ClienteDto dto)
        {
            try
            {
                var cliente = ClienteMapper.ToEntity(dto);
                _clienteService.Guardar(cliente);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public static bool Eliminar(int id)
        {
            try
            {
                _clienteService.Eliminar(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public static ClienteDto ObtenerPorId(int id)
        {
            var c = _clienteService.ObtenerPorId(id);
            if (c == null) return null;

            return new ClienteDto
            {
                IdCliente = c.IdCliente,
                Cedula = c.Cedula,
                Nombre = c.Nombre,
                Genero = c.Genero,
                FechaNacimiento = c.FechaNacimiento.ToString("yyyy-MM-dd"),
                EstadoCivilId = c.EstadoCivilId,
                EstadoCivil = c.EstadoCivil
            };
        }

        [WebMethod]
        public static void CerrarSesion()
        {
            FormsAuthentication.SignOut();
        }

    }
}