using ProvaCandidato.Utils.Environment;
using System.Data;
using System.Data.SqlClient;

namespace ProvaCandidato.Utils.Connections
{
    public class SqlServerConnection
    {
        protected readonly IDbConnection _db;

        public SqlServerConnection()
        {
            _db = new SqlConnection(ApiEnvironment.CnnDbProvaCandidato);
        }
    }
}
