#Use this to build the docker image
docker build -t rb-experiencer-pixelizer-demo -f Dockerfile .

#Use this to tag and push the docker image to docker hub
docker tag rb-experiencer-pixelizer-demo runblade/platform:rb-experiencer-pixelizer-demo
docker push runblade/platform:rb-experiencer-pixelizer-demo

#Use this to run the docker image (use port 8051 onwards, 8052 for this server)
#ALWAYS RUN FROM docker hub repository to avoid versioning issues!
docker run -d --name lc-experiencer-pixelizer-demo -p 8052:80 runblade/platform:rb-experiencer-pixelizer-demo

#Use this to view the output (lc prefix means local run)
docker attach lc-experiencer-pixelizer-demo