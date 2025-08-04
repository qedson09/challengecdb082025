# Etapa 1: Build Angular SSR (Client + Server)
FROM node:22.12.0 AS builder

WORKDIR /app

# Instala dependências
COPY package*.json ./
RUN npm install

# Copia o restante do projeto e executa o build SSR (client + server)
COPY . .
RUN npm run build:client

# Etapa 2: Runtime com Node.js
FROM node:22.12.0-alpine

WORKDIR /app

# Copia apenas os arquivos necessários para rodar a aplicação
COPY --from=builder /app/dist /app/dist
COPY --from=builder /app/package*.json ./

# Instala apenas dependências de produção
RUN npm install --omit=dev

EXPOSE 4000

# Usa o script "serve:ssr" do package.json
CMD ["npm", "run", "serve:ssr"]
