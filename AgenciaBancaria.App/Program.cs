using System;
using AgenciaBancaria.Dominio;

namespace AgenciaBancaria.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Endereco endereco = new Endereco("Rua Jose Joao", "53240277", "Recife", "Pernambuco");
                Cliente cliente = new Cliente("Gabriel", "12345678912", "7894561", endereco);

                Console.WriteLine("Que tipo de conta você gostaria de abrir ?\n\n1 - Conta Corrente\n\n2 - Conta Poupança\n\n");
                Console.Write("Digite o número da opção: ");
                string tipoDeConta = Console.ReadLine();

                ContaBancaria conta = new ContaCorrente(cliente, 1000);

                if (tipoDeConta == "1")
                {
                    conta = new ContaCorrente(cliente, 1000);
                    Console.WriteLine("\n Conta Corrente selecionada.\n");
                } 
                else if (tipoDeConta == "2")
                {
                    conta = new ContaPoupanca(cliente);
                    Console.WriteLine("\n Conta Poupança selecionada.\n");
                } 
                else
                {
                    throw new Exception("Tipo de conta selecionada inválida");
                }
                
                

                Console.WriteLine($"Conta criada\n Situação: {conta.Situacao}. \n Número da Conta: {conta.NumeroConta}-{conta.DigitoVerificador}");

                Console.Write("Digite uma senha: ");
                string senha = Console.ReadLine();
                conta.Abrir(senha);

                Console.WriteLine($"\nParabéns, {cliente.Nome}. Sua conta está aberta!\n");

                do
                {
                    Console.WriteLine("Deseja fazer alguma operação ?\n\n1- Sacar.\n2-Depositar.\n3-Ver Saldo.\n\n4-Sair.\n\n");
                    Console.Write("Digite uma opção: ");
                    string opcoesOperacao = Console.ReadLine();
                    if (opcoesOperacao == "1")
                    {
                        Console.Write("Digite o valor do saque: ");
                        string valorSaque = Console.ReadLine();
                        decimal valorDecimal = Convert.ToDecimal(valorSaque);
                        conta.Sacar(valorDecimal, senha);
                        Console.WriteLine($"Você sacou: R$ {valorDecimal}, seu saldo agora é de: R$ {conta.Saldo}");

                    }
                    Console.WriteLine("\n\nDeseja fazer uma nova operação ?\n\n");
                    string ficarSair = Console.ReadLine();
                    if (ficarSair == "1")
                    {

                    }
                } while (opcoesOperacao != 4);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
