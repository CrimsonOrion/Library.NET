namespace Library.NET.DataAccess;

/// <summary>
/// Used to connect to a database using SqlConnection.
/// </summary>
public interface ISqlDataAccess : IDataAccess, IDataAccessAsync, IDbDataAccessConnection { }