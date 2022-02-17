namespace Library.NET.DataAccess;
public interface IDbDataAccessConnection
{
    bool TestConnection(string connectionString);
}