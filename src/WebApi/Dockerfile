FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /App
COPY . ./
RUN dotnet restore
EXPOSE 5226
CMD /usr/bin/dotnet run --project /App/WebApi.csproj