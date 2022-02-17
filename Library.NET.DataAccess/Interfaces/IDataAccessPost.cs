namespace Library.NET.DataAccess;

public interface IDataAccessPost
{
    int PostData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure, int? commandTimeout);
    int PostData(string query, string connectionString) => PostData(query, connectionString, false, null);
    int PostData(string queryOrStoredProcedure, string connectionString, bool isStoredProcedure) => PostData(queryOrStoredProcedure, connectionString, isStoredProcedure, null);
    int PostData(string query, string connectionString, int? commandTimeout) => PostData(query, connectionString, false, commandTimeout);

    int PostData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure, int? commandTimeout);
    int PostData<T>(string query, string connectionString, T parameters) => PostData(query, connectionString, parameters, false, null);
    int PostData<T>(string queryOrStoredProcedure, string connectionString, T parameters, bool isStoredProcedure) => PostData(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, null);
    int PostData<T>(string query, string connectionString, T parameters, int? commandTimeout) => PostData(query, connectionString, parameters, false, commandTimeout);
}