using Npgsql;
using System.Data;

namespace DbViewChallenge.Api.Infrastructure.Context;

public class DBcontext
{
    private readonly string _connectionString;

    public DBcontext(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }
    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}