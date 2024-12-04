# Web API BURGUER MANIA

Este projeto é uma API para gerenciamento de pedidos, cardápio e clientes de uma hamburgueria.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET 8
- **ORM**: Entity Framework Core
- **Banco de Dados**: SQL Server

## Objetivo do Projeto

O objetivo desta API é fornecer funcionalidades para a gestão de uma hamburgueria, incluindo gerenciamento de pedidos, produtos, clientes e integração com sistemas externos

## Configuração do Ambiente

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/valeriasoars/api-burguer-mania.git
2. Navegue até a pasta do projeto
   ```bash
     cd api-burguer-mania

3. **Instale as dependências**
   ```bash
      dotnet restore

4. **Configuração de Banco de Dados**
   ```bash
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO;User Id=SEU_USUARIO;Password=SUA_SENHA;"
     }
   }

5. **Aplicar Migrações: Execute o comando abaixo para criar as tabelas no banco de dados**
```bash
dotnet ef database update
