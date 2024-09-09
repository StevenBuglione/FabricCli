# Use the .NET SDK to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FabricCli.csproj", "."]
RUN dotnet restore "./FabricCli.csproj"
COPY . .
RUN dotnet publish "./FabricCli.csproj" -c Release -o /app/publish /p:PublishSingleFile=true /p:SelfContained=true /p:RuntimeIdentifier=linux-x64

# Final stage with runtime-deps
FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Make sure the binary is executable
RUN chmod +x /app/fabric

# Set the entrypoint to the full path
ENTRYPOINT ["/app/fabric"] 