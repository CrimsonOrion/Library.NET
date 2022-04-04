namespace Library.NET.DataAccess;

/// <summary>
/// Provides a means to test a connection to a database.
/// </summary>
public interface IDbDataAccessConnection
{
    /// <summary>
    /// Test a connection to a database.
    /// </summary>
    /// <param name="connectionString">Connection string</param>
    /// <returns>True if connection is successful; false if it is not successful</returns>
    bool TestConnection(string connectionString);

    /// <summary>
    /// Test a connection to a database using <see cref="StoredConnectionString.ConnectionString"/>.
    /// </summary>
    /// <returns>True if connection is successful; false if it is not successful</returns>
    bool TestConnection() => TestConnection(StoredConnectionString.ConnectionString);
}