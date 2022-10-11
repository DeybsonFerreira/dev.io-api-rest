# Controller > Services > Repository
# View > Business > Data

# Onion Architecture

## Camada Api/View (Api) é a mais external
- Conversa com o Domain
- Conversa com a Infrastructure

## Camada de Infrastructure (Data)
- Conversa com o Domain

## Camada Domain (Business) é a mais interna
- não depender de ninguém




---------------------------------------------------------
# Pacotes
> UTILIZAR CUSTOM RESPONSE, PARA TODOS ENDPOINTS (PADRÃO) 

- dotnet add package AutoMapper --version 11.0.1
- dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 11.0.0
- dotnet add package Microsoft.AspNetCore.Mvc.Versioning --version 5.0.0
- dotnet add package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer --version 5.0.0