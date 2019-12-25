#Use this to build the docker image
dotnet publish -c Release
docker build -t rb-csharpblockchain -f Dockerfile .

#Use this to run the docker image (pass PoW difficulty as parameter)
docker run -d --name lc-csharpblockchain rb-csharpblockchain 10

#Use this to view the output
docker attach lc-csharpblockchain