
# Aplicativo de Gerenciamento de Processos - ASP.NET Core MVC

## Visão Geral

Este é um aplicativo ASP.NET Core MVC para gerenciar informações de processos. Ele permite criar, visualizar, editar e excluir processos. O sistema inclui funcionalidades como seleção dinâmica de estados e municípios, integração com a API de Localidades do IBGE, integração opcional com API de CEP e uma funcionalidade de paginação para facilitar a navegação entre registros.

### Paginação
A paginação foi implementada manualmente, sem dependências externas, usando os métodos `Skip` e `Take` do Entity Framework Core. Esta abordagem divide os resultados em páginas e limita o número de registros exibidos por página. No controlador, utilizamos variáveis de controle, como o número da página e a quantidade de registros por página, para gerenciar a exibição de dados e gerar a interface de navegação entre páginas.

## Dependências

O projeto utiliza as seguintes dependências:

- **ASP.NET Core MVC**: Framework para criar aplicativos Web.
- **Entity Framework Core**: ORM para trabalhar com banco de dados.
- **API de Localidades IBGE**: Integração com API externa para carregar estados e municípios dinamicamente.

## Estrutura do Projeto

```plaintext
Crud_IBGE/
├── Controllers/
│   ├── ProcessosController.cs      // Controlador principal para operações CRUD e paginação
├── Models/
│   ├── Processo.cs                 // Modelo de dados do processo
│   ├── Context.cs                  // Contexto do banco de dados (EF Core)
│   └── PaginacaoViewModel.cs       // Modelo auxiliar para dados de paginação
├── Views/
│   ├── Processos/
│   │   ├── Index.cshtml            // Lista de processos com paginação
│   │   ├── Create.cshtml           // Formulário para criação de processo
│   │   ├── Edit.cshtml             // Formulário para edição de processo
│   │   └── Details.cshtml          // Exibe detalhes de um processo
├── wwwroot/
│   └── css, js, libs               // Recursos estáticos do aplicativo
└── Program.cs                      // Classe principal para configuração do aplicativo
```

## Configuração e Instalação

### Pré-requisitos
- .NET SDK 8 ou superior
- SQL Server ou outro banco de dados compatível com Entity Framework Core

### Instalação
1. Clone o repositório:
   ```shell
   git clone <url-do-repositorio>
   ```

2. Instale as dependências com o Gerenciador de Pacotes NuGet:
   ```shell
   dotnet restore
   ```

3. Configure o banco de dados no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=SEU_SERVIDOR;Database=Crud_IBGE;Trusted_Connection=True;"
   }
   ```

4. Execute as migrações para configurar o banco de dados:
   ```shell
   dotnet ef database update
   ```

5. Inicie o aplicativo:
   ```shell
   dotnet run
   ```

## Funcionalidades Principais

- **CRUD de Processos**: Criação, edição, visualização e exclusão de registros de processos.
- **Seleção de Estados e Municípios**: Dropdown dinâmico que permite escolher estados e municípios integrados com a API de Localidades do IBGE.
- **Paginação Manual**: Implementação de paginação usando `Skip` e `Take` para dividir a exibição dos registros.

## Uso do Aplicativo

Após iniciar o aplicativo, você poderá acessar a página inicial, onde é possível:

- **Listar Processos**: Exibe uma lista de processos com paginação manual.
- **Criar um Novo Processo**: Redireciona para a página de criação.
- **Editar um Processo**: Redireciona para a página de edição do processo selecionado.
- **Excluir um Processo**: Remove o processo do banco de dados.
- **Visualizar Detalhes do Processo**: Exibe as informações detalhadas de um processo específico.

## API Externa (API de Localidades e API de CEP)

### API de Localidades
- **Uso**: Integrada ao sistema para carregar estados e municípios dinamicamente.
- **Endpoints Utilizados**:
  - `https://servicodados.ibge.gov.br/api/v1/localidades/estados`: Lista de estados.
  - `https://servicodados.ibge.gov.br/api/v1/localidades/estados/{UF}/municipios`: Lista de municípios por estado.

### API de CEP
- **Uso**: Pode ser integrada para preencher automaticamente o endereço do processo ao buscar o CEP.
- **Endpoint Exemplo**:
  - `https://viacep.com.br/ws/{CEP}/json/`: Busca dados de endereço com base no CEP.

## Estrutura de Banco de Dados

O banco de dados contém uma tabela `Processos` com as seguintes colunas:

- **Id**: Identificador do processo.
- **NomeProcesso**: Nome do processo.
- **NPU**: Número do processo.
- **DataCadastro**: Data de criação do registro.
- **DataVisualizacao**: Data da última visualização do registro.
- **UF**: Unidade Federativa (estado) do processo.
- **MunicipioNome**: Nome do município do processo.
- **MunicipioCodigo**: Código do município.
