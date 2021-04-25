using DIO.Banco.Enumerador;
using System;

namespace DIO.Banco.Classes
{
    public class ContaCorrente
    {
        private EnumTipoConta TipoConta { get; set; }
        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }

        public ContaCorrente(EnumTipoConta tipoConta,double saldo,double credito,string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (valorSaque == 0)
            {
                Console.WriteLine("O valor do saque deve ser maior que zero!");
                return false;
            }

            if ((this.Saldo - valorSaque) < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            this.ExibirSaldo();

            return true;
        }

        public bool Depositar(double valorDeposito)
        {
            if (valorDeposito == 0)
            {
                Console.WriteLine("O valor do depósito deve ser maior que zero!");
                return false;
            }

            this.Saldo += valorDeposito;

            this.ExibirSaldo();

            return true;
        }

        public bool Transferir(double valorTransferencia ,ContaCorrente contaCorrente)
        {
            if (!this.Sacar(valorTransferencia))
            {
                return false;
            }
            if (!contaCorrente.Depositar(valorTransferencia))
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo Conta: " + this.TipoConta + " ";
            retorno += "Nome: " + this.Nome + " ";
            retorno += "Saldo: R$" + this.Saldo.ToString("0.00") + " ";
            retorno += "Crédito: R$" + this.Credito.ToString("0.00");
            return retorno;
        }

        public void ExibirSaldo()
        {
            Console.WriteLine("O saldo atual da conta corrente de {0} é {1:N2}", this.Nome, this.Saldo);
        }

    }
}
