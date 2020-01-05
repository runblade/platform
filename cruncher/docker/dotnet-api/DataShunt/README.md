# DataShunt

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

## Data Wrangling

```Powershell

```

## Testing

```Bash
#Use bash for now, haven't figured out single-line https bypass in Powershell
curl --insecure http://localhost:5051/api/v1/generic/sampledevices/getbyname/a
```
