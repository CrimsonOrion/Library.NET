namespace Library.NET.DataAccess;

/// <summary>
/// Implements all synchronous interfaces.
/// </summary>
public interface IDataAccess : IDataAccessGet, IDataAccessPost, IDataAccessPut, IDataAccessDelete { }