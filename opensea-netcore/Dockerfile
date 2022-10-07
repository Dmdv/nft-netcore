FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5287
ENV ASPNETCORE_URLS="http://0.0.0.0:5287/"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["opensea-netcore/opensea-netcore.csproj", "opensea-netcore/"]
RUN dotnet restore "opensea-netcore/opensea-netcore.csproj"
COPY . .
WORKDIR "/src/opensea-netcore"
RUN dotnet build "opensea-netcore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "opensea-netcore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "opensea-netcore.dll"]
