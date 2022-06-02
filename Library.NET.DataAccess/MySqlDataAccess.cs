﻿using MySql.Data.MySqlClient;

using System.Data;

namespace Library.NET.DataAccess;
// <summary>
/// Data Access class with synchronous and asynchronous CRUD methods to connect to a MySQL database.
/// </summary>
public class MySqlDataAccess : ISqlDataAccess
{
    public IEnumerable<T> GetData<T>(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new MySqlConnection(connectionString);
        IEnumerable<T> rows = isStoredProcedure ?
            conn.Query<T>(queryOrStoredProcedure, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
            conn.Query<T>(queryOrStoredProcedure, commandTimeout: commandTimeout);

        return rows;
    }
    public IEnumerable<T> GetData<T, U>(string queryOrStoredProcedure, string connectionString, U parameters, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new MySqlConnection(connectionString);
        IEnumerable<T> rows = isStoredProcedure ?
            conn.Query<T>(queryOrStoredProcedure, GetParameters(parameters), commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
            conn.Query<T>(queryOrStoredProcedure, commandTimeout: commandTimeout);

        return rows;
    }

    public int PostData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new MySqlConnection(connectionString);
        return isStoredProcedure ?
            conn.Execute(queryOrStoredProcedure, commandType: CommandType.StoredProcedure) :
            conn.Execute(queryOrStoredProcedure, commandTimeout: commandTimeout);
    }

    public int PostData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new MySqlConnection(connectionString);
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
        using IDbConnection conn = new MySqlConnection(connectionString);
        IEnumerable<T> rows = isStoredProcedure ?
            await conn.QueryAsync<T>(queryOrStoredProcedure, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
            await conn.QueryAsync<T>(queryOrStoredProcedure, commandTimeout: commandTimeout);

        return rows;
    }

    public async Task<IEnumerable<T>> GetDataAsync<T, U>(string queryOrStoredProcedure, string connectionString, U parameters, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new MySqlConnection(connectionString);
        IEnumerable<T> rows = isStoredProcedure ?
            await conn.QueryAsync<T>(queryOrStoredProcedure, GetParameters(parameters), commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
            await conn.QueryAsync<T>(queryOrStoredProcedure, commandTimeout: commandTimeout);

        return rows;
    }

    public async Task<int> PostDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new MySqlConnection(connectionString);
        return isStoredProcedure ?
            await conn.ExecuteAsync(queryOrStoredProcedure, commandType: CommandType.StoredProcedure) :
            await conn.ExecuteAsync(queryOrStoredProcedure, commandTimeout: commandTimeout);
    }

    public async Task<int> PostDataAsync<T>(string queryOrStoredProcedure, string connectionString, T data, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new MySqlConnection(connectionString);
        return isStoredProcedure ?
            await conn.ExecuteAsync(queryOrStoredProcedure, data, commandType: CommandType.StoredProcedure) :
            await conn.ExecuteAsync(queryOrStoredProcedure, data, commandTimeout: commandTimeout);
    }

    public async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        IDbTransaction trans = conn.BeginTransaction();
        var affectedRecords = 0;
        try
        {
            affectedRecords += isStoredProcedure ?
                await conn.ExecuteAsync(queryOrStoredProcedure, data, transaction: trans, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
                await conn.ExecuteAsync(queryOrStoredProcedure, data, transaction: trans, commandTimeout: commandTimeout);
        }
        catch (MySqlException ex)
        {
            logger.LogError(ex, "Error in Post");
        }
        trans.Commit();
        return affectedRecords;
    }

    public async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commandTimeout)
    {
        using IDbConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        IDbTransaction trans = conn.BeginTransaction();
        var affectedRecords = 0;
        foreach (T item in data)
        {
            try
            {
                affectedRecords += isStoredProcedure ?
                    await conn.ExecuteAsync(queryOrStoredProcedure, item, transaction: trans, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout) :
                    await conn.ExecuteAsync(queryOrStoredProcedure, item, transaction: trans, commandTimeout: commandTimeout);
            }
            catch (MySqlException ex)
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
        using IDbConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        return conn.State == ConnectionState.Open;
    }

    /// <summary>
    /// Creates new <see cref="DynamicParameters"/> with parameters
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="parameters">Parameters for the stored procedure or query</param>
    /// <returns><see cref="DynamicParameters"/> to be inserted into the query or stored procedure</returns>
    private static DynamicParameters GetParameters<T>(T parameters)
    {
        if (parameters != null)
        {
            DynamicParameters p = new();

            if (parameters is IDictionary<string, dynamic> dictionary)
            {
                foreach (KeyValuePair<string, dynamic> para in dictionary)
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