FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-buster-arm64v8 AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/core/runtime:3.1.3-buster-slim-arm64v8
WORKDIR /app
COPY --from=build /src/output .
ENTRYPOINT ["dotnet", "whatismyip.dll"]
