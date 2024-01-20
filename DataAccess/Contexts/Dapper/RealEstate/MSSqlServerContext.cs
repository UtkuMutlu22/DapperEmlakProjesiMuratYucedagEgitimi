using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Models.ConfigurationModels;
using System.Data;

namespace DataAccess.Contexts.Dapper.RealEstate
{
    public class MSSqlServerContext
    {
        private static RealStateConfiguration _configuration;
        private static string _connectionString;
        public MSSqlServerContext(IOptions<RealStateConfiguration> configuration)
        {
            _configuration = configuration.Value;
            _connectionString = _configuration.ConnectionString;
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
