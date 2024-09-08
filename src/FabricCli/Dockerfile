# Use the .NET SDK to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FabricCli.csproj", "."]
RUN dotnet restore "./FabricCli.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet publish "./FabricCli.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:PublishSingleFile=true /p:SelfContained=true /p:RuntimeIdentifier=linux-x64

# Use a smaller runtime-deps image for the final stage
FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["./fabric"]