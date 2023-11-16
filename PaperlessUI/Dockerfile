FROM node:latest
COPY . /src/
WORKDIR /src/
RUN npm install -g @angular/cli
RUN npm i
RUN npm run build
EXPOSE 4200
CMD ["ng", "serve", "--host", "0.0.0.0"]
