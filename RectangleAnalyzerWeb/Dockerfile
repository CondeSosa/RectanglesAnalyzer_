#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.  /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RectangleAnalyzerWeb/RectangleAnalyzerWeb.csproj", "RectangleAnalyzerWeb/"]
RUN dotnet restore "RectangleAnalyzerWeb/RectangleAnalyzerWeb.csproj"
COPY . .
WORKDIR "/src/RectangleAnalyzerWeb"
RUN dotnet build "RectangleAnalyzerWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RectangleAnalyzerWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RectangleAnalyzerWeb.dll", "--urls", "http://0.0.0.0"]]