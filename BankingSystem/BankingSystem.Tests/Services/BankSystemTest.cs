using BankingSystem.Application.Services;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace BankingSystem.Tests.Services
{
    public class ContaBancariaServiceTests
    {
        private readonly ContaBancariaService _service;
        private readonly Mock<IContaBancariaRepository> _repositoryMock;

        public ContaBancariaServiceTests()
        {
            _repositoryMock = new Mock<IContaBancariaRepository>();
            _service = new ContaBancariaService(_repositoryMock.Object);
        }

        [Fact]
        public void CriarConta_DeveAdicionarNovaConta()
        {
            _service.CriarConta("Othavio");

            _repositoryMock.Verify(r => r.Adicionar(It.IsAny<ContaBancaria>()), Times.Once);
        }

        [Fact]
        public void Depositar_ValorPositivo_DeveAtualizarSaldo()
        {
            var conta = new ContaBancaria("Othavio");
            _repositoryMock.Setup(r => r.ObterPorNumero(conta.NumeroConta)).Returns(conta);

            _service.Depositar(conta.NumeroConta, 100);

            conta.Saldo.Should().Be(100);
            _repositoryMock.Verify(r => r.Atualizar(conta), Times.Once);
        }

        [Fact]
        public void Sacar_ValorSuperiorAoSaldo_DeveLancarExcecao()
        {
            var conta = new ContaBancaria("Othavio");
            _repositoryMock.Setup(r => r.ObterPorNumero(conta.NumeroConta)).Returns(conta);

            Action act = () => _service.Sacar(conta.NumeroConta, 100);

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Saldo insuficiente.");
        }

        [Fact]
        public void ConsultarSaldo_DeveRetornarSaldoAtual()
        {
            var conta = new ContaBancaria("Othavio");
            _repositoryMock.Setup(r => r.ObterPorNumero(conta.NumeroConta)).Returns(conta);

            var saldo = _service.ConsultarSaldo(conta.NumeroConta);

            saldo.Should().Be(0);
        }
    }
}
