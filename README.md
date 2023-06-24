# y4f

## Description (German)

Yummy4Friends ist eine benutzerfreundliche und visuell ansprechende Webapp zur Onlinebestellung von Speisen mit der dynamischen Einbindung einer Kunden- und Speisendatenbank unter Berücksichtigung von Sonderwünschen. Zur Kundenbindung wird auch die Verwaltung von Kundenrabatten, Vorbestellmöglichkeiten sowie konfigurierbare Abholtermine realisiert.

## Description (English)

Yummy4Friends is a user friendly and visually appealing WebApp for ordering food or other things online. Food or other stuff get dynamically fetched from a customer and food database while also taking into account special requests. To attract customers one can also offer limeted time sales/coupons, ordering in advance as well as being able to choosing their preferred pickup time.  

## Tech Stack

[Blazor WebAssembly](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)

## Dependecies

On Ubuntu our dependencies are:

```bash
nala install dotnet-sdk-7.0 docker-ce docker-ce-cli docker-buildx-plugin docker-compose-plugin
```

Dependency names will depend on your linux distribution.

For this this project you also need Traefik. Or you can use your own reverse proxy and edit the docker-compose files to reflect that. 

## Running it

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

This setup is for showcasing the project and is therefore not intended for production.
