using BankingSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaBancariaController : ControllerBase
    {
        private static List<ContaBancaria> contas = new List<ContaBancaria>();

        [HttpPost("criar")]
        public IActionResult CriarConta([FromQuery] string titular)
        {
            var conta = new ContaBancaria(titular);
            contas.Add(conta);

            return CreatedAtAction(nameof(ConsultarSaldo), new { numeroConta = conta.NumeroConta }, conta);
        }

        [HttpPost("depositar")]
        public IActionResult Depositar([FromQuery] Guid numeroConta, [FromQuery] decimal valor)
        {
            var conta = contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
            if (conta == null)
                return NotFound("Conta não encontrada.");

            try
            {
                conta.Depositar(valor);
                return Ok($"Depósito de {valor} realizado com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("transferir")]
        public IActionResult Transferir([FromQuery] Guid numeroContaOrigem, [FromQuery] Guid numeroContaDestino, [FromQuery] decimal valor)
        {
            var contaOrigem = contas.FirstOrDefault(c => c.NumeroConta == numeroContaOrigem);
            var contaDestino = contas.FirstOrDefault(c => c.NumeroConta == numeroContaDestino);

            if (contaOrigem == null || contaDestino == null)
                return NotFound("Conta não encontrada.");

            try
            {
                contaOrigem.Transferir(contaDestino, valor);
                return Ok($"Transferência de {valor} realizada com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("saldo")]
        public IActionResult ConsultarSaldo([FromQuery] Guid numeroConta)
        {
            var conta = contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
            if (conta == null)
                return NotFound("Conta não encontrada.");

            return Ok($"Saldo da conta {numeroConta}: {conta.ConsultarSaldo()}");
        }
    }
}
