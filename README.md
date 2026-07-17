
# 🎓 Sistema de Gerenciamento Acadêmico – Escola de Cursos

## 📌 Descrição do Projeto

O **Sistema de Gerenciamento Acadêmico – Escola de Cursos** é uma aplicação web desenvolvida para auxiliar uma escola de cursos profissionalizantes no controle de sua estrutura acadêmica.

A plataforma permite gerenciar categorias, níveis de dificuldade, cursos, módulos, turmas, instrutores, alunos e matrículas, oferecendo uma visão centralizada das informações acadêmicas e facilitando os processos administrativos da instituição.

O projeto foi desenvolvido pela **Academia do Programador** com o objetivo de disponibilizar uma solução completa para gerenciamento de cursos presenciais e online.

---

# 🚀 Funcionalidades do Sistema

## 📚 Módulo de Categorias

### Funcionalidades

* Cadastro de categorias.
* Edição de categorias.
* Exclusão de categorias.
* Listagem de categorias cadastradas.
* Pesquisa de categorias pelo nome.

### Regras de Negócio

* O nome da categoria é obrigatório.
* O nome deve possuir entre **2 e 100 caracteres**.
* Não podem existir categorias com nomes duplicados.
* Não é permitida a exclusão de categorias que possuem cursos vinculados.

---

# 📊 Módulo de Níveis de Dificuldade

### Funcionalidades

* Cadastro de níveis de dificuldade.
* Edição de níveis.
* Exclusão de níveis.
* Listagem dos níveis cadastrados.
* Pesquisa por nome.
* Visualização dos cursos associados.

### Regras de Negócio

* Nome obrigatório entre **2 e 50 caracteres**.
* Descrição obrigatória.
* Classificação obrigatória.
* Todo curso deve possuir um nível de dificuldade.
* Um nível pode possuir vários cursos vinculados.
* Não é permitida exclusão de níveis associados a cursos.

---

# 📖 Módulo de Cursos

### Funcionalidades

* Cadastro de cursos.
* Edição de cursos.
* Exclusão de cursos.
* Listagem de cursos.
* Visualização dos módulos pertencentes ao curso.
* Pesquisa por:

  * Nome.
  * Categoria.
  * Nível de dificuldade.

### Regras de Negócio

* Nome obrigatório entre **2 e 100 caracteres**.
* Carga horária obrigatória.
* Categoria obrigatória.
* Nível de dificuldade obrigatório.
* A carga horária deve ser maior que zero.
* Não podem existir cursos com nomes duplicados.
* Um curso pode possuir vários módulos.
* Não é permitida exclusão de cursos com turmas cadastradas.

---

# 🧩 Módulo de Módulos

### Funcionalidades

* Cadastro de módulos.
* Edição de módulos.
* Exclusão de módulos.
* Listagem de módulos.
* Visualização dos módulos de um curso.

### Regras de Negócio

* Nome obrigatório entre **2 e 100 caracteres**.
* Duração obrigatória.
* Ordem obrigatória.
* Curso obrigatório.
* A duração deve ser maior que zero.
* A ordem não pode se repetir dentro do mesmo curso.
* Não é permitida exclusão de módulos vinculados a cursos ativos.

---

# 🏫 Módulo de Turmas

### Funcionalidades

* Cadastro de turmas.
* Edição de turmas.
* Exclusão de turmas.
* Listagem de turmas.
* Visualização dos alunos matriculados.

### Regras de Negócio

* Nome obrigatório entre **2 e 100 caracteres**.
* Período obrigatório.
* Data de início obrigatória.
* Data de término obrigatória.
* Quantidade máxima de alunos obrigatória.
* Curso obrigatório.
* Instrutor obrigatório.

Regras:

* Toda turma deve possuir exatamente um curso.
* Toda turma deve possuir exatamente um instrutor.
* A data final deve ser posterior à data inicial.
* A capacidade máxima deve ser maior que zero.
* Não é permitida exclusão de turmas com matrículas.

---

# 👨‍🏫 Módulo de Instrutores

### Funcionalidades

* Cadastro de instrutores.
* Edição de instrutores.
* Exclusão de instrutores.
* Listagem de instrutores.

### Regras de Negócio

Campos obrigatórios:

* Nome.
* Telefone.
* E-mail.
* CPF.

Validações:

* E-mail deve possuir formato válido.
* CPF deve possuir formato válido.
* CPF deve ser único.
* Telefone deve possuir formato válido.
* Não podem existir instrutores com CPF duplicado.
* Não é permitida exclusão de instrutores vinculados a turmas.

---

# 👨‍🎓 Módulo de Alunos

### Funcionalidades

* Cadastro de alunos.
* Edição de alunos.
* Exclusão de alunos.
* Listagem de alunos.
* Pesquisa por nome.

### Regras de Negócio

Campos obrigatórios:

* Nome.
* Telefone.
* E-mail.

Validações:

* Nome deve possuir entre **2 e 100 caracteres**.
* E-mail deve possuir formato válido.
* Telefone deve possuir formato válido.
* Não podem existir alunos com o mesmo e-mail.
* Não é permitida exclusão de alunos com matrículas ativas.

---

# 📝 Módulo de Matrículas

### Funcionalidades

* Cadastro de matrículas.
* Alteração da situação da matrícula.
* Cancelamento de matrículas.
* Listagem de matrículas.
* Visualização das matrículas por aluno.
* Visualização dos alunos de uma turma.

### Regras de Negócio

Campos obrigatórios:

* Data de inscrição.
* Situação.
* Aluno.
* Turma.

Situações disponíveis:

* Ativa.
* Cancelada.
* Concluída.

Regras:

* Toda matrícula deve possuir um aluno.
* Toda matrícula deve possuir uma turma.
* Apenas alunos cadastrados podem ser matriculados.
* Apenas turmas cadastradas podem receber alunos.
* Um aluno pode participar de várias turmas.
* Um aluno não pode possuir duas matrículas na mesma turma.
* A quantidade de matrículas não pode ultrapassar a capacidade da turma.
* A data de inscrição é registrada automaticamente pelo sistema.

---

# 🏗️ Estrutura do Projeto

O sistema segue uma arquitetura organizada em camadas:

```
EscolaDeCursos
│
├── Dominio
│   ├── Entidades
│   ├── Regras de Negócio
│   └── Interfaces
│
├── Aplicacao
│   ├── Serviços
│   ├── DTOs
│   └── Validações
│
├── Infra
│   ├── Repositórios
│   ├── ORM
│   └── Banco de Dados
│
└── WebApp
    ├── Controllers
    ├── Views
    └── ViewModels
```

---

# 🛠️ Tecnologias Utilizadas

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* Bootstrap
* Razor Pages / Views
* FluentResults
* FluentValidation
* AutoMapper

---

# 🔐 Controle de Acesso

O sistema possui autenticação de usuários permitindo acesso controlado às funcionalidades administrativas.

---

# 📌 Objetivo

Disponibilizar uma solução completa para gerenciamento acadêmico, permitindo que uma escola de cursos organize:

* Seus cursos.
* Professores.
* Alunos.
* Turmas.
* Matrículas.
* Estrutura pedagógica.

Garantindo organização, segurança e facilidade de manutenção das informações.


## 🚀 COMO UTILIZAR

1. Clone o repositório ou baixe o código fonte.
2. Abra o terminal ou o prompt de comando e navegue até a pasta raiz
3. Utilize o comando abaixo para restaurar as dependências do projeto.

   ```bash
   dotnet restore
   ```

4. Para executar o projeto compilando em tempo real

   ```bash
   dotnet run --project EscolaDeCursos.WebApp
   ```

## 📋 Requisitos


- .NET 10.0 SDK

---

## 🌍 Aplicação Online

Acesse a versão publicada do sistema:

<p align="center">
  <a href=https://escola-de-curosos-web-hferg5fkaqhaheg5.chilecentral-01.azurewebsites.net/">
    🚀 Escola de Cursos Online
  </a>
</p>

---