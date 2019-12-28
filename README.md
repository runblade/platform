# Runblade(AU) Platform

## _Landing

* Consumer-facing website currently redirected from Runblade.Pro and Runblade.Com to [Microsoft Azure](https://runbladeau.azurewebsites.net)

* Mojuze.Com can be redirected (docker run -it --rm -p 80:80 runblade/mojuzedotcom:redirect)

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

* SwaggerHub: [rb-concierge](https://app.swaggerhub.com/apis/runblade/concierge/1.0.0)

* To add serving of ___corporate___ information

## Negotiator

Handles buys, sells and trades as efficiently as possible.

* SimulatedDevice runs DEVICE, PLACEMENT and CREATIVE stream simulations

* YouTube: [Runblade™ Negotiator Simulation 1.0](https://youtu.be/y9X8OE2TCwA)

## Experiencer

Organises and delivers creative to placements.

* CSharpBlockchain explores using blockchain(s) for the Pipeliner as a possible alternative to database access

* Pixelizer high-end may use GLTF and WebGL (demo available, see Getting Started)

---

## Getting Started

Run from Docker Hub private repo runblade/platform as follows (authentication required eg. via signing in on Docker Desktop):

```docker
docker run -d --name lc-landing-nginx-static -p 8001:80 runblade/platform:rb-landing-nginx-static
docker run -d --name lc-negotiator-simulateddevice-1 runblade/platform:rb-negotiator-simulateddevice DEVICE
docker run -d --name lc-negotiator-simulateddevice-2 runblade/platform:rb-negotiator-simulateddevice PLACEMENT
docker run -d --name lc-negotiator-simulateddevice-3 runblade/platform:rb-negotiator-simulateddevice CREATIVE
docker run -d --name lc-experiencer-csharpblockchain runblade/platform:rb-experiencer-csharpblockchain 10
docker run -d --name lc-experiencer-pixelizer-demo -p 8002:80 runblade/platform:rb-experiencer-pixelizer-demo
```

View output of running container(s):

```docker
docker attach lc-negotiator-simulateddevice-1
docker attach lc-negotiator-simulateddevice-2
docker attach lc-negotiator-simulateddevice-3
docker attach lc-experiencer-csharpblockchain
```

Stop and remove all containers:

```docker
docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)
```

Nuke all images (docker rmi):

```docker
docker system prune -a
```

---

## License

All ideas, concepts and content here are licensed as Creative Commons - Attribution NonCommercial and remains the property of Project Mojuze (formerly MobileJuze Pty Ltd), with the exception of material by other original creators as credited.
