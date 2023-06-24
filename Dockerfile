FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /App
COPY . ./
RUN dotnet restore
EXPOSE 5248
CMD /usr/bin/dotnet run --project /App/src/y4f/y4f.csproj