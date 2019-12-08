#Use this to run the docker image with shared directory
docker run --name tensorflow -v D:\Shared:/shared -p 8888:8888 -d tensorflow

#Use this to access the container file system, etc
docker exec -it tensorflow /bin/bash

#Generate frames for analysis, starting with 720p from webcams, etc
.\ffmpeg.exe -i .\INPUT.mp4 -vf fps=15,scale=1280:-1 OUTPUT%05d.jpg

#Combine frames into unrendered and rendered output for comparison
.\ffmpeg.exe -framerate 15 -i OUTPUT%05d.jpg -vf "pad=ceil(iw/2)*2:ceil(ih/2)*2" UNRENDERED.mp4
.\ffmpeg.exe -framerate 15 -pattern_type glob -i '*.jpeg' -vf "pad=ceil(iw/2)*2:ceil(ih/2)*2" RENDERED.mp4