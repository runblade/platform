#Use this to build the docker image
docker build -t rb-landing-nginx-static -f Dockerfile .

#Use this to tag and push the docker image to docker hub
docker tag rb-landing-nginx-static runblade/platform:rb-landing-nginx-static
docker push runblade/platform:rb-landing-nginx-static

#Use this to run the docker image (use port 8051 onwards to avoid local conflicts)
#ALWAYS RUN FROM docker hub repository to avoid versioning issues!
docker run -d --name lc-landing-nginx-static -p 8051:80 runblade/platform:rb-landing-nginx-static

#Use this to view the output (lc prefix means local run)
docker attach lc-landing-nginx-static