# Library.NET.DataAccess

## Implementing ISqlDataAccess & IOdbcDataAccess

Set the *StoredConnectionString*:
### *StoredConnectionString* ###
``` cs
StoredConnectionString.SetConnectionString("Driver={IBM i Access ODBC Driver};System=AS400;TRANSLATE=1;SIGNON=4;SSL=1");
```

Create a new instance:
``` cs
IOdbcDataAccess odbcDataAccess = new OdbcDataAccess();
```

Get the data:
``` cs
var records = odbcDataAccess.GetData<int>("SELECT COUNT(*) FROM library.member");
Console.WriteLine("Result:" + records.FirstOrDefault());

Result: 100
```

## Implementing ICustomLogger (Optional)
You can use logging via the ICustomLogger ([Library.NET.Logging](https://github.com/CrimsonOrion/Library.NET/tree/main/Library.NET.Logging)) that comes with this package.

Use:
``` cs
ICustomLogger logger = new CustomLogger(new FileInfo("logfile.log"), true, LogLevel.Information);
```
You can then add it to DI as a singleton.

## Methods

### Options: ###
* `queryOrStoredProcedure`: Full query or Stored Procedure Name
* `connectionString`*(optional)*: Connection string for the query. Defaults to `StoredConnectionString.ConnectionString`.
* `parameters`*(optional)*: Parameters for the stored procedure. Type can be either `Dapper.DynamicParameter` or `Dictionary<string, object>`. Defaults to `null`.
* `isStoredProcedure`*(optional)*: Boolean confirming whether `queryOrStoredProcedure` is a stored procedure. Defaults to `false`.
* `commandTimeout`*(optional)*: How long before the query times out in seconds. Defaults to `null`

### *GetData* & *GetDataAsync*
``` cs
var model = sqlDataAccess.GetData<MODELorTYPE, Dictionary<string, object>>(queryOrStoredProcedure, connectionString, parameters, isStoredProcedure, commandTimeout);
var records = sqlDataAccess.GetData<TableNameModel>("QueryString", "[Full Connection String]", false, 60);
var asyncRecords = await sqlDataAccess.GetDataAsync<TableNameModel>("sp_TableNameGetAll", StoredConnectionString.ConnectionString, true, 60 );
var parameterRecords = sqlDataAccess.GetData<MODELorTYPE, Dictionary<string, object>("sp_TableNameGetByParameters", connString, parameters, true)
```

### *PostData*, *PostDataAsync*, *PutData*, *PutDataAsync*, *DeleteData*, & *DeleteDataAsync*
``` cs
int recordsAffected = sqlDataAccess.PostData(queryOrStoredProcedure, connectionString, isStoredProcedure, commandTimeout);
int recordsAffected = sqlDataAccess.PutData("QueryString", "[Full Connection String]", false, 60);
int recordsAffected = await sqlDataAccess.DeleteDataAsync("sp_TableNameDeleteAll", StoredConnectionString.ConnectionString, true, 60 );
int recordsAffected = sqlDataAccess.PostData<Dictionary<string, object>("sp_TableNamePostByParameters", connString, parameters, true)
```

### *PostDataTransactionAsync* & *PostDataTransactionForEachAsync*
``` cs
int recordsAffected = await sqlDataAccess.PostDataTransactionAsync("QueryString", connectionString, parameters, customLogger, isStoredProcedure, commandTimeout);
```

These are different since, instead of Posting all at once, they are transactional, so not all have to pass field restrictions in order for the process to work.

### *PostDataTransactionAsync* & *PostDataTransactionForEachAsync* Options: ###
Same as above with the exception of:
* `customLogger`: Will note Posts that did not succeed.

### Planned implementations

* MongoDb
* PostgreSQL

### Outside Dependencies

* [Dapper](https://www.nuget.org/packages/Dapper)
* [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient/)
* [System.Data.Odbc](https://www.nuget.org/packages/System.Data.Odbc)
* [MySql.Data](https://www.nuget.org/packages/MySql.Data)