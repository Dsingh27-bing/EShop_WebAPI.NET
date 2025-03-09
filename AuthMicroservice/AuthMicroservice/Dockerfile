FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../../../projects/Documents/Antra/AuthMicroservice/AuthMicroservice/AuthMicroservice.csproj", "../../../projects/Documents/Antra/AuthMicroservice/AuthMicroservice/"]
COPY ["../../../projects/Documents/Antra/AuthMicroservice/AuthenticationInfrastructure/AuthenticationInfrastructure.csproj", "../../../projects/Documents/Antra/AuthMicroservice/AuthenticationInfrastructure/"]
COPY ["../../../projects/Documents/Antra/AuthMicroservice/AuthenticationApplicationCore/AuthenticationApplicationCore.csproj", "../../../projects/Documents/Antra/AuthMicroservice/AuthenticationApplicationCore/"]
COPY ["../../../projects/Documents/Antra/AuthMicroservice/JwtAuthenticationManager/JwtAuthenticationManager.csproj", "../../../projects/Documents/Antra/AuthMicroservice/JwtAuthenticationManager/"]
RUN dotnet restore "../../../projects/Documents/Antra/AuthMicroservice/AuthMicroservice/AuthMicroservice.csproj"
COPY . .
WORKDIR "/src/../../../projects/Documents/Antra/AuthMicroservice/AuthMicroservice"
RUN dotnet build "AuthMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AuthMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthMicroservice.dll"]
