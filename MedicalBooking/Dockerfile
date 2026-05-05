FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY MedicalBooking.API/*.csproj ./MedicalBooking.API/
RUN dotnet restore

COPY MedicalBooking.API/. ./MedicalBooking.API/
WORKDIR /app/MedicalBooking.API
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "MedicalBooking.API.dll"]