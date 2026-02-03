# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Publish the project (path to your .csproj)
RUN dotnet publish "WebApplication1/WebApplication1.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Render provides PORT; ASPNETCORE_URLS makes Kestrel bind to it
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

COPY --from=build /app/publish .

# Your assembly name is usually the project name:
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
