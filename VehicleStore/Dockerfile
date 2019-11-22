FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app
EXPOSE 80


# Prevent 'Warning: apt-key output should not be parsed (stdout is not a terminal)'
ENV ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1
# Install NodeJS 13.x on the image
RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_13.x | bash -
RUN apt-get install -y nodejs
RUN apt-get install build-essential -y

# Restoring project packages and publishing the project release
COPY . .
RUN dotnet restore 
RUN dotnet publish -c Release -o out

# Define the project Entry Point
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "VehicleStore.dll"]