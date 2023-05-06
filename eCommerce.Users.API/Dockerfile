#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0.5-alpine3.17-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0.203-alpine3.17-amd64 AS build
WORKDIR /src
COPY ["eCommerce.Users.API/eCommerce.Users.API.csproj", "eCommerce.Users.API/"]
COPY ["eCommerce.Users.Infrastructure/eCommerce.Users.Infrastructure.csproj", "eCommerce.Users.Infrastructure/"]
COPY ["eCommerce.Users.Application/eCommerce.Users.Application.csproj", "eCommerce.Users.Application/"]
COPY ["eCommerce.Users.API.Domain/eCommerce.Users.Domain.csproj", "eCommerce.Users.API.Domain/"]
COPY ["eCommerce.Users.Presentation/eCommerce.Users.Presentation.csproj", "eCommerce.Users.Presentation/"]
RUN dotnet restore "eCommerce.Users.API/eCommerce.Users.API.csproj"
COPY . .
WORKDIR "/src/eCommerce.Users.API"
RUN dotnet build "eCommerce.Users.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eCommerce.Users.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommerce.Users.API.dll"]