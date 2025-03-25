using BankingSystem.Domain.Entities;

namespace BankingSystem.Domain.Interfaces;

public interface IContaBancariaRepository
{
    void Adicionar(ContaBancaria conta);
    void Atualizar(ContaBancaria conta);
    ContaBancaria? ObterPorNumero(Guid numeroConta);
    IEnumerable<ContaBancaria> ObterTodas();
}
