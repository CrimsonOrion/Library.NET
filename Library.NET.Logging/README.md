# Library.NET.Logging

## Implementing ICustomLogger
You can use logging via the ICustomLogger ([Library.NET](www.github.com/CrimsonOrion/Library.NET)) that comes with this package.

Use:
``` cs
ICustomLogger logger = new CustomLogger(new FileInfo("logfile.log"), true, LogLevel.Information);
```
You can then add it to DI as a singleton.

### Planned implementations

* None

### Outside Dependencies

* None