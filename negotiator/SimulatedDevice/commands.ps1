#Use this to build the docker image
dotnet publish -c Release
docker build -t rb-negotiator-simulateddevice -f Dockerfile .

#Use this to tag and push the docker image to docker hub
docker tag rb-negotiator-simulateddevice runblade/platform:rb-negotiator-simulateddevice
docker push runblade/platform:rb-negotiator-simulateddevice

#Use this to run the docker image (pass DEVICE, CREATIVE or PLACEMENT as parameter)
#ALWAYS RUN FROM docker hub repository to avoid versioning issues!
docker run -d --name lc-negotiator-simulateddevice runblade/platform:rb-negotiator-simulateddevice DEVICE

#Use this to view the output (lc prefix means local run)
docker attach lc-negotiator-simulateddevice