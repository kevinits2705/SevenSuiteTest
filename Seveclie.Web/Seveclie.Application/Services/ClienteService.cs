using Seveclie.Domain.Entities;
using Seveclie.Domain.Interfaces;
using System.Collections.Generic;

namespace Seveclie.Application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepo;

        public ClienteService(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public void Guardar(Cliente cliente)
        {
            if (cliente.IdCliente == 0)
                _clienteRepo.Insertar(cliente);
            else
                _clienteRepo.Actualizar(cliente);
        }

        public void Eliminar(int idCliente)
        {
            _clienteRepo.Eliminar(idCliente);
        }

        public List<Cliente> Consultar(string filtro)
        {
            return _clienteRepo.Consultar(filtro);
        }

        public Cliente ObtenerPorId(int idCliente)
        {
            return _clienteRepo.ObtenerPorId(idCliente);
        }
    }
}
