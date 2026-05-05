FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY MedicalBooking.Web/*.csproj ./MedicalBooking.Web/
RUN dotnet restore

COPY MedicalBooking.Web/. ./MedicalBooking.Web/
WORKDIR /app/MedicalBooking.Web
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /publish .

EXPOSE 8081
ENTRYPOINT ["dotnet", "MedicalBooking.Web.dll"]