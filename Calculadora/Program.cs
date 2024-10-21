using System;
using CalculadoraCalculo;

namespace Calculadora;

    class Program
    {
        static void Main(string[] args)
        {
            Calculo calculadora = new Calculo();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Selecione uma operação:");
                Console.WriteLine("1. Soma");
                Console.WriteLine("2. Subtração");
                Console.WriteLine("3. Multiplicação");
                Console.WriteLine("4. Divisão");
                Console.WriteLine("5. Ver histórico");
                Console.WriteLine("6. Sair");

                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Operacao(calculadora, "soma");
                        break;
                    case "2":
                        Operacao(calculadora, "subtração");
                        break;
                    case "3":
                        Operacao(calculadora, "multiplicação");
                        break;
                    case "4":
                        Operacao(calculadora, "divisão");
                        break;
                    case "5":
                        VerHistorico(calculadora);
                        break;
                    case "6":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void Operacao(Calculo calculadora, string tipoOperacao)
        {
        int num1, num2;

            Console.Write("Digite o primeiro número: ");
        while (!int.TryParse(Console.ReadLine(), out num1))
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
        }

        Console.Write("Digite o segundo número: ");
        while (!int.TryParse(Console.ReadLine(), out num2))
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
        }

        int resultado = 0;
            double resultadoDivisao = 0;

            switch (tipoOperacao)
            {
                case "soma":
                    resultado = calculadora.Somar(num1, num2);
                    Console.WriteLine($"Resultado: {resultado}");
                    break;
                case "subtração":
                    resultado = calculadora.Subtrair(num1, num2);
                    Console.WriteLine($"Resultado: {resultado}");
                    break;
                case "multiplicação":
                    resultado = calculadora.Multiplicar(num1, num2);
                    Console.WriteLine($"Resultado: {resultado}");
                    break;
                case "divisão":
                    try
                    {
                        resultadoDivisao = calculadora.Dividir(num1, num2);
                        Console.WriteLine($"Resultado: {resultadoDivisao}");
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Tipo de operação inválido.");
                    break;
            }
        }

        static void VerHistorico(Calculo calculadora)
        {
            Console.WriteLine("Últimos 5 históricos:");
            var historico = calculadora.Historico();
            foreach (var registro in historico)
            {
                Console.WriteLine(registro);
            }
        }
    }

