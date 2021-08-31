using System;
using System.Collections.Generic;
class Program
{
    static List<Conta> listaContas = new List<Conta>();
    static void Main(string[] args)
    {
        string menu = Menu();

        do{
            switch(menu){
                 case "1":
                    ListarContas();
                    break;
                case "2":
                    InserirConta();
                    break;
                case "3":
                    Transferir();
                    break;
                case "4":
                    Sacar();
                    break;
                case "5":
                    Depositar();
                    break;
                case "6":
                    Console.Clear();
                    break;
                    
                default:
                    break;
            }

            menu = Menu();
        }while(menu.ToUpper() != "X");

        Console.WriteLine("Obrigado por utilizar nossos serviços.");
            

    }

    private static void InserirConta(){
        Console.WriteLine("Inserir nova conta");

        Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
        int entradaTipoConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o Nome do cliente: ");
        string entradaNome = Console.ReadLine();

        Console.Write("Digite o saldo inicial");
        double entradaSaldo = double.Parse(Console.ReadLine());

        Console.Write("Digite o crédito");
        double entradaCredito = double.Parse(Console.ReadLine());

        Conta novaConta = new Conta((TipoConta)entradaTipoConta, entradaSaldo, entradaCredito, entradaNome);

        listaContas.Add(novaConta);
    }

    private static void ListarContas(){
        Console.WriteLine("Listar contas");

        if (listaContas.Count <= 0){
            Console.WriteLine("nenhuma conta cadastrada.");

        }else{

            for (int i=0; i < listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }    
        }
    }

    private static void Transferir(){
        Console.Write("Digite o número da conta de origem: ");
        int indiceContaOrigem = int.Parse(Console.ReadLine());

        Console.Write("Digite o número da conta de destino: ");
        int indiceContaDestino = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser transferido: ");
        double valorTransf = double.Parse(Console.ReadLine());

        listaContas[indiceContaOrigem].Transferir(valorTransf, listaContas[indiceContaDestino]);
    }

    private static void Sacar(){
        Console.Write("Digite o número da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser sacado: ");
        double valorSaque = double.Parse(Console.ReadLine());

        listaContas[indiceConta].Sacar(valorSaque);
    }

    private static void Depositar(){
        Console.Write("Digite o número da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser depositado: ");
        double valorDeposito = double.Parse(Console.ReadLine());

        listaContas[indiceConta].Depositar(valorDeposito);
    }

    private static string Menu(){
        Console.WriteLine();
        Console.WriteLine("Bem-vindo ao BankTwo");
        Console.WriteLine("Informe a opção desejada");

        Console.WriteLine("1 - Listar Contas");
        Console.WriteLine("2 - Cadastrar nova conta");
        Console.WriteLine("3 - Transferir");
        Console.WriteLine("4 - Sacar");
        Console.WriteLine("5 - Depositar");
        Console.WriteLine("6 - Limpar a tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();

        string menu = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return menu;
    }
}