# Useful Commands

## Dependencies

```Powershell
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Newtonsoft.Json
dotnet add package Microsoft.AspNetCore.Http.Abstractions
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
```

## Using ("Import")

```C#
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Newtonsoft.Json;
```

## Database-First

```Powershell
dotnet ef dbcontext scaffold "Server=127.0.0.1;Database=MSSQL;User Id=USERID;Password=YOURPASSWORDHERE" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

## Credential Storage

```Powershell
#DEVELOPMENT ONLY, NOT ENCRYPTED!
dotnet user-secrets init
dotnet user-secrets set "Database:ConnectionString" "CONNECTIONSTRINGHERE"
```

## Tests

```Powershell
#To Be Continued...
```
