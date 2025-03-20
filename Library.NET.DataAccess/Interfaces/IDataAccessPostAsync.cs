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
    Task<int> PostDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout, CancellationToken token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string queryOrStoredProcedure, bool isStoredProcedure, int? commandTimeout, CancellationToken token)
        => await PostDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database with no timeout.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string query, string connectionString, CancellationToken token)
        => await PostDataAsync(query, connectionString, false, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> with no timeout.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string query, CancellationToken token)
        => await PostDataAsync(query, StoredConnectionString.ConnectionString, false, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database with no timeout.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, CancellationToken token)
        => await PostDataAsync(queryOrStoredProcedure, connectionString, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> with no timeout.
    /// </summary>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string queryOrStoredProcedure, bool isStoredProcedure, CancellationToken token)
        => await PostDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string query, string connectionString, int? commandTimeout, CancellationToken token)
        => await PostDataAsync(query, connectionString, false, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync(string query, int? commandTimeout, CancellationToken token)
        => await PostDataAsync(query, StoredConnectionString.ConnectionString, false, commandTimeout, token);

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
    Task<int> PostDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout, CancellationToken token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string queryOrStoredProcedure, T parameters, bool isStoredProcedure, int? commandTimeout, CancellationToken token)
        => await PostDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters, isStoredProcedure, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string query, string connectionString, T parameters, CancellationToken token)
        => await PostDataAsync(query, connectionString, parameters, false, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string query, T parameters, CancellationToken token)
        => await PostDataAsync(query, StoredConnectionString.ConnectionString, parameters, false, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, CancellationToken token)
        => await PostDataAsync(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string queryOrStoredProcedure, T parameters, bool isStoredProcedure, CancellationToken token)
        => await PostDataAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, parameters, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string query, string connectionString, T parameters, int? commandTimeout, CancellationToken token)
        => await PostDataAsync(query, connectionString, parameters, false, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="parameters"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="parameters">parameters where type is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataAsync<T>(string query, T parameters, int? commandTimeout, CancellationToken token)
        => await PostDataAsync(query, StoredConnectionString.ConnectionString, parameters, false, commandTimeout, token);

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
    Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commmandTimeout, CancellationToken token);

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
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commmandTimeout, CancellationToken token)
        => await PostDataTransactionAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, logger, isStoredProcedure, commmandTimeout, token);

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
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, bool isStoredProcedure, int? commmandTimeout, CancellationToken token)
        => await PostDataTransactionAsync(queryOrStoredProcedure, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, commmandTimeout, token);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/>.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commmandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, bool isStoredProcedure, int? commmandTimeout, CancellationToken token) => await PostDataTransactionAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, commmandTimeout, token);

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
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, CancellationToken token)
        => await PostDataTransactionAsync(queryOrStoredProcedure, connectionString, data, logger, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, CancellationToken token)
        => await PostDataTransactionAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, logger, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, bool isStoredProcedure, CancellationToken token)
        => await PostDataTransactionAsync(queryOrStoredProcedure, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, bool isStoredProcedure, CancellationToken token)
        => await PostDataTransactionAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string query, string connectionString, IEnumerable<T> data, ICustomLogger logger, int? commandTimeout, CancellationToken token)
        => await PostDataTransactionAsync(query, connectionString, data, logger, false, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string query, IEnumerable<T> data, ICustomLogger logger, int? commandTimeout, CancellationToken token)
        => await PostDataTransactionAsync(query, StoredConnectionString.ConnectionString, data, logger, false, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string query, string connectionString, IEnumerable<T> data, int? commandTimeout, CancellationToken token)
        => await PostDataTransactionAsync(query, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), false, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous transactional procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionAsync<T>(string query, IEnumerable<T> data, int? commandTimeout, CancellationToken token)
        => await PostDataTransactionAsync(query, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), false, commandTimeout, token);

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
    Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commmandTimeout, CancellationToken token);

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
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commmandTimeout, CancellationToken token)
        => await PostDataTransactionForEachAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, logger, isStoredProcedure, null, token);

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
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, bool isStoredProcedure, int? commmandTimeout, CancellationToken token)
        => await PostDataTransactionForEachAsync(queryOrStoredProcedure, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/>.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <param name="commmandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, bool isStoredProcedure, int? commmandTimeout, CancellationToken token)
        => await PostDataTransactionForEachAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null, token);

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
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, CancellationToken token)
        => await PostDataTransactionForEachAsync(queryOrStoredProcedure, connectionString, data, logger, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, CancellationToken token)
        => await PostDataTransactionForEachAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, logger, isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, bool isStoredProcedure, CancellationToken token)
        => await PostDataTransactionForEachAsync(queryOrStoredProcedure, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null, token);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/> with no timeout.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="queryOrStoredProcedure">Query string or Stored Procedure name</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="isStoredProcedure">Is the <paramref name="queryOrStoredProcedure"/> a stored procedure?</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, IEnumerable<T> data, bool isStoredProcedure, CancellationToken token)
        => await PostDataTransactionForEachAsync(queryOrStoredProcedure, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), isStoredProcedure, null, token);

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
    async Task<int> PostDataTransactionForEachAsync<T>(string query, string connectionString, IEnumerable<T> data, ICustomLogger logger, int? commandTimeout, CancellationToken token)
        => await PostDataTransactionForEachAsync(query, connectionString, data, logger, false, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/> and parameters.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="logger"><see cref="ICustomLogger"/> instance for error logging</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string query, IEnumerable<T> data, ICustomLogger logger, int? commandTimeout, CancellationToken token)
        => await PostDataTransactionForEachAsync(query, StoredConnectionString.ConnectionString, data, logger, false, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using parameters and a default <see cref="ICustomLogger"/>.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="connectionString">Connection string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string query, string connectionString, IEnumerable<T> data, int? commandTimeout, CancellationToken token)
        => await PostDataTransactionForEachAsync(query, connectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), false, commandTimeout, token);

    /// <summary>
    /// Executes an asynchronous transactional iteration procedure for posting/inserting data into the database using <see cref="StoredConnectionString.ConnectionString"/>, parameters and a default <see cref="ICustomLogger"/>.
    /// </summary>
    /// <typeparam name="T">Type for <paramref name="data"/></typeparam>
    /// <param name="query">Query string</param>
    /// <param name="data"><see cref="IEnumerable{T}"/> where T is <see cref="Dapper.DynamicParameters"/> or <see cref="IDictionary{TKey, TValue}"/> with 'key' string and 'value' object</param>
    /// <param name="commandTimeout">How long before the query times out in seconds</param>
    /// <returns>Number of affected rows</returns>
    async Task<int> PostDataTransactionForEachAsync<T>(string query, IEnumerable<T> data, int? commandTimeout, CancellationToken token)
        => await PostDataTransactionForEachAsync(query, StoredConnectionString.ConnectionString, data, new CustomLogger(new(Path.GetTempFileName()), true, Logging.LogLevel.Information), false, commandTimeout, token);

    #endregion
}