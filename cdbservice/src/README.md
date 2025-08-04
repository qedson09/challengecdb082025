# 🧮 cdbservice

API em .NET 8 responsável pelo cálculo de retorno de investimento em CDB, utilizada pelo frontend Angular `cdbportal`.

---

## 📘 Visão Geral

O `cdbservice` expõe um endpoint HTTP `POST` que calcula o valor bruto e líquido de um investimento em CDB, com base no valor inicial e na quantidade de meses.

Desenvolvido com .NET 8, seguindo boas práticas de arquitetura, SOLID e DDD, e preparado para execução em containers Docker.

---

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- [ASP.NET Core Web API](https://learn.microsoft.com/aspnet/core)
- [C# 12](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [Docker](https://www.docker.com/)

---

## 🛠️ Estrutura de Pastas

```
src/
├── Cdb.Api/
│   ├── Controllers/
│   │   └── CdbController.cs
│   ├── Models/
│   │   └── RetornoInvestimento.cs
│   ├── Services/
│   │   └── CdbService.cs
│   ├── Program.cs
│   └── Cdb.Api.csproj
```

---

## 🖥️ Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Docker instalado (opcional para containerização)

---

## ⚙️ Execução Local

### Via CLI:

```bash
dotnet run --project src/Cdb.Api
```

A API será exposta em:
[http://localhost:8080](http://localhost:8080)

---

## 🐳 Executando com Docker

### Build da imagem:

```bash
docker build -t cdbservice ./src
```

### Executar container:

```bash
docker run -d -p 8080:8080 --name cdbservice-container cdbservice
```

A API estará disponível em:
[http://localhost:8080/swagger](http://localhost:8080)

---

## 📡 Endpoint

```http
POST /api/Cdb/calcularretornoinvestimento
```

### Payload esperado:

```json
{
  "valorInicial": 1000,
  "meses": 6
}
```

### Exemplo de resposta:

```json
{
  "valorBruto": 1009.72,
  "valorLiquido": 782.533
}
```

---

## 🧪 Testes

O projeto possui testes unitários implementados utilizando **xUnit**.

A cobertura de testes é medida com o **Coverlet** e está configurada para exigir **mínimo de 90%** de cobertura.

### 📊 Como gerar o relatório de cobertura

1. Execute os testes com a coleta de cobertura:

```bash
dotnet test --collect:"XPlat Code Coverage" --settings coverage.runsettings
```

2. Gere o relatório visual em HTML:

```bash
reportgenerator -reports:**/coverage.cobertura.xml -targetdir:coveragereport -reporttypes:Html
```

3. Abra o arquivo `coveragereport/index.html` no navegador para visualizar os resultados de cobertura.

> O arquivo `coverage.runsettings` já está configurado na raiz ou no projeto de testes.

---

## 📦 Build e Publicação

### Build local:

```bash
dotnet build src/Cdb.Api
```

### Publicação:

```bash
dotnet publish src/Cdb.Api -c Release -o ./publish
```

---

## 🐞 Problemas Conhecidos

- A performance da simulação pode variar com regras de negócio mais complexas e para prazos de investimentos com número de meses maior.
- A validação de entrada é básica e será expandida em versões futuras.

---
