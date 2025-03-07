FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV ShippingDb="Server=host.docker.internal,1433;Database=ShippingDb;User Id=sa;Password=Pawan1128; TrustServerCertificate=true;"

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../../../projects/Documents/Antra/ShippingMicroservice/ShippingMicroservice/ShippingMicroservice.csproj", "../../../projects/Documents/Antra/ShippingMicroservice/ShippingMicroservice/"]
COPY ["../../../projects/Documents/Antra/ShippingMicroservice/InfrastructureShipping/InfrastructureShipping.csproj", "../../../projects/Documents/Antra/ShippingMicroservice/InfrastructureShipping/"]
COPY ["../../../projects/Documents/Antra/ShippingMicroservice/ApplicationCoreShipping/ApplicationCoreShipping.csproj", "../../../projects/Documents/Antra/ShippingMicroservice/ApplicationCoreShipping/"]
RUN dotnet restore "../../../projects/Documents/Antra/ShippingMicroservice/ShippingMicroservice/ShippingMicroservice.csproj"
COPY . .
WORKDIR "/src/../../../projects/Documents/Antra/ShippingMicroservice/ShippingMicroservice"
RUN dotnet build "ShippingMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ShippingMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShippingMicroservice.dll"]
