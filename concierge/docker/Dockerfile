#Build environment
FROM node:latest as build
WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH
COPY react-dashboard-black/package.json /app/package.json
RUN npm install 
#RUN npm install react-scripts@3.0.1 -g --silent
COPY react-dashboard-black /app
RUN npm run build

#Production environment
FROM nginx:latest
COPY --from=build /app/build /usr/share/nginx/html/runblade-concierge
#Redirect page
COPY react-dashboard-black/.index.html  /usr/share/nginx/html/index.html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]