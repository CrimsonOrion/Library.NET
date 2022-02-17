using Microsoft.Data.SqlClient;

namespace Library.NET.DataAccess.ConnectionStrings;
public class MsSqlConnectionStrings
{
    public static string ConnectionString(MsSqlConnection connection)
    {
        SqlConnectionStringBuilder connString = connection switch
        {
            MsSqlConnection.Home => new()
            {
                DataSource = "MySqlServer",
                InitialCatalog = "MySqlTable",
                IntegratedSecurity = true,
                TrustServerCertificate = true
            },
            _ => new()
        };

        return connString.ConnectionString;
    }
}
public enum MsSqlConnection
{
    Home
}