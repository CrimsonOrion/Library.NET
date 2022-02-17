namespace Library.NET.DataAccess;

public interface IDataAccessGetAsync
{
    Task<IEnumerable<T>> GetDataAsync<T>(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);
    async Task<IEnumerable<T>> GetDataAsync<T>(string query, string connectionString) => await GetDataAsync<T>(query, connectionString, false, null);
    async Task<IEnumerable<T>> GetDataAsync<T>(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => await GetDataAsync<T>(queryOrStoredProcedure, connectionString, isStoredProcedure, null);
    async Task<IEnumerable<T>> GetDataAsync<T>(string query, string connectionString, int? commandTimeout) => await GetDataAsync<T>(query, connectionString, false, commandTimeout);

    Task<IEnumerable<T>> GetDataAsync<T, U>(string queryOrStoredProcedure, string connectionString, U parameters, bool isStoredProcedure, int? commandTimeout);
    async Task<IEnumerable<T>> GetDataAsync<T, U>(string query, string connectionString, U parameters) => await GetDataAsync<T, U>(query, connectionString, parameters, false, null);
    async Task<IEnumerable<T>> GetDataAsync<T, U>(string queryOrStoredProcedure, string connectionString, U parameters, bool isStoredProcedure) => await GetDataAsync<T, U>(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null);
    async Task<IEnumerable<T>> GetDataAsync<T, U>(string query, string connectionString, U parameters, int? commandTimeout) => await GetDataAsync<T, U>(query, connectionString, parameters, false, commandTimeout);
}