FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Practise/Practise.csproj", "Practise/"]
RUN dotnet restore "Practise/Practise.csproj"
COPY . .
WORKDIR "/src/Practise"
RUN dotnet build "Practise.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Practise.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Practise.dll"]
