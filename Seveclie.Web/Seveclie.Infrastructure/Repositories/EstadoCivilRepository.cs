using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Seveclie.Domain.Entities;
using Seveclie.Domain.Interfaces;
using Seveclie.Infrastructure.Db;

namespace Seveclie.Infrastructure.Repositories
{
    public class EstadoCivilRepository : IEstadoCivilRepository
    {
        public List<EstadoCivil> ObtenerTodos()
        {
            List<EstadoCivil> lista = new List<EstadoCivil>();

            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM EstadoCivil", conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new EstadoCivil
                        {
                            IdEstadoCivil = Convert.ToInt32(dr["IdEstadoCivil"]),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
