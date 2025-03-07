FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV PromotionDB="Server=host.docker.internal,1433;Database=PromotionDB;User Id=sa;Password=Pawan1128; TrustServerCertificate=true;"

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../../../projects/Documents/Antra/PromotionMicroservice/PromotionMicroservice/PromotionMicroservice.csproj", "../../../projects/Documents/Antra/PromotionMicroservice/PromotionMicroservice/"]
COPY ["../../../projects/Documents/Antra/PromotionMicroservice/PromotionApplicationCore/PromotionApplicationCore.csproj", "../../../projects/Documents/Antra/PromotionMicroservice/PromotionApplicationCore/"]
COPY ["../../../projects/Documents/Antra/PromotionMicroservice/PromotionInfrastructure/PromotionInfrastructure.csproj", "../../../projects/Documents/Antra/PromotionMicroservice/PromotionInfrastructure/"]
RUN dotnet restore "../../../projects/Documents/Antra/PromotionMicroservice/PromotionMicroservice/PromotionMicroservice.csproj"
COPY . .
WORKDIR "/src/../../../projects/Documents/Antra/PromotionMicroservice/PromotionMicroservice"
RUN dotnet build "PromotionMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PromotionMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PromotionMicroservice.dll"]
