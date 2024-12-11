# Aplicação Web de Vendas de Lanches - ASP.NET Core MVC 6.0

## Descrição do Projeto

Esta aplicação web de vendas de lanches foi desenvolvida utilizando o **ASP.NET Core MVC 6.0**. O projeto abrange os seguintes conceitos:

- Implementação do padrão **MVC**.
- Definição de entidades do modelo de domínio usando **Entity Framework Core**.
- Validação e configuração das entidades utilizando **Data Annotations**.
- Criação do banco de dados e tabelas via migrações com abordagem **Code-First**.
- Popular o banco de dados com dados iniciais (seeding).
- Uso do padrão **Repository** e **ViewModel**.
- Implementação de um carrinho de compras com **Session**.
- Definição de rotas e uso de **View Components**.
- Implementação de segurança com **ASP.NET Core Identity** (Login, Registro, Logout).
- Utilização de **Partial Views**.
- Paginação e filtragem de dados.
- Geração de relatórios com **LINQ** e gráficos com **GoogleChart**.
- Criação de relatórios em **PDF** usando **FastReport OpenSource**.

## Funcionalidades
- Listagem de lanches disponíveis para venda.
- Filtro e paginação dos lanches.
- Adição de lanches ao carrinho de compras.
- Processo de compra e checkout.
- Login e registro de usuários.
- Geração de relatórios e gráficos.

## Tecnologias Utilizadas
- ASP.NET Core MVC 6.0
- Entity Framework Core
- LINQ
- GoogleChart
- FastReport OpenSource

# Convenção de Commits

Este projeto segue a convenção de commits **Conventional Commits** para manter um histórico claro, padronizado e facilitando a automação de tarefas como geração de changelogs e versionamento semântico.

## Padrão de Commit

**`<tipo>`**: Define a natureza da mudança. Exemplo:
   - **`feat`**: Nova funcionalidade.
   - **`fix`**: Correção de bug.
   - **`docs`**: Atualizações na documentação.
   - **`style`**: Alterações que não afetam a lógica do código (ex.: formatação, espaçamento).
   - **`refactor`**: Modificação no código sem alteração na funcionalidade.
   - **`test`**: Alterações ou adições nos testes.
   - **`chore`**: Atualizações administrativas (ex.: dependências, configurações).
   - **`perf`**: Melhoria de desempenho.
   - **`build`**: Alterações no sistema de build (scripts, CI/CD).
   - **`ci`**: Alterações em configurações de integração contínua.
   - **`revert`**: Revertendo um commit anterior.

2. **`<descrição>`**: Um resumo conciso da mudança realizada. 

