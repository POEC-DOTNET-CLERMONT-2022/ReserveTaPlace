#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
#EXPOSE 7091

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReserveTaPlace.API/ReserveTaPlace.API.csproj", "ReserveTaPlace.API/"]
COPY ["ReserveTaPlace.DTOS/ReserveTaPlace.DTOS.csproj", "ReserveTaPlace.DTOS/"]
COPY ["ReserveTaPlace.Data/ReserveTaPlace.Data.csproj", "ReserveTaPlace.Data/"]
COPY ["ReserveTaPlace.Entities/ReserveTaPlace.Entities.csproj", "ReserveTaPlace.Entities/"]
COPY ["ReserveTaPlace.Models/ReserveTaPlace.Models.csproj", "ReserveTaPlace.Models/"]
COPY ["ReserveTaPlace.Logic/ReserveTaPlace.Logic.csproj", "ReserveTaPlace.Logic/"]
COPY ["ReserveTaPlace.Persistance/ReserveTaPlace.Persistance.csproj", "ReserveTaPlace.Persistance/"]
COPY ["ReserveTaPlace.MovieDataBaseService/ReserveTaPlace.MovieDataBaseService.csproj", "ReserveTaPlace.MovieDataBaseService/"]
RUN dotnet restore "ReserveTaPlace.API/ReserveTaPlace.API.csproj"
COPY . .
WORKDIR "/src/ReserveTaPlace.API"
RUN dotnet build "ReserveTaPlace.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReserveTaPlace.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReserveTaPlace.API.dll"]