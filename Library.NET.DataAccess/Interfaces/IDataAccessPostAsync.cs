using Library.NET.Logging;

namespace Library.NET.DataAccess;

/// <summary>
/// Implements asynchronous post/insert functions. (Transactional post/insert functions can implement <see cref="ICustomLogger"/>. If you don't have one set up, skip it to create an error log to the console.)
/// </summary>
public interface IDataAccessPostAsync
{
    #region PostDataAsync

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    Task<int> PostDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string queryOrStoredProcedure, bool isStoredProcedure, int? commandTimeout) => await PostDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, commandTimeout);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database with no timeout.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string query, string connectionString) => await PostDataAsync(query, connectionString, false, null);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> with no timeout.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string query) => await PostDataAsync(query, StoredConnectionString.ConnectionString, false, null);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database with no timeout.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => await PostDataAsync(queryOrStoredProcedure, connectionString, isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> with no timeout.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string queryOrStoredProcedure, bool isStoredProcedure) => await PostDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string query, string connectionString, int? commandTimeout) => await PostDataAsync(query, connectionString, false, commandTimeout);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string query, int? commandTimeout) => await PostDataAsync(query, StoredConnectionString.ConnectionString, false, commandTimeout);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    Task<int> PostDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string queryOrStoredProcedure, T parameters, bool isStoredProcedure, int? commandTimeout) => await PostDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters, isStoredProcedure, commandTimeout);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string query, string connectionString, T parameters) => await PostDataAsync(query, connectionString, parameters, false, null);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string query, T parameters) => await PostDataAsync(query, StoredConnectionString.ConnectionString, parameters, false, null);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure) => await PostDataAsync(queryOrStoredProcedure, connectionString, parameters,
isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string queryOrStoredProcedure, T parameters, bool isStoredProcedure) => await PostDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters,
isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string query, string connectionString, T parameters, int? commandTimeout) => await PostDataAsync(query, connectionString, parameters, false, commandTimeout);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string query, T parameters, int? commandTimeout) => await PostDataAsync(query, StoredConnectionString.ConnectionString, parameters, false, commandTimeout);

    #endregion

    #region PostDataTransactionAsync

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commmandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commmandTimeout);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commmandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commmandTimeout) => await PostDataTransactionAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, logger, isStoredProcedure, commmandTimeout);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using parameters and a default <see cref="ICustomLogger"/>.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commmandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, bool isStoredProcedure, int? commmandTimeout) => await PostDataTransactionAsync(queryOrStoredProcedure, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, commmandTimeout);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/>.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commmandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, bool isStoredProcedure, int? commmandTimeout) => await PostDataTransactionAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, commmandTimeout);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure) => await PostDataTransactionAsync(queryOrStoredProcedure, connectionString, data, logger, isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure) => await PostDataTransactionAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, logger, isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, bool isStoredProcedure) => await PostDataTransactionAsync(queryOrStoredProcedure, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, bool isStoredProcedure) => await PostDataTransactionAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string query, string connectionString, IEnumerable<T> data, ICustomLogger logger, int? commandTimeout) => await PostDataTransactionAsync(query, connectionString, data, logger, false, commandTimeout);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string query, IEnumerable<T> data, ICustomLogger logger, int? commandTimeout) => await PostDataTransactionAsync(query, StoredConnectionString.ConnectionString, data, logger, false, commandTimeout);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string query, string connectionString, IEnumerable<T> data, int? commandTimeout) => await PostDataTransactionAsync(query, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), false, commandTimeout);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string query, IEnumerable<T> data, int? commandTimeout) => await PostDataTransactionAsync(query, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), false, commandTimeout);

    #endregion

    #region PostDataTransactionForEachAsync

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commmandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commmandTimeout);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commmandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commmandTimeout) => await PostDataTransactionForEachAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, logger, isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using parameters and a default <see cref="ICustomLogger"/>.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commmandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, bool isStoredProcedure, int? commmandTimeout) => await PostDataTransactionForEachAsync(queryOrStoredProcedure, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/>.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commmandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, bool isStoredProcedure, int? commmandTimeout) => await PostDataTransactionForEachAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure) => await PostDataTransactionForEachAsync(queryOrStoredProcedure, connectionString, data, logger, isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure) => await PostDataTransactionForEachAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, logger, isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, bool isStoredProcedure) => await PostDataTransactionForEachAsync(queryOrStoredProcedure, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, bool isStoredProcedure) => await PostDataTransactionForEachAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string query, string connectionString, IEnumerable<T> data, ICustomLogger logger, int? commandTimeout) => await PostDataTransactionForEachAsync(query, connectionString, data, logger, false, commandTimeout);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string query, IEnumerable<T> data, ICustomLogger logger, int? commandTimeout) => await PostDataTransactionForEachAsync(query, StoredConnectionString.ConnectionString, data, logger, false, commandTimeout);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using parameters and a default <see cref="ICustomLogger"/>.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string query, string connectionString, IEnumerable<T> data, int? commandTimeout) => await PostDataTransactionForEachAsync(query, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), false, commandTimeout);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/>.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string query, IEnumerable<T> data, int? commandTimeout) => await PostDataTransactionForEachAsync(query, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), false, commandTimeout);

    #endregion
}