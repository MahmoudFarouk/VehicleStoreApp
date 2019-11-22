FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["VehicleStore.csproj", "./"]
RUN dotnet restore "VehicleStore.csproj"


# Install NodeJS 13.x on the image
# Prevent 'Warning: apt-key output should not be parsed (stdout is not a terminal)'
ENV ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1

RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_13.x | bash -
RUN apt-get install -y nodejs
RUN apt-get install build-essential -y
RUN npm install node-gyp

COPY . .
RUN dotnet restore 
RUN dotnet publish -c Release -o out

# Define the project Entry Point
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "VehicleStore.dll"]