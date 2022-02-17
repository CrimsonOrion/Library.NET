using Dapper;

using Library.NET.Logging;

using System.Data;
using System.Data.Odbc;

namespace Library.NET.DataAccess;
public class OdbcDataAccess : IOdbcDataAccess
{
    public IEnumerable<T> GetData<T>(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new OdbcConnection(connectionString);
        var rows = isStoredProcedure ?
            conn.Query<T>(queryOrStoredProcedure, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
            conn.Query<T>(queryOrStoredProcedure, commandTimeout: commandTimeout);

        return rows;
    }

    public IEnumerable<T> GetData<T, U>(string queryOrStoredProcedure, string connectionString, U parameters, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new OdbcConnection(connectionString);
        var rows = isStoredProcedure ?
            conn.Query<T>(queryOrStoredProcedure, GetParameters(parameters), commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
            conn.Query<T>(queryOrStoredProcedure, commandTimeout: commandTimeout);

        return rows;
    }

    public int PostData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new OdbcConnection(connectionString);
        return isStoredProcedure ?
            conn.Execute(queryOrStoredProcedure, commandType: CommandType.StoredProcedure) :
            conn.Execute(queryOrStoredProcedure, commandTimeout: commandTimeout);
    }

    public int PostData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new OdbcConnection(connectionString);
        return isStoredProcedure ?
            conn.Execute(queryOrStoredProcedure, GetParameters(parameters), commandType: CommandType.StoredProcedure) :
            conn.Execute(queryOrStoredProcedure, commandTimeout: commandTimeout);
    }

    public int PutData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout) => PostData(queryOrStoredProcedure, connectionString, isStoredProcedure, commandTimeout);

    public int PutData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout) => PostData(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, commandTimeout);

    public int DeleteData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout) => PostData(queryOrStoredProcedure, connectionString, isStoredProcedure, commandTimeout);

    public int DeleteData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout) => PostData(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, commandTimeout);

    public async Task<IEnumerable<T>> GetDataAsync<T>(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new OdbcConnection(connectionString);
        var rows = isStoredProcedure ?
            await conn.QueryAsync<T>(queryOrStoredProcedure, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
            await conn.QueryAsync<T>(queryOrStoredProcedure, commandTimeout: commandTimeout);

        return rows;
    }

    public async Task<IEnumerable<T>> GetDataAsync<T, U>(string queryOrStoredProcedure, string connectionString, U parameters, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new OdbcConnection(connectionString);
        var rows = isStoredProcedure ?
            await conn.QueryAsync<T>(queryOrStoredProcedure, GetParameters(parameters), commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
            await conn.QueryAsync<T>(queryOrStoredProcedure, commandTimeout: commandTimeout);

        return rows;
    }

    public async Task<int> PostDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new OdbcConnection(connectionString);
        return isStoredProcedure ?
            await conn.ExecuteAsync(queryOrStoredProcedure, commandType: CommandType.StoredProcedure) :
            await conn.ExecuteAsync(queryOrStoredProcedure, commandTimeout: commandTimeout);
    }

    public async Task<int> PostDataAsync<T>(string queryOrStoredProcedure, string connectionString, T data, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new OdbcConnection(connectionString);
        return isStoredProcedure ?
            await conn.ExecuteAsync(queryOrStoredProcedure, data, commandType: CommandType.StoredProcedure) :
            await conn.ExecuteAsync(queryOrStoredProcedure, data, commandTimeout: commandTimeout);
    }

    public async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new OdbcConnection(connectionString);
        conn.Open();
        var trans = conn.BeginTransaction();
        var affectedRecords = 0;
        try
        {
            affectedRecords += isStoredProcedure ?
                await conn.ExecuteAsync(queryOrStoredProcedure, data, transaction: trans, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
                await conn.ExecuteAsync(queryOrStoredProcedure, data, transaction: trans, commandTimeout: commandTimeout);
        }
        catch (OdbcException ex)
        {
            logger.LogError(ex, "Error in Post");
        }
        trans.Commit();
        return affectedRecords;
    }

    public async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new OdbcConnection(connectionString);
        conn.Open();
        var trans = conn.BeginTransaction();
        var affectedRecords = 0;
        foreach (var item in data)
        {
            try
            {
                affectedRecords += isStoredProcedure ?
                    await conn.ExecuteAsync(queryOrStoredProcedure, item, transaction: trans, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
                    await conn.ExecuteAsync(queryOrStoredProcedure, item, transaction: trans, commandTimeout: commandTimeout);
            }
            catch (OdbcException ex)
            {
                logger.LogError(ex, "Error in Post");
            }
        }
        trans.Commit();
        return affectedRecords;
    }

    public async Task<int> PutDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout) => await PostDataAsync(queryOrStoredProcedure, connectionString, isStoredProcedure, commandTimeout);

    public async Task<int> PutDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout) => await PostDataAsync(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, commandTimeout);

    public async Task<int> DeleteDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout) => await PostDataAsync(queryOrStoredProcedure, connectionString, isStoredProcedure, commandTimeout);

    public async Task<int> DeleteDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout) => await PostDataAsync(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, commandTimeout);

    public bool TestConnection(string connectionString)
    {
        using IDbConnection conn = new OdbcConnection(connectionString);
        conn.Open();
        return conn.State == ConnectionState.Open;
    }

    private static DynamicParameters GetParameters<T>(T parameters)
    {
        if (parameters != null)
        {
            var p = new DynamicParameters();

            if (parameters is IDictionary<string, dynamic> dictionary)
            {
                foreach (var para in dictionary)
                {
                    p.Add(para.Key, para.Value);
                }
            }
            else if (parameters is DynamicParameters)
            {
                p = new DynamicParameters(parameters);
            }

            return p;
        }
        else
        {
            return null;
        }
    }
}