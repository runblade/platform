#Use this to build the docker image
dotnet publish .\DataShunt
docker build -t rb-cruncher-dotnet-api -f Dockerfile .

#Use this to tag and push the docker image to docker hub
docker tag rb-cruncher-dotnet-api runblade/platform:rb-cruncher-dotnet-api
docker push runblade/platform:rb-cruncher-dotnet-api