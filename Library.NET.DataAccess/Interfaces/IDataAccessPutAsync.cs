namespace Library.NET.DataAccess;

public interface IDataAccessPutAsync
{
    Task<int> PutDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);
    async Task<int> PutDataAsync(string query, string connectionString) => await PutDataAsync(query, connectionString, false, null);
    async Task<int> PutDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => await PutDataAsync(queryOrStoredProcedure, connectionString, isStoredProcedure, null);
    async Task<int> PutDataAsync(string query, string connectionString, int? commandTimeout) => await PutDataAsync(query, connectionString, false, commandTimeout);

    Task<int> PutDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout);
    async Task<int> PutDataAsync<T>(string query, string connectionString, T parameters) => await PutDataAsync(query, connectionString, parameters, false, null);
    async Task<int> PutDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure) => await PutDataAsync(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null);
    async Task<int> PutDataAsync<T>(string query, string connectionString, T parameters, int? commandTimeout) => await PutDataAsync(query, connectionString, parameters, false, commandTimeout);
}