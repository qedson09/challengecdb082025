# Etapa 1: Build Angular SPA
FROM node:22.12.0 AS builder

WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npm run build

# Etapa 2: Servidor NGINX
FROM nginx:stable-alpine

WORKDIR /usr/share/nginx/html

# Copia os arquivos buildados do Angular para o nginx
COPY --from=builder /app/dist/cdbportal .

# Remove o default.conf e adiciona custom SPA config
RUN rm /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d/

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
