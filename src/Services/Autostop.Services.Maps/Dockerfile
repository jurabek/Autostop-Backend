FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY Services/Autostop.Services.Maps/Autostop.Services.Maps.csproj Services/Autostop.Services.Maps/
COPY Common/Autostop.Shared.Google.Maps/Autostop.Shared.Google.Maps.csproj Common/Autostop.Shared.Google.Maps/
COPY Common/Autostop.Common.Shared/Autostop.Common.Shared.csproj Common/Autostop.Common.Shared/
RUN dotnet restore
COPY . .
WORKDIR /src/Services/Autostop.Services.Maps
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Autostop.Services.Maps.dll"]
