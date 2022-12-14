FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SfPlayground.DataService/SfPlayground.DataService.csproj", "SfPlayground.DataService/"]
RUN dotnet restore "SfPlayground.DataService/SfPlayground.DataService.csproj"
COPY . .
WORKDIR "/src/SfPlayground.DataService"
RUN dotnet build "SfPlayground.DataService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SfPlayground.DataService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SfPlayground.DataService.dll"]
