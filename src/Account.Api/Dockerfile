FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /home/app

COPY ./*.sln ./
COPY ./src/*/*.csproj ./
COPY ./NuGet.config ./


RUN for file in $(ls *.csproj); do mkdir -p ./src/${file%.*}/ && mv $file ./src/${file%.*}/; done

RUN ls src/
RUN dotnet restore --configfile NuGet.config /home/app/src/Account.Api/Account.Api.csproj
 
COPY . .	

RUN dotnet build -c Release /home/app/src/Account.Api/Account.Api.csproj && \
	dotnet publish -c Debug -o /publish /home/app/src/Account.Api/Account.Api.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /publish

COPY --from=build /publish .

ENTRYPOINT ["dotnet", "Account.Api.dll"]