FROM node:21-alpine3.18 AS base
WORKDIR /app
EXPOSE 80

FROM base as build
COPY package*.json .
RUN npm install
ENV NODE_ENV production
COPY . .
ARG VITE_APIURL
ENV VITE_APIURL=$VITE_APIURL
RUN npm run build

FROM base AS publish
RUN npm install -g serve
COPY --from=build /app/dist .
ENTRYPOINT [ "serve", "-s", "-l", "80" ]