namespace Library.NET.DataAccess.ConnectionStrings;

/// <summary>
/// Simple static class to hold your connection string.
/// </summary>
public static class StoredConnectionString
{
    /// <summary>
    /// Returns the connection string.
    /// </summary>
    public static string ConnectionString { get; private set; }

    /// <summary>
    /// Sets the connection string to <see cref="ConnectionString"/>.
    /// </summary>
    /// <param name="connectionString">Your connection string.</param>
    public static void SetConnectionString(string connectionString) => ConnectionString = connectionString;
}