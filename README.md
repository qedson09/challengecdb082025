# 📊 Simulador CDB - Fullstack (Angular SSR + .NET API)

Projeto completo com frontend em **Angular 20.1.4** com **SSR (Server-Side Rendering)** e backend em **.NET 8**, orquestrado com **Docker Compose**.

---

## 🧭 Visão Geral

Este projeto consiste em dois serviços:

- **cdbportal**: SPA com SSR (Angular) responsável pela interface e chamada à API.
- **cdbservice**: API .NET 8 que realiza o cálculo do retorno do investimento em CDB.

O usuário acessa o simulador no navegador, informa o valor inicial e o prazo (em meses), e obtém o retorno bruto e líquido do investimento.

---

## ⚙️ Tecnologias Utilizadas

- [Angular 20.1.4](https://angular.io/)
- [Node.js 22.18.0](https://nodejs.org/)
- [.NET 8](https://dotnet.microsoft.com/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)
- [RxJS](https://rxjs.dev/)
- [TypeScript](https://www.typescriptlang.org/)

---

## 🧱 Estrutura de Pastas

```
.
├── cdbportal/          # Projeto Angular
│   └── src/
│       ├── app/
│       ├── environments/
│       └── ...
├── cdbservice/         # Projeto .NET API
│   └── src/
│       ├── Controllers/
│       ├── Services/
│       └── ...
├── docker-compose.yml
```

---

## ▶️ Como Executar com Docker Compose

### 1. Build dos serviços

```bash
docker-compose build
```

### 2. Subir os containers

```bash
docker-compose up
```

### 3. Acessar o projeto

- Frontend Angular (SPA SSR): [http://localhost:4200](http://localhost:4200)
- API .NET: [http://localhost:8080/swagger](http://localhost:8080/swagger)

---

## 🖥️ Configuração das URLs

O frontend se comunica com a API através da seguinte rota:

```http
POST http://localhost:8080/api/Cdb/calcularretornoinvestimento
```

A URL está centralizada no arquivo:

```ts
src/config/api-url.config.ts
```

---

## 💡 Funcionalidades

- Simulação de retorno de investimento (bruto e líquido)
- Layout moderno com menu lateral fixo
- Formulário com validações reativas
- Loading spinner durante o processamento
- Feedback em caso de erros ou timeout
- SPA com SSR (server-side rendering)

---

## 📦 Build Manual (caso não use Docker)

### Angular

```bash
cd cdbportal
npm install
npm run build:ssr
npm run serve:ssr
```

### .NET API

```bash
cd cdbservice/src
dotnet build
dotnet run
```

---
