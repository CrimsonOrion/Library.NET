using Library.NET.Logging;

namespace Library.NET.DataAccess;

public interface IDataAccessPostAsync
{
    Task<int> PostDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);
    async Task<int> PostDataAsync(string query, string connectionString) => await PostDataAsync(query, connectionString, false, null);
    async Task<int> PostDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => await PostDataAsync(queryOrStoredProcedure, connectionString, isStoredProcedure, null);
    async Task<int> PostDataAsync(string query, string connectionString, int? commandTimeout) => await PostDataAsync(query, connectionString, false, commandTimeout);

    Task<int> PostDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout);
    async Task<int> PostDataAsync<T>(string query, string connectionString, T parameters) => await PostDataAsync(query, connectionString, parameters, false, null);
    async Task<int> PostDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure) => await PostDataAsync(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null);
    async Task<int> PostDataAsync<T>(string query, string connectionString, T parameters, int? commandTimeout) => await PostDataAsync(query, connectionString, parameters, false, commandTimeout);

    Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commmandTimeout);
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure) => await PostDataTransactionAsync(queryOrStoredProcedure, connectionString, data, logger, isStoredProcedure, null);
    async Task<int> PostDataTransactionAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, int? commandTimeout) => await PostDataTransactionAsync(queryOrStoredProcedure, connectionString, data, logger, false, commandTimeout);
    Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure, int? commmandTimeout);
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, bool isStoredProcedure) => await PostDataTransactionForEachAsync(queryOrStoredProcedure, connectionString, data, logger, isStoredProcedure, null);
    async Task<int> PostDataTransactionForEachAsync<T>(string queryOrStoredProcedure, string connectionString, IEnumerable<T> data, ICustomLogger logger, int? commandTimeout) => await PostDataTransactionForEachAsync(queryOrStoredProcedure, connectionString, data, logger, false, commandTimeout);
}