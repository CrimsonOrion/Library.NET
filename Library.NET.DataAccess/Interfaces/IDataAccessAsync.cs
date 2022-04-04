namespace Library.NET.DataAccess;

/// <summary>
/// Implements all asynchronous interfaces.
/// </summary>
public interface IDataAccessAsync : IDataAccessGetAsync, IDataAccessPostAsync, IDataAccessPutAsync, IDataAccessDeleteAsync { }