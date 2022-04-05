# Library.NET.DataAccess
So far, it has two classes: `MsSqlDataAccess` and `OdbcDataAccess`. These both implement `ISqlDataAccess` & `IOdbcDataAccess`, respectively, and can be used for dependancy injection using these interfaces.

## Implementing ICustomLogger (Optional)
You can use logging via the ICustomLogger ([Library.NET](www.github.com/CrimsonOrion/Library.NET)) that comes with this package.

Use:
``` cs
ICustomLogger logger = new CustomLogger(new FileInfo("logfile.log"), true, LogLevel.Information);
```
You can then add it to DI as a singleton.

### Planned implementations

* MySql
* MongoDb
* PostgreSQL

### Outside Dependencies

* Dapper
* Microsoft.Data.SqlClient
* System.Data.Odbc