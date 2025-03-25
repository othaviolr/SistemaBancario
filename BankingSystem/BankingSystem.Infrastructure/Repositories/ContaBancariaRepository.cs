namespace BankingSystem.Infrastructure.Repositories;

using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces;

public class ContaBancariaRepository : IContaBancariaRepository
{
    private readonly List<ContaBancaria> _contas = new();

    public void Adicionar(ContaBancaria conta)
    {
        _contas.Add(conta);
    }

    public void Atualizar(ContaBancaria conta)
    {
        var contaExistente = ObterPorNumero(conta.NumeroConta);
        if (contaExistente != null)
        {
            _contas.Remove(contaExistente);
            _contas.Add(conta);
        }
    }

    public ContaBancaria? ObterPorNumero(Guid numeroConta)
    {
        return _contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
    }

    public IEnumerable<ContaBancaria> ObterTodas()
    {
        return _contas;
    }
}
