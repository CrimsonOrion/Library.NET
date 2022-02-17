namespace Library.NET.DataAccess;

public interface IDataAccessDeleteAsync
{
    Task<int> DeleteDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);
    async Task<int> DeleteDataAsync(string query, string connectionString) => await DeleteDataAsync(query, connectionString, false, null);
    async Task<int> DeleteDataAsync(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => await DeleteDataAsync(queryOrStoredProcedure, connectionString, isStoredProcedure, null);
    async Task<int> DeleteDataAsync(string query, string connectionString, int? commandTimeout) => await DeleteDataAsync(query, connectionString, false, commandTimeout);

    Task<int> DeleteDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout);
    async Task<int> DeleteDataAsync<T>(string query, string connectionString, T parameters) => await DeleteDataAsync(query, connectionString, parameters, false, null);
    async Task<int> DeleteDataAsync<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure) => await DeleteDataAsync(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null);
    async Task<int> DeleteDataAsync<T>(string query, string connectionString, T parameters, int? commandTimeout) => await DeleteDataAsync(query, connectionString, parameters, false, commandTimeout);
}