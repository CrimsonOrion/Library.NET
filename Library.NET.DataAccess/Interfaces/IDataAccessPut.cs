namespace Library.NET.DataAccess;

public interface IDataAccessPut
{
    int PutData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);
    int PutData(string query, string connectionString) => PutData(query, connectionString, false, null);
    int PutData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => PutData(queryOrStoredProcedure, connectionString, isStoredProcedure, null);
    int PutData(string query, string connectionString, int? commandTimeout) => PutData(query, connectionString, false, commandTimeout);

    int PutData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout);
    int PutData<T>(string query, string connectionString, T parameters) => PutData(query, connectionString, parameters, false, null);
    int PutData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure) => PutData(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null);
    int PutData<T>(string query, string connectionString, T parameters, int? commandTimeout) => PutData(query, connectionString, parameters, false, commandTimeout);
}