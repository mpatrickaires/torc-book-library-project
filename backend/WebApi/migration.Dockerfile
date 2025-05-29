FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet ef migrations bundle --output /bundle/migration-bundle.exe

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /bundle
COPY --from=build /bundle/migration-bundle.exe ./

ENTRYPOINT ["./migration-bundle.exe", "--connection"]
