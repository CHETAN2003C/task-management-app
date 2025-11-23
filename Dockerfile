# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY TaskManagementApp.csproj .
RUN dotnet restore TaskManagementApp.csproj

# Copy everything else and build
COPY . .
RUN dotnet publish TaskManagementApp.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Railway provides PORT environment variable
ENV ASPNETCORE_URLS=http://+:$PORT

EXPOSE $PORT

ENTRYPOINT ["dotnet", "TaskManagementApp.dll"]
