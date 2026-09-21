FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NumbersToWords/NumbersToWords.Client/NumbersToWords.Client.csproj", "NumbersToWords/NumbersToWords.Client/"]
RUN dotnet restore "NumbersToWords/NumbersToWords.Client/NumbersToWords.Client.csproj"
COPY . .
WORKDIR "/src/NumbersToWords/NumbersToWords.Client"
RUN dotnet build "./NumbersToWords.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NumbersToWords.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NumbersToWords.Client.dll"]
