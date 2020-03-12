FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy necessary files and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore -s https://api.nuget.org/v3/index.json -s https://www.myget.org/F/ccms/api/v3/index.json

# Copy everthing and build
COPY . ./
RUN dotnet publish -c Release -o out

#Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
COPY --from=build-env /app/out .

# Start
ENTRYPOINT ["dotnet", "Services.Dashboard.AuditlogService.dll"]