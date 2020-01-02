#Use this to build the docker image
docker build -t rb-concierge-react-dashboard -f platform/concierge/docker/Dockerfile platform/concierge/docker

#Use this to tag and push the docker image to docker hub
docker tag rb-concierge-react-dashboard runblade/platform:rb-concierge-react-dashboard
docker push runblade/platform:rb-concierge-react-dashboard

#Use this to run the docker image
#Use port 5051 onwards to avoid local conflicts
docker run -d --name lc-concierge-react-dashboard -p 5051:5000 runblade/platform:rb-concierge-react-dashboard npx serve build