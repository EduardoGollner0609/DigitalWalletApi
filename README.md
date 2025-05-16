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
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('f6a7c18a-809e-4765-ab79-7187ae2875da', 'Eduardo', 'Gomes', 'eduardo.gomes@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 742.57, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('90cefd69-c66a-4228-8b42-64eeac434c6a', 'Maria', 'Ferreira', 'maria.ferreira@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2291.78, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('5c3589c6-d829-4f5d-b447-0b4964d3b677', 'Juliana', 'Martins', 'juliana.martins@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 757.47, 'Admin');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('1e37ccf4-f069-48ec-8548-c12f2b5bcae9', 'Rafael', 'Silva', 'rafael.silva@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2706.53, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 'Carlos', 'Oliveira', 'carlos.oliveira@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2601.57, 'Admin');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('6322387c-40b4-4e93-af2c-064da912054e', 'Fernanda', 'Pereira', 'fernanda.pereira@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2710.17, 'Admin');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('68d13b33-9da4-4307-926c-4c84eeee2206', 'Carlos', 'Souza', 'carlos.souza@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 921.53, 'Admin');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('aebcb787-76a2-432a-809a-bfec792975f6', 'Rafael', 'Almeida', 'rafael.almeida@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 979.29, 'Admin');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('c7fcfcc3-26a6-4281-a5f0-dfc2d0b08015', 'Pedro', 'Lima', 'pedro.lima@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 707.64, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('ae8253c2-6970-45ef-8cb0-293a04f8727c', 'Juliana', 'Lima', 'juliana.lima@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2318.54, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('213a6ddb-02ae-4fac-9ace-e73963a2940b', 'Beatriz', 'Souza', 'beatriz.souza@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2610.48, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('c40ec55f-6de5-4d65-8b4b-5c75788a6b31', 'João', 'Pereira', 'joão.pereira@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2152.45, 'Admin');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('446cde3c-e174-4ff0-9c24-782b4f5b51ed', 'Fernanda', 'Almeida', 'fernanda.almeida@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 1665.91, 'Admin');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('cc223c2b-15b1-448f-b755-580462ecf6e7', 'Carlos', 'Ferreira', 'carlos.ferreira@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2796.27, 'Admin');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('7222ca02-13c5-44de-a424-6a13ab0b9a74', 'Maria', 'Gomes', 'maria.gomes@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2433.08, 'User');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('9e96b095-a505-411b-b83f-da6ce8f92ae2', 'Ana', 'Silva', 'ana.silva@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 2476.25, 'Admin');
INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "Balance", "Role") VALUES ('baf124f9-acc0-4177-8635-9c8dffa7f3da', 'Juliana', 'Lima', 'juliana.lima@example.com', '$2a$11$rsuz4P7u06bk0gZYkLeasu5uLlum5MfHRm9rgfgabyzlupHubkpH6', 973.22, 'Admin');
```

### 🔁 Tabela `Transfers`

```sql

INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('16c51744-3308-41e0-bf9f-dae9f4e21e26', '96974ddc-3926-4182-870e-e413fe38da7c', '1e37ccf4-f069-48ec-8548-c12f2b5bcae9', 145.32, '2024-08-28T14:39:01.590710');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('58d6ace2-eabc-42e4-9b40-0abe6da7cf2c', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 169.38, '2025-01-22T14:39:01.590772');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('ea3da181-9845-406c-9135-843cbd42f250', '5c3589c6-d829-4f5d-b447-0b4964d3b677', 'aebcb787-76a2-432a-809a-bfec792975f6', 51.9, '2025-02-03T14:39:01.590820');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('c07704bc-de9a-4f46-888a-3ce31b88da8e', '7222ca02-13c5-44de-a424-6a13ab0b9a74', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 459.03, '2025-03-06T14:39:01.590982');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('44a5b73b-6968-479b-bd0c-7342fb15fcc1', 'f35a78e8-e39a-48ec-88cc-f95846978908', 'f6a7c18a-809e-4765-ab79-7187ae2875da', 251.78, '2024-07-02T14:39:01.591296');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('aad5900c-381d-425f-9c7a-f385e63d9d53', '6322387c-40b4-4e93-af2c-064da912054e', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 54.12, '2024-10-30T14:39:01.591346');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d4d06f13-480d-4bab-919f-b6ea879f58f5', 'c7fcfcc3-26a6-4281-a5f0-dfc2d0b08015', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 134.88, '2024-08-28T14:39:01.591387');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('0e76e130-4b6a-40a1-8ace-5e3d8d3be613', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', 481.54, '2024-10-21T14:39:01.591502');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('04c828ed-1097-48ed-8389-b09060ef39af', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 32.97, '2024-08-09T14:39:01.591633');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('1f6f5ed7-6695-4ce2-94a8-ea60ce2f26f8', 'aebcb787-76a2-432a-809a-bfec792975f6', 'c7fcfcc3-26a6-4281-a5f0-dfc2d0b08015', 441.48, '2024-11-16T14:39:01.591843');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d5744da3-ee5a-41e7-8f5c-758dc8c93dd2', '850161fb-c09d-48ad-83a2-827d7dc6febe', '5c3589c6-d829-4f5d-b447-0b4964d3b677', 398.68, '2024-05-27T14:39:01.591906');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('cb49ad37-19fa-41a5-8918-510d531548f3', 'f6a7c18a-809e-4765-ab79-7187ae2875da', '213a6ddb-02ae-4fac-9ace-e73963a2940b', 55.26, '2025-02-28T14:39:01.591950');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('767a5e30-9efe-4c71-91f5-497c1cec7fca', '96974ddc-3926-4182-870e-e413fe38da7c', '850161fb-c09d-48ad-83a2-827d7dc6febe', 231.04, '2024-05-27T14:39:01.591975');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('610986cd-e6a5-4104-aa4a-524ced5e6a79', '5c3589c6-d829-4f5d-b447-0b4964d3b677', '6322387c-40b4-4e93-af2c-064da912054e', 220.09, '2024-12-11T14:39:01.592008');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('5abaf47e-1ca4-459c-9ed1-d92876d1bac7', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', '446cde3c-e174-4ff0-9c24-782b4f5b51ed', 144.02, '2025-03-13T14:39:01.592044');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('4bde38f4-0ac2-47eb-b736-703ef467c179', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', '68d13b33-9da4-4307-926c-4c84eeee2206', 86.14, '2024-07-23T14:39:01.592213');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('446a8dbb-1112-43df-ad1c-e91beeaf9939', '446cde3c-e174-4ff0-9c24-782b4f5b51ed', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 363.04, '2025-05-06T14:39:01.592256');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('5ee4e166-9ebb-4dad-b3d2-e3fd68e57f67', '6322387c-40b4-4e93-af2c-064da912054e', '1e37ccf4-f069-48ec-8548-c12f2b5bcae9', 16.41, '2024-10-23T14:39:01.592490');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('b2071455-6b27-4ae9-86a1-5d2b751aa845', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', '6322387c-40b4-4e93-af2c-064da912054e', 18.66, '2025-03-17T14:39:01.592558');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('79541f2b-8cb0-4905-88bb-efb81b01950a', 'c7fcfcc3-26a6-4281-a5f0-dfc2d0b08015', '5c3589c6-d829-4f5d-b447-0b4964d3b677', 192.0, '2025-02-09T14:39:01.592581');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('2d7f28b4-db51-497a-9c31-468e809209ca', '68d13b33-9da4-4307-926c-4c84eeee2206', '7222ca02-13c5-44de-a424-6a13ab0b9a74', 15.84, '2024-12-16T14:39:01.592599');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('cb762403-1189-4618-9b02-146af6874f20', '213a6ddb-02ae-4fac-9ace-e73963a2940b', '5c3589c6-d829-4f5d-b447-0b4964d3b677', 201.51, '2025-05-12T14:39:01.592622');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('35da783d-e1e2-4e4b-a3e7-3ef942f23cd9', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', 60.06, '2024-07-04T14:39:01.592652');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d515f734-2fbf-4c1d-9b47-aea14b324244', '5c3589c6-d829-4f5d-b447-0b4964d3b677', 'c7fcfcc3-26a6-4281-a5f0-dfc2d0b08015', 70.19, '2025-04-19T14:39:01.592677');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('95d8b226-771d-4c43-a117-542a64d8b919', '96974ddc-3926-4182-870e-e413fe38da7c', 'f35a78e8-e39a-48ec-88cc-f95846978908', 30.04, '2025-04-01T14:39:01.592699');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('0e32dabb-99cd-487d-80a2-fd787b4723c0', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', '90cefd69-c66a-4228-8b42-64eeac434c6a', 60.6, '2025-01-01T14:39:01.592712');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('6d280b97-dfa6-4512-b7e5-b2aa73ad1731', '9e96b095-a505-411b-b83f-da6ce8f92ae2', '7222ca02-13c5-44de-a424-6a13ab0b9a74', 388.83, '2024-08-19T14:39:01.592723');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('b84c93fb-ca0a-493b-a30d-195281d3dfc2', '6322387c-40b4-4e93-af2c-064da912054e', 'baf124f9-acc0-4177-8635-9c8dffa7f3da', 425.59, '2024-09-01T14:39:01.592736');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('8f8a46ba-1dfa-4ca8-9b53-6f07e76b4e37', '96974ddc-3926-4182-870e-e413fe38da7c', '850161fb-c09d-48ad-83a2-827d7dc6febe', 10.63, '2024-06-19T14:39:01.592778');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('22bbee05-46b4-43a9-a9ee-dca66f11a597', '850161fb-c09d-48ad-83a2-827d7dc6febe', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 368.8, '2024-06-14T14:39:01.592790');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('4a956d21-b1c4-4b83-917d-df17342d4d50', '1e37ccf4-f069-48ec-8548-c12f2b5bcae9', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 320.25, '2024-10-23T14:39:01.592802');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('c13f1983-d076-4103-87df-478ec8418c80', '90cefd69-c66a-4228-8b42-64eeac434c6a', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 456.33, '2025-01-28T14:39:01.592815');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('413776f1-72ad-40a3-bc1e-4278dbaf9c1a', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', '446cde3c-e174-4ff0-9c24-782b4f5b51ed', 122.77, '2024-10-04T14:39:01.592836');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('c7e7e8f2-47e2-4620-b031-ecd7fbbca537', 'aebcb787-76a2-432a-809a-bfec792975f6', 'f6a7c18a-809e-4765-ab79-7187ae2875da', 120.59, '2025-02-07T14:39:01.592871');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('4ff137e0-6da3-4da3-88ae-eaa9fda86958', 'f6a7c18a-809e-4765-ab79-7187ae2875da', '90cefd69-c66a-4228-8b42-64eeac434c6a', 411.12, '2024-08-09T14:39:01.592906');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('56773648-ea96-4c86-ae68-f8f184044164', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 393.93, '2024-06-29T14:39:01.592919');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('fe0e84be-da5f-4eab-9ebe-8c10d62d761d', '96974ddc-3926-4182-870e-e413fe38da7c', 'f6a7c18a-809e-4765-ab79-7187ae2875da', 39.07, '2024-06-14T14:39:01.592931');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('57881650-5865-44e9-829e-ffc9b469a40a', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 'c7fcfcc3-26a6-4281-a5f0-dfc2d0b08015', 34.77, '2025-01-28T14:39:01.592949');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('eadfda75-cb2b-426c-b4b9-2cd8677edc4c', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 67.5, '2024-07-17T14:39:01.592964');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('9b6908ab-1633-42b7-9195-4e32b9e9699b', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', '213a6ddb-02ae-4fac-9ace-e73963a2940b', 230.13, '2025-03-09T14:39:01.593053');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('d410d7ac-4a03-474e-bc7c-fa93eb933111', '68d13b33-9da4-4307-926c-4c84eeee2206', 'f35a78e8-e39a-48ec-88cc-f95846978908', 94.29, '2024-12-14T14:39:01.593211');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('14b6f506-1520-48d5-8145-e06791b55110', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', '850161fb-c09d-48ad-83a2-827d7dc6febe', 319.06, '2024-11-01T14:39:01.593281');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('e467e709-5e08-4708-92be-097761672bac', 'c40ec55f-6de5-4d65-8b4b-5c75788a6b31', '68d13b33-9da4-4307-926c-4c84eeee2206', 370.62, '2025-03-14T14:39:01.593302');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('215954d5-f4e8-4988-b341-5108d9ff1cab', '1e37ccf4-f069-48ec-8548-c12f2b5bcae9', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', 302.0, '2025-05-13T14:39:01.593316');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('c96ae60f-9425-4607-a21f-ceb83eecb0d5', '5c3589c6-d829-4f5d-b447-0b4964d3b677', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 201.46, '2024-10-05T14:39:01.593329');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('3d371946-b603-4e6e-b7ef-2a19b651d2ed', 'aebcb787-76a2-432a-809a-bfec792975f6', 'f9a472fb-59ae-4d75-bbed-4d4c37abf8c3', 339.39, '2024-09-21T14:39:01.593346');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('73762abf-8855-433c-9d49-2442dab21a29', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 380.78, '2024-09-05T14:39:01.593362');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('2022bd45-0130-4cb1-852b-b0ff7f68965f', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 'cc223c2b-15b1-448f-b755-580462ecf6e7', 105.5, '2024-10-28T14:39:01.593386');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('6bbacfc4-e9c9-43b0-9f41-ed56ea271553', '446cde3c-e174-4ff0-9c24-782b4f5b51ed', '213a6ddb-02ae-4fac-9ace-e73963a2940b', 413.92, '2025-04-02T14:39:01.593411');
INSERT INTO "Transfers" ("Id", "SenderId", "ReceiverId", "Amount", "Moment") VALUES ('06285cd7-fff3-4da4-9224-8c4df61b60da', 'ae8253c2-6970-45ef-8cb0-293a04f8727c', '9e96b095-a505-411b-b83f-da6ce8f92ae2', 432.02, '2024-06-23T14:39:01.593423');
```
