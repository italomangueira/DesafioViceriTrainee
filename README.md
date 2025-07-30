
## DesafioViceriTrainee/Junior - Italo Mangueira 

O objetivo desse desafio é a criação de uma aplicação web composta de um frontend em Angular 19
e um backend (API) em .Net Core, versão 8. O aplicativo prover as
funcionalidades CRUD (Create, Read, Update, Delete) para uma base de dados de super-heróis, utilizando SQL Server. 

Optei por utilizar Arquitetura Limpa no meu projeto .NET porque ela oferece uma estrutura organizada, com separação clara de responsabilidades, facilitando a manutenção e evolução do sistema.

Além disso, a arquitetura limpa naturalmente incorpora diversos princípios do SOLID, como a Inversão de Dependência e a Responsabilidade Única, promovendo um código mais flexível e desacoplado.

Ela também se alinha com conceitos do Domain-Driven Design (DDD), valorizando a camada de domínio como núcleo da aplicação, onde a lógica de negócio é independente de infraestrutura e frameworks.

Por fim, o uso de design patterns, como Repository e Use Case, é facilitado e incentivado, contribuindo para um código mais reutilizável, testável e escalável.

Essa combinação me permite desenvolver um sistema robusto, preparado para mudanças futuras e com foco na qualidade de código desde o início.

## Funcionalidades

O aplicativo deve prover as seguintes funcionalidades:

• Cadastro de um novo super-herói

• Listagem dos super-heróis

• Consulta de um super-herói por Id

• Atualização de informações do super-herói por Id

• Exclusão de um super-herói por Id

• Disponibilização da documentação da API utilizando o Swagger

• Entity Framework para acesso ao banco de dados, tanto para leitura como para gravação
## Documentação da API

#### Retorna um item

```http
  GET /api/Herois/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `int` | **Obrigatório**. O ID do Heroi que você quer |

#### Cria um Heroi
```http
  POST /api/Herois
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `nome`      | `string` | **Obrigatório**. O nome do Heroi que você quer criar |
| `nomeHeroi`      | `string` | **Obrigatório**. O nome de Heroi que você quer criar |
| `dataNascimento`      | `datetime` | **Opcional**. A data de nascimento do Heroi que você quer criar |
| `altura`      | `float` | **Obrigatório**. Altura do Heroi que você quer criar |
| `peso`      | `float` | **Obrigatório**. O Peso do Heroi que você quer criar |
| `superpoderesIds`      | `int` | **Obrigatório**. Pelo menos um super poder para seu Super Heroi |


#### Atualiza um Heroi
```http
  PUT /api/Herois/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `int` | **Obrigatório**. O ID do Heroi que você quer atualizar |

#### Deleta um Heroi
```http
  DELETE /api/Herois/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `int` | **Obrigatório**. O ID do Heroi que você quer Excluir |






## Rodando localmente

Clone o projeto

```bash
  git clone https://github.com/italomangueira/DesafioViceriTrainee.git
```
**Projeto Angular**

• Mude a porta que você usa na sua maquina.

![App Screenshot](/assets/Cors.png)

• Mude a porta que você usa na sua maquina.

![App Screenshot](/assets/HeroServiceUrlApi.png)

• Mude a porta que você usa na sua maquina.

![App Screenshot](/assets/SuperPoderServiceUrlAPI.png)

Comandos

```bash
  npm install
```

```bash
  ng s
```

**Projeto .Net**

• Primeiro: rode o script que tem na pasta DataBase para criar as tabelas do banco de dados e coloque sua string de conexão junto com database context.

![App Screenshot](/assets/Connectionstring.png)
![App Screenshot](/assets/DbcontextSlqServer.png)

caso estiver usando outro banco de dados altere.

• Segundo: para facilitar a vida do examinador se quiser criar pelo codigo os super poderes altere só o nome do poder e a descrição.

![App Screenshot](/assets/CriarSuperPoderes.png)

Comandos

```bash
  dotnet build
```
```bash
  dotnet run
```

Comandos Migrations

```bash
  donet ef migrations add nome-da-migration --Infrastructure\BackHero_CRUD.Infrastructure --startup-project API\BackHero_CRUD.API
```
```bash
  donet ef database update nome-da-migration --Infrastructure\BackHero_CRUD.Infrastructure --startup-project API\BackHero_CRUD.API
```


## Script SQL

```sql
﻿USE [herois_db]
GO
/****** Object:  Table [dbo].[Herois]    Script Date: 29/07/2025 18:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Herois](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[NomeHeroi] [nvarchar](450) NOT NULL,
	[DataNascimento] [datetime2](7) NULL,
	[Altura] [real] NOT NULL,
	[Peso] [real] NOT NULL,
 CONSTRAINT [PK_Herois] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeroisSuperpoderes]    Script Date: 29/07/2025 18:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeroisSuperpoderes](
	[HeroiId] [int] NOT NULL,
	[SuperpoderId] [int] NOT NULL,
 CONSTRAINT [PK_HeroisSuperpoderes] PRIMARY KEY CLUSTERED 
(
	[HeroiId] ASC,
	[SuperpoderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Superpoderes]    Script Date: 29/07/2025 18:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Superpoderes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Superpoder] [nvarchar](max) NOT NULL,
	[Descricao] [nvarchar](max) NULL,
 CONSTRAINT [PK_Superpoderes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[HeroisSuperpoderes]  WITH CHECK ADD  CONSTRAINT [FK_HeroisSuperpoderes_Herois_HeroiId] FOREIGN KEY([HeroiId])
REFERENCES [dbo].[Herois] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HeroisSuperpoderes] CHECK CONSTRAINT [FK_HeroisSuperpoderes_Herois_HeroiId]
GO
ALTER TABLE [dbo].[HeroisSuperpoderes]  WITH CHECK ADD  CONSTRAINT [FK_HeroisSuperpoderes_Superpoderes_SuperpoderId] FOREIGN KEY([SuperpoderId])
REFERENCES [dbo].[Superpoderes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HeroisSuperpoderes] CHECK CONSTRAINT [FK_HeroisSuperpoderes_Superpoderes_SuperpoderId]
GO
```


## Demostração UI

• Tela Inicial: onde pode vizualizar os herois e cadastrar heroi tambem como excluir heroi.

![App Screenshot](/assets/Home.png)
lembrando que na hora de escolher um super poder para seu heroi, pressionar Ctrl para selecionar mais de um.

• Tela de Atulizar Heroi: onde pode atualizar Heroi já cadastrado junto com seus super poderes.

![App Screenshot](/assets/AtualizarHeroi.png)

• Tela de Cadastro de Heroi: tela separada para cadastro de heroi.

![App Screenshot](/assets/AtualizarHeroi.png)

• Tela de Detalhes do Heroi: Ao clicar no nome do heroi em seu card, redireciona para a tela onde pode vizualizar todos os dados do Heroi (Drescrição dos super poderes).

![App Screenshot](/assets/DetalhesHeroi.png)


## Autores

- [@italomangueira](https://github.com/italomangueira)

