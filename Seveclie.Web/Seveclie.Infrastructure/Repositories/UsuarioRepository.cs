using System.Data.SqlClient;
using Seveclie.Domain.Entities;
using Seveclie.Domain.Interfaces;
using Seveclie.Infrastructure.Db;

namespace Seveclie.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario Login(string username, string password)
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Usuarios WHERE Username=@u AND Password=@p", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Usuario
                        {
                            IdUsuario = (int)dr["IdUsuario"],
                            Username = dr["Username"].ToString()
                        };
                    }
                }
            }

            return null;
        }
    }
}
