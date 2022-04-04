namespace Library.NET.DataAccess;

/// <summary>
/// Used to connect to a database using OdbcConnection.
/// </summary>
public interface IOdbcDataAccess : IDataAccess, IDataAccessAsync, IDbDataAccessConnection { }