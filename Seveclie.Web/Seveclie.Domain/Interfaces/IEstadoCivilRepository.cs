using Seveclie.Domain.Entities;
using System.Collections.Generic;

namespace Seveclie.Domain.Interfaces
{
    public interface IEstadoCivilRepository
    {
        List<EstadoCivil> ObtenerTodos();
    }
}
