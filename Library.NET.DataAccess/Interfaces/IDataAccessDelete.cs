namespace Library.NET.DataAccess;

public interface IDataAccessDelete
{
    int DeleteData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);
    int DeleteData(string query, string connectionString) => DeleteData(query, connectionString, false, null);
    int DeleteData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => DeleteData(queryOrStoredProcedure, connectionString, isStoredProcedure, null);
    int DeleteData(string query, string connectionString, int? commandTimeout) => DeleteData(query, connectionString, false, commandTimeout);

    int DeleteData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout);
    int DeleteData<T>(string query, string connectionString, T parameters) => DeleteData(query, connectionString, parameters, false, null);
    int DeleteData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure) => DeleteData(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null);
    int DeleteData<T>(string query, string connectionString, T parameters, int? commandTimeout) => DeleteData(query, connectionString, parameters, false, commandTimeout);
}