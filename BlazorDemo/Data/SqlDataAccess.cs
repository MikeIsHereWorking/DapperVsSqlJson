using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlazorDemo.Data;

public class SqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<string> LoadDataAsyncNonList(string sql, object parameters)
    {
        string? connectionString = _config.GetConnectionString("Default");
        object json;
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(
                     sql, (SqlConnection)connection);
            //command.Parameters.AddRange(parameters);
            connection.Open();
            json = await command.ExecuteScalarAsync();
        }

        return json.ToString();
    }

    public async Task<List<T>> LoadDataAsync<T, U>(string sql, U parameters)
    {
        string? connectionString = _config.GetConnectionString("Default");

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var rows = await connection.QueryAsync<T>(sql, parameters);
            return rows.ToList();
        }
    }

    public Task SaveData<T>(string sql, T parameters)
    {
        string? connectionString = _config.GetConnectionString("Default");

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            return connection.ExecuteAsync(sql, parameters);
        }
    }
}
