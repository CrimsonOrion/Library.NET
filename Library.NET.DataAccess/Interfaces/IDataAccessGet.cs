namespace Library.NET.DataAccess;

public interface IDataAccessGet
{
    IEnumerable<T> GetData<T>(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);
    IEnumerable<T> GetData<T>(string query, string connectionString) => GetData<T>(query, connectionString, false, null);
    IEnumerable<T> GetData<T>(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => GetData<T>(queryOrStoredProcedure, connectionString, isStoredProcedure, null);
    IEnumerable<T> GetData<T>(string query, string connectionString, int? commandTimeout) => GetData<T>(query, connectionString, false, commandTimeout);

    IEnumerable<T> GetData<T, U>(string queryOrStoredProcedure, string connectionString, U parameters, bool isStoredProcedure, int? commandTimeout);
    IEnumerable<T> GetData<T, U>(string query, string connectionString, U parameters) => GetData<T, U>(query, connectionString, parameters, false, null);
    IEnumerable<T> GetData<T, U>(string queryOrStoredProcedure, string connectionString, U parameters, bool isStoredProcedure) => GetData<T, U>(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null);
    IEnumerable<T> GetData<T, U>(string query, string connectionString, U parameters, int? commandTimeout) => GetData<T, U>(query, connectionString, parameters, false, commandTimeout);
}