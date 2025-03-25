# Sistema Bancário

Este é um sistema bancário simples desenvolvido com C# e .NET, com funcionalidades básicas como criar conta, depositar, sacar, transferir e consultar saldo.

## Funcionalidades

- **Criar Conta**: Cria uma nova conta bancária para um titular.
- **Depositar**: Permite realizar depósitos na conta bancária.
- **Sacar**: Realiza saques da conta bancária, desde que o saldo seja suficiente.
- **Transferir**: Permite transferir valores de uma conta para outra.
- **Consultar Saldo**: Consulta o saldo atual de uma conta bancária.

## Tecnologias Utilizadas

- **C#**
- **.NET 6+**
- **Fluent Assertions** (para testes)
- **xUnit** (framework de testes)
- **Moq** (para mock de dependências nos testes)

## Estrutura do Projeto

- **BankingSystem.Application**: Contém os serviços que implementam a lógica de negócio.
- **BankingSystem.Domain**: Contém as entidades do sistema, como `ContaBancaria`, que representa a conta bancária do cliente.
- **BankingSystem.Tests**: Contém os testes unitários para validar o comportamento do sistema.

## Como Executar o Projeto

1. Clone o repositório:

    ```bash
    git clone https://github.com/othaviolr/SistemaBancario.git
    ```

2. Abra o projeto no Visual Studio ou em outro editor de sua preferência.

3. Restaure os pacotes NuGet:

    ```bash
    dotnet restore
    ```

4. Compile e execute a aplicação:

    ```bash
    dotnet run
    ```

5. Para rodar os testes:

    ```bash
    dotnet test
    ```

## Como Contribuir

1. Faça o fork do repositório.
2. Crie uma branch para a sua feature (`git checkout -b feature/nome-da-feature`).
3. Faça o commit das suas alterações (`git commit -m 'Adiciona nova funcionalidade'`).
4. Faça o push para a branch (`git push origin feature/nome-da-feature`).
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para mais detalhes.
