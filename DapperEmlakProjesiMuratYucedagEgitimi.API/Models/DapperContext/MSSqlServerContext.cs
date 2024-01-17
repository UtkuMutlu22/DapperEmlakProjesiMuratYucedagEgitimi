using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperEmlakProjesiMuratYucedagEgitimi.API.Models.DapperContext
{
    public class MSSqlServerContext
    {
        private readonly IConfiguration _configuration;
        private static string _connectionString;
        public MSSqlServerContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
