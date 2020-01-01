#Use latest Node for cool factor (?!)
FROM node:latest

#Create app directory
WORKDIR /usr/src/app

#Copy app source
COPY ./react-dashboard .

#Install app dependencies
#A wildcard is used to ensure both package.json AND package-lock.json are copied where available (npm@5+)
COPY ./react-dashboard/package*.json ./
RUN npm install

#As per create-react-app run the production build
RUN npm run build

#Serve using serve.js (not ExpressJS)
CMD [ "node", "node_modules/serve/bin/server.js" ]