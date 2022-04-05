# Library.NET.Logging

## Implementing ICustomLogger
You can use implement ICustomLogger like this:

``` cs
ICustomLogger logger = new CustomLogger(new FileInfo("logfile.log"), true, LogLevel.Information);
```
You can then add it to DI as a singleton.

### Planned implementations

* None

### Outside Dependencies

* None