FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish API -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/API/out .
ENTRYPOINT ["dotnet", "API.dll"]
EXPOSE 80