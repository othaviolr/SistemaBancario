using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces;

namespace BankingSystem.Application.Services
{
    public class ContaBancariaService
    {
        private readonly IContaBancariaRepository _repository;

        public ContaBancariaService(IContaBancariaRepository repository)
        {
            _repository = repository;
        }

        public void CriarConta(string titular)
        {
            var conta = new ContaBancaria(titular);
            _repository.Adicionar(conta);
        }

        public void Depositar(Guid numeroConta, decimal valor)
        {
            var conta = _repository.ObterPorNumero(numeroConta);
            conta.Depositar(valor);
            _repository.Atualizar(conta);
        }

        public void Sacar(Guid numeroConta, decimal valor)
        {
            var conta = _repository.ObterPorNumero(numeroConta);
            conta.Sacar(valor);
            _repository.Atualizar(conta);
        }

        public void Transferir(Guid numeroContaOrigem, Guid numeroContaDestino, decimal valor)
        {
            var contaOrigem = _repository.ObterPorNumero(numeroContaOrigem);
            var contaDestino = _repository.ObterPorNumero(numeroContaDestino);
            contaOrigem.Transferir(contaDestino, valor);
            _repository.Atualizar(contaOrigem);
            _repository.Atualizar(contaDestino);
        }

        public decimal ConsultarSaldo(Guid numeroConta)
        {
            var conta = _repository.ObterPorNumero(numeroConta);
            return conta.ConsultarSaldo();
        }
    }
}
