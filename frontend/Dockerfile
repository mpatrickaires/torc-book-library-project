FROM node:22-alpine AS build
COPY package*.json ./
RUN npm install

ARG VITE_BACKEND_URL
ENV VITE_BACKEND_URL $VITE_BACKEND_URL

COPY . .
RUN npm run build
 
FROM nginx:stable-alpine AS production
COPY --from=build /dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
