FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY ./publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Catalog Service.dll"]