using Seveclie.Domain.Entities;
using System.Collections.Generic;

namespace Seveclie.Domain.Interfaces
{
    public interface IClienteRepository
    {
        void Insertar(Cliente cliente);
        void Actualizar(Cliente cliente);
        void Eliminar(int idCliente);
        List<Cliente> Consultar(string filtro);
        Cliente ObtenerPorId(int idCliente);
    }
}
