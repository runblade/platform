#Use this to build the docker image (react-dashboard-black)
docker build -t rb-concierge-react-dashboard -f Dockerfile .

#Use this to tag and push the docker image to docker hub
docker tag rb-concierge-react-dashboard runblade/platform:rb-concierge-react-dashboard
docker push runblade/platform:rb-concierge-react-dashboard

#Use this to run the docker image
#Use port 5051 onwards to avoid local conflicts
docker run -d --name lc-concierge-react-dashboard -p 5052:80 runblade/platform:rb-concierge-react-dashboard