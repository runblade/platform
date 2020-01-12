#Use this to build the docker image
#Using Debug version for now
dotnet publish -c Debug
docker build -t rb-negotiator-simulateddevice -f Dockerfile .

#Use this to tag and push the docker image to docker hub
docker tag rb-negotiator-simulateddevice runblade/platform:rb-negotiator-simulateddevice
docker push runblade/platform:rb-negotiator-simulateddevice