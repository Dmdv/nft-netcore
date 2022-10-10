FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5287
ENV ASPNETCORE_URLS="http://0.0.0.0:5287/"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nft-netcore/nft-netcore.csproj", "nft-netcore/"]
RUN dotnet restore "nft-netcore/nft-netcore.csproj"
COPY . .
WORKDIR "/src/nft-netcore"
RUN dotnet build "nft-netcore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "nft-netcore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nft-netcore.dll"]
