# Runblade(AU) Platform

## _Landing

* Consumer-facing website to be redirected from Runblade.Pro and Runblade.Com to (_fill in site_)

* Mojuze.Com can be redirected ([see runblade/mojuzedotcom:redirect](https://hub.docker.com/repository/docker/runblade/mojuzedotcom) on Docker Hub)

* YouTube: [Runblade™ Presentation 1.2](https://youtu.be/_YeRkaNMjMU)

## Ingestor

Receives all incoming creative and placements.

* SwaggerHub: [rb-ingestor](https://app.swaggerhub.com/apis/runblade/ingestor/1.0.0)

## Cruncher

Ensures safety, fairness and accuracy across the platform.

* SwaggerHub: [rb-cruncher](https://app.swaggerhub.com/apis/runblade/cruncher/1.0.0)

* Dotnet-API Engine (DataShunt with sample data)

* Docker Tensorflow (crowd detection), see YouTube: [Runblade™ Crowd Detection 1.0](https://youtu.be/rkwSw_xYqD4)

## Concierge

API engine, dashboards and reporting for various touchpoints.

* React-Dashboard API client

* SwaggerHub: [rb-concierge](https://app.swaggerhub.com/apis/runblade/concierge/1.0.0)

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
    #Dotnet-API
        docker run -d --name lc-cruncher-dotnet-api -p 5051:80 runblade/platform:rb-cruncher-dotnet-api --DBCONFIGSTRING="Server=172.17.0.2;Database=MSSQL;User Id=USERID;Password=YOURPASSWORDHERE"
    #Tensorflow

#Concierge
    #API-Swagger
    #React-Dashboard
        docker run -d --name lc-concierge-react-dashboard -p 5052:80 runblade/platform:rb-concierge-react-dashboard

#Negotiator
    #API-Swagger
    #Database
    #Simulated Device
        docker run -d --name lc-negotiator-simulateddevice-1 runblade/platform:rb-negotiator-simulateddevice DEVICE http://172.17.0.3:8091 USERID YOURPASSWORDHERE BUCKETNAME
        docker run -d --name lc-negotiator-simulateddevice-2 runblade/platform:rb-negotiator-simulateddevice PLACEMENT http://172.17.0.3:8091 USERID YOURPASSWORDHERE BUCKETNAME
        docker run -d --name lc-negotiator-simulateddevice-3 runblade/platform:rb-negotiator-simulateddevice CREATIVE http://172.17.0.3:8091 USERID YOURPASSWORDHERE BUCKETNAME

#Experiencer
    #API-Swagger
    #Pipeliner
        docker run -d --name lc-experiencer-csharpblockchain runblade/platform:rb-experiencer-csharpblockchain 10
    #Pixelizer
        docker run -d --name lc-experiencer-pixelizer-demo -p 8002:80 runblade/platform:rb-experiencer-pixelizer-demo
```

View output of running container(s):

```PowerShell
#Ingestor
#Cruncher
#Concierge
#Negotiator
    #(Use this to view as there is curently no web interface)
    docker attach lc-negotiator-simulateddevice-1
    docker attach lc-negotiator-simulateddevice-2
    docker attach lc-negotiator-simulateddevice-3
#Experiencer
    #(Use this to view as there is curently no web interface)
    docker attach lc-experiencer-csharpblockchain
```

Stop and remove all containers:

```PowerShell
#Platform-Wide
    docker stop $(docker ps -a -q)
    docker rm   $(docker ps -a -q)
```

Nuke all images (docker rmi):

```PowerShell
#Platform-Wide
    docker system prune -a
```

---

## Building Platform

CI/CD:

```Powershell
#Began testing Gitlab _Pipelines and _Jobs
```

Build modules:

```Powershell
#Requirements: Docker, Dotnet Core, Git, NodeJS
#Clone from Github (this repository)
    git clone https://github.com/runblade/platform.git
#Landing
    #Static Website (Consumer-Facing)
        #(see commands.ps1 in directory)
#Cruncher
    #Dotnet-API
        #(see commands.ps1 in directory)
#Concierge
    #React-Dashboard
        #(see commands.ps1 in directory)
#Negotiator
    #Simulated Device
        #(see commands.ps1 in directory)
#Experiencer
    #Pipeliner
        #(see commands.ps1 in directory)
    #Pixelizer
        #(see commands.ps1 in directory)
```

Data wrangling:

```Powershell
#Database-SQL
    docker pull mcr.microsoft.com/mssql/server:2019-latest
    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YOURPASSWORDHERE" -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
        #Import CSV or Excel
        #Use Microsoft SQL Server Management Studio (SSMS)
        #Use Sqlpackage (eg. DataShunt sample data)
            #Export database
            sqlpackage.exe /a:Export /ssn:127.0.0.1 /sdn:MSSQL /su:USERID /sp:YOURPASSWORDHERE /tf:MSSQL.bacpac
            #Import database
            sqlpackage.exe /a:Import /tsn:127.0.0.1 /tdn:MSSQL /tu:USERID /tp:YOURPASSWORDHERE /sf:MSSQL.bacpac
#Database-NoSQL
    docker run -d -p 8091-8094:8091-8094 -p 11210:11210 couchbase
        #Import JSON
        cbimport json -c 127.0.0.1 -u USER -p PASSWORD -b BUCKET -d file://SHAREDFOLDER/JSONFILE.json -f lines --generate-key key::%ID%::#MONO_INCR#
```

---

## Testing

```Powershell
#Negotiator
    #Simulated Device
        dotnet test SimulatedDevice.Tests
```

---

## License

All ideas, concepts and content here are licensed as Creative Commons - Attribution NonCommercial and remains the property of Mojuze (formerly MobileJuze Pty Ltd), with the exception of material by any other original creators as credited or recorded otherwise.
