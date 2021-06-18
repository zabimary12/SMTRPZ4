FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Shop/Shop.csproj", "Shop/"]
RUN dotnet restore "Shop/Shop.csproj"
COPY . .
WORKDIR "/src/Shop"
RUN dotnet build "Shop.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Shop.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shop.dll"]