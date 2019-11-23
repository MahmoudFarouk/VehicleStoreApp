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


#TODO:YML with SQL Server Image (worked locally but failed on azure and aws)
#services:
  #web:
    #build:
      #context: .
    #image: "vehiclestoreappprojectacr.azurecr.io/vehiclestoreappproject"
    #ports:
     #- "80:80"
    #depends_on:
     #- db
#
  #db:
    #ports:
     #- "1433:1433"
    #image: "mcr.microsoft.com/mssql/server"
    #environment:
     #SA_PASSWORD: "P@ssw0rd"
     #ACCEPT_EULA: "Y"