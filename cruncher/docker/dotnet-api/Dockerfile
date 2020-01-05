FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY DataShunt/bin/Debug/netcoreapp3.1/publish/ app/
ENTRYPOINT ["dotnet", "app/DataShunt.dll"]