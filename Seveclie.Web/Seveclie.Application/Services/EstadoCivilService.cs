using System.Collections.Generic;
using Seveclie.Domain.Entities;
using Seveclie.Domain.Interfaces;

namespace Seveclie.Application.Services
{
    public class EstadoCivilService
    {
        private readonly IEstadoCivilRepository _repo;

        public EstadoCivilService(IEstadoCivilRepository repo)
        {
            _repo = repo;
        }

        public List<EstadoCivil> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }
    }
}
