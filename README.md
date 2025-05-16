# 💸 Digital Wallet API

Sistema de transações bancárias desenvolvido em **C# com ASP.NET Core**, aplicando os princípios de **Clean Architecture** e o padrão **Repository Pattern**.

Esta API permite que usuários realizem transferências entre contas com controle de saldo e histórico de movimentações.

---

## 🚀 Tecnologias Utilizadas

- C# com ASP.NET Core
- PostgreSQL com Entity Framework Core
- Clean Architecture
- Repository Pattern
- Authentication e JWT Bearer
- Swagger (OpenAPI) para documentação

---

## 📁 Estrutura da Solução

A aplicação foi construída seguindo os princípios da **Clean Architecture**, organizando o código em camadas bem definidas e independentes entre si. Essa estrutura facilita a manutenção, testes e escalabilidade da aplicação:

- **`Domain`**  
  Contém as **entidades** do núcleo do sistema e as **interfaces** que representam os contratos da aplicação.

- **`Application`**  
  Camada responsável pelos **casos de uso**, validações e regras de negócio. Orquestra as regras da aplicação e depende apenas de abstrações definidas no domínio.

- **`Infrastructure`**  
  Implementa os contratos definidos (abstrações), o acesso ao banco de dados usando **Entity Framework Core** e injeção de dependências.
  
- **`API`**  
  Contém a **camada de apresentação** — Controllers, End-Points, DTOs, documentação com Swagger.

---

## 🧑‍💼 Estrutura do Banco de Dados

### 🧍 Tabela `Users`

| Campo       | Tipo         | Descrição                  |
|-------------|--------------|----------------------------|
| Id          | UUID         | Identificador único        |
| FirstName   | varchar(40)  | Primeiro nome              |
| LastName    | varchar(40)  | Sobrenome                  |
| Email       | text         | E-mail do usuário          |
| Password    | text         | Senha (criptografada)      |
| Balance     | numeric(18,2)| Saldo disponível           |
| Role        | text         | Papel (`Admin`, `User`)    |

### 🔁 Tabela `Transfers`

| Campo       | Tipo                        | Descrição                        |
|-------------|-----------------------------|----------------------------------|
| Id          | UUID                        | Identificador da transferência   |
| SenderId    | UUID (FK → Users)           | Quem enviou                      |
| ReceiverId  | UUID (FK → Users)           | Quem recebeu                     |
| Amount      | numeric(18,2)               | Valor transferido                |
| Moment      | timestamp with time zone    | Data e hora da transferência     |

---

## ⚙️ Como Rodar o Projeto

1. Clone o repositório:

```bash
git clone https://github.com/EduardoGollner0609/DigitalWalletApi.git
cd DigitalWalletApi
```

---

## 💾 Populando o Banco de Dados

- **OBS:** Execute as migrations que está na camada de infra, abre o terminal na raiz do projeto e execute o comando:

```bash
dotnet ef database update --project DigitalWallet.Infrastructure --startup-project DigitalWallet.Web
```

Abaixo estão os comandos SQL para inserir dados de exemplo no banco PostgreSQL. Isso facilita a visualização e testes dos endpoints da API. (🚨🚨Obs: A senha de todos os usuários estäo criptografadas, a senha real é "123456"🚨🚨)

---

### 👤 Inserindo Usuários

```sql

```

### 🔁 Tabela `Transfers`

```sql

```
