#Use this to build the docker image
dotnet publish -c Release
docker build -t rb-experiencer-csharpblockchain -f Dockerfile .

#Use this to tag and push the docker image to docker hub
docker tag rb-experiencer-csharpblockchain runblade/platform:rb-experiencer-csharpblockchain
docker push runblade/platform:rb-experiencer-csharpblockchain

#Use this to run the docker image (pass PoW difficulty as parameter)
#ALWAYS RUN FROM docker hub repository to avoid versioning issues!
docker run -d --name lc-experiencer-csharpblockchain runblade/platform:rb-experiencer-csharpblockchain 10

#Use this to view the output (lc prefix means local run)
docker attach lc-experiencer-csharpblockchain