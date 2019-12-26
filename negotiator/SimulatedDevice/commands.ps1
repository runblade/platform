#Use this to build the docker image
dotnet publish -c Release
docker build -t rb-simulateddevice -f Dockerfile .

#Use this to run the docker image (pass DEVICE, CREATIVE or PLACEMENT as parameter)
docker run -d --name lc-simulateddevice rb-simulateddevice DEVICE

#Use this to view the output
docker attach lc-simulateddevice