# 📈 cdbportal

Simulador de CDB com layout SPA (Single Page Application) desenvolvido em **Angular 20.1.4** com suporte a **SSR (Server-Side Rendering)**, integrado com uma API .NET que realiza o cálculo de retorno de investimento.

---

## 📘 Visão Geral

O projeto `cdbportal` tem como objetivo fornecer uma interface interativa para simular investimentos em CDB, consumindo os dados de retorno de uma API .NET. Foi desenvolvido com foco em boas práticas de arquitetura, DDD, SOLID e otimizações modernas como SSR e Docker.

---

## 🚀 Tecnologias Utilizadas

- [Angular 20.1.4](https://angular.io/)
- [Node.js 22.18.0](https://nodejs.org/)
- [NPM 11.5.2](https://www.npmjs.com/)
- [Docker](https://www.docker.com/)
- [RxJS](https://rxjs.dev/)
- [TypeScript](https://www.typescriptlang.org/)
- [API externa em .NET 8](https://dotnet.microsoft.com/en-us/)

---

## 🛠️ Estrutura de Pastas

```
src/
├── app/
│   ├── components/
│   │   └── simulador-cdb/
│   ├── services/
│   ├── models/
│   ├── app.config.ts
│   ├── app.routes.ts
│   ├── app.ts
├── environments/
│   └── environment.ts
├── main.ts
├── main.server.ts
├── server.ts
├── styles.css
```

---

## 🖥️ Pré-requisitos

- Node.js `v22.18.0` ou superior
- Angular CLI `v20.1.4`
- Docker instalado (caso queira rodar com Docker)

---

## ⚙️ Instalação e Execução Local

```bash
# Instale as dependências
npm install

# Execute o projeto em modo de desenvolvimento
npm run start
```

---

## 🐳 Executando com Docker

### Build da imagem Docker:

```bash
docker build -t cdbportal .
```

### Executar o container:

```bash
docker run -d -p 4200:80 --name cdbportal-container cdbportal
```

O projeto estará disponível em:

[http://localhost:4200](http://localhost:4200)

> Certifique-se de que o build Angular foi gerado corretamente para produção (`dist/cdbportal`) antes de executar o container.

---


Certifique-se de que a porta `4200` (frontend) está liberada.

---

## 📡 Comunicação com a API .NET

A URL da API está centralizada em:

```
src/config/api-url.config.ts
```

O método chamado é:

```http
POST /api/Cdb/calcularretornoinvestimento
```

---

## 🔍 Funcionalidades

- 💰 Simulação de retorno de investimento em CDB
- 🔧 Validações de formulário com `ReactiveForms`
- ⌛ Loading spinner durante o cálculo
- 💡 Feedback para erros de API ou timeout
- 📐 Layout com menu lateral e SPA
- 🌐 SSR (Server-Side Rendering) ativado

---

## 📁 Configurações de Ambiente

O arquivo de ambiente está localizado em:

```ts
src/environments/environment.ts
```

Exemplo:

```ts
export const environment = {
  apiUrl: 'http://localhost:8080'
};
```

---

## 🧪 Testes

🛣️ **No roadmap**: Os testes com **Karma/Jasmine** serão incluídos em versões futuras.

---

## 📦 Build e Deploy

### Build para produção:

```bash
npm run build:ssr
```

### Servir SSR local:

```bash
npm run serve:ssr
```

---

## 🐞 Problemas Conhecidos

- A funcionalidade SSR pode não funcionar corretamente com todos os navegadores legados.
- O tempo de resposta da API .NET pode afetar a UX se não for otimizado.

---
