FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
EXPOSE 80
#EXPOSE 443


COPY ["WebAPI/WebAPI.csproj", "WebAPI/"]
COPY ["Infrastructure/Models.csproj", "Models/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "./WebAPI/WebAPI.csproj"
#RUN dotnet dev-certs https --clean
#RUN dotnet dev-certs https -t


COPY . .
RUN dotnet build "WebAPI/WebAPI.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "WebAPI/WebAPI.csproj" -c Release -o /app/out


FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=publish /app/out .

#ENV ASPNETCORE_URLS=https://+:443;http://+:80

ENTRYPOINT ["dotnet", "/app/WebAPI.dll"]