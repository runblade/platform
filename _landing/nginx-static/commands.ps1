#Use this to build the docker image
docker build -t rb-landing -f Dockerfile .

#Use this to run the docker image (use port 8001 onwards)
docker run -d --name lc-landing -p 8001:80 rb-landing

#Use this to view the output
docker attach lc-landing