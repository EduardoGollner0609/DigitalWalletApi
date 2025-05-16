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

## Endpoints da API

Abaixo estão listados os principais endpoints disponíveis na API, suas funcionalidades e requisitos de autenticação.

### 🧑‍💻 Usuário

- **Criar Usuário**
  - **Método:** `POST`
  - **Endpoint:** `/api/user`
  - **Descrição:** Cria um novo usuário no sistema.
  - **Autenticação:** ❌ Não requer autenticação

- **Login**
  - **Método:** `POST`
  - **Endpoint:** `/api/auth/login`
  - **Descrição:** Realiza o login do usuário e retorna um token JWT para autenticação.
  - **Autenticação:** ❌ Não requer autenticação

### 💼 Carteira

- **Consultar Saldo**
  - **Método:** `GET`
  - **Endpoint:** `/api/wallet/balance`
  - **Descrição:** Retorna o saldo atual da carteira do usuário autenticado.
  - **Autenticação:** ✅ Requer token JWT

- **Depositar Valor**
  - **Método:** `PUT`
  - **Endpoint:** `/api/wallet/deposit`
  - **Descrição:** Realiza um depósito na carteira do usuário autenticado.
  - **Autenticação:** ✅ Requer token JWT

### 🔁 Transferências

- **Criar Transferência**
  - **Método:** `POST`
  - **Endpoint:** `/api/transfer`
  - **Descrição:** Cria uma nova transferência entre usuários.
  - **Autenticação:** ✅ Requer token JWT

- **Listar Transferências Enviadas**
  - **Método:** `GET`
  - **Endpoint:** `/api/transfer/sent`
  - **Descrição:** Lista todas as transferências enviadas pelo usuário autenticado.
  - **Autenticação:** ✅ Requer token JWT

- **Listar Todas as Transferências**
  - **Método:** `GET`
  - **Endpoint:** `/api/transfer`
  - **Descrição:** Lista todas as transferências em que o usuário autenticado participou (enviadas e recebidas).
  - **Autenticação:** ✅ Requer token JWT

### 🔐 Autenticação

Para os endpoints protegidos, é necessário incluir o token JWT no cabeçalho da requisição:

```http
Authorization: Bearer <seu_token_aqui>
```
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



## 💾 Populando o Banco de Dados

- **OBS:** Execute as migrations que está na camada de infra, abre o terminal na raiz do projeto e execute o comando:

```bash
dotnet ef database update --project DigitalWallet.Infrastructure --startup-project DigitalWallet.Web
```

Abaixo estão os comandos SQL para inserir dados de exemplo no banco PostgreSQL. Isso facilita a visualização e testes dos endpoints da API. (🚨🚨Obs: A senha de todos os usuários estäo criptografadas, a senha real é "123456"🚨🚨)

### 👤 Inserindo Usuários

```sql
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('f6a7c18a-809e-4765-ab79-7187ae2875da', 'Eduardo', 'Gomes', 'eduardo.gomes@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 742.57, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('90cefd69-c66a-4228-8b42-64eeac434c6a', 'Maria', 'Ferreira', 'maria.ferreira@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2291.78, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('5c3589c6-d829-4f5d-b447-0b4964d3b677', 'Juliana', 'Martins', 'juliana.martins@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 757.47, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('1e37ccf4-f069-48ec-8548-c12f2b5bcae9', 'Rafael', 'Silva', 'rafael.silva@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2706.53, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 'Carlos', 'Oliveira', 'carlos.oliveira@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2601.57, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('6322387c-40b4-4e93-af2c-064da912054e', 'Fernanda', 'Pereira', 'fernanda.pereira@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2710.17, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('68d13b33-9da4-4307-926c-4c84eeee2206', 'Carlos', 'Souza', 'carlos.souza@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 921.53, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('aebcb787-76a2-432a-809a-bfec792975f6', 'Rafael', 'Almeida', 'rafael.almeida@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 979.29, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('c7fcfcc3-26a6-4281-a5f0-dfc2d0b08015', 'Pedro', 'Lima', 'pedro.lima@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 707.64, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('ae8253c2-6970-45ef-8cb0-293a04f8727c', 'Juliana', 'Lima', 'juliana.lima@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2318.54, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('213a6ddb-02ae-4fac-9ace-e73963a2940b', 'Beatriz', 'Souza', 'beatriz.souza@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2610.48, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('c40ec55f-6de5-4d65-8b4b-5c75788a6b31', 'João', 'Pereira', 'joão.pereira@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2152.45, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('446cde3c-e174-4ff0-9c24-782b4f5b51ed', 'Fernanda', 'Almeida', 'fernanda.almeida@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 1665.91, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('cc223c2b-15b1-448f-b755-580462ecf6e7', 'Carlos', 'Ferreira', 'carlos.ferreira@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2796.27, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('7222ca02-13c5-44de-a424-6a13ab0b9a74', 'Maria', 'Gomes', 'maria.gomes@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2433.08, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('9e96b095-a505-411b-b83f-da6ce8f92ae2', 'Ana', 'Silva', 'ana.silva@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2476.25, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('baf124f9-acc0-4177-8635-9c8dffa7f3da', 'Juliana', 'Lima', 'juliana.lima@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 973.22, 'User');
```

### 🔁 Tabela `Transfers`

```sql
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('2ef9615a-c338-4c9e-a913-9678373cc2f0', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '1e37ccf4-f069-48ec-8548-c12f2b5bcae9', 352.73, '2025-05-01T12:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d77f306a-c557-4b54-9186-71c1e53f4a88', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 385.53, '2025-05-01T12:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('9c7cfa38-d307-4923-9c55-e9782f62a1b9', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '7222ca02-13c5-44de-a424-6a13ab0b9a74', 409.5, '2025-05-01T13:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('411fafa4-edfd-4cd8-b69a-e9dbdeef613b', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', 232.07, '2025-05-01T14:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('18d2d21f-300e-49f9-9ed4-4e1fa11cd264', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'f6a7c18a-809e-4765-ab79-7187ae2875da', 183.52, '2025-05-01T15:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('2542dffd-f8ec-4654-9d5b-2da271185dbe', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'c7fcfcc3-26a6-4281-a5f0-dfc2d0b08015', 412.94, '2025-05-01T15:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('2b2a8de6-3232-45a1-bc06-dcd2309d96c2', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', 172.61, '2025-05-01T16:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('921bedd9-7cde-4f7b-bd65-72a03de32cde', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '1e37ccf4-f069-48ec-8548-c12f2b5bcae9', 223.57, '2025-05-01T17:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('ea84ea13-3701-419a-a139-0e311e7db156', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '446cde3c-e174-4ff0-9c24-782b4f5b51ed', 106.07, '2025-05-01T18:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d2da99d5-30ea-484d-9135-3b445cf6b866', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'baf124f9-acc0-4177-8635-9c8dffa7f3da', 383.94, '2025-05-01T18:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('1b485bc9-7179-48ac-9284-6cf31940e8ff', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'baf124f9-acc0-4177-8635-9c8dffa7f3da', 428.98, '2025-05-01T19:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('67725535-c4b8-4f6e-b699-d9f48c9d5d65', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 267.89, '2025-05-01T20:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('caa4cc8f-2b22-4233-9888-a0bf3c682ee3', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '446cde3c-e174-4ff0-9c24-782b4f5b51ed', 75.26, '2025-05-01T21:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('35e8861c-21dc-4b4f-b52b-6a07db8ff11b', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', 468.03, '2025-05-01T21:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('10b89267-6562-471b-93c0-4eda1257d95b', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'aebcb787-76a2-432a-809a-bfec792975f6', 46.37, '2025-05-01T22:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('53f4adca-2c73-4f39-8200-dcb288e7db9e', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', 151.14, '2025-05-01T23:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d6a9f9f2-e7d9-4585-b964-49b093470e1e', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 403.87, '2025-05-02T00:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('7ab623f7-4530-4608-b2b6-555aacc46143', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'baf124f9-acc0-4177-8635-9c8dffa7f3da', 259.14, '2025-05-02T00:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('97d3033a-316c-4eb1-818a-7004afcb9e83', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'baf124f9-acc0-4177-8635-9c8dffa7f3da', 454.48, '2025-05-02T01:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('3d3300b0-fb8f-4336-9778-f0985e57f1bd', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '6322387c-40b4-4e93-af2c-064da912054e', 423.48, '2025-05-02T02:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('934a6d8f-b56b-4a21-95b7-e5d69b9db482', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', 116.34, '2025-05-02T03:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('24969689-a4e0-4a6e-a572-d5c96b22fcc2', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 389.24, '2025-05-02T03:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('c0add648-3c52-434b-bdb4-456c7a50608b', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'aebcb787-76a2-432a-809a-bfec792975f6', 26.62, '2025-05-02T04:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('1174fceb-8092-45a6-aad4-848dd63c9e05', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'aebcb787-76a2-432a-809a-bfec792975f6', 133.54, '2025-05-02T05:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('46b740d6-23bf-4fd2-8c57-db295fe4dc4f', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'c7fcfcc3-26a6-4281-a5f0-dfc2d0b08015', 43.87, '2025-05-02T06:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('9c864637-df86-4b42-b79e-edd9899b9b4c', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', 122.16, '2025-05-02T06:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('dd26998b-c916-473b-b114-c386ab7a2fa3', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 41.27, '2025-05-02T07:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d9ca9c89-ab3f-43bd-b372-d5996c3a9245', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '446cde3c-e174-4ff0-9c24-782b4f5b51ed', 271.33, '2025-05-02T08:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('6348fbca-f547-4562-9721-fd4ebbd2d2c8', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '446cde3c-e174-4ff0-9c24-782b4f5b51ed', 151.33, '2025-05-02T09:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('22ccdf53-7576-449f-a87b-60e4b79c58c0', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '6322387c-40b4-4e93-af2c-064da912054e', 331.37, '2025-05-02T09:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('61fc9a6d-7d20-43d8-9f3b-93eeab190a18', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '7222ca02-13c5-44de-a424-6a13ab0b9a74', 63.67, '2025-05-02T10:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('61383366-ee31-47a5-ac85-d2cd207a9e17', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '90cefd69-c66a-4228-8b42-64eeac434c6a', 229.29, '2025-05-02T11:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('698a9df5-665f-4694-b8bc-5952eed37b05', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '213a6ddb-02ae-4fac-9ace-e73963a2940b', 427.43, '2025-05-02T12:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('3d93aced-f13c-41a0-bf61-e4a8bb5a289d', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '68d13b33-9da4-4307-926c-4c84eeee2206', 483.87, '2025-05-02T12:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('c1f76fc4-417f-466c-b460-7d5af03d55ed', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '7222ca02-13c5-44de-a424-6a13ab0b9a74', 353.22, '2025-05-02T13:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('6c572a9e-d11e-4411-b7e6-37f72c166139', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'baf124f9-acc0-4177-8635-9c8dffa7f3da', 316.38, '2025-05-02T14:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('36ec538c-e59c-46b9-985f-c4ab498cca4d', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '68d13b33-9da4-4307-926c-4c84eeee2206', 374.19, '2025-05-02T15:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('56cc0b14-4ffc-4271-a9ec-9273309af9f1', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '6322387c-40b4-4e93-af2c-064da912054e', 310.72, '2025-05-02T15:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('5321d286-f28d-4084-af22-cc59d4dd56ee', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '213a6ddb-02ae-4fac-9ace-e73963a2940b', 277.49, '2025-05-02T16:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('eaf03613-6990-4235-b3b3-7fd1db0a40ff', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 70.44, '2025-05-02T17:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('ba92f66c-d304-4313-ac31-940ea3da2003', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', 440.61, '2025-05-02T18:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('a8e9a02b-d4ed-469c-8a87-c058fea68b28', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'baf124f9-acc0-4177-8635-9c8dffa7f3da', 313.13, '2025-05-02T18:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('e41e17e4-9c02-4f2c-9516-5f87f5345c1a', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', 203.62, '2025-05-02T19:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('0363cab1-4dfa-4707-a488-b9f162464153', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 297.05, '2025-05-02T20:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('5676c7b2-0104-4ac1-b24c-1af31b58d088', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'f6a7c18a-809e-4765-ab79-7187ae2875da', 59.0, '2025-05-02T21:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('ac842a1a-7068-4a20-b80a-8b11971f55ab', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', 310.54, '2025-05-02T21:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('a238c7b9-19b7-4176-9832-e0020d4fce8c', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '7222ca02-13c5-44de-a424-6a13ab0b9a74', 344.35, '2025-05-02T22:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('ae6c306d-b83b-42ed-ac57-375193c3075a', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '68d13b33-9da4-4307-926c-4c84eeee2206', 238.03, '2025-05-02T23:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('88d1cd25-06a3-4135-bb01-c1903a47ab7f', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 476.04, '2025-05-03T00:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d3098f2b-5cd0-4af0-b158-efd6b592915d', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'f6a7c18a-809e-4765-ab79-7187ae2875da', 81.16, '2025-05-03T00:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('61294b6f-3539-4baa-8c31-e8810594c420', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'aebcb787-76a2-432a-809a-bfec792975f6', 62.79, '2025-05-03T01:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('989c9ff3-6dea-498e-8399-d603211a3cdd', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '68d13b33-9da4-4307-926c-4c84eeee2206', 435.31, '2025-05-03T02:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('915cc9bd-229f-4360-bebc-9edd5345dbc6', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 262.91, '2025-05-03T03:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('e0e9d990-f116-4e56-9931-d090610ed178', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '5c3589c6-d829-4f5d-b447-0b4964d3b677', 416.42, '2025-05-03T03:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('2c9b481a-3618-41b5-bd93-1e686c2e6250', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '7222ca02-13c5-44de-a424-6a13ab0b9a74', 114.79, '2025-05-03T04:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('5f5bfcbf-8de7-4042-8c77-40887928b2ee', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '446cde3c-e174-4ff0-9c24-782b4f5b51ed', 207.47, '2025-05-03T05:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d42117f9-5d30-4c91-a311-d3e0e6071a98', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', 70.42, '2025-05-03T06:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('5f313b22-74c1-4b41-b20e-6eb1c89a942f', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '6322387c-40b4-4e93-af2c-064da912054e', 431.98, '2025-05-03T06:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('705f5927-b751-4609-b7f2-7e1744c1d338', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '7222ca02-13c5-44de-a424-6a13ab0b9a74', 70.12, '2025-05-03T07:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('721239f5-0610-4868-971f-b28009c42b85', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '7222ca02-13c5-44de-a424-6a13ab0b9a74', 111.28, '2025-05-03T08:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('3d34f197-53c3-4f7f-bd0e-c26761ae0f1d', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '6322387c-40b4-4e93-af2c-064da912054e', 425.29, '2025-05-03T09:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('8d3abd83-d311-4699-8386-165a4edcaabb', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'c7fcfcc3-26a6-4281-a5f0-dfc2d0b08015', 213.14, '2025-05-03T09:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('67805725-6c9a-40c6-a112-8f35cd45114b', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '6322387c-40b4-4e93-af2c-064da912054e', 339.65, '2025-05-03T10:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('2d545706-fcb9-499a-b8a2-671126268789', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'aebcb787-76a2-432a-809a-bfec792975f6', 128.78, '2025-05-03T11:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('4ae98c55-f783-459b-8d71-0c2707eb8018', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '90cefd69-c66a-4228-8b42-64eeac434c6a', 330.97, '2025-05-03T12:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('6d9fac8b-e060-4963-a7b4-d45e8ada62a5', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 91.21, '2025-05-03T12:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('ea0380cd-723d-487e-8d2f-9d6a2d174ad1', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '68d13b33-9da4-4307-926c-4c84eeee2206', 434.97, '2025-05-03T13:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('42780c76-ab19-47ae-8b7f-94ce86f3920b', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '7222ca02-13c5-44de-a424-6a13ab0b9a74', 170.31, '2025-05-03T14:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('6f46aba8-d7b7-42c8-9579-e34bad9a114a', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '213a6ddb-02ae-4fac-9ace-e73963a2940b', 202.76, '2025-05-03T15:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('af249673-821e-4449-b13d-d95273580f0f', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '446cde3c-e174-4ff0-9c24-782b4f5b51ed', 493.25, '2025-05-03T15:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('4cfc4c58-661c-4a77-844a-f65247f3b210', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '446cde3c-e174-4ff0-9c24-782b4f5b51ed', 163.88, '2025-05-03T16:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('87f462a2-6ff0-4598-b470-3c2250cdb749', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '90cefd69-c66a-4228-8b42-64eeac434c6a', 153.75, '2025-05-03T17:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('9d48e327-faf8-42f1-99c2-21c3234fb1ba', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 40.6, '2025-05-03T18:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('f8ba1d8c-3ee3-4685-8f08-0a3a34827264', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '5c3589c6-d829-4f5d-b447-0b4964d3b677', 174.84, '2025-05-03T18:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d154b05d-9f07-4b40-802a-f0bc5e23f18b', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'aebcb787-76a2-432a-809a-bfec792975f6', 290.7, '2025-05-03T19:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('e2c3cb73-859c-4318-80d9-69cd15a50baf', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '1e37ccf4-f069-48ec-8548-c12f2b5bcae9', 442.47, '2025-05-03T20:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('f1704c47-3c07-42b0-8fb5-da63b42178b0', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'baf124f9-acc0-4177-8635-9c8dffa7f3da', 175.22, '2025-05-03T21:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d1c8186b-f779-40cc-b676-40eb948ecc11', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 158.33, '2025-05-03T21:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('b654e473-85f7-45f2-bc16-058c42a6675b', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'f6a7c18a-809e-4765-ab79-7187ae2875da', 288.29, '2025-05-03T22:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('a36b6a08-12cf-4cfa-ac0b-161b6d8b39e3', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', 421.95, '2025-05-03T23:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('c2cf8e42-0269-4e25-a079-9c75358d5c0a', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 179.01, '2025-05-04T00:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('fe4177a7-0e33-4aba-89e2-dcf072670390', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '213a6ddb-02ae-4fac-9ace-e73963a2940b', 114.35, '2025-05-04T00:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('a508d998-ff8b-4f8c-b22f-47e2bcfc822a', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '68d13b33-9da4-4307-926c-4c84eeee2206', 150.53, '2025-05-04T01:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('48af633f-3db4-499f-95ba-112182d3631e', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '5c3589c6-d829-4f5d-b447-0b4964d3b677', 62.82, '2025-05-04T02:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('901c2e58-1fe6-4f04-92b8-9d95bec339fe', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '5c3589c6-d829-4f5d-b447-0b4964d3b677', 303.13, '2025-05-04T03:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('b662f343-92c5-4fd1-a3d0-8efd68060267', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', 298.18, '2025-05-04T03:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('e78346c0-8d5f-4910-aafc-59ff90a71c1e', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '6322387c-40b4-4e93-af2c-064da912054e', 223.91, '2025-05-04T04:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('29f77e27-8a67-4b52-abf9-8b01a11676b6', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '6322387c-40b4-4e93-af2c-064da912054e', 141.4, '2025-05-04T05:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('dd099444-70bd-43ab-8861-340547ef8fde', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '5c3589c6-d829-4f5d-b447-0b4964d3b677', 56.57, '2025-05-04T06:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('03d8d4a2-0802-4836-92b6-04a53dc96aa0', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'f6a7c18a-809e-4765-ab79-7187ae2875da', 10.6, '2025-05-04T06:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('2e6b4346-d3d0-43e3-b91c-d49bb16e20b1', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '90cefd69-c66a-4228-8b42-64eeac434c6a', 103.47, '2025-05-04T07:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('63b8416c-7ef1-49cd-af68-42be6b5932c1', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 115.55, '2025-05-04T08:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('610553fc-74ac-4dac-b9dd-cc7712d9e130', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', 160.83, '2025-05-04T09:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('9432ad92-023b-4234-a96c-aa07646bf929', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '6322387c-40b4-4e93-af2c-064da912054e', 36.59, '2025-05-04T09:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('c5c8855c-afe6-4df3-ab2b-2bb1940557cf', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'c7fcfcc3-26a6-4281-a5f0-dfc2d0b08015', 205.31, '2025-05-04T10:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('7d164926-41cd-4cb6-9fe5-07528bcc9e56', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'baf124f9-acc0-4177-8635-9c8dffa7f3da', 197.29, '2025-05-04T11:15:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('b02fd3df-e31c-4263-9002-6c724db23ae4', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '68d13b33-9da4-4307-926c-4c84eeee2206', 124.02, '2025-05-04T12:00:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('bd8edd23-d5be-47cd-89de-14fe37f36092', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '6322387c-40b4-4e93-af2c-064da912054e', 497.42, '2025-05-04T12:45:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('6c137f5d-a45a-4d5d-a5a6-013fb8abdd6f', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'aebcb787-76a2-432a-809a-bfec792975f6', 313.22, '2025-05-04T13:30:00');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('47062f19-0a28-45e3-b19f-55e770f5afa9', 'cc223c2b-15b1-448f-b755-580462ecf6e7', '1e37ccf4-f069-48ec-8548-c12f2b5bcae9', 221.8, '2025-05-04T14:15:00');
```

---

## ⚙️ Como Rodar o Projeto

1. Clone o repositório:

```bash
git clone https://github.com/EduardoGollner0609/DigitalWalletApi.git
cd DigitalWalletApi
```
