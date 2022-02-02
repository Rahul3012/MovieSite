namespace Movie.Data.Engine.Model
{
    using Movie.Data.Engine.Interface;
    using System.Data;
    using System.Data.SqlClient;

    public class SqlConnect : ISqlConnect
    {
        private readonly string _connectionString = string.Empty;

        public SqlConnect(string connectionString)
        {
            _connectionString = connectionString;   
        }
        public IDbConnection GetDbConnection()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
                throw new InvalidOperationException("Connection string is not valid");
            return new SqlConnection(_connectionString);
        }
    }
}
