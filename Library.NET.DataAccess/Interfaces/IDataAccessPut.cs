namespace Library.NET.DataAccess;

/// <summary>
/// Implements synchronous put/update functions.
/// </summary>
public interface IDataAccessPut
{
    /// <summary>
    /// Executes a procedure for updating data in the database.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int PutData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);

    /// <summary>
    /// Executes a procedure for updating data in the database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int PutData(string queryOrStoredProcedure, bool isStoredProcedure, int? commandTimeout) => PutData(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, commandTimeout);

    /// <summary>
    /// Executes a procedure for updating data in the database with no timeout.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <returns>Number of affected rows</returns>
    int PutData(string query, string connectionString) => PutData(query, connectionString, false, null);

    /// <summary>
    /// Executes a procedure for updating data in the database using <see cref="StoredConnectionString.ConnectionString"/> and no timeout.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <returns>Number of affected rows</returns>
    int PutData(string query) => PutData(query, StoredConnectionString.ConnectionString, false, null);

    /// <summary>
    /// Executes a procedure for updating data in the database with no timeout.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    int PutData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => PutData(queryOrStoredProcedure, connectionString, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for updating data in the database using <see cref="StoredConnectionString.ConnectionString"/> and no timeout.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    int PutData(string queryOrStoredProcedure, bool isStoredProcedure) => PutData(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for updating data in the database.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int PutData(string query, string connectionString, int? commandTimeout) => PutData(query, connectionString, false, commandTimeout);

    /// <summary>
    /// Executes a procedure for updating data in the database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int PutData(string query, int? commandTimeout) => PutData(query, StoredConnectionString.ConnectionString, false, commandTimeout);

    /// <summary>
    /// Executes a procedure for updating data in the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int PutData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout);

    /// <summary>
    /// Executes a procedure for updating data in the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int PutData<T>(string queryOrStoredProcedure, T parameters, bool isStoredProcedure, int? commandTimeout) => PutData(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters, isStoredProcedure, commandTimeout);

    /// <summary>
    /// Executes a procedure for updating data in the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    int PutData<T>(string query, string connectionString, T parameters) => PutData(query, connectionString, parameters, false, null);

    /// <summary>
    /// Executes a procedure for updating data in the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    int PutData<T>(string query, T parameters) => PutData(query, StoredConnectionString.ConnectionString, parameters, false, null);

    /// <summary>
    /// Executes a procedure for updating data in the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    int PutData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure) => PutData(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for updating data in the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    int PutData<T>(string queryOrStoredProcedure, T parameters, bool isStoredProcedure) => PutData(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for updating data in the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int PutData<T>(string query, string connectionString, T parameters, int? commandTimeout) => PutData(query, connectionString, parameters, false, commandTimeout);

    /// <summary>
    /// Executes a procedure for updating data in the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int PutData<T>(string query, T parameters, int? commandTimeout) => PutData(query, StoredConnectionString.ConnectionString, parameters, false, commandTimeout);
}