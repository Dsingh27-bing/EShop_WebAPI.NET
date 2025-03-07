FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV ProductDB="Server=host.docker.internal,1433;Database=ProductDB;User Id=sa;Password=Pawan1128; TrustServerCertificate=true;"

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../../../projects/Documents/Antra/ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj", "../../../projects/Documents/Antra/ProductMicroservice/ProductMicroservice/"]
COPY ["../../../projects/Documents/Antra/ProductMicroservice/ProductInfrastructure/ProductInfrastructure.csproj", "../../../projects/Documents/Antra/ProductMicroservice/ProductInfrastructure/"]
COPY ["../../../projects/Documents/Antra/ProductMicroservice/ProductApplicationCore/ProductApplicationCore.csproj", "../../../projects/Documents/Antra/ProductMicroservice/ProductApplicationCore/"]
RUN dotnet restore "../../../projects/Documents/Antra/ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj"
COPY . .
WORKDIR "/src/../../../projects/Documents/Antra/ProductMicroservice/ProductMicroservice"
RUN dotnet build "ProductMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProductMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]
