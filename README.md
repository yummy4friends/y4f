# y4f

## Tech Stack

[Blazor WebAssembly](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)

## Dependecies

On Ubuntu our dependencies are:

```bash
nala install dotnet-sdk-7.0 docker-ce docker-ce-cli docker-buildx-plugin docker-compose-plugin
```

Dependency names will depend on your linux distribution.

For this this project you also need Traefik. Or you can use your own reverse proxy and edit the docker-compose files to reflect that. 

## Installation

Clone the repo.

```bash
git clone https://github.com/yummy4friends/y4f.git && cd y4f
```

Start the website with docker-compose.

```bash
docker-compose up --build -d
```

Also start up the API.

```bash
cd src/WebApi/ && docker-compose up --build -d
```