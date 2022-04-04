namespace Library.NET.DataAccess;

/// <summary>
/// Implements synchronous delete functions.
/// </summary>
public interface IDataAccessDelete
{
    /// <summary>
    /// Executes a procedure for deleting data from the database.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);

    /// <summary>
    /// Executes a procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData(string queryOrStoredProcedure, bool isStoredProcedure, int? commandTimeout) => DeleteData(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, commandTimeout);

    /// <summary>
    /// Executes a procedure for deleting data from the database with no timeout.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData(string query, string connectionString) => DeleteData(query, connectionString, false, null);

    /// <summary>
    /// Executes a procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and no timeout.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData(string query) => DeleteData(query, StoredConnectionString.ConnectionString, false, null);

    /// <summary>
    /// Executes a procedure for deleting data from the database with no timeout.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => DeleteData(queryOrStoredProcedure, connectionString, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and no timeout.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData(string queryOrStoredProcedure, bool isStoredProcedure) => DeleteData(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for deleting data from the database.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData(string query, string connectionString, int? commandTimeout) => DeleteData(query, connectionString, false, commandTimeout);

    /// <summary>
    /// Executes a procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData(string query, int? commandTimeout) => DeleteData(query, StoredConnectionString.ConnectionString, false, commandTimeout);

    /// <summary>
    /// Executes a procedure for deleting data from the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout);

    /// <summary>
    /// Executes a procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData<T>(string queryOrStoredProcedure, T parameters, bool isStoredProcedure, int? commandTimeout) => DeleteData(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters, isStoredProcedure, commandTimeout);

    /// <summary>
    /// Executes a procedure for deleting data from the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData<T>(string query, string connectionString, T parameters) => DeleteData(query, connectionString, parameters, false, null);

    /// <summary>
    /// Executes a procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData<T>(string query, T parameters) => DeleteData(query, StoredConnectionString.ConnectionString, parameters, false, null);

    /// <summary>
    /// Executes a procedure for deleting data from the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure) => DeleteData(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData<T>(string queryOrStoredProcedure, T parameters, bool isStoredProcedure) => DeleteData(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for deleting data from the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData<T>(string query, string connectionString, T parameters, int? commandTimeout) => DeleteData(query, connectionString, parameters, false, commandTimeout);

    /// <summary>
    /// Executes a procedure for deleting data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    int DeleteData<T>(string query, T parameters, int? commandTimeout) => DeleteData(query, StoredConnectionString.ConnectionString, parameters, false, commandTimeout);
}