namespace Library.NET.DataAccess;

/// <summary>
/// Implements asynchronous delete functions.
/// </summary>
public interface IDataAccessDeleteAsync
{
    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    Task<int> DeleteDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout, CancellationToken token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync(string queryOrStoredProcedure, bool isStoredProcedure, int? commandTimeout, CancellationToken token)
        => await DeleteDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database with no timeout.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync(string query, string connectionString, CancellationToken token)
        => await DeleteDataAsync(query, connectionString, false, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and no timeout.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync(string query, CancellationToken token)
        => await DeleteDataAsync(query, StoredConnectionString.ConnectionString, false, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database with no timeout.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, CancellationToken token)
        => await DeleteDataAsync(queryOrStoredProcedure, connectionString, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and no timeout.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync(string queryOrStoredProcedure, bool isStoredProcedure, CancellationToken token)
        => await DeleteDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync(string query, string connectionString, int? commandTimeout, CancellationToken token)
        => await DeleteDataAsync(query, connectionString, false, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and no timeout.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync(string query, int? commandTimeout, CancellationToken token)
        => await DeleteDataAsync(query, StoredConnectionString.ConnectionString, false, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    Task<int> DeleteDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout, CancellationToken token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync<T>(string queryOrStoredProcedure, T parameters, bool isStoredProcedure, int? commandTimeout, CancellationToken token)
        => await DeleteDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters, isStoredProcedure, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using parameters and no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync<T>(string query, string connectionString, T parameters, CancellationToken token)
        => await DeleteDataAsync(query, connectionString, parameters, false, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync<T>(string query, T parameters, CancellationToken token)
        => await DeleteDataAsync(query, StoredConnectionString.ConnectionString, parameters, false, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, CancellationToken token)
        => await DeleteDataAsync(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync<T>(string queryOrStoredProcedure, T parameters, bool isStoredProcedure, CancellationToken token)
        => await DeleteDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync<T>(string query, string connectionString, T parameters, int? commandTimeout, CancellationToken token)
        => await DeleteDataAsync(query, connectionString, parameters, false, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> DeleteDataAsync<T>(string query, T parameters, int? commandTimeout, CancellationToken token)
        => await DeleteDataAsync(query, StoredConnectionString.ConnectionString, parameters, false, commandTimeout, token);
}