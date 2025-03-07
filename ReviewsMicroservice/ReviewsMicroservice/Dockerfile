FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV ReviewDB="Server=host.docker.internal,1433;Database=ReviewDB;User Id=sa;Password=Pawan1128; TrustServerCertificate=true;"

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../../../projects/Documents/Antra/ReviewsMicroservice/ReviewsMicroservice/ReviewsMicroservice.csproj", "../../../projects/Documents/Antra/ReviewsMicroservice/ReviewsMicroservice/"]
COPY ["../../../projects/Documents/Antra/ReviewsMicroservice/ReviewsInfrastructure/ReviewsInfrastructure.csproj", "../../../projects/Documents/Antra/ReviewsMicroservice/ReviewsInfrastructure/"]
COPY ["../../../projects/Documents/Antra/ReviewsMicroservice/ReviewsApplicationCore/ReviewsApplicationCore.csproj", "../../../projects/Documents/Antra/ReviewsMicroservice/ReviewsApplicationCore/"]
RUN dotnet restore "../../../projects/Documents/Antra/ReviewsMicroservice/ReviewsMicroservice/ReviewsMicroservice.csproj"
COPY . .
WORKDIR "/src/../../../projects/Documents/Antra/ReviewsMicroservice/ReviewsMicroservice"
RUN dotnet build "ReviewsMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ReviewsMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReviewsMicroservice.dll"]
