FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy from <source> to <container> and restore
COPY . ./
RUN dotnet restore

# Build and publish the app
RUN dotnet publish -c Release -o out

# Run the application
ENTRYPOINT ["dotnet", "out/API.dll"]