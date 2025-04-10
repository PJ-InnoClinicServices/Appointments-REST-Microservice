FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../AppointmentREST.WebAPI/AppointmentREST.WebAPI.csproj", "AppointmentREST.WebAPI/"]
COPY ["../AppointmentREST.Shared/AppointmentREST.Shared.csproj", "AppointmentREST.Shared/"]
COPY ["../AppointmentREST.BusinessLogic/AppointmentREST.BusinessLogic.csproj", "AppointmentREST.BusinessLogic/"]
COPY ["../AppointmentREST.DataAccess/AppointmentREST.DataAccess.csproj", "AppointmentREST.DataAccess/"]
RUN dotnet restore "AppointmentREST.WebAPI/AppointmentREST.WebAPI.csproj"
COPY . .
WORKDIR "/src/AppointmentREST.WebAPI"
RUN dotnet build "AppointmentREST.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AppointmentREST.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppointmentREST.WebAPI.dll"]
