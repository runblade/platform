#Use latest Node for cool factor (?!)
FROM node:latest

#Create app directory
WORKDIR /usr/src/app

#Copy app source
COPY ./react-dashboard .

#Install app dependencies
RUN npm install

#As per create-react-app run the production build
RUN npm run build