using DIO.Banco.Classes;
using DIO.Banco.Enumerador;
using DIO.Banco.Repositorio;
using System;

namespace DIO.Banco
{
    class Program
    {
        static ContaCorrenteRepositorio repositorio = new ContaCorrenteRepositorio();

        static void Main(string[] args)
        {

            var opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        TransferirValor();
                        break;
                    case "4":
                        SacarValor();
                        break;
                    case "5":
                        DepositarValor();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nosssos serviços.");
            Console.ReadLine();

        }

        private static void ListarContas(bool esperar = true)
        {
            Console.Clear();

            Console.WriteLine("Listar contas correntes cadastradas");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhuma conta corrente foi encontrada.");
            }

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine();
                Console.Write("#ID {0}:", (i+1));
                var contaCorrente = lista[i];
                Console.WriteLine(contaCorrente);
            }
            if (esperar == true)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
                Console.ReadLine();
            }

        }


        private static void InserirConta()
        {
            Console.Clear();
            Console.WriteLine("Inserir nova conta corrente");

            foreach (int i in Enum.GetValues(typeof(EnumTipoConta)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(EnumTipoConta), i));
            }

            Console.WriteLine();
            Console.Write("Digite o tipo de conta entre as opções acima: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Digite o nome do correntista: ");
            string entradaNomeCorrentista = Console.ReadLine();

            double entradaValor = 0.0;

            double entradaCredito = 300.00;

            int proximoId = repositorio.ProximoId();

            ContaCorrente novaContaCorrente = new ContaCorrente(tipoConta: (EnumTipoConta)entradaTipoConta,
                                                                nome:entradaNomeCorrentista,
                                                                saldo:entradaValor,
                                                                credito:entradaCredito);

            repositorio.Insere(novaContaCorrente);

            Console.WriteLine();
            Console.WriteLine("A conta corrente foi inserida com sucesso.");

            Console.WriteLine();
            Console.WriteLine(novaContaCorrente);

            Console.WriteLine();
            Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
            Console.ReadLine();

        }

        private static void SacarValor()
        {
            ListarContas();

            Console.WriteLine();
            Console.Write("Informe o número da conta corrente para sacar: ");
            int entradaNumeroConta = int.Parse(Console.ReadLine());

            if ((entradaNumeroConta - 1) >= repositorio.ProximoId())
            {
                Console.WriteLine();
                Console.Write("O número da conta corrente informada é inválida. ");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.Write("Informe o valor do saque: ");
            double entradaValorSaque = double.Parse(Console.ReadLine());

            repositorio.RetornaPorId((entradaNumeroConta-1)).Sacar(entradaValorSaque);

            Console.WriteLine();
            Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
            Console.ReadLine();

        }

        private static void DepositarValor()
        {
            ListarContas();

            Console.WriteLine();
            Console.Write("Informe o número da conta corrente para depositar: ");
            int entradaNumeroConta = int.Parse(Console.ReadLine());

            if ((entradaNumeroConta - 1) >= repositorio.ProximoId())
            {
                Console.WriteLine();
                Console.Write("O número da conta corrente informada é inválida. ");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.Write("Informe o valor do deposito: ");
            double entradaValorDeposito = double.Parse(Console.ReadLine());

            repositorio.RetornaPorId((entradaNumeroConta - 1)).Depositar(entradaValorDeposito);

            Console.WriteLine();
            Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
            Console.ReadLine();

        }

        private static void TransferirValor()
        {
            ListarContas();

            Console.WriteLine();
            Console.Write("Informe o número da conta corrente para retirada: ");
            int entradaNumeroContaSaida = int.Parse(Console.ReadLine());

            if ((entradaNumeroContaSaida - 1) >= repositorio.ProximoId())
            {
                Console.WriteLine();
                Console.Write("O número da conta corrente informada é inválida. ");
                Console.ReadLine();
                return;
            }

            Console.Write("Informe o número da conta corrente para depósito: ");
            int entradaNumeroContaEntrada = int.Parse(Console.ReadLine());

            if ((entradaNumeroContaEntrada - 1) >= repositorio.ProximoId())
            {
                Console.WriteLine();
                Console.Write("O número da conta corrente informada é inválida. ");
                Console.ReadLine();
                return;
            }


            Console.WriteLine();
            Console.Write("Informe o valor da transferência: ");
            double entradaValorTransferencia = double.Parse(Console.ReadLine());

            repositorio.RetornaPorId((entradaNumeroContaSaida - 1)).Transferir(entradaValorTransferencia, repositorio.RetornaPorId((entradaNumeroContaEntrada - 1)));

            Console.WriteLine();
            Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
            Console.ReadLine();

        }


        private static string ObterOpcaoUsuario()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("DIO.Bank a seu dispor!!!");
            Console.WriteLine("Opções:");

            Console.WriteLine("1-Listar contas");
            Console.WriteLine("2-Inserir nova conta");
            Console.WriteLine("3-Transferir");
            Console.WriteLine("4-Sacar");
            Console.WriteLine("5-Depositar");
            Console.WriteLine("C-Limpar Tela");
            Console.WriteLine("X-Sair");
            Console.WriteLine("");

            Console.Write("Informe a opção desejada: ");
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
