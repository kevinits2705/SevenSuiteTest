using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Seveclie.Domain.Entities;
using Seveclie.Domain.Interfaces;
using Seveclie.Infrastructure.Db;

namespace Seveclie.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public void Insertar(Cliente cliente)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_GuardarCliente", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdCliente", 0);
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Genero", cliente.Genero);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@IdEstadoCivil", cliente.EstadoCivilId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Cliente cliente)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_GuardarCliente", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Genero", cliente.Genero);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@IdEstadoCivil", cliente.EstadoCivilId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idCliente)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_EliminarCliente", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Cliente> Consultar(string filtro)
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_ConsultarClientes", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Filtro", filtro ?? "");

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Cliente
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Cedula = dr["Cedula"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Genero = dr["Genero"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                            EstadoCivilId = Convert.ToInt32(dr["IdEstadoCivil"]),
                            EstadoCivil = dr["EstadoCivil"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public Cliente ObtenerPorId(int idCliente)
        {
            Cliente cliente = null;

            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_ConsultarClientes", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Filtro", "");

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (Convert.ToInt32(dr["IdCliente"]) == idCliente)
                        {
                            cliente = new Cliente
                            {
                                IdCliente = idCliente,
                                Cedula = dr["Cedula"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Genero = dr["Genero"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                                EstadoCivilId = Convert.ToInt32(dr["IdEstadoCivil"])
                            };
                            break;
                        }
                    }
                }
            }

            return cliente;
        }
    }
}
