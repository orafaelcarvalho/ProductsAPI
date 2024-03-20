using Microsoft.Data.SqlClient;
using System.Data;

namespace ProductsAPI.Infra.DbSession
{
    public class DbSessionDapper : IDbSessionDapper
    {
        public IDbConnection Connection { get; }

        public DbSessionDapper()
        {
            Connection = new SqlConnection("Server=localhost;Database=Products;User Id=sa;Password=123456;");
            Connection.Open();
        }

        public void Dispose() => Connection?.Close();
    }
}
