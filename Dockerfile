FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# copy everything and restore
COPY . ./
RUN dotnet restore

RUN dotnet publish GymSystemAPI.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "GymSystemAPI.dll"]
