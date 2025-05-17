FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY PracticasPresencialesBack/*.csproj ./PracticasPresencialesBack/
COPY Data/*.csproj ./Data/
COPY DTOs/*.csproj ./DTOs/
COPY Models/*.csproj ./Models/
COPY Services/*.csproj ./Services/
RUN dotnet restore PracticasPresencialesBack/PracticasPresencialesBack.csproj

COPY . .
RUN dotnet publish PracticasPresencialesBack/PracticasPresencialesBack.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "PracticasPresencialesBack.dll"]
