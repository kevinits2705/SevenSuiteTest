using System.Configuration;
using System.Data.SqlClient;

namespace Seveclie.Infrastructure.Db
{
    public static class DbConnectionFactory
    {
        public static SqlConnection Create()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            );
        }
    }
}
