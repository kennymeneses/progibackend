FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/BidCalculation.Api/BidCalculation.Api.csproj", "src/BidCalculation.Api/"]
COPY ["src/BidCalculation.Application/BidCalculation.Application.csproj", "src/BidCalculation.Application/"]

RUN dotnet restore "src/BidCalculation.Api/BidCalculation.Api.csproj"

COPY . .
WORKDIR "/src/src/BidCalculation.Api"
RUN dotnet build "BidCalculation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BidCalculation.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "BidCalculation.Api.dll"]