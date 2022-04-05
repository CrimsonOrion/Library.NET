# Library.NET.Logging

## Implementing ICustomLogger
You can use implement ICustomLogger like this:

``` cs
ICustomLogger logger = new CustomLogger(new FileInfo("logfile.log"), true, LogLevel.Information);
```
You can then add it to DI as a singleton.

## Methods
### *LogDebug*
``` cs
logger.LogDebug("This is a Debug message");
```
Output:
``` sh
[Debug] <4/5/2022 1:42:26 PM> : This is Debug message
```

### *LogInformation*
``` cs
logger.LogInformation("This is Information message");
```
Output:
``` sh
[Information] <4/5/2022 1:42:26 PM> : This is Information message
```

### *LogWarning*
``` cs
logger.LogWarning(new Exception("Test Warning Message"), "This is Warning message");
```
Output:
``` sh
[Warning] <4/5/2022 2:04:21 PM> : This is Warning message
        Exception Message:Test Warning Message
```

### *LogTrace*
``` cs
logger.LogTrace(new Exception("Test Trace Message", new Exception("Testing the logger system with a test trace message.")), "This is Stacktrace message");
```
Output:
``` sh
[Error] <4/5/2022 2:04:21 PM> : This is Stacktrace message
        Exception Message:Test Trace Message
        Inner Message:System.Exception: Testing the logger system with a test trace message.
            Stack Trace:
```

### *LogError*
``` cs
logger.LogError(new Exception("Test Error Message", new Exception("Testing the logger system with a test error message.")), "This is Error message");
```
Output:
``` sh
[Error] <4/5/2022 2:04:21 PM> : This is Error message
        Exception Message:Test Error Message
        Inner Message:System.Exception: Testing the logger system with a test error message.
```

### *LogCritical*
``` cs
logger.LogCritical(new Exception("Test Critical Message", new Exception("Testing the logger system with a test critical message.")), "This is Critical message");
```
Output:
``` sh
[Critical] <4/5/2022 2:04:21 PM> : This is Critical message
        Exception Message:Test Critical Message
        Inner Message:System.Exception: Testing the logger system with a test critical message.
```

### Planned implementations

* None

### Outside Dependencies

* None