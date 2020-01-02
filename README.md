# Runblade(AU) Platform

## _Landing

* Consumer-facing website to be redirected from Runblade.Pro and Runblade.Com to ()

* Mojuze.Com can be redirected ([see runblade/mojuzedotcom:redirect](https://hub.docker.com/repository/docker/runblade/mojuzedotcom) on Docker Hub)

* YouTube: [Runblade™ Presentation 1.2](https://youtu.be/_YeRkaNMjMU)

## Ingestor

Receives all incoming creative and placements.

* SwaggerHub: [rb-ingestor](https://app.swaggerhub.com/apis/runblade/ingestor/1.0.0)

## Cruncher

Ensures safety, fairness and accuracy across the platform.

* SwaggerHub: [rb-cruncher](https://app.swaggerhub.com/apis/runblade/cruncher/1.0.0)

* Docker Tensorflow (crowd detection), see YouTube: [Runblade™ Crowd Detection 1.0](https://youtu.be/rkwSw_xYqD4)

## Concierge

API engine, dashboards and reporting for various touchpoints.

* React-Dashboard API client

* SwaggerHub: [rb-concierge](https://app.swaggerhub.com/apis/runblade/concierge/1.0.0)

* To add serving of _corporate_ information...

## Negotiator

Handles buys, sells and trades as efficiently as possible.

* SimulatedDevice runs DEVICE, PLACEMENT and CREATIVE stream simulations

* YouTube: [Runblade™ Negotiator Simulation 1.0](https://youtu.be/y9X8OE2TCwA)

## Experiencer

Organises and delivers creative to placements.

* CSharpBlockchain explores using blockchain(s) for the Pipeliner as a possible alternative to database access

* Pixelizer high-end may use GLTF and WebGL (demo available)

---

## Getting Started

Run from Docker Hub private repo runblade/platform as follows (authentication required eg. via signing in on Docker Desktop):

```PowerShell
#Landing
    #Static Website (Consumer-Facing)
    docker run -d --name lc-landing-nginx-static -p 8001:80 runblade/platform:rb-landing-nginx-static

#Ingestor
    #API-Swagger

#Cruncher
    #API-Swagger
    #Tensorflow

#Concierge
    #API-Swagger
    #React-Dashboard
    docker run -d --name lc-concierge-react-dashboard -p 5051:5000 runblade/platform:rb-concierge-react-dashboard npx serve build

#Negotiator
    #API-Swagger
    #Database
    #Simulated Device
    docker run -d --name lc-negotiator-simulateddevice-1 runblade/platform:rb-negotiator-simulateddevice DEVICE
    docker run -d --name lc-negotiator-simulateddevice-2 runblade/platform:rb-negotiator-simulateddevice PLACEMENT
    docker run -d --name lc-negotiator-simulateddevice-3 runblade/platform:rb-negotiator-simulateddevice CREATIVE

#Experiencer
    #API-Swagger
    #Pipeliner
    docker run -d --name lc-experiencer-csharpblockchain runblade/platform:rb-experiencer-csharpblockchain 10
    #Pixelizer
    docker run -d --name lc-experiencer-pixelizer-demo -p 8002:80 runblade/platform:rb-experiencer-pixelizer-demo
```

View output of running container(s)

```PowerShell
#Negotiator
    docker attach lc-negotiator-simulateddevice-1
    docker attach lc-negotiator-simulateddevice-2
    docker attach lc-negotiator-simulateddevice-3
#Experiencer
    docker attach lc-experiencer-csharpblockchain
```

Stop and remove all containers

```PowerShell
#Platform-Wide
    docker stop $(docker ps -a -q)
    docker rm $(docker ps -a -q)
```

Nuke all images (docker rmi)

```PowerShell
#Platform-Wide
    docker system prune -a
```

---

## Building Platform

Requirements

* Docker
* Dotnet Core
* Git
* NodeJS

Clone from Github (this repository)

```Powershell
    git clone https://github.com/runblade/platform.git
```

Build all modules

```Powershell
#Landing
    #Static Website (Consumer-Facing)
    docker build -t rb-landing-nginx-static -f platform/_landing/nginx-static/Dockerfile platform/_landing/nginx-static
#Concierge
    #React-Dashboard
    docker build -t rb-concierge-react-dashboard -f platform/concierge/docker/Dockerfile platform/concierge/docker
#To Be Continued...
```

Data wrangling

```Powershell
    #Database-SQL
    docker pull mcr.microsoft.com/mssql/server:2019-latest
    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YOURPASSWORDHERE" -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
    #Database-NoSQL
    docker run -d -p 8091-8094:8091-8094 -p 11210:11210 couchbase
    cbimport json -c 127.0.0.1 -u USER -p PASSWORD -b BUCKET -d file://SHAREDFOLDER/JSONDATA.json -f lines --generate-key key::%ID%::#MONO_INCR#
```

---

## License

All ideas, concepts and content here are licensed as Creative Commons - Attribution NonCommercial and remains the property of Project Mojuze (formerly MobileJuze Pty Ltd), with the exception of material by any other original creators as credited or recorded otherwise.
