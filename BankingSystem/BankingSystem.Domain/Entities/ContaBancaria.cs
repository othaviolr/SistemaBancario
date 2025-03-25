namespace BankingSystem.Domain.Entities
{
    public class ContaBancaria
    {
        public Guid NumeroConta { get; private set; }
        public string Titular { get; private set; }
        public decimal Saldo { get; private set; }

        public ContaBancaria(string titular)
        {
            NumeroConta = Guid.NewGuid();
            Titular = titular;
            Saldo = 0.0m;
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");
            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser maior que zero.");
            if (Saldo < valor)
                throw new InvalidOperationException("Saldo insuficiente.");
            Saldo -= valor;
        }

        public void Transferir(ContaBancaria contaDestino, decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor da transferência deve ser maior que zero.");
            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente.");

            Sacar(valor);
            contaDestino.Depositar(valor);
        }

        public decimal ConsultarSaldo()
        {
            return Saldo;
        }
    }
}
