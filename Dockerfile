FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /SchoolApp/SchoolApi

# Copy everything
COPY . /SchoolApp/SchoolApi
# Restore as distinct layers
RUN dotnet restore SchoolApp/SchoolApi/SchoolApi.csproj
# Build and publish a release
RUN dotnet publish SchoolApp/SchoolApi/SchoolApi.csproj --output /SchoolApp/SchoolApi/out/ --configuration Release --no-restore
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /SchoolApp/SchoolApi
COPY --from=build-env /SchoolApp/SchoolApi .
EXPOSE 80
ENTRYPOINT ["dotnet", "SchoolApi.dll"]