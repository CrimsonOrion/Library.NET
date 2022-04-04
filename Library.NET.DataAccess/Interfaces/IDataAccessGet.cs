namespace Library.NET.DataAccess;

/// <summary>
/// Implements synchronous get/retrieve functions.
/// </summary>
public interface IDataAccessGet
{
    /// <summary>
    /// Executes a procedure for retrieving data from the database.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T>(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T>(string queryOrStoredProcedure, bool isStoredProcedure, int? commandTimeout) => GetData<T>(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, commandTimeout);

    /// <summary>
    /// Executes a procedure for retrieving data from the database with no timeout.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T>(string query, string connectionString) => GetData<T>(query, connectionString, false, null);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using <see cref="StoredConnectionString.ConnectionString"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <param name="query">Query string</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T>(string query) => GetData<T>(query, StoredConnectionString.ConnectionString, false, null);

    /// <summary>
    /// Executes a procedure for retrieving data from the database with no timeout.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T>(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => GetData<T>(queryOrStoredProcedure, connectionString, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using <see cref="StoredConnectionString.ConnectionString"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T>(string queryOrStoredProcedure, bool isStoredProcedure) => GetData<T>(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for retrieving data from the database.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T>(string query, string connectionString, int? commandTimeout) => GetData<T>(query, connectionString, false, commandTimeout);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <param name="query">Query string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T>(string query, int? commandTimeout) => GetData<T>(query, StoredConnectionString.ConnectionString, false, commandTimeout);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using parameters.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <typeparam name="U">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T, U>(string queryOrStoredProcedure, string connectionString, U parameters, bool isStoredProcedure, int? commandTimeout);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <typeparam name="U">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T, U>(string queryOrStoredProcedure, U parameters, bool isStoredProcedure, int? commandTimeout) => GetData<T, U>(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters, isStoredProcedure, commandTimeout);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <typeparam name="U">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T, U>(string query, string connectionString, U parameters) => GetData<T, U>(query, connectionString, parameters, false, null);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <typeparam name="U">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T, U>(string query, U parameters) => GetData<T, U>(query, StoredConnectionString.ConnectionString, parameters, false, null);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <typeparam name="U">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T, U>(string queryOrStoredProcedure, string connectionString, U parameters, bool isStoredProcedure) => GetData<T, U>(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <typeparam name="U">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T, U>(string queryOrStoredProcedure, U parameters, bool isStoredProcedure) => GetData<T, U>(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters, isStoredProcedure, null);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using parameters.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <typeparam name="U">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T, U>(string query, string connectionString, U parameters, int? commandTimeout) => GetData<T, U>(query, connectionString, parameters, false, commandTimeout);

    /// <summary>
    /// Executes a procedure for retrieving data from the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <typeparam name="U">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Enumerable set of type <typeparamref name="T"/></returns>
    IEnumerable<T> GetData<T, U>(string query, U parameters, int? commandTimeout) => GetData<T, U>(query, StoredConnectionString.ConnectionString, parameters, false, commandTimeout);
}