FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
RUN apt-get update && apt-get install -y libgdiplus

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY ./PlatfozaTestTask.API.csproj /src/PlatfozaTestTask.API/

WORKDIR /src/PlatfozaTestTask.API/
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM runtime
WORKDIR /app
COPY --from=build /src/PlatfozaTestTask.API/out .

EXPOSE 49000
ENTRYPOINT ["dotnet", "PlatfozaTestTask.API.dll"]
